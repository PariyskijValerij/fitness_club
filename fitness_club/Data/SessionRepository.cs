using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace fitness_club.Data
{
    public class SessionRepository
    {
        public DataTable GetSessionsByTrainer(int trainerId, DateTime? dateFrom, DateTime? dateTo)
        {
            var table = new DataTable();

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand())
            {
                cmd.Connection = conn;

                string sql = @"
                    SELECT s.session_id, s.session_type, s.session_date, s.start_time, s.end_time,
                    s.duration_min, s.difficulty_level, s.session_status, r.room_number, c.club_name, r.capacity,
                    COUNT(b.membership_id) AS confirmed_bookings,
                    ROUND(COUNT(CASE WHEN b.booking_status = 'confirmed' THEN 1 END) / r.capacity * 100, 1) 
                    AS occupancy_percent
                    FROM session s JOIN room r ON r.room_id = s.room_id 
                    JOIN club c ON c.club_id = r.club_id
                    LEFT JOIN booking b ON b.session_id = s.session_id AND b.booking_status = 'confirmed'
                    WHERE s.trainer_id = @trainerId";

                cmd.Parameters.AddWithValue("@trainerId", trainerId);

                if (dateFrom.HasValue)
                {
                    sql += " AND s.session_date >= @dateFrom";
                    cmd.Parameters.AddWithValue("@dateFrom", dateFrom.Value.Date);
                }

                if (dateTo.HasValue)
                {
                    sql += " AND s.session_date <= @dateTo";
                    cmd.Parameters.AddWithValue("@dateTo", dateTo.Value.Date);
                }

                sql += @"
                    GROUP BY s.session_id, s.session_type, s.session_date, s.start_time, s.end_time, s.duration_min,
                    s.difficulty_level, s.session_status, r.room_number, c.club_name, r.capacity
                    ORDER BY s.session_date DESC, s.start_time;";

                cmd.CommandText = sql;

                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    conn.Open();
                    adapter.Fill(table);
                }
            }
            return table;
        }

        public int CreateSession(int trainerId, int roomId, string type, DateTime date, TimeSpan startTime,
            int durationMin, string difficultyDb, string statusDb)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                INSERT INTO session (room_id, trainer_id, session_type, session_date, start_time, 
                    duration_min, difficulty_level, session_status)
                VALUES (@room_id, @trainer_id, @type, @date, @start_time, @duration, @difficulty, @status);", conn))
            {
                cmd.Parameters.AddWithValue("@room_id", roomId);
                cmd.Parameters.AddWithValue("@trainer_id", trainerId);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@date", date.Date);
                cmd.Parameters.AddWithValue("@start_time", startTime);
                cmd.Parameters.AddWithValue("@duration", durationMin);
                cmd.Parameters.AddWithValue("@difficulty", difficultyDb);
                cmd.Parameters.AddWithValue("@status", statusDb);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        public void UpdateSession(int sessionId, int roomId, string type, DateTime date, TimeSpan startTime, int durationMin,
            string difficultyDb, string statusDb)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                UPDATE session
                SET room_id = @room_id,
                    session_type = @type,
                    session_date = @date,
                    start_time = @start_time,
                    duration_min = @duration,
                    difficulty_level = @difficulty,
                    session_status = @status
                WHERE session_id = @id;", conn))
            {
                cmd.Parameters.AddWithValue("@room_id", roomId);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@date", date.Date);
                cmd.Parameters.AddWithValue("@start_time", startTime);
                cmd.Parameters.AddWithValue("@duration", durationMin);
                cmd.Parameters.AddWithValue("@difficulty", difficultyDb);
                cmd.Parameters.AddWithValue("@status", statusDb);
                cmd.Parameters.AddWithValue("@id", sessionId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteSession(int sessionId)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(
                "DELETE FROM session WHERE session_id = @id;", conn))
            {
                cmd.Parameters.AddWithValue("@id", sessionId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetAvailableSessionsForMembership(int membershipId, DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            var table = new DataTable();

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand())
            {
                cmd.Connection = conn;

                string sql = @"
                SELECT s.session_id, s.session_type, s.session_date, s.start_time, s.duration_min,
                s.difficulty_level, s.session_status, c.club_name, r.room_id, r.room_number, r.capacity,
                
                (SELECT COUNT(*) FROM booking b WHERE b.session_id = s.session_id 
                AND b.booking_status = 'confirmed') 
                AS confirmed_bookings

                FROM session s
                JOIN room r ON s.room_id = r.room_id
                JOIN club c ON r.club_id = c.club_id
                JOIN membership m ON m.membership_id = @membershipId
                JOIN membership_type mt ON m.membership_type_id = mt.membership_type_id

                WHERE 
                -- 1. Перевірка статусу сесії та дати
                s.session_status != 'cancelled'
                AND s.session_date >= CURDATE()
                
                -- 2. Перевірка, чи діє абонемент у цей період
                AND m.membership_status = 'active'
                AND CURDATE() BETWEEN m.start_date AND m.end_date
                AND s.session_date BETWEEN m.start_date AND m.end_date

                -- 3. Перевірка доступу до клубу 
                AND (mt.access_level_to_clubs = 'all_clubs' 
                    OR (mt.access_level_to_clubs = 'home' AND r.club_id = m.club_id))

                -- 4. Перевірка, чи клієнт вже не записаний на це заняття
                AND NOT EXISTS (SELECT 1 FROM booking bx 
                    WHERE bx.membership_id = m.membership_id 
                    AND bx.session_id = s.session_id 
                    AND bx.booking_status = 'confirmed')

                -- 5. Перевірка наявності вільних місць
                AND (SELECT COUNT(*) FROM booking b2 
                    WHERE b2.session_id = s.session_id AND b2.booking_status = 'confirmed') < r.capacity";

                if (dateFrom.HasValue)
                {
                    sql += " AND s.session_date >= @dateFrom ";
                    cmd.Parameters.AddWithValue("@dateFrom", dateFrom.Value.Date);
                }

                if (dateTo.HasValue)
                {
                    sql += " AND s.session_date <= @dateTo ";
                    cmd.Parameters.AddWithValue("@dateTo", dateTo.Value.Date);
                }

                sql += " ORDER BY s.session_date, s.start_time;";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@membershipId", membershipId);

                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    conn.Open();
                    adapter.Fill(table);
                }
            }

            return table;
        }

        public bool IsSessionConflict(int trainerId, int roomId, DateTime date, TimeSpan start, int durationMin, int? excludeSessionId = null)
        {
            TimeSpan end = start.Add(TimeSpan.FromMinutes(durationMin));

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand())
            {
                cmd.Connection = conn;
                string sql = @"
                    SELECT COUNT(*) 
                    FROM session    
                    WHERE (room_id = @roomId OR trainer_id = @trainerId)
                    AND session_date = @date
                    AND session_status != 'cancelled'
                    AND (@newStart < end_time AND @newEnd > start_time)";

                if (excludeSessionId.HasValue)
                {
                    sql += " AND session_id != @excludeId";
                    cmd.Parameters.AddWithValue("@excludeId", excludeSessionId.Value);
                }

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@trainerId", trainerId);
                cmd.Parameters.AddWithValue("@roomId", roomId);
                cmd.Parameters.AddWithValue("@date", date.Date);
                cmd.Parameters.AddWithValue("@newStart", start);
                cmd.Parameters.AddWithValue("@newEnd", end);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0; 
            }
        }

        public void UpdatePastSessionsStatus()
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand())
            {
                cmd.Connection = conn;

                string sql = @"
                    UPDATE session
                    SET session_status = 'completed' 
                    WHERE session_status = 'planned' 
                    AND ADDTIME(TIMESTAMP(session_date, start_time), SEC_TO_TIME(duration_min * 60)) < NOW();";

                cmd.CommandText = sql;
                conn.Open();

                int updatedRows = cmd.ExecuteNonQuery();
            }
        }
    }
}

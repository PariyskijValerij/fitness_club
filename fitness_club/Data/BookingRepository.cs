using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Data;

namespace fitness_club.Data
{
    public class BookingRepository
    {
        public DataTable GetBookingsBySession(int sessionId, bool sortByDateAsc)
        {
            var table = new DataTable();

            using (var conn = DbHelper.GetConnection())
            {
                string order = sortByDateAsc ? "ASC" : "DESC";

                using (var cmd = new MySqlCommand(@"
                SELECT b.membership_id, b.session_id, b.booking_date_and_time, b.booking_status, c.client_full_name,
                c.client_phone, c.client_email, mt.membership_name
                FROM booking b
                JOIN membership m ON m.membership_id = b.membership_id
                JOIN client c ON c.client_id = m.client_id
                JOIN membership_type mt ON mt.membership_type_id = m.membership_type_id
                WHERE b.session_id = @sessionId
                ORDER BY b.booking_date_and_time " + order + ";", conn))
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    cmd.Parameters.AddWithValue("@sessionId", sessionId);
                    conn.Open();
                    adapter.Fill(table);
                }
            }
            return table;
        }

        public void UpdateBookingStatus(int membershipId, int sessionId, string newStatus)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                UPDATE booking
                SET booking_status = @status
                WHERE membership_id = @memebershipId AND session_id = @sessionId;", conn))
            {
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@memebershipId", membershipId);
                cmd.Parameters.AddWithValue("@sessionId", sessionId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteBooking(int membershipId, int sessionId)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                DELETE FROM booking
                WHERE membership_id = @memebershipId AND session_id = @sessionId;", conn))
            {
                cmd.Parameters.AddWithValue("@memebershipId", membershipId);
                cmd.Parameters.AddWithValue("@sessionId", sessionId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void CreateBooking(int membershipId, int sessionId)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                string checkSql = @"SELECT booking_status FROM booking 
                                    WHERE membership_id = @memId AND session_id = @sessId";

                string currentStatus = null;
                using (var cmdCheck = new MySqlCommand(checkSql, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@memId", membershipId);
                    cmdCheck.Parameters.AddWithValue("@sessId", sessionId);
                    var result = cmdCheck.ExecuteScalar();
                    if (result != null) currentStatus = result.ToString();
                }

                if (currentStatus == "confirmed")
                {
                    throw new Exception("This client is already booked for this session.");
                }
                else if (currentStatus == "cancelled")
                {
                    string updateSql = @"UPDATE booking 
                                       SET booking_status = 'confirmed', 
                                       booking_date_and_time = NOW() 
                                       WHERE membership_id = @memId AND session_id = @sessId";

                    using (var cmdUpdate = new MySqlCommand(updateSql, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@memId", membershipId);
                        cmdUpdate.Parameters.AddWithValue("@sessId", sessionId);
                        cmdUpdate.ExecuteNonQuery();
                    }
                }
                else
                {
                    string insertSql = @"INSERT INTO booking (membership_id, session_id, 
                                       booking_date_and_time, booking_status)
                                       VALUES (@memId, @sessId, NOW(), 'confirmed')";

                    using (var cmdInsert = new MySqlCommand(insertSql, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@memId", membershipId);
                        cmdInsert.Parameters.AddWithValue("@sessId", sessionId);
                        cmdInsert.ExecuteNonQuery();
                    }
                }
            }
        }

        public DataTable GetBookingsByMembership(int membershipId)
        {
            var table = new DataTable();

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                SELECT s.session_date, s.start_time, s.session_type, 
                       t.trainer_name, r.room_number, b.booking_status
                FROM booking b
                JOIN session s ON b.session_id = s.session_id
                JOIN trainer t ON s.trainer_id = t.trainer_id
                JOIN room r ON s.room_id = r.room_id
                WHERE b.membership_id = @mid
                ORDER BY s.session_date DESC, s.start_time DESC;", conn))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@mid", membershipId);
                conn.Open();
                adapter.Fill(table);
            }

            return table;
        }
    }
}

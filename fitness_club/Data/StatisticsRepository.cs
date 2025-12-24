using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace fitness_club.Data
{
    public class StatisticsRepository
    {
        public DataTable GetActiveClientsPerClub()
        {
            var table = new DataTable();

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                SELECT c.club_id, c.club_name, COUNT(DISTINCT cl.client_id) AS active_clients
                FROM club c LEFT JOIN membership m ON c.club_id = m.club_id AND m.membership_status = 'active'
                LEFT JOIN client cl ON cl.client_id = m.client_id AND cl.client_status = 'active'
                GROUP BY c.club_id, c.club_name
                ORDER BY active_clients DESC;", conn))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                conn.Open();
                adapter.Fill(table);
            }

            return table;
        }

        public DataTable GetSessionOccupancy()
        {
            var table = new DataTable();

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                SELECT s.session_id, s.session_type, s.session_date, c.club_name, r.room_number, r.capacity, 
                COUNT(b.membership_id) AS booking_count,
                ROUND(COUNT(b.membership_id) / r.capacity * 100, 1) AS occupancy_percent
                FROM session s JOIN room r ON r.room_id = s.room_id
                JOIN club c ON r.club_id = c.club_id
                LEFT JOIN booking b ON s.session_id = b.session_id AND b.booking_status = 'confirmed'
                GROUP BY s.session_id, s.session_type, s.session_date, c.club_name, r.room_number, r.capacity;", conn))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                conn.Open();
                adapter.Fill(table);
            }

            return table;
        }

        public DataTable GetRevenueByMembershipType()
        {
            var table = new DataTable();

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                SELECT mt.membership_name, 
                COUNT(m.membership_id) AS total_sold, 
                IFNULL(SUM(mt.price_per_month * mt.duration_months), 0) AS total_revenue
                FROM membership_type mt
                LEFT JOIN membership m ON mt.membership_type_id = m.membership_type_id
                WHERE YEAR(m.start_date) = YEAR(CURDATE())
                GROUP BY mt.membership_type_id, mt.membership_name
                ORDER BY total_revenue DESC;", conn))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                conn.Open();
                adapter.Fill(table);
            }

            return table;
        }

        public DataTable GetActiveMembershipsReport()
        {
            var table = new DataTable();

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                SELECT clb.club_name AS 'Club', c.client_full_name AS 'Client',
                mt.membership_name AS 'Membership type', mt.access_level_to_clubs AS 'Access level',
                m.start_date AS 'Start date', m.end_date AS 'End date', m.membership_status AS 'Status',
                c.client_phone AS 'Phone', c.client_email AS 'Email'
                FROM membership m
                JOIN club clb ON clb.club_id = m.club_id
                JOIN client c ON c.client_id = m.client_id
                JOIN membership_type mt ON mt.membership_type_id = m.membership_type_id
                JOIN app_user u ON u.user_id = c.user_id
                WHERE m.membership_status = 'active' AND c.client_status = 'active' AND u.user_status = 'active'
                ORDER BY clb.club_name, c.client_full_name;", conn))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                conn.Open();
                adapter.Fill(table);
            }

            return table;
        }

        public DataTable GetTrainerWorkloadReport(DateTime fromDate, DateTime toDate)
        {
            var table = new DataTable();

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                SELECT c.club_name AS 'Club', t.trainer_name AS 'Trainer', COUNT(ss.session_id) AS 'Sessions',
                IFNULL(ROUND(AVG(ss.duration_min)), 0) AS 'Avg duration, min', IFNULL(SUM(ss.booking_count), 0) AS 'Bookings',
                IFNULL(ROUND(AVG(ss.booking_count / ss.capacity * 100)), 0) AS 'Avg occupancy, %'
                FROM trainer t
                JOIN club c ON c.club_id = t.club_id
                LEFT JOIN (SELECT s.session_id, s.trainer_id, s.duration_min, r.capacity, COUNT(b.membership_id) AS booking_count
                    FROM session s
                    JOIN room r ON r.room_id = s.room_id
                    LEFT JOIN booking b ON b.session_id = s.session_id AND b.booking_status = 'confirmed'
                    WHERE s.session_date BETWEEN @fromDate AND @toDate
                    GROUP BY s.session_id, s.trainer_id, s.duration_min, r.capacity) ss ON ss.trainer_id = t.trainer_id
                WHERE t.trainer_status = 'active'
                GROUP BY c.club_name, t.trainer_name
                ORDER BY c.club_name, t.trainer_name;", conn))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@fromDate", fromDate.Date);
                cmd.Parameters.AddWithValue("@toDate", toDate.Date);

                conn.Open();
                adapter.Fill(table);
            }

            return table;
        }

        public DataTable GetMostPopularMembershipType()
        {
            var table = new DataTable();

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
            SELECT mt.membership_type_id, mt.membership_name, COUNT(m.membership_id) AS total_memberships
            FROM membership_type mt
            JOIN membership m ON m.membership_type_id = mt.membership_type_id
            WHERE m.membership_status = 'active'
            GROUP BY mt.membership_type_id, mt.membership_name
            ORDER BY total_memberships DESC
            LIMIT 1;", conn))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                conn.Open();
                adapter.Fill(table);
            }

            return table;
        }

        public DataTable GetMostPopularClub()
        {
            var table = new DataTable();

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
            SELECT c.club_id, c.club_name, COUNT(m.membership_id) AS total_memberships
            FROM club c
            LEFT JOIN membership m ON m.club_id = c.club_id
            WHERE m.membership_status = 'active'
            GROUP BY c.club_id, c.club_name
            ORDER BY total_memberships DESC
            LIMIT 1;", conn))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                conn.Open();
                adapter.Fill(table);
            }

            return table;
        }
    }
}
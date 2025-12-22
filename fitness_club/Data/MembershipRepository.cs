using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace fitness_club.Data
{
    public class MembershipRepository
    {
        public DataTable GetMembershipsByClient(int clientId)
        {
            var table = new DataTable();

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                SELECT m.membership_id, m.membership_type_id, mt.membership_name, m.club_id,
                c.club_name, m.start_date, m.end_date, m.membership_status
                FROM membership m
                JOIN membership_type mt ON mt.membership_type_id = m.membership_type_id
                JOIN club c ON c.club_id = m.club_id
                WHERE m.client_id = @clientId", conn))
            {
                cmd.Parameters.AddWithValue("@clientId", clientId);
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    conn.Open();
                    adapter.Fill(table);
                }
            }

            return table;
        }

        public DataTable GetMembershipsByClientAndFilter(int clientId, MembershipFilter filter)
        {
            var table = new DataTable();

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand())
            {
                cmd.Connection = conn;

                string sql = @"
                    SELECT m.membership_id, m.membership_type_id, mt.membership_name, m.club_id,
                    c.club_name, m.start_date, m.end_date, m.membership_status
                    FROM membership m
                    JOIN membership_type mt ON mt.membership_type_id = m.membership_type_id
                    JOIN club c ON c.club_id = m.club_id
                    WHERE m.client_id = @clientId";

                var statuses = new List<string>();
                if (filter.FilterActive) 
                    statuses.Add("'active'");
                if (filter.FilterPaused) 
                    statuses.Add("'paused'");
                if (filter.FilterExpired) 
                    statuses.Add("'expired'");

                if (statuses.Count > 0)
                    sql += $" AND m.membership_status IN ({string.Join(",", statuses)})";

                if (filter.StartDateFrom.HasValue)
                {
                    sql += " AND m.start_date >= @startFrom";
                    cmd.Parameters.AddWithValue("@startFrom", filter.StartDateFrom.Value);
                }
                if (filter.StartDateTo.HasValue)
                {
                    sql += " AND m.start_date <= @startTo";
                    cmd.Parameters.AddWithValue("@startTo", filter.StartDateTo.Value);
                }

                if (filter.EndDateFrom.HasValue)
                {
                    sql += " AND m.end_date >= @endFrom";
                    cmd.Parameters.AddWithValue("@endFrom", filter.EndDateFrom.Value);
                }
                if (filter.EndDateTo.HasValue)
                {
                    sql += " AND m.end_date <= @endTo";
                    cmd.Parameters.AddWithValue("@endTo", filter.EndDateTo.Value);
                }

                sql += " ORDER BY m.end_date DESC";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@clientId", clientId);

                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    conn.Open();
                    adapter.Fill(table);
                }
            }

            return table;
        }

        public void CreateMembership(int clientId, int membershipTypeId, int clubId, DateTime startDate, string statusDb)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                INSERT INTO membership
                    (membership_type_id, client_id, club_id, start_date, membership_status)
                VALUES
                    (@typeId, @clientId, @clubId, @startDate, @status);", conn))
            {
                cmd.Parameters.AddWithValue("@typeId", membershipTypeId);
                cmd.Parameters.AddWithValue("@clientId", clientId);
                cmd.Parameters.AddWithValue("@clubId", clubId);
                cmd.Parameters.AddWithValue("@startDate", startDate.Date);
                cmd.Parameters.AddWithValue("@status", statusDb);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateMembership(int membershipId, int membershipTypeId, int clubId, DateTime startDate, string statusDb)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                UPDATE membership
                SET membership_type_id = @typeId,
                    club_id = @clubId,
                    start_date = @startDate,
                    membership_status = @status
                WHERE membership_id = @id;", conn))
            {
                cmd.Parameters.AddWithValue("@id", membershipId);
                cmd.Parameters.AddWithValue("@typeId", membershipTypeId);
                cmd.Parameters.AddWithValue("@clubId", clubId);
                cmd.Parameters.AddWithValue("@startDate", startDate.Date);
                cmd.Parameters.AddWithValue("@status", statusDb);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        
        public void DeleteMembership(int membershipId)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(
                "DELETE FROM membership WHERE membership_id = @id;", conn))
            {
                cmd.Parameters.AddWithValue("@id", membershipId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetActiveMembershipsForClient(int clientId)
        {
            var table = new DataTable();

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                SELECT m.membership_id, m.club_id, c.club_name, mt.membership_name, mt.access_level_to_clubs,
                m.start_date, m.end_date
                FROM membership m 
                JOIN club c ON c.club_id = m.club_id
                JOIN membership_type mt ON mt.membership_type_id = m.membership_type_id
                WHERE m.client_id = @clientId AND m.membership_status = 'active'
                AND CURDATE() BETWEEN m.start_date AND m.end_date
                ORDER BY m.end_date;", conn))
            using (var ad = new MySqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@clientId", clientId);
                conn.Open();
                ad.Fill(table);
            }

            return table;
        }

        public bool HasActiveMembershipInClub(int clientId, int clubId, int? excludeMembershipId = null)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand())
            {
                cmd.Connection = conn;
                string sql = @"
                    SELECT COUNT(*) FROM membership
                    WHERE client_id = @clientId 
                    AND club_id = @clubId
                    AND membership_status = 'active'
                    AND end_date >= CURDATE()"; 

                if (excludeMembershipId.HasValue)
                {
                    sql += " AND membership_id != @excludeId";
                    cmd.Parameters.AddWithValue("@excludeId", excludeMembershipId.Value);
                }

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@clientId", clientId);
                cmd.Parameters.AddWithValue("@clubId", clubId);

                conn.Open();
                long count = Convert.ToInt64(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        public void UpdateExpiredMemberships()
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                UPDATE membership 
                SET membership_status = 'expired' 
                WHERE membership_status = 'active' 
                AND end_date < CURDATE();", conn))
            {
                conn.Open();
                int count = cmd.ExecuteNonQuery();
            }
        }
    }
}

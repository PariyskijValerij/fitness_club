using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace fitness_club.Data
{
    public class ClubRepository
    {
        public DataTable GetAllClubs()
        {
            return GetClubByFilter(null);
        }

        public DataTable GetClubByFilter(ClubFilter filter)
        {
            var table = new DataTable();

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand())
            {
                cmd.Connection = conn;

                string sql = @"
                SELECT c.club_id, c.club_name, c.city, c.club_address, c.club_description, c.working_hours,
                c.club_support_phone, c.club_status, COUNT(DISTINCT m.client_id) AS total_clients,
                SUM(m.membership_status = 'active') AS active_memberships
                FROM club c LEFT JOIN membership m ON m.club_id = c.club_id
                WHERE 1=1";

                if (filter != null)
                {
                    var citiesValues = new List<string>();

                    if (filter.FilterKharkiv)
                        citiesValues.Add("Kharkiv");
                    if (filter.FilterKyiv)
                        citiesValues.Add("Kyiv");
                    if (filter.FilterLviv)
                        citiesValues.Add("Lviv");

                    if (citiesValues.Count > 0)
                    {
                        var paramNames = new List<string>();
                        for (int i = 0; i < citiesValues.Count; i++)
                        {
                            var paramName = "@city" + i;
                            paramNames.Add(paramName);
                            cmd.Parameters.AddWithValue(paramName, citiesValues[i]);
                        }

                        sql += " AND city IN (" + string.Join(", ", paramNames) + ")";
                    }

                    var statusValues = new List<string>();

                    if (filter.FilterActive)
                        statusValues.Add("Active");
                    if (filter.FilterInactive)
                        statusValues.Add("Inactive");

                    if (statusValues.Count > 0)
                    {
                        var paramNames = new List<string>();
                        for (int i = 0; i < statusValues.Count; i++)
                        {
                            var paramName = "@status" + i;
                            paramNames.Add(paramName);
                            cmd.Parameters.AddWithValue(paramName, statusValues[i]);
                        }

                        sql += " AND club_status IN (" + string.Join(", ", paramNames) + ")";
                    }
                }

                sql += @"
                        GROUP BY c.club_id, c.club_name, c.city, c.club_address, c.club_description, c.working_hours,
                        c.club_support_phone, c.club_status
                        ORDER BY c.club_name;";

                cmd.CommandText = sql;
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    conn.Open();
                    adapter.Fill(table);
                }
            }

            return table;
        }

        public int CreateClub(string name, string city, string address, string description,
            string workingHours, string supportPhone, string statusDb)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                INSERT INTO club (club_name, city, club_address, club_description, 
                working_hours, club_support_phone, club_status)
                VALUES (@name, @city, @address, @desc,
                @work, @phone, @status);", conn))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@desc", string.IsNullOrWhiteSpace(description) ? (object)DBNull.Value : description);
                cmd.Parameters.AddWithValue("@work", string.IsNullOrWhiteSpace(workingHours) ? (object)DBNull.Value : workingHours);
                cmd.Parameters.AddWithValue("@phone", string.IsNullOrWhiteSpace(supportPhone) ? (object)DBNull.Value : supportPhone);
                cmd.Parameters.AddWithValue("@status", statusDb);

                conn.Open();
                var result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        public void UpdateClub(int clubId, string name, string city, string address, string description,
            string workingHours, string supportPhone, string statusDb)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                UPDATE club
                SET club_name = @name,
                    city = @city,
                    club_address = @address,
                    club_description = @desc,
                    working_hours = @work,
                    club_support_phone = @phone,
                    club_status = @status
                WHERE club_id = @id;", conn))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@desc", string.IsNullOrWhiteSpace(description) ? (object)DBNull.Value : description);
                cmd.Parameters.AddWithValue("@work", string.IsNullOrWhiteSpace(workingHours) ? (object)DBNull.Value : workingHours);
                cmd.Parameters.AddWithValue("@phone", string.IsNullOrWhiteSpace(supportPhone) ? (object)DBNull.Value : supportPhone);
                cmd.Parameters.AddWithValue("@status", statusDb);
                cmd.Parameters.AddWithValue("@id", clubId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteClub(int clubId)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(
                "DELETE FROM club WHERE club_id = @id;", conn))
            {
                cmd.Parameters.AddWithValue("@id", clubId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

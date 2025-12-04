using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace fitness_club.Data
{
    public class ClientRepository
    {
        public void CreateClient(int userId, string fullName, string phone, string email,
            DateTime? birthDate, string gender)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                INSERT INTO client (user_id, client_full_name, client_phone, client_email, 
                birth_date, registration_date, client_gender, client_status)
                VALUES (@user_id, @full_name, @phone, @email,
                @birth_date, @registration_date, @gender, 'active');
                ", conn))
            {
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@full_name", fullName);
                cmd.Parameters.AddWithValue("@phone", string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone);
                cmd.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);

                if (birthDate.HasValue)
                {
                    cmd.Parameters.AddWithValue("@birth_date", birthDate.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@birth_date", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("@registration_date", DateTime.Today);
                cmd.Parameters.AddWithValue("@gender", gender);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetAllClients()
        {
            return GetClientsByFilter(null);
        }

        public DataTable GetClientsByFilter(ClientFilter filter)
        {
            var table = new DataTable();

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand())
            {
                cmd.Connection = conn;

                string sql = @"
                SELECT c.client_id, c.user_id, u.login, u.password_hash, c.client_full_name, c.client_phone, c.client_email,
                c.birth_date, c.registration_date, c.client_gender, c.client_status
                FROM client c JOIN app_user u ON u.user_id = c.user_id
                WHERE 1=1";

                if (filter != null)
                {
                    //Фільтрація за статтю
                    var genderValues = new List<string>();

                    if (filter.FilterMale)
                        genderValues.Add("male");
                    if (filter.FilterFemale)
                        genderValues.Add("female");
                    if (filter.FilterOther)
                        genderValues.Add("other");

                    if (genderValues.Count > 0)
                    {
                        var paramNames = new List<string>();

                        for (int i = 0; i < genderValues.Count; i++)
                        {
                            string paramName = "@gender" + i;
                            paramNames.Add(paramName);
                            cmd.Parameters.AddWithValue(paramName, genderValues[i]);
                        }

                        sql += " AND client_gender IN (" + string.Join(", ", paramNames) + ")";
                    }

                    //Фільтрація за статусом
                    var statusValues = new List<string>();

                    if (filter.FilterActive)
                        statusValues.Add("active");
                    if (filter.FilterInactive)
                        statusValues.Add("inactive");

                    if (statusValues.Count > 0)
                    {
                        var paramNames = new List<string>();

                        for (int i = 0; i < statusValues.Count; i++)
                        {
                            string paramName = "@status" + i;
                            paramNames.Add(paramName);
                            cmd.Parameters.AddWithValue(paramName, statusValues[i]);
                        }

                        sql += " AND client_status IN (" + string.Join(", ", paramNames) + ")";
                    }

                    //Фільтре для дати реєстрації
                    if (filter.RegistrationDateFrom.HasValue)
                    {
                        sql += " AND registration_date >= @regFrom";
                        cmd.Parameters.AddWithValue("@regFrom", filter.RegistrationDateFrom.Value.Date);
                    }

                    if (filter.RegistrationDateTo.HasValue)
                    {
                        sql += " AND registration_date <= @regTo";
                        cmd.Parameters.AddWithValue("@regTo", filter.RegistrationDateTo.Value.Date);
                    }
                }

                cmd.CommandText = sql;
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    conn.Open();
                    adapter.Fill(table);
                }
            }

            return table;
        }

        public void UpdateClient(int clientId, string fullName, string phone, string email,
            DateTime? birthDate, string genderDb, string statusDb)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                UPDATE client
                SET client_full_name = @fullName,
                    client_phone = @phone,
                    client_email = @email,
                    birth_date = @birth,
                    client_gender = @gender,
                    client_status = @status
                WHERE client_id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@fullName", fullName);
                cmd.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone);
                cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                cmd.Parameters.AddWithValue("@birth", birthDate.HasValue ? (object)birthDate.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@gender", genderDb);
                cmd.Parameters.AddWithValue("@status", statusDb);
                cmd.Parameters.AddWithValue("@id", clientId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteClient(int clientId)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(
                "DELETE FROM client WHERE client_id = @id;", conn))
            {
                cmd.Parameters.AddWithValue("@id", clientId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

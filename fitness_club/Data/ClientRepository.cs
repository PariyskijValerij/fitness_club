using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace fitness_club.Data
{
    public class ClientRepository
    {
        public void CreateClient(int userId, string fullName, string phone, string email, DateTime? birthDate, string gender)
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
                cmd.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : phone);

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
            var table = new DataTable();
            
            using(var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                SELECT client_id, user_id, client_full_name, client_phone, client_email,
                birth_date, registration_date, client_gender, client_status
                FROM client;", conn))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                conn.Open();
                adapter.Fill(table);
            }

            return table;
        }
    }
}

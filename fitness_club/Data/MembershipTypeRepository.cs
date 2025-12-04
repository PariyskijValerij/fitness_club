using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace fitness_club.Data
{
    public class MembershipTypeRepository
    {
        public DataTable GetAllMembershipTypes()
        {
            var table = new DataTable();

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                SELECT membership_type_id, membership_name, membership_description, price_per_month,
                access_level_to_clubs, freeze_allowed, duration_months, membership_type_status
                FROM membership_type;", conn))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                conn.Open();
                adapter.Fill(table);
            }

            return table;
        }

        public int CreateMembershipType(string name, string description, decimal pricePerMonth,
            string accessLevelDb, bool freezeAllowed, int durationMonths, string statusDb)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                INSERT INTO membership_type (membership_name, membership_description, price_per_month,
                access_level_to_clubs, freeze_allowed, duration_months, membership_type_status)
                VALUES(@name, @description, @price, @accessLevel, @freeze, @durationMonths, 
                @status);", conn))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@description", (object)description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@price", pricePerMonth);
                cmd.Parameters.AddWithValue("@accessLevel", accessLevelDb);
                cmd.Parameters.AddWithValue("@freeze", freezeAllowed);
                cmd.Parameters.AddWithValue("@durationMonths", durationMonths);
                cmd.Parameters.AddWithValue("@status", statusDb);

                conn.Open();
                var result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        public void UpdateMembershipType(int id, string name, string description, decimal pricePerMonth,
            string accessLevelDb, bool freezeAllowed, int durationMonths, string statusDb)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                UPDATE membership_type
                SET membership_name = @name,
                    membership_description = @description,
                    price_per_month = @price,
                    access_level_to_clubs = @accessLevel,
                    freeze_allowed = @freeze,
                    duration_months = @durationMonths,
                    membership_type_status = @status
                WHERE membership_type_id = @id;", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@description", (object)description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@price", pricePerMonth);
                cmd.Parameters.AddWithValue("@accessLevel", accessLevelDb);
                cmd.Parameters.AddWithValue("@freeze", freezeAllowed);
                cmd.Parameters.AddWithValue("@durationMonths", durationMonths);
                cmd.Parameters.AddWithValue("@status", statusDb);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteMembershipType(int id)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                DELETE FROM membership_type
                WHERE membership_type_id = @id;", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

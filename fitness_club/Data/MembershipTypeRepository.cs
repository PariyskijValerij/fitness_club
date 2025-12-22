using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
                SELECT mt.membership_type_id, mt.membership_name, mt.membership_description, mt.price_per_month,
                mt.access_level_to_clubs, mt.freeze_allowed, mt.duration_months, mt.membership_type_status,
                COUNT(m.membership_id) AS sold_memberships,
                COUNT(m.membership_id) * mt.price_per_month * mt.duration_months AS total_revenue
                FROM membership_type mt LEFT JOIN membership m ON mt.membership_type_id = m.membership_type_id
                GROUP BY membership_type_id, membership_name, membership_description, price_per_month,
                access_level_to_clubs, freeze_allowed, duration_months, membership_type_status;", conn))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                conn.Open();
                adapter.Fill(table);
            }

            return table;
        }

        public DataTable GetMembershipTypesByFilter(MembershipTypeFilter filter)
        {
            var table = new DataTable();

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand())
            {
                cmd.Connection = conn;

                string sql = @"
                    SELECT mt.membership_type_id, mt.membership_name, mt.membership_description, mt.price_per_month,
                    mt.access_level_to_clubs, mt.freeze_allowed, mt.duration_months, mt.membership_type_status,
                    COUNT(m.membership_id) AS sold_memberships,
                    COUNT(m.membership_id) * mt.price_per_month * mt.duration_months AS total_revenue
                    FROM membership_type mt LEFT JOIN membership m ON mt.membership_type_id = m.membership_type_id
                    WHERE 1=1";

                var statuses = new List<string>();
                if (filter.FilterActive)
                    statuses.Add("'active'");
                if (filter.FilterInactive)
                    statuses.Add("'inactive'");

                if (filter.FreezeAllowed)
                    sql += " AND mt.freeze_allowed = 1";

                if (statuses.Count > 0)
                {
                    sql += $" AND mt.membership_type_status IN ({string.Join(",", statuses)})";
                }

                if (filter.PriceFrom.HasValue)
                {
                    sql += " AND mt.price_per_month >= @priceFrom";
                    cmd.Parameters.AddWithValue("@priceFrom", filter.PriceFrom.Value);
                }
                if (filter.PriceTo.HasValue)
                {
                    sql += " AND mt.price_per_month <= @priceTo";
                    cmd.Parameters.AddWithValue("@priceTo", filter.PriceTo.Value);
                }

                if (filter.DurationFrom.HasValue)
                {
                    sql += " AND mt.duration_months >= @durFrom";
                    cmd.Parameters.AddWithValue("@durFrom", filter.DurationFrom.Value);
                }
                if (filter.DurationTo.HasValue)
                {
                    sql += " AND mt.duration_months <= @durTo";
                    cmd.Parameters.AddWithValue("@durTo", filter.DurationTo.Value);
                }

                sql += @"
                    GROUP BY mt.membership_type_id, mt.membership_name, mt.membership_description, mt.price_per_month,
                    mt.access_level_to_clubs, mt.freeze_allowed, mt.duration_months, mt.membership_type_status";

                cmd.CommandText = sql;

                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    conn.Open();
                    adapter.Fill(table);
                }
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

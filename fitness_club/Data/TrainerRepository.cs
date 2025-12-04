using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace fitness_club.Data
{
    public class TrainerRepository
    {
        public DataTable GetAllTrainers()
        {
            var table = new DataTable();

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                SELECT t.trainer_id, t.user_id, u.login AS user_login, t.club_id, c.club_name, t.trainer_name, 
                t.trainer_phone, t.trainer_email, t.trainer_specialization, t.hire_date, t.trainer_gender, t.trainer_status
                FROM trainer t
                JOIN app_user u ON u.user_id = t.user_id
                JOIN club c ON c.club_id = t.club_id", conn))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                conn.Open();
                adapter.Fill(table);
            }

            return table;
        }

        public DataTable GetTrainerUsers()
        {
            var table = new DataTable();

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                SELECT user_id, login
                FROM app_user
                WHERE role = 'trainer'",
                conn))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                conn.Open();
                adapter.Fill(table);
            }

            return table;
        }

        public int CreateTrainer(int userId, int clubId, string name, string phone, string email,
            string specialization, DateTime? hireDate, string genderDb, string statusDb)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                INSERT INTO trainer (user_id, club_id, trainer_name, trainer_phone, trainer_email,
                trainer_specialization, hire_date, trainer_gender, trainer_status)
                VALUES (@userId, @clubId, @name, @phone, @email,
                @spec, @hireDate, @gender, @status);", conn))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@clubId", clubId);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@phone", string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone);
                cmd.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);
                cmd.Parameters.AddWithValue("@spec", string.IsNullOrWhiteSpace(specialization) ? (object)DBNull.Value : specialization);

                if (hireDate.HasValue)
                    cmd.Parameters.AddWithValue("@hireDate", hireDate.Value.Date);
                else
                    cmd.Parameters.AddWithValue("@hireDate", DBNull.Value);

                cmd.Parameters.AddWithValue("@gender", genderDb);
                cmd.Parameters.AddWithValue("@status", statusDb);

                conn.Open();
                var result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        public void UpdateTrainer(int trainerId, int userId, int clubId, string name, string phone, string email,
            string specialization, DateTime? hireDate, string genderDb, string statusDb)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                UPDATE trainer
                SET user_id = @userId,
                    club_id = @clubId,
                    trainer_name = @name,
                    trainer_phone = @phone,
                    trainer_email = @email,
                    trainer_specialization = @spec,
                    hire_date = @hireDate,
                    trainer_gender = @gender,
                    trainer_status = @status
                WHERE trainer_id = @id;", conn))
            {
                cmd.Parameters.AddWithValue("@id", trainerId);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@clubId", clubId);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@phone", string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone);
                cmd.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);
                cmd.Parameters.AddWithValue("@spec", string.IsNullOrWhiteSpace(specialization) ? (object)DBNull.Value : specialization);

                if (hireDate.HasValue)
                    cmd.Parameters.AddWithValue("@hireDate", hireDate.Value.Date);
                else
                    cmd.Parameters.AddWithValue("@hireDate", DBNull.Value);

                cmd.Parameters.AddWithValue("@gender", genderDb);
                cmd.Parameters.AddWithValue("@status", statusDb);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTrainer(int trainerId)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(
                "DELETE FROM trainer WHERE trainer_id = @id;", conn))
            {
                cmd.Parameters.AddWithValue("@id", trainerId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

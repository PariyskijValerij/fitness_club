using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace fitness_club.Data
{
    public class TrainerRepository
    {
        private readonly UserRepository _userRepository = new UserRepository();
        public DataTable GetAllTrainers()
        {
            var table = new DataTable();

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                SELECT t.trainer_id, t.user_id, u.login AS user_login, u.user_status, t.trainer_status, t.club_id, c.club_name, 
                t.trainer_name, t.trainer_phone, t.trainer_email, t.trainer_specialization, t.hire_date, t.trainer_gender,
                COUNT(s.session_id) AS total_sessions,
                IFNULL(SUM(s.duration_min), 0) AS total_minutes
                FROM trainer t
                JOIN app_user u ON u.user_id = t.user_id
                JOIN club c ON c.club_id = t.club_id
                LEFT JOIN session s ON t.trainer_id = s.trainer_id AND s.session_status = 'completed'
                GROUP BY t.trainer_id, t.user_id, u.login, u.user_status, t.trainer_status, t.club_id, 
                c.club_name, t.trainer_name, t.trainer_phone, t.trainer_email, t.trainer_specialization, 
                t.hire_date, t.trainer_gender", conn))
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

        public void CreateTrainerWithUser(string login, string password, string userStatusDb, string fullName, string phone,
            string email, string specialization, string genderDb, int clubId, DateTime? hireDate, string trainerStatusDb)
        {
            string passwordHash = UserRepository.HashPassword(password);

            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                int userId;
                using (var cmdUser = new MySqlCommand(@"
                    INSERT INTO app_user (login, password_hash, role, user_status)
                    VALUES (@login, @password, 'trainer', @status);", conn))
                {
                    cmdUser.Parameters.AddWithValue("@login", login);
                    cmdUser.Parameters.AddWithValue("@password", passwordHash);
                    cmdUser.Parameters.AddWithValue("@status", userStatusDb);

                    cmdUser.ExecuteNonQuery();
                    userId = (int)cmdUser.LastInsertedId;
                }

                using (var cmdTrainer = new MySqlCommand(@"
                    INSERT INTO trainer (user_id, club_id, trainer_name, trainer_phone, trainer_email,
                    trainer_specialization, hire_date, trainer_gender, trainer_status)
                    VALUES (@user_id, @club_id, @name, @phone, @email,
                    @spec, @hire_date, @gender, @tstatus);", conn))
                {
                    cmdTrainer.Parameters.AddWithValue("@user_id", userId);
                    cmdTrainer.Parameters.AddWithValue("@club_id", clubId);
                    cmdTrainer.Parameters.AddWithValue("@name", fullName);
                    cmdTrainer.Parameters.AddWithValue("@phone", phone);
                    cmdTrainer.Parameters.AddWithValue("@email", email);
                    cmdTrainer.Parameters.AddWithValue("@spec", specialization);
                    cmdTrainer.Parameters.AddWithValue("@gender", genderDb);
                    cmdTrainer.Parameters.AddWithValue("@tstatus", trainerStatusDb);

                    if (hireDate.HasValue)
                        cmdTrainer.Parameters.AddWithValue("@hire_date", hireDate.Value.Date);
                    else
                        cmdTrainer.Parameters.AddWithValue("@hire_date", DBNull.Value);

                    cmdTrainer.ExecuteNonQuery();
                }
            }
        }

        public void UpdateTrainerWithUser(int trainerId, int userId, string login, string newPassword,
            string userStatusDb, string fullName, string phone, string email, string specialization,  string genderDb,
            int clubId, DateTime? hireDate, string trainerStatusDb)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                _userRepository.UpdateUser(userId, login, newPassword, userStatusDb);

                using (var cmdTrainer = new MySqlCommand(@"
                    UPDATE trainer
                    SET club_id = @club_id,
                        trainer_name = @name,
                        trainer_phone = @phone,
                        trainer_email = @email,
                        trainer_specialization = @spec,
                        hire_date = @hire_date,
                        trainer_gender = @gender,
                        trainer_status = @tstatus
                    WHERE trainer_id = @trainer_id;", conn))
                {
                    cmdTrainer.Parameters.AddWithValue("@trainer_id", trainerId);
                    cmdTrainer.Parameters.AddWithValue("@club_id", clubId);
                    cmdTrainer.Parameters.AddWithValue("@name", fullName);
                    cmdTrainer.Parameters.AddWithValue("@phone", phone);
                    cmdTrainer.Parameters.AddWithValue("@email", email);
                    cmdTrainer.Parameters.AddWithValue("@spec", specialization);
                    cmdTrainer.Parameters.AddWithValue("@gender", genderDb);
                    cmdTrainer.Parameters.AddWithValue("@tstatus", trainerStatusDb);

                    if (hireDate.HasValue)
                        cmdTrainer.Parameters.AddWithValue("@hire_date", hireDate.Value.Date);
                    else
                        cmdTrainer.Parameters.AddWithValue("@hire_date", DBNull.Value);

                    cmdTrainer.ExecuteNonQuery();
                }
            }
        }

        public void DeleteTrainerWithUser(int trainerId, int userId)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                using (var cmdTrainer = new MySqlCommand(
                    "DELETE FROM trainer WHERE trainer_id = @id;", conn))
                {
                    cmdTrainer.Parameters.AddWithValue("@id", trainerId);
                    cmdTrainer.ExecuteNonQuery();
                }

                using (var cmdUser = new MySqlCommand(
                    "DELETE FROM app_user WHERE user_id = @uid;", conn))
                {
                    cmdUser.Parameters.AddWithValue("@uid", userId);
                    cmdUser.ExecuteNonQuery();
                }
            }
        }

        public bool IsTrainerPhoneExists(string phone, int? excludeId = null)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand())
            {
                cmd.Connection = conn;
                string sql = @"SELECT COUNT(*) 
                               FROM trainer
                               WHERE trainer_phone = @phone";

                if (excludeId.HasValue)
                {
                    sql += " AND trainer_id != @id";
                    cmd.Parameters.AddWithValue("@id", excludeId.Value);
                }

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@phone", phone);

                conn.Open();
                long count = Convert.ToInt64(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }
}

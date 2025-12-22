using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;
using System.Security.Cryptography;

namespace fitness_club
{
    public class UserRepository
    {
        public static string HashPassword(string password)
        {
            if (password == null)
                throw new ArgumentNullException(nameof(password));

            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hashBytes = sha.ComputeHash(bytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        public User GetByLoginAndPassword(string login, string password)
        {
            string passwordHash = HashPassword(password);

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                SELECT user_id, login, role, user_status
                FROM app_user
                WHERE login = @login AND password_hash = @password_hash
                LIMIT 1", conn))
            {
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password_hash", passwordHash);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    return new User
                    {
                        UserId = reader.GetInt32("user_id"),
                        Login = reader.GetString("login"),
                        Role = reader.GetString("role"),
                        UserStatus = reader.GetString("user_status")
                    };
                }
            }
        }

        public bool isLoginTaken(string login, int? userId = null)
        {
            using (var conn = DbHelper.GetConnection())
            {
                string sql = @"
                    SELECT COUNT(user_id)
                    FROM app_user
                    WHERE login = @login";

                if (userId.HasValue)
                    sql += " AND user_id <> @excludeId";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    if (userId.HasValue)
                        cmd.Parameters.AddWithValue("@excludeId", userId.Value);

                    conn.Open();
                    var count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public int CreateUser(string login, string password, string role)
        {
            string passwordHash = HashPassword(password);

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                INSERT INTO app_user (login, password_hash, role, user_status)
                VALUES (@login, @password_hash, @role, 'active');
                SELECT LAST_INSERT_ID();", conn))
            {
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password_hash", passwordHash);
                cmd.Parameters.AddWithValue("@role", role);
                conn.Open();
                cmd.ExecuteNonQuery();
                return (int)cmd.LastInsertedId;
            }
        }

        public void UpdateUserStatusByClient(int clientId, string clientStatus)
        {
            string newUserStatus;

            if (clientStatus == "blocked")
                newUserStatus = "blocked";
            else
                newUserStatus = "active";

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                UPDATE app_user u
                JOIN client c ON u.user_id = c.user_id
                SET u.user_status = @userStatus
                WHERE c.client_id = @clientId;", conn))
            {
                cmd.Parameters.AddWithValue("@userStatus", newUserStatus);
                cmd.Parameters.AddWithValue("@clientId", clientId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateUser(int userId, string login, string newPassword, string userStatus)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();

                string sql;
                if (!string.IsNullOrEmpty(newPassword))
                {
                    sql = @"
                        UPDATE app_user
                        SET login = @login,
                            password_hash = @password_hash,
                            user_status = @user_status
                        WHERE user_id = @user_id;";
                }
                else
                {
                    sql = @"
                        UPDATE app_user
                        SET login = @login,
                            user_status = @user_status
                        WHERE user_id = @user_id;";
                }

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@user_status", userStatus);
                    cmd.Parameters.AddWithValue("@user_id", userId);

                    if (!string.IsNullOrEmpty(newPassword))
                    {
                        string hash = HashPassword(newPassword);
                        cmd.Parameters.AddWithValue("@password_hash", hash);
                    }

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

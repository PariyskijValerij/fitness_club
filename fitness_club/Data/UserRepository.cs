using MySql.Data.MySqlClient;
using System;

namespace fitness_club
{
    public class UserRepository
    {
        public User GetByLoginAndPassword(string login, string password)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                SELECT user_id, login, role, user_status
                FROM app_user
                WHERE login = @login AND password_hash = @password
                LIMIT 1", conn))
            {
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    var user = new User
                    {
                        UserId = reader.GetInt32("user_id"),
                        Login = reader.GetString("login"),
                        Role = reader.GetString("role"),
                        UserStatus = reader.GetString("user_status")
                    };

                    return user;
                }
            }
        }

        public bool isLoginTaken(string login)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                SELECT COUNT(user_id) 
                FROM app_user
                WHERE login = @login", conn))
            {
                cmd.Parameters.AddWithValue("@login", login);
                conn.Open();
                var count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        public int CreateUser(string login, string password, string role)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                INSERT INTO app_user (login, password_hash, role, user_status)
                VALUES (@login, @password, @role, 'active');
                SELECT LAST_INSERT_ID();", conn))
            {
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@role", role);
                conn.Open();
                var result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }
    }
}

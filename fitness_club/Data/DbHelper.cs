using MySql.Data.MySqlClient;
using System.Configuration;

namespace fitness_club
{
    internal class DbHelper
    {
        public static MySqlConnection GetConnection()
        {
            string connString = ConfigurationManager.ConnectionStrings["FitnessClubConnection"].ConnectionString;

            return new MySqlConnection(connString);
        }
    }
}

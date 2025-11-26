using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

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

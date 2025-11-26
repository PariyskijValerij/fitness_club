using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitness_club
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string UserStatus { get; set; } = string.Empty;
    }
}

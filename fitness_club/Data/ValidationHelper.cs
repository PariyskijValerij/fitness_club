using System.Net.Mail;

namespace fitness_club.Data
{
    public class ValidationHelper
    {
        public bool isEmailValid(string email)  
        {
            if (string.IsNullOrEmpty(email)) return true;

            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}

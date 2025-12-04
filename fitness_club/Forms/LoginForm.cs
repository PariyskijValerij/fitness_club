using fitness_club.Forms;
using System;
using System.Windows.Forms;

namespace fitness_club
{
    public partial class LoginForm : Form
    {
        private readonly UserRepository _userRepository = new UserRepository();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblLoginError.Visible = false;
            lblPasswordError.Visible = false;
            lblAuthError.Visible = false;

            bool hasError = false;

            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(login))
            {
                lblLoginError.Visible = true;
                hasError = true;
            }

            if (string.IsNullOrEmpty(password))
            {
                lblPasswordError.Visible = true;
                hasError = true;
            }

            if (hasError)
                return;

            User user = null;

            try
            {
                user = _userRepository.GetByLoginAndPassword(login, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while accessing the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (user == null)
            {
                lblAuthError.Text = "Invalid login or password.";
                lblAuthError.Visible = true;
                return;
            }

            if (user.UserStatus == "blocked")
            {
                lblAuthError.Text = "Your account is blocked. Please contact support.";
                lblAuthError.Visible = true;
                return;
            }

            MessageBox.Show($"Welcome, {user.Login}! You are logged in as {user.Role}.");

            if (user.Role == "admin")
            {
                using (var adminForm = new AdminForm())
                {
                    this.Hide();
                    adminForm.ShowDialog();
                    this.Show();
                }
            }
            //else if (user.Role == "client")
            //{
            //    using (var clientForm = new ClientDashboardForm(user))
            //    {
            //        this.Hide();
            //        clientForm.ShowDialog();
            //        this.Show();
            //    }
            //}
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            using (var regForm = new ClientRegistrationForm())
            {
                regForm.ShowDialog();
            }
        }
    }
}

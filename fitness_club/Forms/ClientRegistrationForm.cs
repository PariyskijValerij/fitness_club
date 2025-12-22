using fitness_club.Data;
using System;
using System.Windows.Forms;

namespace fitness_club.Forms
{
    public partial class ClientRegistrationForm : Form
    {
        private readonly UserRepository _userRepository = new UserRepository();
        private readonly ClientRepository _clientRepository = new ClientRepository();
        private readonly ValidationHelper _validationHelper = new ValidationHelper();

        public ClientRegistrationForm()
        {
            InitializeComponent();

            cbGender.Items.Clear();
            cbGender.Items.Add("Male");
            cbGender.Items.Add("Female");
            cbGender.Items.Add("Other");
            cbGender.SelectedIndex = 0;

            dtpBirthDate.MaxDate = DateTime.Today.AddYears(-16);
            dtpBirthDate.MinDate = DateTime.Today.AddYears(-90);
            dtpBirthDate.Value = dtpBirthDate.MaxDate;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            lblLoginError.Visible = false;
            lblPasswordError.Visible = false;
            lblConfirmPasswordError.Visible = false;
            lblFullNameError.Visible = false;
            lblEmailError.Visible = false;
            lblPhoneError.Visible = false;
            lblGenderError.Visible = false;
            lblGeneralError.Visible = false;

            bool hasError = false;

            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string fullName = txtFullName.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (!txtPhone.MaskFull)
            {
                lblPhoneError.Text = "Phone is required.";
                lblPhoneError.Visible = true;
                hasError = true;
            }

            string email = txtEmail.Text.Trim();

            if (!_validationHelper.isEmailValid(email))
            {
                lblEmailError.Text = "Incorrect email format.";
                lblEmailError.Visible = true;
                hasError = true;
            }

            if (string.IsNullOrEmpty(login))
            {
                lblLoginError.Text = "Login is required.";
                lblLoginError.Visible = true;
                hasError = true;
            }
            if (string.IsNullOrEmpty(password))
            {
                lblPasswordError.Text = "Password is required.";
                lblPasswordError.Visible = true;
                hasError = true;
            }
            if (password != confirmPassword)
            {
                lblConfirmPasswordError.Text = "Passwords do not match.";
                lblConfirmPasswordError.Visible = true;
                hasError = true;
            }
            if (string.IsNullOrEmpty(fullName))
            {
                lblFullNameError.Text = "Full name is required.";
                lblFullNameError.Visible = true;
                hasError = true;
            }
            if (cbGender.SelectedItem == null)
            {
                lblGenderError.Text = "Select gender";
                lblGenderError.Visible = true;
                hasError = true;
            }

            if (hasError)
            {
                return;
            }

            try
            {
                if (_userRepository.isLoginTaken(login))
                {
                    lblLoginError.Text = "Login is already taken.";
                    lblLoginError.Visible = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                lblGeneralError.Text = "An error occurred while checking login availability." + ex.Message;
                lblGeneralError.Visible = true;
                return;
            }

            string genderDb;
            switch (cbGender.SelectedItem.ToString())
            {
                case "Male":
                    genderDb = "male";
                    break;
                case "Female":
                    genderDb = "female";
                    break;
                default:
                    genderDb = "other";
                    break;
            }

            DateTime? birthDate = null;
            if (dtpBirthDate.Checked)
            {
                birthDate = dtpBirthDate.Value.Date;
            }

            try
            {
                int newUserId = _userRepository.CreateUser(login, password, "client");
                _clientRepository.CreateClient(newUserId, fullName, phone, email, birthDate, genderDb);
            }
            catch (Exception ex)
            {
                lblGeneralError.Text = "An error occurred while creating the account." + ex.Message;
                lblGeneralError.Visible = true;
                return;
            }

            MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}

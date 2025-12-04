using fitness_club.Data;
using System;
using System.Windows.Forms;

namespace fitness_club.Forms
{
    public partial class ClientEditForm : Form
    {
        private readonly ClientRepository _clientRepository = new ClientRepository();
        private readonly UserRepository _userRepository  = new UserRepository();
        private readonly int _clientId;

        public ClientEditForm(int clientId, string fullName, string phone, string email, DateTime? birthDate, string genderDb, string statusDb)
        {
            InitializeComponent();
            _clientId = clientId;

            txtFullName.Text = fullName;
            txtPhone.Text = phone;
            txtEmail.Text = email;

            if (birthDate.HasValue)
            {
                dtpBirthDate.Value = birthDate.Value;
                dtpBirthDate.Checked = true;
            }
            else
            {
                dtpBirthDate.Checked = false;
            }

            cbGender.Items.Clear();
            cbGender.Items.Add("Male");
            cbGender.Items.Add("Female");
            cbGender.Items.Add("Other");

            switch (genderDb)
            {
                case "male":
                    cbGender.SelectedItem = "Male";
                    break;
                case "female":
                    cbGender.SelectedItem = "Female";
                    break;
                default:
                    cbGender.SelectedItem = "Other";
                    break;
            }

            cbStatus.Items.Clear();
            cbStatus.Items.Add("Active");
            cbStatus.Items.Add("Inactive");
            cbStatus.Items.Add("Blocked");

            switch (statusDb)
            {
                case "active":
                    cbStatus.SelectedItem = "Active";
                    break;
                case "inactive":
                    cbStatus.SelectedItem = "Inactive";
                    break;
                default:
                    cbStatus.SelectedItem = "Blocked";
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            if (string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Full name is required");
                return;
            }

            if (cbGender.SelectedItem == null)
            {
                MessageBox.Show("Select gender");
                return;
            }

            if (cbStatus.SelectedItem == null)
            {
                MessageBox.Show("Select status");
                return;
            }

            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();

            string genderDb;
            switch (cbGender.SelectedItem.ToString())
            {
                case "Male":
                    genderDb = "male";
                    break;
                case "Female":
                    genderDb = "female";
                    break;
                case "Other":
                    genderDb = "other";
                    break;
                default:
                    genderDb = "other";
                    break;
            }

            string statusDb;
            switch (cbStatus.SelectedItem.ToString())
            {
                case "Active":
                    statusDb = "active";
                    break;
                case "Inactive":
                    statusDb = "inactive";
                    break;
                case "Blocked":
                    statusDb = "blocked";
                    break;
                default:
                    statusDb = "active";
                    break;
            }

            DateTime? birthDate = null;
            if (dtpBirthDate.Checked)
            {
                birthDate = dtpBirthDate.Value.Date;
            }

            try
            {
                _clientRepository.UpdateClient(_clientId, fullName, phone, email, birthDate, genderDb, statusDb);
                _userRepository.UpdateUserStatusByClient(_clientId, statusDb);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }
    }
}

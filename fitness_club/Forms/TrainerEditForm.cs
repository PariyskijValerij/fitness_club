using fitness_club.Data;
using System;
using System.Data;
using System.Windows.Forms;

namespace fitness_club.Forms
{
    public partial class TrainerEditForm : Form
    {
        private readonly TrainerRepository _trainerRepository = new TrainerRepository();
        private readonly UserRepository _userRepository = new UserRepository();
        private readonly ClubRepository _clubRepository = new ClubRepository();
        private readonly ValidationHelper _validationHelper = new ValidationHelper();

        private int? _trainerId;
        private int? _userId;

        private class ClubItem
        {
            public int Id { get; }
            public string Name { get; }
            public ClubItem(int id, string name) { Id = id; Name = name; }
            public override string ToString() => Name;
        }

        public TrainerEditForm()
        {
            InitializeComponent();

            _trainerId = null;
            _userId = null;

            InitCombos();
            LoadClubs();
        }

        public TrainerEditForm(int trainerId, int userId, string login, string fullName, string phone, string email,
            string specialization, string genderDb, string trainerStatusDb, string userStatusDb, int clubId, DateTime? hireDate)
            : this()
        {
            _trainerId = trainerId;
            _userId = userId;

            txtLogin.Text = login;
            txtFullName.Text = fullName;
            txtPhone.Text = phone;
            txtEmail.Text = email;
            txtSpecialization.Text = specialization;

            switch (genderDb)
            {
                case "male": cbGender.SelectedItem = "Male"; break;
                case "female": cbGender.SelectedItem = "Female"; break;
                default: cbGender.SelectedItem = "Other"; break;
            }

            cbTrainerStatus.SelectedItem =
                trainerStatusDb == "inactive" ? "Inactive" : "Active";

            cbUserStatus.SelectedItem =
                userStatusDb == "blocked" ? "Blocked" : "Active";

            if (hireDate.HasValue)
            {
                dtpHireDate.Checked = true;
                dtpHireDate.Value = hireDate.Value;
            }
            else
            {
                dtpHireDate.Checked = false;
            }

            foreach (ClubItem item in cbClub.Items)
            {
                if (item.Id == clubId)
                {
                    cbClub.SelectedItem = item;
                    break;
                }
            }
        }

        private void InitCombos()
        {
            cbGender.Items.Clear();
            cbGender.Items.Add("Male");
            cbGender.Items.Add("Female");
            cbGender.Items.Add("Other");
            cbGender.SelectedIndex = 0;

            cbTrainerStatus.Items.Clear();
            cbTrainerStatus.Items.Add("Active");
            cbTrainerStatus.Items.Add("Inactive");
            cbTrainerStatus.SelectedIndex = 0;

            cbUserStatus.Items.Clear();
            cbUserStatus.Items.Add("Active");
            cbUserStatus.Items.Add("Blocked");
            cbUserStatus.SelectedIndex = 0;
        }

        private void LoadClubs()
        {
            var clubs = _clubRepository.GetAllClubs();
            cbClub.Items.Clear();

            foreach (DataRow row in clubs.Rows)
            {
                int id = Convert.ToInt32(row["club_id"]);
                string name = row["club_name"].ToString();
                cbClub.Items.Add(new ClubItem(id, name));
            }

            if (cbClub.Items.Count > 0)
                cbClub.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Login is required.");
                return;
            }

            if (_userRepository.isLoginTaken(login, _userId))
            {
                MessageBox.Show("This login is already used by another user.");
                return;
            }

            string fullName = txtFullName.Text.Trim();
            if (string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Full name is required.");
                return;
            }
            string phone = txtPhone.Text.Trim();
            if (!txtPhone.MaskFull)
            {
                MessageBox.Show("Phone is required");
                return;
            }

            if (cbClub.SelectedItem == null)
            {
                MessageBox.Show("Select club.");
                return;
            }

            if (cbGender.SelectedItem == null || cbTrainerStatus.SelectedItem == null || cbUserStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select gender and statuses.");
                return;
            }

            string password = txtPassword.Text;
            string email = txtEmail.Text.Trim();

            if (!_validationHelper.isEmailValid(email))
            {
                MessageBox.Show("Incorrect email format.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string specialization = txtSpecialization.Text.Trim();

            string genderDb =
                cbGender.SelectedItem.ToString() == "Male" ? "male" :
                cbGender.SelectedItem.ToString() == "Female" ? "female" : "other";

            string trainerStatusDb =
                cbTrainerStatus.SelectedItem.ToString() == "Inactive" ? "inactive" : "active";

            string userStatusDb =
                cbUserStatus.SelectedItem.ToString() == "Blocked" ? "blocked" : "active";

            var clubItem = (ClubItem)cbClub.SelectedItem;
            int clubId = clubItem.Id;

            DateTime? hireDate = dtpHireDate.Checked ? dtpHireDate.Value.Date : (DateTime?)null;

            try
            {
                if (_trainerId == null)
                {
                    if (string.IsNullOrEmpty(password))
                    {
                        MessageBox.Show("Password is required for a new trainer.");
                        return;
                    }

                    _trainerRepository.CreateTrainerWithUser(login, password, userStatusDb,fullName, phone, email, 
                        specialization, genderDb, clubId, hireDate, trainerStatusDb);
                }
                else
                {
                    _trainerRepository.UpdateTrainerWithUser(_trainerId.Value, _userId.Value, login,
                        string.IsNullOrEmpty(password) ? null : password, userStatusDb, fullName, phone, email,
                        specialization, genderDb, clubId, hireDate, trainerStatusDb);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving trainer: " + ex.Message);
            }
        }
    }
}

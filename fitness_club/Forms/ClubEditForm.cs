using fitness_club.Data;
using System;
using System.Windows.Forms;

namespace fitness_club.Forms
{
    public partial class ClubEditForm : Form
    {
        private readonly ClubRepository _clubRepository = new ClubRepository();
        private readonly int? _clubId;

        public ClubEditForm()
        {
            InitializeComponent();

            _clubId = null;
            InitStatusCombo();
            InitCityCombo();
        }

        public ClubEditForm(int clubId, string name, string description, string city, string address, string workingHours,
            string supportPhone, string statusDb) : this()
        {
            _clubId = clubId;
            txtName.Text = name;
            txtDescription.Text = description;
            if (cbCity.Items.Contains(city))
            {
                cbCity.SelectedItem = city;
            }
            else
            {
                cbCity.SelectedIndex = 0;
            }
            txtAddress.Text = address;
            txtWorkingHours.Text = workingHours;
            txtSupportPhone.Text = supportPhone;

            switch (statusDb)
            {
                case "active":
                    cbStatus.SelectedItem = "Active";
                    break;
                case "inactive":
                    cbStatus.SelectedItem = "Inactive";
                    break;
                default:
                    cbStatus.SelectedItem = "Active";
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
            string name = txtName.Text.Trim();
            string description = txtDescription.Text.Trim();
            string city = cbCity.SelectedItem.ToString();
            string address = txtAddress.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Club name is required.");
                return;
            }
            if (string.IsNullOrEmpty(city))
            {
                MessageBox.Show("City is required.");
                return;
            }
            if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Address is required.");
                return;
            }

            string workingHours = txtWorkingHours.Text.Trim();
            string supportPhone = txtSupportPhone.Text.Trim();
            string statusDb = cbStatus.SelectedItem?.ToString() == "Inactive" ? "inactive" : "active";

            try
            {
                if (_clubId == null)
                {
                    _clubRepository.CreateClub(name, city, address, description, workingHours, supportPhone, statusDb);
                }
                else
                {
                    _clubRepository.UpdateClub(_clubId.Value, name, city, address, description, workingHours, supportPhone, statusDb);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error while saving club");
            }
        }

        private void InitStatusCombo()
        {
            cbStatus.Items.Clear();
            cbStatus.Items.Add("Active");
            cbStatus.Items.Add("Inactive");
            cbStatus.SelectedIndex = 0;
        }

        private void InitCityCombo()
        {
            cbCity.Items.Clear();
            cbCity.Items.Add("Kharkiv");
            cbCity.Items.Add("Kyiv");
            cbCity.Items.Add("Lviv");
            cbCity.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCity.SelectedIndex = 0;
        }
    }
}

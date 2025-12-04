using fitness_club.Data;
using System;
using System.Windows.Forms;

namespace fitness_club.Forms
{
    public partial class MembershipTypeEditForm : Form
    {
        private readonly MembershipTypeRepository _membershipTypeRepository = new MembershipTypeRepository();
        private readonly int? _id;

        public MembershipTypeEditForm()
        {
            InitializeComponent();

            _id = null;
            InitCombos();
        }

        public MembershipTypeEditForm(int id, string name, string description, decimal price,
            string accessLevelDb, bool freezeAllowed, int durationMonths, string statusDb)
        {
            InitializeComponent();

            _id = id;
            InitCombos();

            txtName.Text = name;
            txtDescription.Text = description;
            nudPrice.Value = (price >= nudPrice.Minimum && price <= nudPrice.Maximum) ? price : nudPrice.Minimum;
            nudDuration.Value = (durationMonths >= nudDuration.Minimum && durationMonths <= nudDuration.Maximum)
                ? durationMonths : nudDuration.Minimum;
            chkFreezeAllowed.Checked = freezeAllowed;

            switch (accessLevelDb)
            {
                case "all_clubs":
                    cbAccessLevel.SelectedItem = "All clubs";
                    break;
                default:
                    cbAccessLevel.SelectedItem = "Home club only";
                    break;
            }

            switch (statusDb)
            {
                case "inactive":
                    cbStatus.SelectedItem = "Inactive";
                    break;
                default:
                    cbStatus.SelectedItem = "Active";
                    break;
            }
        }

        private void InitCombos()
        {
            cbAccessLevel.Items.Clear();
            cbAccessLevel.Items.Add("Home club only");
            cbAccessLevel.Items.Add("All clubs");
            cbAccessLevel.SelectedIndex = 0;

            cbStatus.Items.Clear();
            cbStatus.Items.Add("Active");
            cbStatus.Items.Add("Inactive");
            cbStatus.SelectedIndex = 0;
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

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Membership name is required.");
                return;
            }

            if (cbAccessLevel.SelectedItem == null)
            {
                MessageBox.Show("Select access level.");
                return;
            }

            if (cbStatus.SelectedItem == null)
            {
                MessageBox.Show("Select status.");
                return;
            }

            decimal price = nudPrice.Value;
            int durationMonths = (int)nudDuration.Value;
            bool freezeAllowed = chkFreezeAllowed.Checked;

            string accessLevelDb =
                cbAccessLevel.SelectedItem.ToString() == "All clubs" ? "all_clubs" : "home";

            string statusDb =
                cbStatus.SelectedItem.ToString() == "Inactive" ? "inactive" : "active";

            try
            {
                if (_id == null)
                {
                    _membershipTypeRepository.CreateMembershipType(name, description, price,
                        accessLevelDb, freezeAllowed, durationMonths, statusDb);
                }
                else
                {
                    _membershipTypeRepository.UpdateMembershipType(_id.Value, name, description, price,
                        accessLevelDb, freezeAllowed, durationMonths, statusDb);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving membership type: " + ex.Message);
            }
        }
    }
}

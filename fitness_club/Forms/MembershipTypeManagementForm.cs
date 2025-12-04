using fitness_club.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace fitness_club.Forms
{
    public partial class MembershipTypeManagementForm : Form
    {
        private readonly MembershipTypeRepository _membershiptypeRepository = new MembershipTypeRepository();
        private DataTable _membeshipTypesTable;

        public MembershipTypeManagementForm()
        {
            InitializeComponent();
        }

        private void MembershipTypeManagementForm_Load(object sender, EventArgs e)
        {
            LoadMembershipTypes();
        }

        private void LoadMembershipTypes()
        {
            _membeshipTypesTable = _membershiptypeRepository.GetAllMembershipTypes();
            dgvMembershipTypes.DataSource = _membeshipTypesTable;
            dgvMembershipTypes.ClearSelection();
        }

        private void btnAddMembershipType_Click(object sender, EventArgs e)
        {
            using (var form = new MembershipTypeEditForm())
            {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    LoadMembershipTypes();
                }
            }
        }

        private void btnEditMembershipType_Click(object sender, EventArgs e)
        {
            if (dgvMembershipTypes.SelectedRows.Count == 0)
                return;

            var row = dgvMembershipTypes.SelectedRows[0];

            int id = Convert.ToInt32(row.Cells["membership_type_id"].Value);
            string name = row.Cells["membership_name"].Value?.ToString() ?? "";
            string description = row.Cells["membership_description"].Value?.ToString() ?? "";
            decimal price = Convert.ToDecimal(row.Cells["price_per_month"].Value);
            string accessLevelDb = row.Cells["access_level_to_clubs"].Value?.ToString() ?? "home";
            bool freezeAllowed = Convert.ToBoolean(row.Cells["freeze_allowed"].Value);
            int durationMonths = Convert.ToInt32(row.Cells["duration_months"].Value);
            string statusDb = row.Cells["membership_type_status"].Value?.ToString() ?? "active";

            using (var form = new MembershipTypeEditForm(
                id, name, description, price, accessLevelDb, freezeAllowed, durationMonths, statusDb))
            {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    LoadMembershipTypes();
                }
            }
        }

        private void btnDeleteMembershipType_Click(object sender, EventArgs e)
        {
            if (dgvMembershipTypes.SelectedRows.Count == 0)
                return;

            var row = dgvMembershipTypes.SelectedRows[0];

            int id = Convert.ToInt32(row.Cells["membership_type_id"].Value);
            string name = row.Cells["membership_name"].Value?.ToString() ?? "";

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete membership type:\n" +
                $"Id: {id}\n" +
                $"Name: {name}\n" +
                $"This action cannot be undone.",
                "Confirm deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                _membershiptypeRepository.DeleteMembershipType(id);
                LoadMembershipTypes();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    MessageBox.Show(
                        "Cannot delete this membership type because it is used by existing memberships.\n" +
                        "Delete or change related memberships first.",
                        "Delete membership type",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error while deleting membership type: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting membership type: " + ex.Message);
            }
        }
    }
}

using fitness_club.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace fitness_club.Forms
{
    public partial class ClubManagementForm : Form
    {
        private readonly ClubRepository _clubRepository = new ClubRepository();
        private DataTable _clubsTable;

        private ClubFilter _currentFilter = new ClubFilter();

        public ClubManagementForm()
        {
            InitializeComponent();
        }

        private void ClubManagementForm_Load(object sender, EventArgs e)
        {
            LoadClubs();
        }

        private void LoadClubs()
        {
            _clubsTable = _clubRepository.GetClubByFilter(_currentFilter);
            dgvClubs.DataSource = _clubsTable;
            dgvClubs.ClearSelection();
        }

        private void btnClubSearch_Click(object sender, EventArgs e)
        {
            string term = txtClubSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(term))
            {
                ClearClubsRowColors();
                return;
            }

            ClearClubsRowColors();

            foreach (DataGridViewRow row in dgvClubs.Rows)
            {
                if (row.IsNewRow) continue;
                string clubName = row.Cells["club_name"].Value?.ToString().ToLower() ?? "";
                //string clubAddress = row.Cells["club_address"].Value?.ToString().ToLower() ?? "";
                string clubDescription = row.Cells["club_description"].Value?.ToString().ToLower() ?? "";
                //string clubCity = row.Cells["city"].Value?.ToString().ToLower() ?? "";
                bool match =
                    clubName.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    clubDescription.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0;
                if (match)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LightPink;
                }
            }
        }

        private void btnClubClearSearch_Click(object sender, EventArgs e)
        {
            txtClubSearch.Clear();
            ClearClubsRowColors();
            dgvClubs.ClearSelection();
        }

        private void ClearClubsRowColors()
        {
            foreach (DataGridViewRow row in dgvClubs.Rows)
            {
                if (row.IsNewRow) continue;
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            using (var filterForm = new ClubFilterForm())
            {
                filterForm.FilterActive = _currentFilter.FilterActive;
                filterForm.FilterInactive = _currentFilter.FilterInactive;
                filterForm.FilterKharkiv = _currentFilter.FilterKharkiv;
                filterForm.FilterKyiv = _currentFilter.FilterKyiv;

                var result = filterForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    _currentFilter.FilterActive = filterForm.FilterActive;
                    _currentFilter.FilterInactive = filterForm.FilterInactive;
                    _currentFilter.FilterKharkiv = filterForm.FilterKharkiv;
                    _currentFilter.FilterKyiv = filterForm.FilterKyiv;

                    LoadClubs();
                }
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            _currentFilter = new ClubFilter();
            LoadClubs();

            dgvClubs.ClearSelection();
        }

        private void btnAddClub_Click(object sender, EventArgs e)
        {
            using (var form = new ClubEditForm())
            {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    LoadClubs();
                }
            }
        }

        private void btnEditClub_Click(object sender, EventArgs e)
        {
            if (dgvClubs.SelectedRows.Count == 0)
            {
                return;
            }

            var row = dgvClubs.SelectedRows[0];

            int clubId = Convert.ToInt32(row.Cells["club_id"].Value);
            string name = row.Cells["club_name"].Value?.ToString() ?? "";
            string description = row.Cells["club_description"].Value?.ToString() ?? "";
            string city = row.Cells["city"].Value?.ToString() ?? "";
            string address = row.Cells["club_address"].Value?.ToString() ?? "";
            string workingHours = row.Cells["working_hours"].Value?.ToString() ?? "";
            string phone = row.Cells["club_support_phone"].Value?.ToString() ?? "";
            string statusDb = row.Cells["club_status"].Value?.ToString() ?? "active";

            using (var form = new ClubEditForm(clubId, name, description, city, address, workingHours, phone, statusDb))
            {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    LoadClubs();
                }
            }
        }

        private void btnDeleteClub_Click(object sender, EventArgs e)
        {
            if (dgvClubs.SelectedRows.Count == 0)
            {
                return;
            }

            var row = dgvClubs.SelectedRows[0];

            int clubId = Convert.ToInt32(row.Cells["club_id"].Value);
            string name = row.Cells["club_name"].Value?.ToString() ?? "";
            string city = row.Cells["city"].Value?.ToString() ?? "";

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete club:\n" +
                $"Name: {name}\n" +
                $"City: {city}\n" +
                $"This action cannot be undone.",
                "Confirm deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                _clubRepository.DeleteClub(clubId);
                LoadClubs();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    MessageBox.Show(
                        "Cannot delete this club because it has related rooms, trainers, or memberships.\n" +
                        "Delete or reassign related data first.",
                        "Delete club", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error while deleting club");
                }
            }
            catch
            {
                MessageBox.Show("Error while deleting club");
            }
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            if (dgvClubs.SelectedRows.Count == 0)
            {
                return;
            }

            var row  = dgvClubs.SelectedRows[0];

            int clubId = Convert.ToInt32(row.Cells["club_id"].Value);
            string clubName = row.Cells["club_name"].Value?.ToString() ?? "";

            using (var form = new RoomManagementForm(clubId, clubName))
            {
                form.ShowDialog(this);
            }
        }
    }
}

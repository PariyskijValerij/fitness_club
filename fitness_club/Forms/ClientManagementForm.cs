using fitness_club.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace fitness_club.Forms
{
    public partial class ClientManagementForm : Form
    {
        private readonly ClientRepository _clientRepository = new ClientRepository();
        private DataTable _clientsTable;

        private ClientFilter _currentFilter = new ClientFilter();

        public ClientManagementForm()
        {
            InitializeComponent();
        }

        private void ClientManagementForm_Load(object sender, EventArgs e)
        {
            LoadClients();
        }

        private void LoadClients()
        {
            _clientsTable = _clientRepository.GetClientsByFilter(_currentFilter);
            dgvClients.DataSource = _clientsTable;
            dgvClients.ClearSelection();
        }

        private void btnClientSearch_Click(object sender, EventArgs e)
        {
            string term = txtClientSearch.Text.Trim();

            if (string.IsNullOrEmpty(term))
            {
                ClearClientRowColors();
                return;
            }

            ClearClientRowColors();

            foreach (DataGridViewRow row in dgvClients.Rows)
            {
                if (row.IsNewRow) continue;

                string fullName = row.Cells["client_full_name"].Value?.ToString() ?? "";
                string phone = row.Cells["client_phone"].Value?.ToString() ?? "";
                string email = row.Cells["client_email"].Value?.ToString() ?? "";

                bool match =
                    fullName.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    phone.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    email.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0;

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

        private void btnClientClearSearch_Click(object sender, EventArgs e)
        {
            txtClientSearch.Clear();
            ClearClientRowColors();
            dgvClients.ClearSelection();
        }

        private void ClearClientRowColors()
        {
            foreach (DataGridViewRow row in dgvClients.Rows)
            {
                if (row.IsNewRow) continue;
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            using (var filterForm = new ClientFilterForm())
            {
                filterForm.FilterMale = _currentFilter.FilterMale;
                filterForm.FilterFemale = _currentFilter.FilterFemale;
                filterForm.FilterOther = _currentFilter.FilterOther;
                filterForm.FilterActive = _currentFilter.FilterActive;
                filterForm.FilterInactive = _currentFilter.FilterInactive;
                filterForm.RegDateFrom = _currentFilter.RegistrationDateFrom;
                filterForm.RegDateTo = _currentFilter.RegistrationDateTo;

                var result = filterForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    _currentFilter.FilterMale = filterForm.FilterMale;
                    _currentFilter.FilterFemale = filterForm.FilterFemale;
                    _currentFilter.FilterOther = filterForm.FilterOther;
                    _currentFilter.FilterActive = filterForm.FilterActive;
                    _currentFilter.FilterInactive = filterForm.FilterInactive;
                    _currentFilter.RegistrationDateFrom = filterForm.RegDateFrom;
                    _currentFilter.RegistrationDateTo = filterForm.RegDateTo;

                    LoadClients();
                }
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            _currentFilter = new ClientFilter();
            LoadClients();

            dgvClients.ClearSelection();
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            using (var regForm = new ClientRegistrationForm())
            {
                regForm.ShowDialog(this);
            }

            LoadClients();
        }

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count == 0)
            {
                return;
            }

            var row = dgvClients.SelectedRows[0];

            int clientId = Convert.ToInt32(row.Cells["client_id"].Value);
            string fullName = row.Cells["client_full_name"].Value?.ToString() ?? "";
            string phone = row.Cells["client_phone"].Value?.ToString() ?? "";
            string email = row.Cells["client_email"].Value?.ToString() ?? "";

            DateTime? birthDate = null;
            if (row.Cells["birth_date"].Value != DBNull.Value && row.Cells["birth_date"].Value != null)
            {
                birthDate = Convert.ToDateTime(row.Cells["birth_date"].Value);
            }

            string genderDb = row.Cells["client_gender"].Value?.ToString() ?? "other";
            string statusDb = row.Cells["client_status"].Value?.ToString() ?? "active";

            using (var editForm = new ClientEditForm(clientId, fullName, phone, email, birthDate, genderDb, statusDb))
            {
                var result = editForm.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    LoadClients();
                }
            }
        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count == 0)
            {
                return;
            }

            var row = dgvClients.SelectedRows[0];

            int clientId = Convert.ToInt32(row.Cells["client_id"].Value);
            string fullName = row.Cells["client_full_name"].Value?.ToString() ?? "";
            string phone = row.Cells["client_phone"].Value?.ToString() ?? "";

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete client:\n" +
                $"Id: {clientId}\n" +
                $"Full name: {fullName}\n" +
                $"Phone: {phone}\n" +
                $"This action cannot be undone.",
                "Confirm deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _clientRepository.DeleteClient(clientId);
                LoadClients();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    MessageBox.Show(
                        "Cannot delete this client because they have related memberships or bookings." +
                        "First delete or deactivate related data.",
                        "Delete client",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error while deleting client: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting client: " + ex.Message);
            }
        }
    }
}

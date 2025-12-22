using fitness_club.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace fitness_club.Forms
{
    public partial class TrainerManagementForm : Form
    {
        private readonly TrainerRepository _trainerRepository = new TrainerRepository();
        private readonly UserRepository _userRepository = new UserRepository();
        private DataTable _trainersTable;

        public TrainerManagementForm()
        {
            InitializeComponent();
        }

        private void TrainerManagementForm_Load(object sender, EventArgs e)
        {
            LoadTrainers();
        }

        private void LoadTrainers()
        {
            _trainersTable = _trainerRepository.GetAllTrainers();
            dgvTrainers.DataSource = _trainersTable;

            if (dgvTrainers.Columns.Contains("user_id"))
                dgvTrainers.Columns["user_id"].Visible = false;
            if (dgvTrainers.Columns.Contains("club_id"))
                dgvTrainers.Columns["club_id"].Visible = false;
            if (dgvTrainers.Columns.Contains("total_sessions"))
                dgvTrainers.Columns["total_sessions"].HeaderText = "Sessions";
            if (dgvTrainers.Columns.Contains("total_minutes"))
                dgvTrainers.Columns["total_minutes"].HeaderText = "Total minutes";

            dgvTrainers.ClearSelection();
        }

        private void btnAddTrainer_Click(object sender, EventArgs e)
        {
            using (var form = new TrainerEditForm())
            {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    LoadTrainers();
                }
            }
        }

        private void btnEditTrainer_Click(object sender, EventArgs e)
        {
            if (dgvTrainers.SelectedRows.Count == 0)
                return;

            var row = dgvTrainers.SelectedRows[0];

            int trainerId = Convert.ToInt32(row.Cells["trainer_id"].Value);
            int userId = Convert.ToInt32(row.Cells["user_id"].Value);

            string login = row.Cells["user_login"].Value?.ToString() ?? "";
            string fullName = row.Cells["trainer_name"].Value?.ToString() ?? "";
            string phone = row.Cells["trainer_phone"].Value?.ToString() ?? "";
            string email = row.Cells["trainer_email"].Value?.ToString() ?? "";
            string spec = row.Cells["trainer_specialization"].Value?.ToString() ?? "";
            string genderDb = row.Cells["trainer_gender"].Value?.ToString() ?? "other";
            string trainerStatusDb = row.Cells["trainer_status"].Value?.ToString() ?? "active";
            string userStatusDb = row.Cells["user_status"].Value?.ToString() ?? "active";
            int clubId = Convert.ToInt32(row.Cells["club_id"].Value);

            DateTime? hireDate = null;
            if (row.Cells["hire_date"].Value != DBNull.Value &&
                row.Cells["hire_date"].Value != null)
            {
                hireDate = Convert.ToDateTime(row.Cells["hire_date"].Value);
            }

            using (var form = new TrainerEditForm(trainerId, userId, login, fullName, phone, email,
                spec, genderDb, trainerStatusDb, userStatusDb, clubId, hireDate))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    LoadTrainers();
            }
        }

        private void btnDeleteTrainer_Click(object sender, EventArgs e)
        {
            if (dgvTrainers.SelectedRows.Count == 0)
                return;

            var row = dgvTrainers.SelectedRows[0];

            int trainerId = Convert.ToInt32(row.Cells["trainer_id"].Value);
            int userId = Convert.ToInt32(row.Cells["user_id"].Value);
            string name = row.Cells["trainer_name"].Value?.ToString() ?? "";

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete trainer:\n" +
                $"ID: {trainerId}\n" +
                $"Name: {name}\n" +
                $"This action cannot be undone.",
                "Delete trainer",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                _trainerRepository.DeleteTrainerWithUser(trainerId, userId);
                LoadTrainers();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    MessageBox.Show(
                        "Cannot delete this trainer because he/she has related sessions or bookings.\n" +
                        "Delete or reassign this data first.",
                        "Delete trainer",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error while deleting trainer: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting trainer: " + ex.Message);
            }
        }

        private void btnSessions_Click(object sender, EventArgs e)
        {
            if (dgvTrainers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a trainer first.");
                return;
            }

            var row = dgvTrainers.SelectedRows[0];

            int trainerId = Convert.ToInt32(row.Cells["trainer_id"].Value);
            int clubId = Convert.ToInt32(row.Cells["club_id"].Value);
            string trainerName = row.Cells["trainer_name"].Value?.ToString() ?? "";
            string clubName = row.Cells["club_name"].Value?.ToString() ?? "";

            using (var form = new TrainerSessionForm(trainerId, clubId, trainerName, clubName))
            {
                form.ShowDialog(this);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTrainers();
        }

        private void btnTrainerSearch_Click(object sender, EventArgs e)
        {
            string term = txtTrainerSearch.Text.Trim();

            if (string.IsNullOrEmpty(term))
            {
                ClearTrainerRowColors();
                return;
            }

            ClearTrainerRowColors();

            foreach (DataGridViewRow row in dgvTrainers.Rows)
            {
                if (row.IsNewRow) continue;

                string fullName = row.Cells["trainer_name"].Value?.ToString() ?? "";
                string phone = row.Cells["trainer_phone"].Value?.ToString() ?? "";
                string email = row.Cells["trainer_email"].Value?.ToString() ?? "";

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

        private void btnTrainerClearSearch_Click(object sender, EventArgs e)
        {
            txtTrainerSearch.Clear();
            ClearTrainerRowColors();
            dgvTrainers.ClearSelection();
        }

        private void ClearTrainerRowColors()
        {
            foreach (DataGridViewRow row in dgvTrainers.Rows)
            {
                if (row.IsNewRow) continue;
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }
    }
}

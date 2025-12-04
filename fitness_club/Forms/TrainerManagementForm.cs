using fitness_club.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace fitness_club.Forms
{
    public partial class TrainerManagementForm : Form
    {
        private readonly TrainerRepository _trainerRepository = new TrainerRepository();
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
            {
                MessageBox.Show("Please select a trainer to edit.",
                    "Edit trainer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvTrainers.SelectedRows[0];

            int trainerId = Convert.ToInt32(row.Cells["trainer_id"].Value);
            int userId = Convert.ToInt32(row.Cells["user_id"].Value);
            string userLogin = row.Cells["user_login"].Value?.ToString() ?? "";
            int clubId = Convert.ToInt32(row.Cells["club_id"].Value);
            string clubName = row.Cells["club_name"].Value?.ToString() ?? "";
            string name = row.Cells["trainer_name"].Value?.ToString() ?? "";
            string phone = row.Cells["trainer_phone"].Value?.ToString() ?? "";
            string email = row.Cells["trainer_email"].Value?.ToString() ?? "";
            string specialization = row.Cells["trainer_specialization"].Value?.ToString() ?? "";

            DateTime? hireDate = null;
            if (row.Cells["hire_date"].Value != DBNull.Value && row.Cells["hire_date"].Value != null)
            {
                hireDate = Convert.ToDateTime(row.Cells["hire_date"].Value);
            }

            string genderDb = row.Cells["trainer_gender"].Value?.ToString() ?? "other";
            string statusDb = row.Cells["trainer_status"].Value?.ToString() ?? "inactive";

            //using (var form = new TrainerEditForm(trainerId, userId, userLogin, clubId, clubName,
            //    name, phone, email, specialization, hireDate, genderDb, statusDb))
            //{
            //    var result = form.ShowDialog(this);
            //    if (result == DialogResult.OK)
            //    {
            //        LoadTrainers();
            //    }
            //}
        }

        private void btnDeleteTrainer_Click(object sender, EventArgs e)
        {
            if (dgvTrainers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a trainer to delete.",
                    "Delete trainer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvTrainers.SelectedRows[0];

            int trainerId = Convert.ToInt32(row.Cells["trainer_id"].Value);
            string name = row.Cells["trainer_name"].Value?.ToString() ?? "";
            string clubName = row.Cells["club_name"].Value?.ToString() ?? "";

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete trainer:\n" +
                $"Name: {name}\n" +
                $"Club: {clubName}\n" +
                $"This action cannot be undone.",
                "Confirm deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                _trainerRepository.DeleteTrainer(trainerId);
                LoadTrainers();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    MessageBox.Show("Cannot delete this trainer because there are related sessions.\n" +
                        "Delete or reassign these sessions first.",
                        "Delete trainer", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}

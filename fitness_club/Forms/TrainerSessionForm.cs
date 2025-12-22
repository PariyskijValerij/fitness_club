using fitness_club.Data;
using System;
using System.Data;
using System.Windows.Forms;

namespace fitness_club.Forms
{
    public partial class TrainerSessionForm : Form
    {
        private readonly SessionRepository _sessionRepository = new SessionRepository();
        private readonly int _trainerId;
        private readonly int _clubId;
        private readonly string _trainerName;
        private readonly string _clubName;

        private DataTable _sessionsTable;
        public TrainerSessionForm(int trainerId, int clubId, string trainerName, string clubName)
        {
            InitializeComponent();

            _trainerId = trainerId;
            _clubId = clubId;
            _trainerName = trainerName;
            _clubName = clubName;
        }

        private void TrainerSessionForm_Load(object sender, EventArgs e)
        {
            if (lblTitle != null)
            {
                lblTitle.Text = $"Sessions of trainer: {_trainerName} ({_clubName})";
            }

            dtpFrom.Checked = false;
            dtpTo.Checked = false;
            LoadSessions();
        }

        private void LoadSessions()
        {
            DateTime? dateFrom = dtpFrom.Checked ? dtpFrom.Value.Date : (DateTime?)null;
            DateTime? dateTo = dtpTo.Checked ? dtpTo.Value.Date : (DateTime?)null;

            _sessionsTable = _sessionRepository.GetSessionsByTrainer(_trainerId, dateFrom, dateTo);
            dgvSessions.DataSource = _sessionsTable;

            if (dgvSessions.Columns.Contains("occupancy_percent"))
                dgvSessions.Columns["occupancy_percent"].HeaderText = "Occupancy, %";

            dgvSessions.ClearSelection();
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            LoadSessions();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            dtpFrom.Checked = false;
            dtpTo.Checked = false;
            LoadSessions();
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            if (dgvSessions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a session first.");
                return;
            }

            var row = dgvSessions.SelectedRows[0];

            int sessionId = Convert.ToInt32(row.Cells["session_id"].Value);
            string sessionType = row.Cells["session_type"].Value?.ToString() ?? "";
            DateTime sessionDate = Convert.ToDateTime(row.Cells["session_date"].Value);
            string roomNumber = row.Cells["room_number"].Value?.ToString() ?? "";
            string trainerName = _trainerName;

            using (var form = new SessionBookingForm(sessionId, sessionType, sessionDate, roomNumber, trainerName))
            {
                form.ShowDialog(this);
            }
        }

        private void btnAddSession_Click(object sender, EventArgs e)
        {
            using (var form = new SessionEditForm(_trainerId, _clubId, _trainerName, _clubName))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    RefreshSessions();
                }
            }
        }

        private void btnEditSession_Click(object sender, EventArgs e)
        {
            if (dgvSessions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select session to edit.");
                return;
            }

            var row = dgvSessions.SelectedRows[0];

            int sessionId = Convert.ToInt32(row.Cells["session_id"].Value);
            int roomId = Convert.ToInt32(row.Cells["room_id"].Value);
            string type = row.Cells["session_type"].Value?.ToString() ?? "";
            DateTime date = Convert.ToDateTime(row.Cells["session_date"].Value);
            TimeSpan startTime = (TimeSpan)row.Cells["start_time"].Value;
            int duration = Convert.ToInt32(row.Cells["duration_min"].Value);
            string difficultyDb = row.Cells["difficulty_level"].Value?.ToString() ?? "easy";
            string statusDb = row.Cells["session_status"].Value?.ToString() ?? "planned";

            using (var form = new SessionEditForm(_trainerId, _clubId, _trainerName, _clubName,
                sessionId, roomId, type, date, startTime, duration, difficultyDb, statusDb))
            {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    LoadSessions();
                }
            }
        }

        private void btnDeleteSession_Click(object sender, EventArgs e)
        {
            if (dgvSessions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select session to delete.");
                return;
            }

            var row = dgvSessions.SelectedRows[0];

            int sessionId = Convert.ToInt32(row.Cells["session_id"].Value);
            string type = row.Cells["session_type"].Value?.ToString() ?? "";
            DateTime date = Convert.ToDateTime(row.Cells["session_date"].Value);

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete session:\n" +
                $"ID: {sessionId}\n" +
                $"\"{type}\" on {date:dd.MM.yyyy}?\n" +
                $"All related bookings will be lost.",
                "Delete session",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                _sessionRepository.DeleteSession(sessionId);
                LoadSessions();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting session: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSessions();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpTo.MinDate = dtpFrom.Value.Date;

            if (dtpTo.Value < dtpFrom.Value)
            {
                dtpTo.Value = dtpFrom.Value;
            }
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            dtpFrom.MaxDate = dtpTo.Value.Date;

            if (dtpFrom.Value > dtpTo.Value)
            {
                dtpFrom.Value = dtpTo.Value;
            }
        }

        private void RefreshSessions()
        {
            DateTime? from = dtpFrom.Checked ? dtpFrom.Value.Date : (DateTime?)null;
            DateTime? to = dtpTo.Checked ? dtpTo.Value.Date : (DateTime?)null;

            dgvSessions.DataSource = _sessionRepository.GetSessionsByTrainer(_trainerId, from, to);
            dgvSessions.ClearSelection();
        }
    }
}

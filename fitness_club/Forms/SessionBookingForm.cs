using fitness_club.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace fitness_club.Forms
{
    public partial class SessionBookingForm : Form
    {
        private readonly BookingRepository _bookingRepository = new BookingRepository();
        private readonly int _sessionId;
        private bool _sortAsc = true;
        private DataTable _bookingsTable;

        public SessionBookingForm(int sessionId, string sessionType, DateTime sessionDate, string roomNumber,
            string trainerName)
        {
            InitializeComponent();

            _sessionId = sessionId;

            lblTitle.Text = $"Bookings for session: {sessionType}";
            lblInfo.Text = $"Date: {sessionDate:dd.MM.yyyy}, Room: {roomNumber}, Trainer: {trainerName}";
        }

        private void SessionBookingForm_Load(object sender, EventArgs e)
        {
            LoadBookings();
        }

        private void LoadBookings()
        {
            _bookingsTable = _bookingRepository.GetBookingsBySession(_sessionId, _sortAsc);
            dgvBookings.DataSource = _bookingsTable;
            dgvBookings.ClearSelection();

            ApplyRowColors();
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count == 0)
                return;

            var row = dgvBookings.SelectedRows[0];

            if (row.Cells["booking_status"].Value.ToString() == "cancelled")
                return;

            int membershipId = Convert.ToInt32(row.Cells["membership_id"].Value);
            string clientName = row.Cells["client_full_name"].Value?.ToString() ?? "";
            string membershipName = row.Cells["membership_name"].Value?.ToString() ?? "";

            var confirm = MessageBox.Show(
                $"Cancel this booking?\n" +
                $"Client: {clientName}\n" +
                $"Membership: {membershipName}",
                "Cancel booking",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                _bookingRepository.UpdateBookingStatus(membershipId, _sessionId, "cancelled");
                LoadBookings();
                ApplyRowColors();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database error while cancelling booking: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while cancelling booking: " + ex.Message);
            }
        }

        private void btnActivateBooking_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count == 0)
                return;

            var row = dgvBookings.SelectedRows[0];

            if (row.Cells["booking_status"].Value.ToString() == "confirmed")
                return;

            int membershipId = Convert.ToInt32(row.Cells["membership_id"].Value);
            string clientName = row.Cells["client_full_name"].Value?.ToString() ?? "";
            string membershipName = row.Cells["membership_name"].Value?.ToString() ?? "";

            var confirm = MessageBox.Show(
                $"Active this booking?\n" +
                $"Client: {clientName}\n" +
                $"Membership: {membershipName}",
                "Active booking",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                _bookingRepository.UpdateBookingStatus(membershipId, _sessionId, "confirmed");
                LoadBookings();
                ApplyRowColors();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database error while activating booking: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while activating booking: " + ex.Message);
            }
        }

        private void btnSortByDate_Click(object sender, EventArgs e)
        {
            LoadBookings();
            _sortAsc = !_sortAsc;
            btnSortByDate.Text = _sortAsc ? "Sort by date ↓" : "Sort by date ↑";
        }

        private void ApplyRowColors()
        {
            foreach (DataGridViewRow row in dgvBookings.Rows)
            {
                if (row.IsNewRow) continue;

                string status = row.Cells["booking_status"].Value?.ToString() ?? "";

                if (status == "confirmed")
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                else if (status == "cancelled")
                    row.DefaultCellStyle.BackColor = Color.LightPink;
                else
                    row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void dgvBookings_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn col in dgvBookings.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            ApplyRowColors();  
        }
    }
}

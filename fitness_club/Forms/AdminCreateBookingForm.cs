using fitness_club.Data;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fitness_club.Forms
{
    public partial class AdminCreateBookingForm : Form
    {
        private readonly SessionRepository _sessionRepository = new SessionRepository();
        private readonly BookingRepository _bookingRepository = new BookingRepository();
        private readonly MembershipRepository _membershipRepository = new MembershipRepository();

        private readonly int _clientId;
        private readonly string _clientName;

        private class MembershipItem
        {
            public int Id { get; set; }
            public string DisplayText { get; set; }
            public override string ToString() => DisplayText;
        }

        public AdminCreateBookingForm(int clientId, string clientName)
        {
            InitializeComponent();
            _clientId = clientId;
            _clientName = clientName;
        }

        private void AdminCreateBookingForm_Load(object sender, EventArgs e)
        {
            lblClientInfo.Text = $"Booking for: {_clientName}";
            LoadActiveMemberships();
        }

        private void LoadActiveMemberships()
        {
            cbMemberships.Items.Clear();
            DataTable memberships = _membershipRepository.GetActiveMembershipsForClient(_clientId);

            if (memberships.Rows.Count == 0)
            {
                MessageBox.Show("Client has no active memberships.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            foreach (DataRow row in memberships.Rows)
            {
                int id = Convert.ToInt32(row["membership_id"]);
                string memName = row["membership_name"].ToString();
                string clubName = row["club_name"].ToString();
                DateTime end = Convert.ToDateTime(row["end_date"]);
                string display = $"{memName} ({clubName}) - till {end:dd.MM.yyyy}";

                cbMemberships.Items.Add(new MembershipItem { Id = id, DisplayText = display });
            }

            cbMemberships.SelectedIndex = 0;
        }

        private void LoadAvailableSessions()
        {
            if (cbMemberships.SelectedItem == null) return;

            MembershipItem selected = (MembershipItem)cbMemberships.SelectedItem;
            int membershipId = selected.Id;

            DataTable sessions = _sessionRepository.GetAvailableSessionsForMembership(membershipId);
            dgvAvailableSessions.DataSource = sessions;

            if (dgvAvailableSessions.Columns.Contains("session_id")) 
                dgvAvailableSessions.Columns["session_id"].Visible = false;
            if (dgvAvailableSessions.Columns.Contains("room_id")) 
                dgvAvailableSessions.Columns["room_id"].Visible = false;
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (dgvAvailableSessions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a session from the list.");
                return;
            }

            if (cbMemberships.SelectedItem == null) return;

            var selectedMem = (MembershipItem)cbMemberships.SelectedItem;
            var row = dgvAvailableSessions.SelectedRows[0];

            int sessionId = Convert.ToInt32(row.Cells["session_id"].Value);
            string sessionInfo = $"{row.Cells["session_type"].Value} at {row.Cells["start_time"].Value}";

            if (MessageBox.Show($"Book '{sessionInfo}' using '{selectedMem.DisplayText}'?",
                "Confirm Booking", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _bookingRepository.CreateBooking(selectedMem.Id, sessionId);
                    MessageBox.Show("Booking successful!");
                    LoadAvailableSessions();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void cbMemberships_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAvailableSessions();
        }
    }
}

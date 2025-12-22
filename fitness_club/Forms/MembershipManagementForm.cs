using fitness_club.Data;
using MySql.Data.MySqlClient;
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
    public partial class MembershipManagementForm : Form
    {
        private readonly MembershipRepository _membershipRepository = new MembershipRepository();
        private readonly MembershipTypeRepository _membershipTypeRepository = new MembershipTypeRepository();
        private readonly ClubRepository _clubRepository = new ClubRepository();

        private readonly int _clientId;
        private readonly string _clientName;

        private DataTable _membershipsTable;
        private MembershipFilter _currentFilter = new MembershipFilter();

        private readonly BookingRepository _bookingRepository = new BookingRepository();

        public MembershipManagementForm(int clientId, string clientName)
        {
            InitializeComponent();

            _clientId = clientId;
            _clientName = clientName;
        }

        private void MembershipManagementForm_Load(object sender, EventArgs e)
        {
            if (lblTitle != null)
            {
                lblTitle.Text = $"Memberships of client: {_clientName}";
            }

            LoadMemberships();
            dgvMemberships.ClearSelection();
        }

        private void LoadMemberships()
        {
            _membershipsTable = _membershipRepository.GetMembershipsByClientAndFilter(_clientId, _currentFilter); dgvMemberships.DataSource = _membershipsTable;
            dgvMemberships.DataSource = _membershipsTable;
            dgvMemberships.ClearSelection();
        }

        private void btnAddMembership_Click(object sender, EventArgs e)
        {
            using (var form = new MembershipEditForm(_clientId, _clientName))
            {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    LoadMemberships();
                }
            }
        }

        private void btnEditMembership_Click(object sender, EventArgs e)
        {
            if (dgvMemberships.SelectedRows.Count == 0)
                return;

            var row = dgvMemberships.SelectedRows[0];

            int membershipId = Convert.ToInt32(row.Cells["membership_id"].Value);
            int membershipTypeId = Convert.ToInt32(row.Cells["membership_type_id"].Value);
            int clubId = Convert.ToInt32(row.Cells["club_id"].Value);

            DateTime startDate = Convert.ToDateTime(row.Cells["start_date"].Value);
            DateTime? endDate = null;
            if (row.Cells["end_date"].Value != DBNull.Value && row.Cells["end_date"].Value != null)
            {
                endDate = Convert.ToDateTime(row.Cells["end_date"].Value);
            }

            string statusDb = row.Cells["membership_status"].Value?.ToString() ?? "active";

            using (var form = new MembershipEditForm(_clientId, _clientName, membershipId, membershipTypeId, clubId,
                startDate, endDate, statusDb))
            {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    LoadMemberships();
                }
            }
        }

        private void btnDeleteMembership_Click(object sender, EventArgs e)
        {
            if (dgvMemberships.SelectedRows.Count == 0)
                return;

            var row = dgvMemberships.SelectedRows[0];

            int membershipId = Convert.ToInt32(row.Cells["membership_id"].Value);
            string membershipName = row.Cells["membership_name"].Value?.ToString() ?? "";
            string clubName = row.Cells["club_name"].Value?.ToString() ?? "";

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete membership:\n" +
                $"ID: {membershipId}\n" +
                $"Type: {membershipName}\n" +
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
                _membershipRepository.DeleteMembership(membershipId);
                LoadMemberships();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    MessageBox.Show(
                        "Cannot delete this membership because it has related bookings.\n" +
                        "Delete or cancel bookings first.",
                        "Delete membership",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error while deleting membership: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting membership: " + ex.Message);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            using (var form = new MembershipFilterForm(_currentFilter))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    _currentFilter = form.Filter;
                    LoadMemberships();
                }
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            _currentFilter = new MembershipFilter();
            LoadMemberships();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (dgvMemberships.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a membership first.");
                return;
            }

            var row = dgvMemberships.SelectedRows[0];

            int membershipId = Convert.ToInt32(row.Cells["membership_id"].Value);

            DataRow dataRow = ((DataRowView)row.DataBoundItem).Row;

            DataTable history = _bookingRepository.GetBookingsByMembership(membershipId);

            string _clientMembershipName = row.Cells["membership_name"].Value?.ToString() ?? "";

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                sfd.FileName = $"MembershipReport_{_clientName}_{_clientMembershipName}_{DateTime.Now:yyyyMMdd_HHmm}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        PdfReportHelper.ExportMembershipReport(sfd.FileName, _clientName, dataRow, history);

                        MessageBox.Show("Report generated successfully!", "Success", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error generating report: " + ex.Message, 
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

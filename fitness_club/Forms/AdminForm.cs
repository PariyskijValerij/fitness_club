using fitness_club.Data;
using System;
using System.Windows.Forms;

namespace fitness_club.Forms
{
    public partial class AdminForm : Form
    {
        private readonly MembershipRepository _membershipRepository = new MembershipRepository();
        private readonly SessionRepository _sessionRepository = new SessionRepository();

        public AdminForm()
        {
            InitializeComponent();
        }
        private void AdminForm_Load(object sender, EventArgs e)
        {
            try
            {
                _membershipRepository.UpdateExpiredMemberships();
                _sessionRepository.UpdatePastSessionsStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating statuses: " + ex.Message);
            }
        }

        private void btnOpenClients_Click(object sender, EventArgs e)
        {
            using (var clientForm = new ClientManagementForm())
            {
                clientForm.ShowDialog();
            }
        }

        private void btnManageClubs_Click(object sender, EventArgs e)
        {
            using (var clubForm = new ClubManagementForm())
            {
                clubForm.ShowDialog();
            }
        }

        private void btnManageMembershipTypes_Click(object sender, EventArgs e)
        {
            using (var form = new MembershipTypeManagementForm())
            {
                form.ShowDialog();
            }
        }

        private void btnManageTrainers_Click(object sender, EventArgs e)
        {
            using (var form = new TrainerManagementForm())
            {
                form.ShowDialog();
            }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            using (var form = new StatisticsForm())
            {
                form.ShowDialog(this);
            }
        }
    }
}

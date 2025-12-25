using fitness_club.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace fitness_club.Forms
{
    public partial class AdminForm : Form
    {
        private readonly MembershipRepository _membershipRepository = new MembershipRepository();
        private readonly SessionRepository _sessionRepository = new SessionRepository();
        private readonly StatisticsRepository _statisticsRepository = new StatisticsRepository();

        public AdminForm()
        {
            InitializeComponent();
        }
        private void AdminForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Автоматичне переведення протермінованих абонементів у статус 'Expired'
                _membershipRepository.UpdateExpiredMemberships();

                // Автоматичне закриття минулих занять (статус 'Completed')
                _sessionRepository.UpdatePastSessionsStatus();

                // Завантаження оперативної статистики на Дашборд
                LoadDashboardStats();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating statuses: " + ex.Message);
            }
        }

        private void LoadDashboardStats()
        {
            var popType = _statisticsRepository.GetMostPopularMembershipType();
            if (popType.Rows.Count > 0)
            {
                string count = popType.Rows[0]["active_count"].ToString();

                List<string> memNames = new List<string>();

                foreach (DataRow row in popType.Rows)
                {
                    memNames.Add(row["membership_name"].ToString());
                }

                string distinctNames = string.Join(", ", memNames);

                lblPopularMembership.Text =
                    $"Most popular membership: {distinctNames} ({count} active memberships)";
            }
            else
            {
                lblPopularMembership.Text = "Most popular membership: no data.";
            }

            var popClub = _statisticsRepository.GetMostPopularClub();
            if (popClub.Rows.Count > 0)
            {
                string count = popClub.Rows[0]["active_memberships"].ToString();

                List<string> clubNames = new List<string>();

                foreach (DataRow row in popClub.Rows)
                {
                    clubNames.Add(row["club_name"].ToString());
                }

                string distinctNames = string.Join(", ", clubNames);

                lblPopularClub.Text =
                    $"Club with most memberships: {distinctNames} ({count} active memberships)";
            }
            else
            {
                lblPopularClub.Text = "Club with most memberships: no data.";
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

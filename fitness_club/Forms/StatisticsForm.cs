using fitness_club.Data;
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
    public partial class StatisticsForm : Form
    {
        private readonly StatisticsRepository _statisticsRepository = new StatisticsRepository();
        public StatisticsForm()
        {
            InitializeComponent();
        }

        private void LoadTable(DataTable table, string title)
        {
            dgvStatistics.DataSource = table;
            dgvStatistics.ClearSelection();
            lblTitle.Text = title;
        }

        private void btnClientsPerClub_Click(object sender, EventArgs e)
        {
            var table = _statisticsRepository.GetActiveClientsPerClub();
            LoadTable(table, "Active clients per club");
        }
        private void btnRevenue_Click(object sender, EventArgs e)
        {
            var table = _statisticsRepository.GetRevenueByMembershipType();
            LoadTable(table, "Membership statuses per club");
        }

        private void btnTrainerWorkload_Click(object sender, EventArgs e)
        {
            var from = dtpFrom.Value.Date;
            var to = dtpTo.Value.Date;

            var table = _statisticsRepository.GetTrainerWorkloadReport(from, to);
            string title = $"Trainer Workload ({from:dd.MM.yyyy} - {to:dd.MM.yyyy})";
            LoadTable(table, title);
        }

        private void bttnSessionOccupancy_Click(object sender, EventArgs e)
        {
            var table = _statisticsRepository.GetSessionOccupancy();
            LoadTable(table, "Session occupancy");
        }

        private void btnActiveMembershipsPdf_Click(object sender, EventArgs e)
        {
            var table = _statisticsRepository.GetActiveMembershipsReport();

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF files (*.pdf)|*.pdf";
                sfd.FileName = "ActiveMemberships_" +
                               DateTime.Now.ToString("yyyyMMdd_HHmm") + ".pdf";

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    PdfReportHelper.ExportDataTableToPdf(
                        table,
                        "Active Club Memberships",
                        sfd.FileName
                    );
                    MessageBox.Show("Report saved successfully.",
                        "PDF Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnTrainerWorkloadPdf_Click(object sender, EventArgs e)
        {
            var from = dtpFrom.Value.Date;
            var to = dtpTo.Value.Date;

            var table = _statisticsRepository.GetTrainerWorkloadReport(from, to);

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF files (*.pdf)|*.pdf";
                sfd.FileName = "TrainerWorkload_" +
                               DateTime.Now.ToString("yyyyMMdd_HHmm") + ".pdf";

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    string title = $"TrainerWorkload_" +
                                   $"({from:dd.MM.yyyy} – {to:dd.MM.yyyy})";

                    PdfReportHelper.ExportDataTableToPdf(
                        table,
                        title,
                        sfd.FileName
                    );

                    MessageBox.Show("Report saved successfully.",
                        "PDF Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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
            dtpTo.MaxDate = DateTime.Today;

            if (dtpFrom.Value > dtpTo.Value)
            {
                dtpFrom.Value = dtpTo.Value;
            }
        }
    }
}

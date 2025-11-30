using System;
using System.Windows.Forms;

namespace fitness_club.Forms
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void btnOpenClients_Click(object sender, EventArgs e)
        {
            using (var clientForm = new ClientManagementForm())
            {
                clientForm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var clubForm = new ClubManagementForm())
            {
                clubForm.ShowDialog();
            }
        }
    }
}

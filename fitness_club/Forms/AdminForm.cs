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
    }
}

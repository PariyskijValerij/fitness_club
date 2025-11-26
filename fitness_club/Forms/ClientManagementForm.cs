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
    public partial class ClientManagementForm : Form
    {
        private readonly ClientRepository _clientRepository = new ClientRepository();
        public ClientManagementForm()
        {
            InitializeComponent();
        }

        private void ClientManagementForm_Load(object sender, EventArgs e)
        {
            LoadClients();
        }

        private void LoadClients()
        {
            var clientsTable = _clientRepository.GetAllClients();
            dgvClients.DataSource = clientsTable;
        }
    }
}

using System;
using System.Windows.Forms;

namespace fitness_club.Forms
{
    public partial class ClientFilterForm : Form
    {
        public bool FilterMale { get; set; }
        public bool FilterFemale { get; set; }
        public bool FilterOther { get; set; }

        public bool FilterActive { get; set; }
        public bool FilterInactive { get; set; }

        public DateTime? RegDateFrom { get; set; }
        public DateTime? RegDateTo { get; set; }

        public ClientFilterForm()
        {
            InitializeComponent();
        }
        private void ClientFilterForm_Load(object sender, EventArgs e)
        {
            chkMale.Checked = FilterMale;
            chkFemale.Checked = FilterFemale;
            chkOther.Checked = FilterOther;
            chkActive.Checked = FilterActive;
            chkInactive.Checked = FilterInactive;

            if (RegDateFrom.HasValue)
            {
                dtpRegFrom.Value = RegDateFrom.Value;
                dtpRegFrom.Checked = true;
            }
            else
            {
                dtpRegFrom.Checked = false;
            }

            if (RegDateTo.HasValue)
            {
                dtpRegTo.Value = RegDateTo.Value;
                dtpRegTo.Checked = true;
            }
            else
            {
                dtpRegTo.Checked = false;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            FilterMale = chkMale.Checked;
            FilterFemale = chkFemale.Checked;
            FilterOther = chkOther.Checked;
            FilterActive = chkActive.Checked;
            FilterInactive = chkInactive.Checked;

            if (dtpRegFrom.Checked)
                RegDateFrom = dtpRegFrom.Value;
            else
                RegDateFrom = null;

            if (dtpRegTo.Checked)
                RegDateTo = dtpRegTo.Value;
            else
                RegDateTo = null;


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dtpRegFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpRegTo.MinDate = dtpRegFrom.Value.Date;

            if (dtpRegTo.Value < dtpRegFrom.Value)
            {
                dtpRegTo.Value = dtpRegFrom.Value;
            }
        }

        private void dtpRegTo_ValueChanged(object sender, EventArgs e)
        {
            dtpRegFrom.MaxDate = dtpRegTo.Value.Date;

            if (dtpRegFrom.Value > dtpRegTo.Value)
            {
                dtpRegFrom.Value = dtpRegTo.Value;
            }
        }
    }
}

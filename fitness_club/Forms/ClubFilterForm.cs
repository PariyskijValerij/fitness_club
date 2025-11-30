using System;
using System.Windows.Forms;

namespace fitness_club.Forms
{
    public partial class ClubFilterForm : Form
    {
        public bool FilterActive { get; set; }
        public bool FilterInactive { get; set; }
        public bool FilterKharkiv { get; set; }
        public bool FilterKyiv { get; set; }

        public ClubFilterForm()
        {
            InitializeComponent();
        }

        private void ClubFilterForm_Load(object sender, EventArgs e)
        {
            chkActive.Checked = FilterActive;
            chkInactive.Checked = FilterInactive;
            chkKharkiv.Checked = FilterKharkiv;
            chkKiev.Checked = FilterKyiv;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            FilterActive = chkActive.Checked;
            FilterInactive = chkInactive.Checked;
            FilterKharkiv = chkKharkiv.Checked;
            FilterKyiv = chkKiev.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

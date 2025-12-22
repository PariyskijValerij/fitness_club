using fitness_club.Data;
using System;
using System.Windows.Forms;

namespace fitness_club.Forms
{
    public partial class MembershipFilterForm : Form
    {
        public MembershipFilter Filter { get; set; }

        public MembershipFilterForm(MembershipFilter currentFilter)
        {
            InitializeComponent();
            Filter = currentFilter ?? new MembershipFilter();

            DateTime minDate = new DateTime(2020, 1, 1);
            DateTime maxDate = DateTime.Today.AddYears(10);

            ConfigurePicker(dtpStartFrom, minDate, maxDate);
            ConfigurePicker(dtpStartTo, minDate, maxDate);
            ConfigurePicker(dtpEndFrom, minDate, maxDate);
            ConfigurePicker(dtpEndTo, minDate, maxDate);
        }

        private void MembershipFilterForm_Load(object sender, EventArgs e)
        {
            chkActive.Checked = Filter.FilterActive;
            chkPaused.Checked = Filter.FilterPaused;
            chkExpired.Checked = Filter.FilterExpired;

            SetDate(dtpStartFrom, Filter.StartDateFrom);
            SetDate(dtpStartTo, Filter.StartDateTo);
            SetDate(dtpEndFrom, Filter.EndDateFrom);
            SetDate(dtpEndTo, Filter.EndDateTo);
        }

        private void SetDate(DateTimePicker dtp, DateTime? date)
        {
            if (date.HasValue)
            {
                dtp.Value = date.Value;
                dtp.Checked = true;
            }
            else
            {
                dtp.Checked = false;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Filter.FilterActive = chkActive.Checked;
            Filter.FilterPaused = chkPaused.Checked;
            Filter.FilterExpired = chkExpired.Checked;

            Filter.StartDateFrom = dtpStartFrom.Checked ? dtpStartFrom.Value.Date : (DateTime?)null;
            Filter.StartDateTo = dtpStartTo.Checked ? dtpStartTo.Value.Date : (DateTime?)null;
            Filter.EndDateFrom = dtpEndFrom.Checked ? dtpEndFrom.Value.Date : (DateTime?)null;
            Filter.EndDateTo = dtpEndTo.Checked ? dtpEndTo.Value.Date : (DateTime?)null;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void dtpStartFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpStartTo.MinDate = dtpStartFrom.Value;

            if (dtpStartTo.Value < dtpStartFrom.Value) 
                dtpStartTo.Value = dtpStartFrom.Value;
        }

        private void dtpStartTo_ValueChanged(object sender, EventArgs e)
        {
            dtpStartFrom.MaxDate = dtpStartTo.Value;

            if (dtpStartFrom.Value > dtpStartTo.Value) 
                dtpStartFrom.Value = dtpStartTo.Value;
        }

        private void dtpEndFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpEndTo.MinDate = dtpEndFrom.Value;

            if (dtpEndTo.Value < dtpEndFrom.Value) 
                dtpEndTo.Value = dtpEndFrom.Value;
        }

        private void dtpEndTo_ValueChanged(object sender, EventArgs e)
        {
            dtpEndFrom.MaxDate = dtpEndTo.Value;

            if (dtpEndFrom.Value > dtpEndTo.Value) 
                dtpEndFrom.Value = dtpEndTo.Value;
        }

        private void ConfigurePicker(DateTimePicker dtp, DateTime min, DateTime max)
        {
            dtp.MinDate = min;
            dtp.MaxDate = max;
            if (dtp.Value < min) 
                dtp.Value = min;
            if (dtp.Value > max) 
                dtp.Value = max;
        }
    }
}

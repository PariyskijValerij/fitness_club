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
    public partial class MembershipTypeFilterForm : Form
    {
        public MembershipTypeFilter Filter { get; set; }

        public MembershipTypeFilterForm(MembershipTypeFilter currentFilter)
        {
            InitializeComponent();
            Filter = currentFilter ?? new MembershipTypeFilter();
        }

        private void MembershipTypeFilterForm_Load(object sender, EventArgs e)
        {
            chkActive.Checked = Filter.FilterActive;
            chkInactive.Checked = Filter.FilterInactive;
            chkFreezeAllowed.Checked = Filter.FreezeAllowed;

            if (Filter.PriceFrom.HasValue || Filter.PriceTo.HasValue)
            {
                chkEnablePrice.Checked = true;
                if (Filter.PriceFrom.HasValue) nudPriceFrom.Value = Filter.PriceFrom.Value;
                if (Filter.PriceTo.HasValue) nudPriceTo.Value = Filter.PriceTo.Value;
            }
            else
            {
                chkEnablePrice.Checked = false;
            }

            if (Filter.DurationFrom.HasValue || Filter.DurationTo.HasValue)
            {
                chkEnableDuration.Checked = true;
                if (Filter.DurationFrom.HasValue) nudDurationFrom.Value = Filter.DurationFrom.Value;
                if (Filter.DurationTo.HasValue) nudDurationTo.Value = Filter.DurationTo.Value;
            }
            else
            {
                chkEnableDuration.Checked = false;
            }

            UpdateControlsState();
        }

        private void UpdateControlsState()
        {
            nudPriceFrom.Enabled = chkEnablePrice.Checked;
            nudPriceTo.Enabled = chkEnablePrice.Checked;

            nudDurationFrom.Enabled = chkEnableDuration.Checked;
            nudDurationTo.Enabled = chkEnableDuration.Checked;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Filter.FilterActive = chkActive.Checked;
            Filter.FilterInactive = chkInactive.Checked;
            Filter.FreezeAllowed = chkFreezeAllowed.Checked;

            if (chkEnablePrice.Checked)
            {
                Filter.PriceFrom = nudPriceFrom.Value > 0 ? nudPriceFrom.Value : (decimal?)null;
                Filter.PriceTo = nudPriceTo.Value > 0 ? nudPriceTo.Value : (decimal?)null;
            }
            else
            {
                Filter.PriceFrom = null;
                Filter.PriceTo = null;
            }

            if (chkEnableDuration.Checked)
            {
                Filter.DurationFrom = nudDurationFrom.Value > 0 ? (int)nudDurationFrom.Value : (int?)null;
                Filter.DurationTo = nudDurationTo.Value > 0 ? (int)nudDurationTo.Value : (int?)null;
            }
            else
            {
                Filter.DurationFrom = null;
                Filter.DurationTo = null;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void nudPriceFrom_ValueChanged(object sender, EventArgs e)
        {
            if (nudPriceTo.Value > 0 && nudPriceTo.Value < nudPriceFrom.Value)
            {
                nudPriceTo.Value = nudPriceFrom.Value;
            }
        }

        private void nudPriceTo_ValueChanged(object sender, EventArgs e)
        {
            if (nudPriceTo.Value > 0 && nudPriceFrom.Value > nudPriceTo.Value)
            {
                nudPriceFrom.Value = nudPriceTo.Value;
            }
        }

        private void nudDurationFrom_ValueChanged(object sender, EventArgs e)
        {
            if (nudDurationTo.Value > 0 && nudDurationTo.Value < nudDurationFrom.Value)
            {
                nudDurationTo.Value = nudDurationFrom.Value;
            }
        }

        private void nudDurationTo_ValueChanged(object sender, EventArgs e)
        {
            if (nudDurationTo.Value > 0 && nudDurationFrom.Value > nudDurationTo.Value)
            {
                nudDurationFrom.Value = nudDurationTo.Value;
            }
        }

        private void chkEnablePrice_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControlsState();
        }

        private void chkEnableDuration_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControlsState();
        }
    }
}

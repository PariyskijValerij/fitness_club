using fitness_club.Data;
using System;
using System.Data;
using System.Windows.Forms;

namespace fitness_club.Forms
{
    public partial class MembershipEditForm : Form
    {
        private readonly MembershipRepository _membershipRepository = new MembershipRepository();
        private readonly MembershipTypeRepository _membershipTypeRepository = new MembershipTypeRepository();
        private readonly ClubRepository _clubRepository = new ClubRepository();

        private readonly int _clientId;
        private readonly string _clientName;

        private readonly int? _membershipId;

        private class ComboItem
        {
            public int Id { get; }
            public string Name { get; }
            public ComboItem(int id, string name) { Id = id; Name = name; }
            public override string ToString() => Name;
        }

        public MembershipEditForm(int clientId, string clientName)
        {
            InitializeComponent();

            _clientId = clientId;
            _clientName = clientName;
            _membershipId = null;

            InitCombos();
            LoadMembershipTypes();
            LoadClubs();

            lblTitle.Text = $"New membership for {_clientName}";
            lblEndDateValue.Text = "- (will be calculated)";
        }

        public MembershipEditForm(int clientId, string clientName, int membershipId, int membershipTypeId, int clubId,
            DateTime startDate, DateTime? endDate, string statusDb)
            : this(clientId, clientName)
        {
            _membershipId = membershipId;

            foreach (ComboItem item in cbMembershipType.Items)
            {
                if (item.Id == membershipTypeId)
                {
                    cbMembershipType.SelectedItem = item;
                    break;
                }
            }

            foreach (ComboItem item in cbClub.Items)
            {
                if (item.Id == clubId)
                {
                    cbClub.SelectedItem = item;
                    break;
                }
            }

            dtpStartDate.Value = startDate;

            if (endDate.HasValue)
                lblEndDateValue.Text = endDate.Value.ToString("dd.MM.yyyy");
            else
                lblEndDateValue.Text = "-";

            switch (statusDb)
            {
                case "paused": cbStatus.SelectedItem = "Paused"; break;
                case "expired": cbStatus.SelectedItem = "Expired"; break;
                default: cbStatus.SelectedItem = "Active"; break;
            }

            lblTitle.Text = $"Edit membership of {_clientName}";
        }

        private void InitCombos()
        {
            cbStatus.Items.Clear();
            cbStatus.Items.Add("Active");
            cbStatus.Items.Add("Paused");
            cbStatus.Items.Add("Expired");
            cbStatus.SelectedIndex = 0;
        }

        private void LoadMembershipTypes()
        {
            var types = _membershipTypeRepository.GetAllMembershipTypes();
            cbMembershipType.Items.Clear();

            foreach (DataRow row in types.Rows)
            {
                int id = Convert.ToInt32(row["membership_type_id"]);
                string name = row["membership_name"].ToString();
                cbMembershipType.Items.Add(new ComboItem(id, name));
            }

            if (cbMembershipType.Items.Count > 0)
                cbMembershipType.SelectedIndex = 0;
        }

        private void LoadClubs()
        {
            var clubs = _clubRepository.GetAllClubs();
            cbClub.Items.Clear();

            foreach (DataRow row in clubs.Rows)
            {
                int id = Convert.ToInt32(row["club_id"]);
                string name = row["club_name"].ToString();
                cbClub.Items.Add(new ComboItem(id, name));
            }

            if (cbClub.Items.Count > 0)
                cbClub.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbMembershipType.SelectedItem == null)
            {
                MessageBox.Show("Select membership type.");
                return;
            }

            if (cbClub.SelectedItem == null)
            {
                MessageBox.Show("Select club.");
                return;
            }

            var typeItem = (ComboItem)cbMembershipType.SelectedItem;
            var clubItem = (ComboItem)cbClub.SelectedItem;

            int membershipTypeId = typeItem.Id;
            int clubId = clubItem.Id;
            DateTime startDate = dtpStartDate.Value.Date;

            string statusDb;
            switch (cbStatus.SelectedItem.ToString())
            {
                case "Paused": statusDb = "paused"; break;
                case "Expired": statusDb = "expired"; break;
                default: statusDb = "active"; break;
            }

            if (statusDb == "active")
            {
                bool hasActive = _membershipRepository.HasActiveMembershipInClub(_clientId, clubId, _membershipId);

                if (hasActive)
                {
                    MessageBox.Show(
                        "Client already has an active membership in this club.\n" +
                        "Please deactivate the old one first or wait until it expires.",
                        "Membership Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                if (_membershipId == null)
                {
                    _membershipRepository.CreateMembership(
                        _clientId, membershipTypeId, clubId, startDate, statusDb);
                }
                else
                {
                    _membershipRepository.UpdateMembership(
                        _membershipId.Value, membershipTypeId, clubId, startDate, statusDb);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving membership: " + ex.Message);
            }

            _membershipRepository.UpdateExpiredMemberships();
        }
    }
}

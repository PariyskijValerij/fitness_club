using fitness_club.Data;
using System;
using System.Windows.Forms;

namespace fitness_club.Forms
{
    public partial class RoomEditForm : Form
    {
        private readonly RoomRepository _roomRepository = new RoomRepository();
        private readonly int _clubId;
        private readonly string _clubName;
        private readonly int? _roomId;

        public RoomEditForm(int clubId, string clubName)
        {
            InitializeComponent();

            _clubId = clubId;
            _clubName = clubName;
            _roomId = null;

            InitStatusCombo();
            InitTitle();
        }

        public RoomEditForm(int clubId, string clubName, int roomId, string roomNumber, int? floor, decimal? area, int capacity,
            string equipment, string statusDb)
            : this(clubId, clubName)
        {
            _roomId = roomId;

            txtRoomNumber.Text = roomNumber;
            nudFloor.Value = floor.Value;
            nudArea.Value = area.Value;
            nudCapacity.Value = capacity;
            txtEquipment.Text = equipment ?? "";

            switch (statusDb)
            {
                case "active":
                    cbStatus.SelectedItem = "Active";
                    break;
                case "inactive":
                    cbStatus.SelectedItem = "Inactive";
                    break;
                default:
                    cbStatus.SelectedItem = "Active";
                    break;
            }
        }

        private void InitStatusCombo()
        {
            cbStatus.Items.Clear();
            cbStatus.Items.Add("Active");
            cbStatus.Items.Add("Inactive");
            cbStatus.SelectedIndex = 0;
        }

        private void InitTitle()
        {
            if (lblClub != null)
            {
                lblClub.Text = $"Club: {_clubName}";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string roomNumber = txtRoomNumber.Text.Trim();
            if (string.IsNullOrEmpty(roomNumber))
            {
                MessageBox.Show("Room number is required.");
                return;
            }

            int capacity = (int)nudCapacity.Value;

            int? floor = null;
            if (nudFloor.Value != 0)
                floor = (int)nudFloor.Value;

            decimal? area = null;
            if (nudArea.Value > 0)
                area = nudArea.Value;

            string equipment = txtEquipment.Text.Trim();
            string statusDb = cbStatus.SelectedItem?.ToString() == "Inactive" ? "inactive" : "active";

            try
            {
                if (_roomId == null)
                {
                    _roomRepository.CreateRoom(_clubId, roomNumber, floor, area, capacity, equipment, statusDb);
                }
                else
                {
                    _roomRepository.UpdateRoom(_roomId.Value, roomNumber, floor, area, capacity, equipment, statusDb);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving room" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

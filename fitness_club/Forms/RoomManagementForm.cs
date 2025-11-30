using fitness_club.Data;
using MySql.Data.MySqlClient;
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
    public partial class RoomManagementForm : Form
    {
        private readonly RoomRepository _roomRepository = new RoomRepository();
        private readonly int _clubId;
        private readonly string _clubName;
        private DataTable _roomsTable;

        public RoomManagementForm(int clubId, string clubName)
        {
            InitializeComponent();

            _clubId = clubId;
            _clubName = clubName;
        }

        private void RoomManagementForm_Load(object sender, EventArgs e)
        {
            if(lblTitle != null)
            {
                lblTitle.Text = $"Rooms of club: {_clubName}";
            }

            LoadRooms();
        }

        private void LoadRooms()
        {
            _roomsTable = _roomRepository.GetRoomsByClub(_clubId);
            dgvRooms.DataSource = _roomsTable;
            dgvRooms.ClearSelection();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            using (var form = new RoomEditForm(_clubId, _clubName))
            {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    LoadRooms();
                }
            }
        }

        private void btnEditRoom_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count == 0)
            {
                return;
            }

            var row = dgvRooms.SelectedRows[0];

            int roomId = Convert.ToInt32(row.Cells["room_id"].Value);
            string roomNumber = row.Cells["room_number"].Value?.ToString() ?? "";
            int? floor = null;
            if (row.Cells["room_floor"].Value != DBNull.Value && row.Cells["room_floor"].Value != null)
            {
                floor = Convert.ToInt32(row.Cells["room_floor"].Value);
            }
            decimal? area = null;
            if (row.Cells["area"].Value != DBNull.Value && row.Cells["area"].Value != null)
            {
                area = Convert.ToDecimal(row.Cells["area"].Value);
            }
            int capacity = Convert.ToInt32(row.Cells["capacity"].Value);
            string equipment = row.Cells["equipment_description"].Value?.ToString() ?? "";
            string statusDb = row.Cells["room_status"].Value?.ToString() ?? "active";

            using (var form = new RoomEditForm(_clubId, _clubName, roomId, roomNumber, floor, area, capacity, equipment, statusDb))
            {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    LoadRooms();
                }
            }
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room to delete.",
                    "Delete room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvRooms.SelectedRows[0];

            int roomId = Convert.ToInt32(row.Cells["room_id"].Value);
            string roomNumber = row.Cells["room_number"].Value?.ToString() ?? "";
            int? floor = null;
            if (row.Cells["room_floor"].Value != DBNull.Value && row.Cells["room_floor"].Value != null)
            {
                floor = Convert.ToInt32(row.Cells["room_floor"].Value);
            }

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete room:\n" +
                $"Number: {roomNumber}\n" +
                (floor.HasValue ? $"Floor: {floor}\n" : "") +
                $"This action cannot be undone.",
                "Confirm deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                _roomRepository.DeleteRoom(roomId);
                LoadRooms();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    MessageBox.Show(
                        "Cannot delete this room because it has related sessions.\n" +
                        "Delete or reassign these sessions first.",
                        "Delete room", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error while deleting room: " + ex.Message,
                        "Delete room", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting room: " + ex.Message,
                    "Delete room", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

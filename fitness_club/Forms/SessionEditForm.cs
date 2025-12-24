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
    public partial class SessionEditForm : Form
    {
        private readonly SessionRepository _sessionRepository = new SessionRepository();
        private readonly RoomRepository _roomRepository = new RoomRepository();

        private readonly int _trainerId;
        private readonly int _clubId;
        private readonly string _trainerName;
        private readonly string _clubName;

        private int? _sessionId;
        private class RoomItem
        {
            public int Id { get; }
            public string Name { get; }

            public RoomItem(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString() => Name;
        }

        public SessionEditForm(int trainerId, int clubId, string trainerName, string clubName)
        {
            InitializeComponent();

            _trainerId = trainerId;
            _clubId = clubId;
            _trainerName = trainerName;
            _clubName = clubName;
            _sessionId = null;

            InitCombos();
            LoadRooms();

            if (lblTitle != null)
                lblTitle.Text = $"Add session for {_trainerName} ({_clubName})";

            dtpDate.Value = DateTime.Today;
            dtpStartTime.Value = DateTime.Today.AddHours(10); 
            numDuration.Value = 60;
        }

        public SessionEditForm(int trainerId, int clubId, string trainerName, string clubName, int sessionId, 
            int roomId, string type, DateTime date, TimeSpan startTime, int durationMin, string difficultyDb, string statusDb)
            : this(trainerId, clubId, trainerName, clubName)
        {
            _sessionId = sessionId;

            if (lblTitle != null)
                lblTitle.Text = $"Edit session for {_trainerName} ({_clubName})";

            txtType.Text = type;
            dtpDate.Value = date.Date;
            dtpStartTime.Value = DateTime.Today.Date + startTime;
            numDuration.Value = durationMin;

            foreach (RoomItem item in cbRoom.Items)
            {
                if (item.Id == roomId)
                {
                    cbRoom.SelectedItem = item;
                    break;
                }
            }

            switch (difficultyDb)
            {
                case "easy":
                    cbDifficulty.SelectedItem = "Easy";
                    break;
                case "medium":
                    cbDifficulty.SelectedItem = "Medium";
                    break;
                case "high":
                    cbDifficulty.SelectedItem = "High";
                    break;
                default:
                    cbDifficulty.SelectedItem = "Easy";
                    break;
            }

            switch (statusDb)
            {
                case "planned":
                    cbStatus.SelectedItem = "Planned";
                    break;
                case "completed":
                    cbStatus.SelectedItem = "Completed";
                    break;
                case "cancelled":
                    cbStatus.SelectedItem = "Cancelled";
                    break;
                default:
                    cbStatus.SelectedItem = "Planned";
                    break;
            }
        }

        private void InitCombos()
        {
            cbDifficulty.Items.Clear();
            cbDifficulty.Items.Add("Easy");
            cbDifficulty.Items.Add("Medium");
            cbDifficulty.Items.Add("High");
            cbDifficulty.SelectedIndex = 0;

            cbStatus.Items.Clear();
            cbStatus.Items.Add("Planned");
            cbStatus.Items.Add("Completed");
            cbStatus.Items.Add("Cancelled");
            cbStatus.SelectedIndex = 0;
        }

        private void LoadRooms()
        {
            var roomsTable = _roomRepository.GetRoomsByClub(_clubId);

            cbRoom.Items.Clear();

            foreach (DataRow row in roomsTable.Rows)
            {
                int id = Convert.ToInt32(row["room_id"]);
                string number = row["room_number"].ToString();
                int capacity = Convert.ToInt32(row["capacity"]);

                cbRoom.Items.Add(new RoomItem(id, $"{number} (cap: {capacity})"));
            }

            if (cbRoom.Items.Count > 0)
                cbRoom.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string type = txtType.Text.Trim();
            if (string.IsNullOrEmpty(type))
            {
                MessageBox.Show("Session name is required.");
                return;
            }

            if (cbRoom.SelectedItem == null)
            {
                MessageBox.Show("Select room.");
                return;
            }

            if (cbDifficulty.SelectedItem == null || cbStatus.SelectedItem == null)
            {
                MessageBox.Show("Select difficulty and status.");
                return;
            }

            if (numDuration.Value <= 0)
            {
                MessageBox.Show("Duration must be greater than zero.");
                return;
            }

            var roomItem = (RoomItem)cbRoom.SelectedItem;
            int roomId = roomItem.Id;

            DateTime date = dtpDate.Value.Date;
            TimeSpan startTime = dtpStartTime.Value.TimeOfDay;
            int duration = (int)numDuration.Value;

            bool isOccupied = _sessionRepository.IsSessionConflict(_trainerId, roomId, date, startTime, duration, _sessionId);

            if (isOccupied)
            {
                MessageBox.Show(
                    $"The room or trainer is already booked for this time interval.\nDate: {date:d}\nTime: {startTime}",
                    "Schedule Conflict",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return; 
            }

            string difficultyDb = cbDifficulty.SelectedItem.ToString() == "Easy" ? "easy" :
                cbDifficulty.SelectedItem.ToString() == "Medium" ? "medium" : "high";

            string statusDb;
            switch (cbStatus.SelectedItem.ToString())
            {
                case "Completed":
                    statusDb = "completed";
                    break;
                case "Cancelled":
                    statusDb = "cancelled";
                    break;
                default:
                    statusDb = "planned";
                    break;
            }

            try
            {
                if (_sessionId == null)
                {
                    _sessionRepository.CreateSession(_trainerId, roomId, type, date, startTime, duration, 
                        difficultyDb, statusDb);
                }
                else
                {
                    _sessionRepository.UpdateSession(_sessionId.Value, roomId, type, date, startTime, duration, 
                        difficultyDb, statusDb);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message,
                    "Session", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving session: " + ex.Message,
                    "Session", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace fitness_club.Data
{
    public class RoomRepository
    {
        public DataTable GetRoomsByClub(int clubId)
        {
            var table = new DataTable();

            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                SELECT room_id, club_id, room_number, room_floor, area, capacity, equipment_description, room_status
                FROM room
                WHERE club_id = @clubId;", conn))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@clubId", clubId);
                conn.Open();
                adapter.Fill(table);
            }

            return table;
        }

        public int CreateRoom(int clubId, string roomNumber, int? roomFloor, decimal? area, int capacity,
            string equipmentDescription, string statusDb)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                INSERT INTO room (club_id, room_number, room_floor, area, capacity, equipment_description, room_status)
                VALUES (@clubId, @number, @floor, @area, @capacity, @equip, @status);
                SELECT LAST_INSERT_ID();", conn))
            {
                cmd.Parameters.AddWithValue("@clubId", clubId);
                cmd.Parameters.AddWithValue("@number", roomNumber);

                if (roomFloor.HasValue)
                    cmd.Parameters.AddWithValue("@floor", roomFloor.Value);
                else
                    cmd.Parameters.AddWithValue("@floor", DBNull.Value);
                if (area.HasValue)
                    cmd.Parameters.AddWithValue("@area", area.Value);
                else
                    cmd.Parameters.AddWithValue("@area", DBNull.Value);

                cmd.Parameters.AddWithValue("@capacity", capacity);
                cmd.Parameters.AddWithValue("@equip", string.IsNullOrWhiteSpace(equipmentDescription) ? (object)DBNull.Value : equipmentDescription);
                cmd.Parameters.AddWithValue("@status", statusDb);

                conn.Open();
                var result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        public void UpdateRoom(int roomId, string roomNumber, int? roomFloor, decimal? area, int capacity,
            string equipmentDescription, string statusDb)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(@"
                UPDATE room
                SET room_number = @number,
                    room_floor = @floor,
                    area = @area,
                    capacity = @capacity,
                    equipment_description = @equip,
                    room_status = @status
                WHERE room_id = @id;", conn))
            {
                cmd.Parameters.AddWithValue("@id", roomId);
                cmd.Parameters.AddWithValue("@number", roomNumber);

                if (roomFloor.HasValue)
                    cmd.Parameters.AddWithValue("@floor", roomFloor.Value);
                else
                    cmd.Parameters.AddWithValue("@floor", DBNull.Value);

                if (area.HasValue)
                    cmd.Parameters.AddWithValue("@area", area.Value);
                else
                    cmd.Parameters.AddWithValue("@area", DBNull.Value);
                cmd.Parameters.AddWithValue("@capacity", capacity);
                cmd.Parameters.AddWithValue("@equip", string.IsNullOrWhiteSpace(equipmentDescription) ? (object)DBNull.Value : equipmentDescription);
                cmd.Parameters.AddWithValue("@status", statusDb);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteRoom(int roomId)
        {
            using (var conn = DbHelper.GetConnection())
            using (var cmd = new MySqlCommand(
                "DELETE FROM room WHERE room_id = @id;", conn))
            {
                cmd.Parameters.AddWithValue("@id", roomId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

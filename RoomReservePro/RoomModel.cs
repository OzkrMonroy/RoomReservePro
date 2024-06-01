using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservePro
{
    internal class RoomModel
    {
        public void add(Room room)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(BDConfig.ConnectionString))
                {
                    connection.Open();
                    string query = $"INSERT INTO room (name, price, quantity, code) VALUES ('{room.name}', '{room.price}', '{room.quantity}', '{room.code}');";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    connection.Close();
                    reader.Close();
                    Console.WriteLine("Proyecto agregado con éxito");
                    Console.WriteLine("\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred" + ex.ToString());
            }
        }

        public List<RegisteredRoom> getAll()
        {
            List<RegisteredRoom> list = new List<RegisteredRoom>();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(BDConfig.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM room where quantity > 0;";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = Int32.Parse(reader["id"].ToString());
                        string name = reader["name"].ToString();
                        string code = reader["code"].ToString();
                        float price = float.Parse(reader["price"].ToString(), CultureInfo.InvariantCulture);
                        int quantity = Int32.Parse(reader["quantity"].ToString());
                        RegisteredRoom room = new RegisteredRoom(id, name, code, price, quantity);
                        list.Add(room);
                        
                    }
                    connection.Close();
                    Console.WriteLine("\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred" + ex.ToString());
            }
            return list;
        }

        public RegisteredRoom getById(int id)
        {
            RegisteredRoom room = null;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(BDConfig.ConnectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM room where id = {id};";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int roomId = Int32.Parse(reader["id"].ToString());
                        string name = reader["name"].ToString();
                        string code = reader["code"].ToString();
                        float price = float.Parse(reader["price"].ToString(), CultureInfo.InvariantCulture);
                        int quantity = Int32.Parse(reader["quantity"].ToString());
                        room = new RegisteredRoom(roomId, name, code, price, quantity);
                    }
                    connection.Close();
                    Console.WriteLine("\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred" + ex.ToString());
                room = null;
            }
            return room;
        }

        public bool update(int id, string property, string value)
        {
            bool success;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(BDConfig.ConnectionString))
                {
                    conn.Open();
                    string query = $"UPDATE user SET {property} = '{value}' WHERE id = {id};";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    conn.Close();
                    success = true;
                }

            }
            catch
            {
                Console.WriteLine("Error");
                success = false;
            }
            return success;
        }
    }
}

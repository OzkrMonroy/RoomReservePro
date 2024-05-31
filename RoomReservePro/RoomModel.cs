using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
                    string query = $"INSERT INTO room (description, price, quantity, code) VALUES ('{room.description}', '{room.price}', '{room.quantity}', '{room.code}');";
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

        public void getAll()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(BDConfig.ConnectionString))
                {
                    Console.WriteLine("Lista de habitaciones");
                    Console.WriteLine("\n");
                    connection.Open();
                    string query = "SELECT * FROM room where quantity > 0;";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine("Id ---------- Nombre --------------- Precio ---------- Cantidad disponible");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["id"]}              {reader["description"]}          {reader["price"]}              {reader["quantity"]}");
                    }
                    connection.Close();
                    Console.WriteLine("\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred" + ex.ToString());
            }
        }
    }
}

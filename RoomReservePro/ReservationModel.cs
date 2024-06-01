using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservePro
{
    internal class ReservationModel
    {
        public string add(Reservation reservation)
        {
            string reservationId = "";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(BDConfig.ConnectionString))
                {
                    connection.Open();
                    string query = $"INSERT INTO room_reservation (customer_name, checkin_date, checkout_date, code, total) VALUES ('{reservation.customerName}', '{reservation.checkinDate}', '{reservation.checkoutDate}', '{reservation.code}', '{reservation.total}');";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Close();

                    string query2 = $"SELECT id FROM room_reservation WHERE code = {reservation.code};";
                    command = new MySqlCommand(query2, connection);
                    reader = command.ExecuteReader();

                    while (reader.Read()) {
                        reservationId = reader["id"].ToString();
                    }
                    connection.Close();
                    reader.Close();
                    Console.WriteLine("Reservacion agregada con éxito");
                    Console.WriteLine("\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred" + ex.ToString());
            }
            return reservationId;
        }

        public List<RegisteredReservation> getAll()
        {
            List< RegisteredReservation> reservationList = new List<RegisteredReservation>();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(BDConfig.ConnectionString))
                {
                    Console.WriteLine("Lista de reservas");
                    Console.WriteLine("\n");
                    connection.Open();
                    string query = "SELECT * FROM room_reservation;";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = Int32.Parse(reader["id"].ToString());
                        string customerName = reader["customer_name"].ToString();
                        string checkinDate = reader["checkin_date"].ToString();
                        string checkoutDate = reader["checkout_date"].ToString();
                        string code = reader["code"].ToString();
                        float total = float.Parse(reader["total"].ToString(), CultureInfo.InvariantCulture);

                        RegisteredReservation reservation = new RegisteredReservation(id, customerName, checkinDate, checkoutDate,code, total);
                        reservationList.Add(reservation);
                    }
                    connection.Close();
                    Console.WriteLine("\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred" + ex.ToString());
            }

            return reservationList;
        }
    }
}

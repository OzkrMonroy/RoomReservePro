using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservePro
{
    internal class ReservationsUI : IControlUI
    {
        ReservationModel model = new ReservationModel();
        public void init()
        {
            MainMenuUI mainMenuUI = new MainMenuUI();
            int option;
            bool displayMenu = true;

            while (displayMenu)
            {
                Console.Clear();
                Console.WriteLine("**************************");
                Console.WriteLine("       Reservaciones      ");
                Console.WriteLine("**************************");
                Console.WriteLine("\n");
                Console.WriteLine("Seleccione el número de la opción que desea realizar:");
                Console.WriteLine("1. Nueva reservación");
                Console.WriteLine("2. Buscar reservación");
                Console.WriteLine("3. Ver todas las reservaciones");
                Console.WriteLine("4. Regresar al menú principal");
                Console.WriteLine("Ingrese opción:");

                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1: 
                        addReservationMessages();
                        displayMenu = false;
                        break;
                    case 3:
                        showAllReservations();
                        displayMenu = false;
                        break;
                    case 4:
                        mainMenuUI.init();
                        displayMenu = false;
                        break;
                    default:
                        Console.WriteLine("Opción ingresada no válida");
                        break;
                }
                Console.WriteLine("\n");

            }
        }

        private void addReservationMessages()
        {
            Console.Clear();
            Console.WriteLine("**************************");
            Console.WriteLine("       Nueva Reserva      ");
            Console.WriteLine("**************************");
            Console.WriteLine("\n");
            Console.WriteLine("Ingresa el nombre del usuario:");
            string userName = Console.ReadLine();
            Console.WriteLine("Ingresa la fecha de ingreso (dd/MM/yyyy)");
            string checkin = getDate();
            Console.WriteLine("Ingresa la fecha de salida (dd/MM/yyyy)");
            string checkout = getDate();
            Reservation reservation = new Reservation(userName, checkin, checkout, 0);
            string currentReservationId = model.add(reservation);
            Console.WriteLine("Reservation id" + currentReservationId);
            addRoom(Int32.Parse(currentReservationId));
        }

        private void addRoom(int reservationId)
        {
            List<RegisteredRoom> roomList = new List<RegisteredRoom>();
            RoomModel roomModel = new RoomModel();
            roomList = roomModel.getAll();
            int option;

            bool displayAddRoomUI = true;
            bool hasAlreadyAddedRoom = false;
            while (displayAddRoomUI) {
                Console.Clear();
                Console.WriteLine("*******************************");
                Console.WriteLine("       Añadir Habitación      ");
                Console.WriteLine("*******************************");
                Console.WriteLine("\n");
                roomList.ForEach(room =>
                {
                    Console.WriteLine($"{room.id}, {room.name}, {room.code}, {room.quantity}, {room.price}");
                });
                Console.WriteLine("\n");
                Console.WriteLine("Ingrese el Id de la habitación que deseas:");
                string selectedCode = Console.ReadLine();
                RegisteredRoom selectedRoom = roomModel.getByCode(selectedCode);
                Console.WriteLine($"Seleccinaste la habitación: {selectedRoom.name}, disponibles: {selectedRoom.quantity}");
                Console.WriteLine("Ingresa la cantidad de habitaciones que deseas");
                int quantityToReserve = Convert.ToInt32(Console.ReadLine());
            }
        }

        private string getDate()
        {
            bool isValidDate = false;
            string stringDate = "";
            while (!isValidDate)
            {
                stringDate = Console.ReadLine(); ;
                isValidDate = IsDateInFormat(stringDate, "dd/MM/yyyy");
                if (!isValidDate)
                {
                    Console.WriteLine("Fecha inválida, intenta nuevamente");
                }
            }
            return stringDate;
        }

        private bool IsDateInFormat(string dateString, string format)
        {
            DateTime date;
            return DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }

        private void showAllReservations() 
        {
            List<RegisteredReservation> registeredReservationsList = new List<RegisteredReservation>();
            ReservationModel reservationModel = new ReservationModel();
            registeredReservationsList = reservationModel.getAll();

            Console.Clear();
            Console.WriteLine("**************************");
            Console.WriteLine("       Reservaciones      ");
            Console.WriteLine("**************************");
            Console.WriteLine("\n");

            Console.WriteLine("** Id ******* Código ************ Cliente ****************** Fecha de ingreso ****************** Fecha de salida ****************** Total **");
            registeredReservationsList.ForEach(reservation =>
            {
                Console.WriteLine($"  {reservation.id}       {reservation.code}             {reservation.customerName}                   {reservation.checkinDate}                  {reservation.checkoutDate}                   {reservation.total}  ");
            });
            Console.WriteLine("\n");
            Console.WriteLine("Presione cualquier tecla para regresar al menú anterior");
            Console.ReadLine();
            init();
        }
    }
}

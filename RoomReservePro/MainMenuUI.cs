using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservePro
{
    internal class MainMenuUI : IControlUI
    {
        public void init()
        {
            RoomsUI roomsUI = new RoomsUI();
            ReservationsUI reservationsUI = new ReservationsUI();
            int option;
            bool displayMenu = true;

            while (displayMenu)
            {
                Console.Clear();
                Console.WriteLine("**************************");
                Console.WriteLine("      Menú principal      ");
                Console.WriteLine("**************************");
                Console.WriteLine("\n");
                Console.WriteLine("Seleccione el número de la opción que desea realizar:");
                Console.WriteLine("1. Reservaciones");
                Console.WriteLine("2. Habitaciones");
                Console.WriteLine("3. Salir");
                Console.WriteLine("Ingrese opción:");

                option = Convert.ToInt32(Console.ReadLine());
                

                switch (option)
                {
                    case 1: 
                        reservationsUI.init();
                        displayMenu = false;
                        break;
                    case 2:
                        roomsUI.init();
                        displayMenu = false;
                        break;
                     case 3:
                        Console.WriteLine("Saliendo...");
                       displayMenu = false;
                     break;
                    default:
                        Console.WriteLine("Opción ingresada no válida");
                        break;
                }

            }
            Console.WriteLine("\n");
            Environment.Exit(0);
        }
    }
}

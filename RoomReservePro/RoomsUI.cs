using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservePro
{
    internal class RoomsUI : IControlUI
    {
        public void init()
        {
            MainMenuUI mainMenuUI = new MainMenuUI();
            int option;
            bool displayMenu = true;

            while (displayMenu)
            {
                Console.Clear();
                Console.WriteLine("**************************");
                Console.WriteLine("        Habitaciones      ");
                Console.WriteLine("**************************");
                Console.WriteLine("\n");
                Console.WriteLine("Seleccione el número de la opción que desea realizar:");
                Console.WriteLine("1. Registrar habitación");
                Console.WriteLine("2. Modificar habitación");
                Console.WriteLine("3. Buscar habitación por código"); 
                Console.WriteLine("4. Ver todas las habitaciones");
                Console.WriteLine("5. Regresar al menú principal");
                Console.WriteLine("Ingrese opción:");

                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 4:
                        showAll();
                        displayMenu = false;
                        break;
                    case 5:
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

        private void showAll()
        {
            List<RegisteredRoom> registeredRoomList = new List<RegisteredRoom>();
            RoomModel roomModel = new RoomModel();
            registeredRoomList = roomModel.getAll();

            Console.Clear();
            Console.WriteLine("**************************");
            Console.WriteLine("       Habitaciones      ");
            Console.WriteLine("**************************");
            Console.WriteLine("\n");

            Console.WriteLine("** Id ******* Código ************ Nombre ****************** Precio ****************** Disponibles **");
            registeredRoomList.ForEach(room =>
            {
                Console.WriteLine($"  {room.id}       {room.code}             {room.name}                   {room.price}                  {room.quantity}  ");
            });
            Console.WriteLine("\n");
            Console.WriteLine("Presione cualquier tecla para regresar al menú anterior");
            Console.ReadLine();
            init();
        }
    }
}

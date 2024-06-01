using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservePro
{
    internal class RoomsUI : IControlUI
    {
        private RoomModel roomModel = new RoomModel();
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
                    case 1:
                        add();
                        break;
                    case 2:
                        update(); 
                    break;
                    case 3:
                        getByCode();
                        break;
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

        private void add() {
            Console.Clear();
            Console.WriteLine("**************************");
            Console.WriteLine("       Nueva Habitación      ");
            Console.WriteLine("**************************");
            Console.WriteLine("\n");
            Console.WriteLine("Ingresa el nombre de la habitación:");
            string roomName = Console.ReadLine();
            Console.WriteLine("Ingresa el precio de la habitación:");
            float price = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("Ingresa la cantidad de habitaciones existentes:");
            int quantity = Int32.Parse(Console.ReadLine());

            Room room = new Room(roomName, price, quantity);
            roomModel.add(room);
            Console.WriteLine("\n");
            Console.WriteLine("Habitación registrada correctamente! Pulse una tecla para continuar...");
            Console.ReadLine();
            init();
        }

        private void showAll()
        {
            List<RegisteredRoom> registeredRoomList = new List<RegisteredRoom>();
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

        private void getByCode()
        {
            Console.Clear();

            Console.WriteLine("*******************************");
            Console.WriteLine("       Buscar habitación      ");
            Console.WriteLine("*******************************");
            Console.WriteLine("\n");

            RegisteredRoom room = getRoom();
            if (room == null) {
                Console.WriteLine("La habitación no existe. Presione cualquier tecla para continuar.");
                Console.ReadLine();
                init();
                return;
            }
            Console.WriteLine("** Id ******* Código ************ Nombre ****************** Precio ****************** Disponibles **");
            Console.WriteLine($"  {room.id}       {room.code}             {room.name}                   {room.price}                  {room.quantity}  ");
            Console.WriteLine("\n");
            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadLine();
            init();
        }

        private void update()
        {
            Console.Clear();

            Console.WriteLine("*******************************");
            Console.WriteLine("       Modificar habitación      ");
            Console.WriteLine("*******************************");
            Console.WriteLine("\n");

            RegisteredRoom room = getRoom();
            if (room == null)
            {
                Console.WriteLine("La habitación no existe. Presione cualquier tecla para continuar.");
                Console.ReadLine();
                init();
                return;
            }
            Console.WriteLine($"Habitación seleccionada: {room.name}");
            Console.WriteLine($"Ingresa el nuevo precio (precio anterior: {room.price}):");
            int newPrice = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Ingresa la nueva cantidad de habitaciones disponibles:");
            int newQuantity = Int32.Parse(Console.ReadLine());

            roomModel.update(room.code, newPrice, newQuantity);
            Console.WriteLine("Datos actualizados correctamente!");
            Console.WriteLine("\n");
            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadLine();
            init();
        }

        private RegisteredRoom getRoom()
        {
            Console.WriteLine("Ingrese el código de la habitación");
            string codeToSearch = Console.ReadLine();
            RegisteredRoom room = roomModel.getByCode(codeToSearch);
            return room;
        }
    }
}

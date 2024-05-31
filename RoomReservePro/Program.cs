using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservePro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RoomModel roomModel = new RoomModel();
            Room room = new Room("Gran Suite", 500, 7);
            roomModel.getAll();
        }
    }
}

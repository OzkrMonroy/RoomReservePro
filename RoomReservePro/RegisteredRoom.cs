using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservePro
{
    internal class RegisteredRoom
    {
        public int id;
        public string name;
        public string code;
        public float price;
        public int quantity;

        public RegisteredRoom(int id, string name, string code, float price, int quantity)
        {
            this.id = id;
            this.name = name;
            this.code = code;
            this.price = price;
            this.quantity = quantity;
        }
    }
}

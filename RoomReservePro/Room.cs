using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservePro
{
    internal class Room
    {
        public string name;
        public string code;
        public float price;
        public int quantity;

        public Room(string name, float price, int quantity)
        {
            var dateToUse = DateTime.Now;
            string random = new DateTimeOffset(dateToUse).ToUnixTimeMilliseconds().ToString();
            string code = random.Substring(6);
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.code = code;
        }
    }
}

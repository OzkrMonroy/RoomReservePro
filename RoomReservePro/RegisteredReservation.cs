using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservePro
{
    internal class RegisteredReservation
    {
        public int id;
        public string customerName;
        public string code;
        public string checkinDate;
        public string checkoutDate;
        public float total;
        public RegisteredReservation(int id, string customerName, string checkinDate, string checkoutDate, string code, float total)
        {
            this.id = id;
            this.customerName = customerName;
            this.code = code;
            this.checkinDate = checkinDate;
            this.checkoutDate = checkoutDate;
            this.total = total;
        }
    }
}

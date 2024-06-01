using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservePro
{
    internal class Reservation
    {
        public string customerName;
        public string code;
        public string checkinDate;
        public string checkoutDate;
        public float total;
        public Reservation(string customerName, string checkinDate, string checkoutDate, float total) {
            var dateToUse = DateTime.Now;
            string random = new DateTimeOffset(dateToUse).ToUnixTimeMilliseconds().ToString();
            string code = random.Substring(6);
            string checkinDateTime = this.getDateTimeByString(checkinDate);
            string checkoutDateTime = this.getDateTimeByString(checkoutDate);

            this.customerName = customerName;
            this.code = code;
            this.checkinDate = checkinDateTime;
            this.checkoutDate = checkoutDateTime;
            this.total = total;
        }

        private string getDateTimeByString(string stringDate) {
            DateTime date;
            DateTime.TryParseExact(stringDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservePro
{
    internal class BDConfig
    {
        private static string connectionString = "server=localhost;user=root;database=progra1_example1;port=3306;password=MyNewPass";

        public static string ConnectionString { get { return connectionString; } } 
    }
}

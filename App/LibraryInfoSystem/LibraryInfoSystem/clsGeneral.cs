using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfoSystem
{
    internal class clsGeneral
    {
        public static string getConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection_String"].ConnectionString;

            return connectionString;
        }
     
    }
}

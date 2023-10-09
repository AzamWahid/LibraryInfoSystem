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
           // string ConnectionString = @"Data Source=azam-lt\sql19;Initial Catalog=bookstore;User ID=sa;Password=sasasa-1;MultipleActiveResultSets=True";
            string connectionString = ConfigurationManager.ConnectionStrings["Connection_String"].ConnectionString;

            return connectionString;
        }
     
    }
}

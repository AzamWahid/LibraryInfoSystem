using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfoSystem.Borrow
{
    public class clsUserList
    {
        public long? UID { get; set; }
        public string? UName { get; set; }
        public string? UEmail { get; set; }
        public string? UMobileNo { get; set; }
        public string UType { get; set; }

        private readonly SqlConnection connection;
        public clsUserList()
        {
            string connectionString = clsGeneral.getConnectionString();
            connection = new SqlConnection(connectionString);
        }
        public List<clsUserList> GetUsers()
        {

            List<clsUserList> UserList = new List<clsUserList>();
            SqlCommand cmd = new SqlCommand("sp_GetUsers", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null)
            {
                while (reader.Read())
                {
                    clsUserList users = new clsUserList();

                    users.UID = long.Parse(reader["UID"].ToString());
                    users.UName = reader["UName"].ToString();
                    users.UEmail = reader["UEmail"].ToString();
                    users.UMobileNo = reader["UMobileNo"].ToString();
                    users.UType = reader["UType"].ToString();

                    UserList.Add(users);
                }
            }
            connection.Close();
            return UserList;
        }
   
    }
}

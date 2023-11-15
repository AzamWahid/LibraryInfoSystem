using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfoSystem.Borrow
{
    public class clsUserManagement
    {
        public long? UID { get; set; }
        public string? UName { get; set; }
        public string? UFName { get; set; }
        public string? UEmail { get; set; }
        public string? UMobileNo { get; set; }
        public string? UType { get; set; }
        public char? UAllowBorrow { get; set; }
        public char? UBookRights { get; set; }

        private readonly SqlConnection connection;
        public clsUserManagement()
        {
            string connectionString = clsGeneral.getConnectionString();
            connection = new SqlConnection(connectionString);
        }
        public List<clsUserManagement> GetUsers()
        {

            List<clsUserManagement> userList = new List<clsUserManagement>();
            SqlCommand cmd = new SqlCommand("sp_GetUsers", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null)
            {
                while (reader.Read())
                {
                    clsUserManagement user = new clsUserManagement();

                    user.UID = long.Parse(reader["UID"].ToString());
                    user.UName = reader["UName"].ToString();
                    user.UFName = reader["UFName"].ToString();
                    user.UEmail = reader["UEmail"].ToString();
                    user.UMobileNo = reader["UMobileNo"].ToString();
                    user.UType = reader["UType"].ToString();
                    user.UAllowBorrow = char.Parse(reader["UAllowBorrow"].ToString());
                    user.UBookRights = char.Parse(reader["UBookRights"].ToString());


                    userList.Add(user);
                }
            }
            connection.Close();
            return userList;
        }

      
        public void UpdateUsers()
        {
            SqlCommand cmd = new SqlCommand("sp_UpdateUserRights", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UID", this.UID);
            cmd.Parameters.AddWithValue("@UAllowBorrow", this.UAllowBorrow);
            cmd.Parameters.AddWithValue("@UBookRights", this.UBookRights);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }
    }
}

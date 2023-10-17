using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfoSystem.Register_Login
{
    public class ClsLogin
    {
        public long? UID { get; set; }
        public string? UEmail { get; set; }
        public string? UPass { get; set; }

        private readonly SqlConnection connection;
        public ClsLogin()
        {
            string connectionString = clsGeneral.getConnectionString();
            connection = new SqlConnection(connectionString);
        }
        public bool ChectUser()
        {
            SqlCommand cmd = new SqlCommand("sp_CheckUserCredentials", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UEmail", this.UEmail);
            cmd.Parameters.AddWithValue("@UPass", this.UPass);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();


            if (reader != null && reader.HasRows)
            {
                reader.Read();
                this.UID = long.Parse(reader["UID"].ToString());
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }

        }

    }
}

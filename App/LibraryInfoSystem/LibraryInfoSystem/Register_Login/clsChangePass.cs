using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfoSystem.Register_Login
{
    public class clsChangePass
    {
        public string? UEmail { get; set; }
        public string? UCurrPass { get; set; }
        public string? UNewPass { get; set; }
        public string? UReNewPass { get; set; }

        private readonly SqlConnection connection;
        public clsChangePass()
        {
            string connectionString = clsGeneral.getConnectionString();
            connection = new SqlConnection(connectionString);
        }
        public bool CheckCurrPass()
        {
            SqlCommand cmd = new SqlCommand("sp_CheckUserCredentials", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UEmail", this.UEmail);
            cmd.Parameters.AddWithValue("@UPass", this.UCurrPass);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();


            if (reader != null && reader.HasRows)
            {
                reader.Read();
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }

        }
        public void UpdatePass()
        {
            SqlCommand cmd = new SqlCommand("sp_UpdatePassword", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UEmail", this.UEmail);
            cmd.Parameters.AddWithValue("@UCurrPass", this.UCurrPass);
            cmd.Parameters.AddWithValue("@UNewPass", this.UNewPass);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }

    }
}

using System.Data;
using System.Data.SqlClient;

namespace LibraryInfoSystem.Register_Login
{
    public class ClsRegister
    {
        public string? UName { get; set; }
        public string? UFName { get; set; }
        public string? UEmail { get; set; }
        public string? UMobileNo { get; set; }
        public string? UPass { get; set; }
        public char? UType { get; set; }

        private readonly SqlConnection connection;

        public ClsRegister()
        {
            string connectionString = clsGeneral.getConnectionString();
            connection = new SqlConnection(connectionString);
        }

        public bool CheckExistUser()
        {
            SqlCommand cmd = new SqlCommand("sp_CheckUserExists", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UEmail", this.UEmail);
            cmd.Parameters.AddWithValue("@UMobileNo", this.UMobileNo);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();


            if (reader != null && reader.HasRows)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }

        }
        public void AddUser()
        {
            SqlCommand cmd = new SqlCommand("sp_AddRegUser", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UName", this.UName);
            cmd.Parameters.AddWithValue("@UFName", this.UFName);
            cmd.Parameters.AddWithValue("@UEmail", this.UEmail);
            cmd.Parameters.AddWithValue("@UMobileNo", this.UMobileNo);
            cmd.Parameters.AddWithValue("@UPass", this.UPass);
            cmd.Parameters.AddWithValue("@UType", this.UType);


            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

    }

}

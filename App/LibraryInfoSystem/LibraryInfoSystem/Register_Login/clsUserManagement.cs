using Microsoft.VisualBasic.ApplicationServices;
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
        public string? UPass { get; set; }
        public string? UType { get; set; }
        public char? UAllowBorrow { get; set; }
        public char? UBookRights { get; set; }
        public char? UBlock { get; set; }

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
                    user.UPass = reader["UPass"].ToString();
                    user.UType = reader["UType"].ToString();
                    user.UAllowBorrow = char.Parse(reader["UAllowBorrow"].ToString());
                    user.UBookRights = char.Parse(reader["UBookRights"].ToString());
                    user.UBlock = char.Parse(reader["UBlock"].ToString());


                    userList.Add(user);
                }
            }
            connection.Close();
            return userList;
        }
        public void GetUserByEmail()
        {
            SqlCommand cmd = new SqlCommand("sp_GetUsersByEmail", connection);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UEmail", this.UEmail);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null && reader.HasRows)
            {
                reader.Read();
                this.UID = long.Parse(reader["UID"].ToString());
                this.UName = reader["UName"].ToString();
                this.UFName = reader["UFName"].ToString();
                this.UEmail = reader["UEmail"].ToString();
                this.UMobileNo = reader["UMobileNo"].ToString();
                this.UPass = reader["UPass"].ToString();
                this.UType = reader["UType"].ToString();
                this.UAllowBorrow = char.Parse(reader["UAllowBorrow"].ToString());
                this.UBookRights = char.Parse(reader["UBookRights"].ToString());
                this.UBlock = char.Parse(reader["UBlock"].ToString());
            }
            else
            {
                this.UEmail = "";
            }
            connection.Close();
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
            cmd.Parameters.AddWithValue("@UAllowBorrow", this.UAllowBorrow);
            cmd.Parameters.AddWithValue("@UBookRights", this.UBookRights);
            cmd.Parameters.AddWithValue("@UBlock", this.UBlock);



            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void UpdateUsers()
        {
            SqlCommand cmd = new SqlCommand("sp_UpdateRegUser", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UID", this.UID);
            cmd.Parameters.AddWithValue("@UName", this.UName);
            cmd.Parameters.AddWithValue("@UFName", this.UFName);
            cmd.Parameters.AddWithValue("@UEmail", this.UEmail);
            cmd.Parameters.AddWithValue("@UMobileNo", this.UMobileNo);
            cmd.Parameters.AddWithValue("@UPass", this.UPass);
            cmd.Parameters.AddWithValue("@UType", this.UType);
            cmd.Parameters.AddWithValue("@UAllowBorrow", this.UAllowBorrow);
            cmd.Parameters.AddWithValue("@UBookRights", this.UBookRights);
            cmd.Parameters.AddWithValue("@UBlock", this.UBlock);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }
    }
}

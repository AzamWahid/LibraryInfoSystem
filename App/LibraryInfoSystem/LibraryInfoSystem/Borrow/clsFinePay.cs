using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfoSystem.Borrow
{
    public class clsFinePay
    {
        public string? UEmail { get; set; }
        public string? UName { get; set; }
        public string? UMobile { get; set; }
        public string? UType { get; set; }
        public long? IFineRefNo { get; set; }
        public DateTime? IFineRefDate { get; set; }
        public long? BorrowID { get; set; }
        public long? BorrowNo { get; set; }
        public DateTime? BorrowDate { get; set; }
        public long? BorrowDays { get; set; }
        public long? BorrowRetID { get; set; }
        public long? BorrowRetNo { get; set; }
        public DateTime? BorrowRetDate { get; set; }
        public string? BookTitle { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public long? Year { get; set; }
        public long? Edition { get; set; }
        public char? BRFineYN { get; set; }
        public long? LateDays { get; set; }
        public decimal? FineAmnt { get; set; }

        private readonly SqlConnection connection;
        public clsFinePay()
        {
            string connectionString = clsGeneral.getConnectionString();
            connection = new SqlConnection(connectionString);
        }
        public List<ClsImopseFine> GetLateRetList()
        {

            List<ClsImopseFine> LateRetList = new List<ClsImopseFine>();
            SqlCommand cmd = new SqlCommand("Sp_GetLateReturnList", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UEmail", this.UEmail);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();



            if (reader != null && reader.HasRows)
            {


                while (reader.Read())
                {
                    ClsImopseFine ImopseFine = new ClsImopseFine();

                    ImopseFine.BorrowID = long.Parse(reader["BBID"].ToString());
                    ImopseFine.BorrowNo = long.Parse(reader["BBRefNo"].ToString());
                    ImopseFine.BorrowDate = DateTime.Parse(reader["BBRefDate"].ToString());
                    ImopseFine.BorrowDays = long.Parse(reader["BBDays"].ToString());
                    ImopseFine.BorrowRetID = long.Parse(reader["BRID"].ToString());
                    ImopseFine.BorrowRetNo = long.Parse(reader["BRRefNo"].ToString());
                    ImopseFine.BorrowRetDate = DateTime.Parse(reader["BRRefDate"].ToString());
                    ImopseFine.BookTitle = reader["BookTitle"].ToString();
                    ImopseFine.Author = reader["BookAuthor"].ToString();
                    ImopseFine.ISBN = reader["BookISBN"].ToString();
                    ImopseFine.Year = long.Parse(reader["BookYear"].ToString());
                    ImopseFine.Edition = long.Parse(reader["BookEdition"].ToString());
                    ImopseFine.LateDays = long.Parse(reader["late_Days"].ToString());

                    LateRetList.Add(ImopseFine);
                }
            }
            connection.Close();
            return LateRetList;
        }
        public void GetImposeFineNo()
        {
            SqlCommand cmd = new SqlCommand("sp_GetImposeFineNo", connection);
            cmd.CommandType = CommandType.StoredProcedure;


            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            this.IFineRefNo = long.Parse(reader["ImposeRefNo"].ToString());
            connection.Close();

        }
        public bool ChectUser()
        {
            SqlCommand cmd = new SqlCommand("sp_CheckUserExists", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UEmail", this.UEmail);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();


            if (reader != null && reader.HasRows)
            {
                reader.Read();
                this.UEmail = reader["UEmail"].ToString();
                this.UName = reader["UName"].ToString();
                this.UMobile = reader["UMobileNo"].ToString();
                this.UType = reader["UType"].ToString();
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }


        public void SaveImposeFine()
        {
            SqlCommand cmd = new SqlCommand("sp_SaveImposeFine", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IFRefNo", this.IFineRefNo);
            cmd.Parameters.AddWithValue("@IFRefDate", this.IFineRefDate);
            cmd.Parameters.AddWithValue("@BorrowRetID", this.BorrowRetID);
            cmd.Parameters.AddWithValue("@FineAmnt", this.FineAmnt);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }
        public void NeglectImposeFine()
        {
            SqlCommand cmd = new SqlCommand("sp_NeglectImposeFine", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BorrowRetID", this.BorrowRetID);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }
    }
}

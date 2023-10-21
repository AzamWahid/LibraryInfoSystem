using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfoSystem.Borrow
{
    public class ClsBorrowRet
    {
        public long? UID { get; set; }
        public long? BorrowRetNo { get; set; }
        public DateTime? BorrowRetDate { get; set; }
        public long? BorrowID { get; set; }
        public long? BorrowNo { get; set; }
        public DateTime? BorrowDate { get; set; }
        public string? BookTitle { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public long? Year { get; set; }
        public long? Edition { get; set; }
        public char? BRFineYN { get; set; }
        public long? DaysLeft { get; set; }

        private readonly SqlConnection connection;
        public ClsBorrowRet()
        {
            string connectionString = clsGeneral.getConnectionString();
            connection = new SqlConnection(connectionString);
        }
        public List<ClsBorrowRet> GetBorrowList()
        {

            List<ClsBorrowRet> borrowList = new List<ClsBorrowRet>();
            SqlCommand cmd = new SqlCommand("sp_getUserBorrowList", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UID", this.UID);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null)
            {
                while (reader.Read())
                {
                    ClsBorrowRet BorrowRet = new ClsBorrowRet();

                    BorrowRet.BorrowID = long.Parse(reader["BBID"].ToString());
                    BorrowRet.BorrowNo = long.Parse(reader["BBRefNo"].ToString());
                    BorrowRet.BorrowDate = DateTime.Parse(reader["BBRefDate"].ToString());
                    BorrowRet.BookTitle = reader["BookTitle"].ToString();
                    BorrowRet.Author = reader["BookAuthor"].ToString();
                    BorrowRet.ISBN = reader["BookISBN"].ToString();
                    BorrowRet.Year = long.Parse(reader["BookYear"].ToString());
                    BorrowRet.Edition = long.Parse(reader["BookEdition"].ToString());
                    BorrowRet.DaysLeft = long.Parse(reader["DaysLeft"].ToString());

                    borrowList.Add(BorrowRet);
                }
            }
            connection.Close();
            return borrowList;
        }
        public void GetBorrowRetNo()
        {
            SqlCommand cmd = new SqlCommand("sp_GetUserBorrowRetNo", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UID", this.UID);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            this.BorrowRetNo = long.Parse(reader["BorrowRetNo"].ToString());
            connection.Close();

        }
     
        public void SaveBorrowRet()
        {
            SqlCommand cmd = new SqlCommand("sp_SaveBorrowRet", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BorrowRetNo", this.BorrowRetNo);
            cmd.Parameters.AddWithValue("@BorrowRetDate", this.BorrowRetDate);
            cmd.Parameters.AddWithValue("@BorrowID", this.BorrowID);
            cmd.Parameters.AddWithValue("@BRFineYN", this.BRFineYN);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }
    }
}

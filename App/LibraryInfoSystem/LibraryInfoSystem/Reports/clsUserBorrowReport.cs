using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfoSystem.Borrow
{
    public class clsUserBorrowReport
    {
        public long? UID { get; set; }
        public DateTime? BorrowDate { get; set; }
        public long? BBDays { get; set; }
        public string? BookTitle { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public long? Edition { get; set; }
        public long? Year { get; set; }
        public long? DaysLeft { get; set; }

        private readonly SqlConnection connection;
        public clsUserBorrowReport()
        {
            string connectionString = clsGeneral.getConnectionString();
            connection = new SqlConnection(connectionString);
        }
        public List<clsUserBorrowReport> GetBorrowList()
        {

            List<clsUserBorrowReport> borrowList = new List<clsUserBorrowReport>();
            SqlCommand cmd = new SqlCommand("sp_getUserBorrowList", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UID", this.UID);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null)
            {
                while (reader.Read())
                {
                    clsUserBorrowReport BorrowRet = new clsUserBorrowReport();

                    BorrowRet.BorrowDate = DateTime.Parse(reader["BBRefDate"].ToString());
                    BorrowRet.BBDays = long.Parse(reader["BBDays"].ToString());
                    BorrowRet.BookTitle = reader["BookTitle"].ToString();
                    BorrowRet.Author = reader["BookAuthor"].ToString();
                    BorrowRet.ISBN = reader["BookISBN"].ToString();
                    BorrowRet.Edition = long.Parse(reader["BookEdition"].ToString());
                    BorrowRet.Year = long.Parse(reader["BookYear"].ToString());
                    BorrowRet.DaysLeft = long.Parse(reader["DaysLeft"].ToString());

                    borrowList.Add(BorrowRet);
                }
            }
            connection.Close();
            return borrowList;
        }
    
    }
}

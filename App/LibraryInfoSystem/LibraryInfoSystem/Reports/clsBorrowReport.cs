using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfoSystem.Borrow
{
    public class clsBorrowReport
    {

        public DateTime? BBRefDate { get; set; }
        public string? BookTitle { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public long Edition { get; set; }
        public long? Year { get; set; }
        public long? BBDays { get; set; }
        public long? DaysLeft { get; set; }
        public string? UEmail { get; set; }
        public string? UName { get; set; }
        public string? UMobileNo { get; set; }

        private readonly SqlConnection connection;
        public clsBorrowReport()
        {
            string connectionString = clsGeneral.getConnectionString();
            connection = new SqlConnection(connectionString);
        }
        public List<clsBorrowReport> GetBorrowList()
        {

            List<clsBorrowReport> borrowList = new List<clsBorrowReport>();
            SqlCommand cmd = new SqlCommand("sp_Rpt_BorrowBook", connection);

            cmd.Parameters.AddWithValue("@UEmail", this.UEmail);

            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null)
            {
                while (reader.Read())
                {
                    clsBorrowReport borrow = new clsBorrowReport();

                    borrow.UEmail = reader["UEmail"].ToString();
                    borrow.UName = reader["UName"].ToString();
                    borrow.UMobileNo = reader["UMobileNo"].ToString();
                    borrow.BBRefDate = DateTime.Parse(reader["BBRefDate"].ToString());
                    borrow.BookTitle = reader["BookTitle"].ToString();
                    borrow.Author = reader["BookAuthor"].ToString();
                    borrow.ISBN = reader["BookISBN"].ToString();
                    borrow.Edition = long.Parse(reader["BookEdition"].ToString());
                    borrow.Year = long.Parse(reader["BookYear"].ToString());
                    borrow.BBDays = long.Parse(reader["BBDays"].ToString());
                    borrow.DaysLeft = long.Parse(reader["DaysLeft"].ToString());

                    borrowList.Add(borrow);
                }
            }
            connection.Close();
            return borrowList;
        }
   
    }
}

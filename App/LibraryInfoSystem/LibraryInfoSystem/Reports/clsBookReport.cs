using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfoSystem.Borrow
{
    public class clsBookReport
    {
        public long? BookID { get; set; }
        public string? BookCode { get; set; }
        public string? BookTitle { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public long Edition { get; set; }
        public long? Year { get; set; }
        public long NoofCopies { get; set; }
        public long Borrow { get; set; }
        public long remainingCopies { get; set; }

        private readonly SqlConnection connection;
        public clsBookReport()
        {
            string connectionString = clsGeneral.getConnectionString();
            connection = new SqlConnection(connectionString);
        }
        public List<clsBookReport> GetAvaBooks()
        {

            List<clsBookReport> bookList = new List<clsBookReport>();
            SqlCommand cmd = new SqlCommand("sp_RptBookDetails", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null)
            {
                while (reader.Read())
                {
                    clsBookReport book = new clsBookReport();

                    book.BookID = long.Parse(reader["BookID"].ToString());
                    book.BookCode = reader["BookCode"].ToString();
                    book.BookTitle = reader["BookTitle"].ToString();
                    book.Author = reader["BookAuthor"].ToString();
                    book.ISBN = reader["BookISBN"].ToString();
                    book.Edition = long.Parse(reader["BookEdition"].ToString());
                    book.Year = long.Parse(reader["BookYear"].ToString());
                    book.NoofCopies = long.Parse(reader["BookNoofCopies"].ToString());
                    book.Borrow = long.Parse(reader["borrow"].ToString());
                    book.remainingCopies = long.Parse(reader["remainingCopies"].ToString());

                    bookList.Add(book);
                }
            }
            connection.Close();
            return bookList;
        }
   
    }
}

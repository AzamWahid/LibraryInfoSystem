using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfoSystem.Borrow
{
    public class ClsBorrow
    {
        public long? BorrowNo { get; set; }
        public DateTime? BorrowDate { get; set; }
        public long? BorrowUID { get; set; }
        public long? BorrowBookID { get; set; }
        public string? BookTitle { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public long? Year { get; set; }
        public long Edition { get; set; }
        public long BorrowDays { get; set; }

        private readonly SqlConnection connection;
        public ClsBorrow()
        {
            string connectionString = clsGeneral.getConnectionString();
            connection = new SqlConnection(connectionString);
        }
        public List<ClsBook> GetBooks()
        {

            List<ClsBook> bookList = new List<ClsBook>();
            SqlCommand cmd = new SqlCommand("sp_getAvailableBook", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null)
            {
                while (reader.Read())
                {
                    ClsBorrow borrow = new ClsBorrow();

                    borrow.BorrowBookID = long.Parse(reader["BookID"].ToString());
                    borrow.BookTitle = reader["BookTitle"].ToString();
                    borrow.Author = reader["BookAuthor"].ToString();
                    borrow.ISBN = reader["BookISBN"].ToString();
                    borrow.Year = long.Parse(reader["BookYear"].ToString());
                    borrow.Edition = long.Parse(reader["BookEdition"].ToString());

                    bookList.Add(borrow);
                }
            }
            connection.Close();
            return bookList;
        }
    }
}

using System.Data;
using System.Data.SqlClient;

namespace LibraryInfoSystem
{
    public class ClsBook
    {
        public long? BookID { get; set; }
        public string? BookCode { get; set; }
        public string? BookTitle { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public long? Year { get; set; }
        public long Edition { get; set; }
        public long NoofCopies { get; set; }

        private readonly SqlConnection connection;

        public ClsBook()
        {
            string connectionString = clsGeneral.getConnectionString();
            connection = new SqlConnection(connectionString);
        }

        public List<ClsBook> GetBooks()
        {

            List<ClsBook> bookList = new List<ClsBook>();
            SqlCommand cmd = new SqlCommand("sp_getBookList", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null)
            {
                while (reader.Read())
                {
                    ClsBook book = new ClsBook();

                    book.BookCode = reader["BookCode"].ToString().Trim();
                    book.BookTitle = reader["BookTitle"].ToString();
                    book.Author = reader["BookAuthor"].ToString();
                    book.ISBN = reader["BookISBN"].ToString();
                    book.Year = long.Parse(reader["BookYear"].ToString());
                    book.Edition = long.Parse(reader["BookEdition"].ToString());
                    book.NoofCopies = long.Parse(reader["BookNoofCopies"].ToString());
                    bookList.Add(book);
                }
            }
            connection.Close();
            return bookList;
        }

        public void GetBookById()
        {
            SqlCommand cmd = new SqlCommand("sp_getBookEdit", connection);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookCode", this.BookCode);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null && reader.HasRows)
            {
                reader.Read();
                this.BookCode = reader["BookCode"].ToString().Trim();
                this.BookTitle = reader["BookTitle"].ToString();
                this.Author = reader["BookAuthor"].ToString();
                this.ISBN = reader["BookISBN"].ToString();
                this.Year = long.Parse(reader["BookYear"].ToString());
                this.Edition = long.Parse(reader["BookEdition"].ToString());
                this.NoofCopies = long.Parse(reader["BookNoofCopies"].ToString());
            }
            else
            {
                this.BookCode = "";
            }
            connection.Close();
        }

        public void AddBook()
        {
            SqlCommand cmd = new SqlCommand("sp_SaveBook", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EntryMode", "Add");
            cmd.Parameters.AddWithValue("@BookCode", this.BookCode);
            cmd.Parameters.AddWithValue("@BookTitle", this.BookTitle);
            cmd.Parameters.AddWithValue("@BookAuthor", this.Author);
            cmd.Parameters.AddWithValue("@BookISBN", this.ISBN);
            cmd.Parameters.AddWithValue("@BookYear", this.Year);
            cmd.Parameters.AddWithValue("@BookEdition", this.Edition);
            cmd.Parameters.AddWithValue("@BookNoofCopies", this.NoofCopies);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }
        public void UpdateBook()
        {
            SqlCommand cmd = new SqlCommand("sp_SaveBook", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EntryMode", "Update");
            cmd.Parameters.AddWithValue("@BookCode", this.BookCode);
            cmd.Parameters.AddWithValue("@BookTitle", this.BookTitle);
            cmd.Parameters.AddWithValue("@BookAuthor", this.Author);
            cmd.Parameters.AddWithValue("@BookISBN", this.ISBN);
            cmd.Parameters.AddWithValue("@BookYear", this.Year);
            cmd.Parameters.AddWithValue("@BookEdition", this.Edition);
            cmd.Parameters.AddWithValue("@BookNoofCopies", this.NoofCopies);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void DeleteBook()
        {

            SqlCommand cmd = new SqlCommand("sp_DeleteBook", connection);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookCode", this.BookCode);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}


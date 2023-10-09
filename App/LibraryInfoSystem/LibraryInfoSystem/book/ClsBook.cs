using System.Data;
using System.Data.SqlClient;

namespace LibraryInfoSystem
{
    public class ClsBook
    {
        public string? BookID { get; set; }
        public string? BookName { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public int Edition { get; set; }

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

                    book.BookID = reader["book_ID"].ToString().Trim();
                    book.BookName = reader["book_Name"].ToString();
                    book.Author = reader["book_Author"].ToString();
                    book.Description = reader["book_Description"].ToString();
                    book.Edition = Convert.ToInt32(reader["edition"]);
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
            cmd.Parameters.AddWithValue("@book_ID", this.BookID);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null && reader.HasRows)
            {
                reader.Read();
                this.BookID = reader["book_ID"].ToString().Trim();
                this.BookName = reader["book_Name"].ToString();
                this.Author = reader["book_Author"].ToString();
                this.Description = reader["book_Description"].ToString();
                this.Edition = Convert.ToInt32(reader["edition"]);
            }
            else
            {
                this.BookID = "";
            }
            connection.Close();
        }

        public void AddBook()
        {
            SqlCommand cmd = new SqlCommand("sp_SaveBook", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EntryMode", "Add");
            cmd.Parameters.AddWithValue("@book_ID", this.BookID);
            cmd.Parameters.AddWithValue("@book_Name", this.BookName);
            cmd.Parameters.AddWithValue("@book_Author", this.Author);
            cmd.Parameters.AddWithValue("@book_Description", this.Description);
            cmd.Parameters.AddWithValue("@edition", this.Edition);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }
        public void UpdateBook()
        {
            SqlCommand cmd = new SqlCommand("sp_SaveBook", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EntryMode", "Update");
            cmd.Parameters.AddWithValue("@book_ID", this.BookID);
            cmd.Parameters.AddWithValue("@book_Name", this.BookName);
            cmd.Parameters.AddWithValue("@book_Author", this.Author);
            cmd.Parameters.AddWithValue("@book_Description", this.Description);
            cmd.Parameters.AddWithValue("@edition", this.Edition);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void DeleteBook()
        {

            SqlCommand cmd = new SqlCommand("sp_DeleteBook", connection);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@book_ID", this.BookID);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}


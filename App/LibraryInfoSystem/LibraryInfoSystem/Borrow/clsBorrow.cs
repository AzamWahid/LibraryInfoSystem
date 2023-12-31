﻿using System;
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
        public long BorrowDays { get; set; }

        private readonly SqlConnection connection;
        public ClsBorrow()
        {
            string connectionString = clsGeneral.getConnectionString();
            connection = new SqlConnection(connectionString);
        }
        public List<ClsBook> GetAvaBooks()
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
                    ClsBook book = new ClsBook();

                    book.BookID = long.Parse(reader["BookID"].ToString());
                    book.BookCode = reader["BookCode"].ToString();
                    book.BookTitle = reader["BookTitle"].ToString();
                    book.Author = reader["BookAuthor"].ToString();
                    book.ISBN = reader["BookISBN"].ToString();
                    book.Edition = long.Parse(reader["BookEdition"].ToString());
                    book.Year = long.Parse(reader["BookYear"].ToString());
                    book.NoofCopies = long.Parse(reader["remainingCopies"].ToString());

                    bookList.Add(book);
                }
            }
            connection.Close();
            return bookList;
        }
        public void GetBorrowNo()
        {
            SqlCommand cmd = new SqlCommand("sp_GetUserBorrowNo", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UID", this.BorrowUID);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            this.BorrowNo = long.Parse(reader["BorrowNo"].ToString());
            connection.Close();

        }
        public bool ChectAlreadyBorrow(long _BookID)
        {
            SqlCommand cmd = new SqlCommand("Sp_ChectAlreadyBorrow", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UID", this.BorrowUID);
            cmd.Parameters.AddWithValue("@BookID", _BookID);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();


            if (reader != null && reader.HasRows)
            {
                reader.Read();
 
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }

        }
        public void SaveBorrow()
        {
            SqlCommand cmd = new SqlCommand("sp_SaveBorrow", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BorrowNo", this.BorrowNo);
            cmd.Parameters.AddWithValue("@BorrowDate", this.BorrowDate);
            cmd.Parameters.AddWithValue("@BorrowUID", this.BorrowUID);
            cmd.Parameters.AddWithValue("@BorrowBookID", this.BorrowBookID);
            cmd.Parameters.AddWithValue("@BorrowDays", this.BorrowDays);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }
    }
}

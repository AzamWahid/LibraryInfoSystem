using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfoSystem.Borrow
{
    public class clsLateReturnReport
    {

        public DateTime? BBRefDate { get; set; }
        public long? BBDays { get; set; }
        public DateTime? BRRefDate { get; set; }
        public long? late_Days { get; set; }
        public string? BookTitle { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public long Edition { get; set; }
        public long? Year { get; set; }
        public string? fineImpose { get; set; }
        public string? UEmail { get; set; }
        public string? UName { get; set; }
        public string? UMobileNo { get; set; }

        private readonly SqlConnection connection;
        public clsLateReturnReport()
        {
            string connectionString = clsGeneral.getConnectionString();
            connection = new SqlConnection(connectionString);
        }
        public List<clsLateReturnReport> GetBorrowList()
        {

            List<clsLateReturnReport> borrowList = new List<clsLateReturnReport>();
            SqlCommand cmd = new SqlCommand("Sp_Rpt_LateReturn", connection);


            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null)
            {
                while (reader.Read())
                {
                    clsLateReturnReport borrow = new clsLateReturnReport();

                    borrow.BBRefDate = DateTime.Parse(reader["BBRefDate"].ToString());
                    borrow.BBDays = long.Parse(reader["BBDays"].ToString());
                    borrow.BRRefDate = DateTime.Parse(reader["BRRefDate"].ToString());
                    borrow.late_Days = long.Parse(reader["late_Days"].ToString());
                    borrow.BookTitle = reader["BookTitle"].ToString();
                    borrow.Author = reader["BookAuthor"].ToString();
                    borrow.ISBN = reader["BookISBN"].ToString();
                    borrow.Edition = long.Parse(reader["BookEdition"].ToString());
                    borrow.Year = long.Parse(reader["BookYear"].ToString());
                    borrow.fineImpose = reader["fineImpose"].ToString();
                    borrow.UEmail = reader["UEmail"].ToString();
                    borrow.UName = reader["UName"].ToString();
                    borrow.UMobileNo = reader["UMobileNo"].ToString();

                    borrowList.Add(borrow);
                }
            }
            connection.Close();
            return borrowList;
        }
   
    }
}

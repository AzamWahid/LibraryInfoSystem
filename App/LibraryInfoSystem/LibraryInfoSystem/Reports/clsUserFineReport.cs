using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfoSystem.Borrow
{
    public class clsUserFineReport
    {
        public long? UID { get; set; }
        public DateTime? IFineRefDate { get; set; }
        public DateTime? BorrowDate { get; set; }
        public long? BorrowDays { get; set; }
        public DateTime? BorrowRetDate { get; set; }
        public long? LateDays { get; set; }
        public string? BookTitle { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public long? Edition { get; set; }
        public long? Year { get; set; }
        public decimal? FineAmnt { get; set; }

        private readonly SqlConnection connection;
        public clsUserFineReport()
        {
            string connectionString = clsGeneral.getConnectionString();
            connection = new SqlConnection(connectionString);
        }
        public List<clsUserFineReport> GetImposeFineList()
        {

            List<clsUserFineReport> FinePayList = new List<clsUserFineReport>();
            SqlCommand cmd = new SqlCommand("Sp_GetUserImposeFine", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UID", this.UID);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();



            if (reader != null && reader.HasRows)
            {


                while (reader.Read())
                {
                    clsUserFineReport finePay = new clsUserFineReport();

                    finePay.IFineRefDate = DateTime.Parse(reader["IFRefDate"].ToString());
                    finePay.BorrowDate = DateTime.Parse(reader["BBRefDate"].ToString());
                    finePay.BorrowDays = long.Parse(reader["BBDays"].ToString());
                    finePay.BorrowRetDate = DateTime.Parse(reader["BRRefDate"].ToString());
                    finePay.BookTitle = reader["BookTitle"].ToString();
                    finePay.Author = reader["BookAuthor"].ToString();
                    finePay.ISBN = reader["BookISBN"].ToString();
                    finePay.Edition = long.Parse(reader["BookEdition"].ToString());
                    finePay.Year = long.Parse(reader["BookYear"].ToString());
                    finePay.LateDays = long.Parse(reader["late_Days"].ToString());
                    finePay.FineAmnt = decimal.Parse(reader["IFAmnt"].ToString());

                    FinePayList.Add(finePay);
                }
            }
            connection.Close();
            return FinePayList;
        }
    }
}

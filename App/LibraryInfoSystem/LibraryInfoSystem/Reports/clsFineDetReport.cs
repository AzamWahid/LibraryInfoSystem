using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfoSystem.Borrow
{
    public class clsFineDetReport
    {

        public DateTime? IFRefDate { get; set; }
        public string? UEmail { get; set; }
        public string? UName { get; set; }
        public string? UMobileNo { get; set; }
        public DateTime? BBRefDate { get; set; }
        public long? BBDays { get; set; }
        public DateTime? BRRefDate { get; set; }
        public long? late_Days { get; set; }
        public string? BookTitle { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public long Edition { get; set; }
        public long? Year { get; set; }
        public decimal? FineAmnt { get; set; }


        private readonly SqlConnection connection;
        public clsFineDetReport()
        {
            string connectionString = clsGeneral.getConnectionString();
            connection = new SqlConnection(connectionString);
        }
        public List<clsFineDetReport> GetImposeFineDetail()
        {

            List<clsFineDetReport> borrowList = new List<clsFineDetReport>();
            SqlCommand cmd = new SqlCommand("sp_Rpt_ImposeFineDetail", connection);

            cmd.Parameters.AddWithValue("@UEmail", this.UEmail);

            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null)
            {
                while (reader.Read())
                {
                    clsFineDetReport IFDet = new clsFineDetReport();

                    IFDet.IFRefDate = DateTime.Parse(reader["IFRefDate"].ToString());
                    IFDet.BBRefDate = DateTime.Parse(reader["BBRefDate"].ToString());
                    IFDet.BBDays = long.Parse(reader["BBDays"].ToString());
                    IFDet.BRRefDate = DateTime.Parse(reader["BRRefDate"].ToString());
                    IFDet.late_Days = long.Parse(reader["late_Days"].ToString());
                    IFDet.BookTitle = reader["BookTitle"].ToString();
                    IFDet.Author = reader["BookAuthor"].ToString();
                    IFDet.ISBN = reader["BookISBN"].ToString();
                    IFDet.Edition = long.Parse(reader["BookEdition"].ToString());
                    IFDet.Year = long.Parse(reader["BookYear"].ToString());
                    IFDet.UEmail = reader["UEmail"].ToString();
                    IFDet.UName = reader["UName"].ToString();
                    IFDet.UMobileNo = reader["UMobileNo"].ToString();
                    IFDet.FineAmnt = decimal.Parse(reader["IFAmnt"].ToString());

                    borrowList.Add(IFDet);
                }
            }
            connection.Close();
            return borrowList;
        }
   
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfoSystem.Borrow
{
    public class clsFinePay
    {
        public long? UID { get; set; }
        public long? FinePayRefNo { get; set; }
        public DateTime? FinePayRefDate { get; set; }
        public long? IFID {get; set; }
        public long? IFineRefNo { get; set; }
        public DateTime? IFineRefDate { get; set; }
        public long? BorrowID { get; set; }
        public long? BorrowNo { get; set; }
        public DateTime? BorrowDate { get; set; }
        public long? BorrowDays { get; set; }
        public long? BorrowRetID { get; set; }
        public long? BorrowRetNo { get; set; }
        public DateTime? BorrowRetDate { get; set; }
        public string? BookTitle { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public long? Year { get; set; }
        public long? Edition { get; set; }
        public char? BRFineYN { get; set; }
        public long? LateDays { get; set; }
        public decimal? FineAmnt { get; set; }

        private readonly SqlConnection connection;
        public clsFinePay()
        {
            string connectionString = clsGeneral.getConnectionString();
            connection = new SqlConnection(connectionString);
        }
        public List<clsFinePay> GetImposeFineList()
        {

            List<clsFinePay> FinePayList = new List<clsFinePay>();
            SqlCommand cmd = new SqlCommand("Sp_GetUserImposeFine", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UID", this.UID);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();



            if (reader != null && reader.HasRows)
            {


                while (reader.Read())
                {
                    clsFinePay finePay = new clsFinePay();

                    finePay.IFID = long.Parse(reader["IFID"].ToString());
                    finePay.IFineRefNo = long.Parse(reader["IFRefNo"].ToString());
                    finePay.IFineRefDate = DateTime.Parse(reader["IFRefDate"].ToString());
                    finePay.BorrowID = long.Parse(reader["BBID"].ToString());
                    finePay.BorrowNo = long.Parse(reader["BBRefNo"].ToString());
                    finePay.BorrowDate = DateTime.Parse(reader["BBRefDate"].ToString());
                    finePay.BorrowDays = long.Parse(reader["BBDays"].ToString());
                    finePay.BorrowRetID = long.Parse(reader["BRID"].ToString());
                    finePay.BorrowRetNo = long.Parse(reader["BRRefNo"].ToString());
                    finePay.BorrowRetDate = DateTime.Parse(reader["BRRefDate"].ToString());
                    finePay.BookTitle = reader["BookTitle"].ToString();
                    finePay.Author = reader["BookAuthor"].ToString();
                    finePay.ISBN = reader["BookISBN"].ToString();
                    finePay.Year = long.Parse(reader["BookYear"].ToString());
                    finePay.Edition = long.Parse(reader["BookEdition"].ToString());
                    finePay.LateDays = long.Parse(reader["late_Days"].ToString());
                    finePay.FineAmnt = decimal.Parse(reader["IFAmnt"].ToString());

                    FinePayList.Add(finePay);
                }
            }
            connection.Close();
            return FinePayList;
        }
        public void GetFinePayNo()
        {
            SqlCommand cmd = new SqlCommand("sp_GetFinePayNo", connection);
            cmd.CommandType = CommandType.StoredProcedure;


            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            this.FinePayRefNo = long.Parse(reader["FRefNo"].ToString());
            connection.Close();

        }

        public void SaveFinePay()
        {
            SqlCommand cmd = new SqlCommand("sp_SaveFinePay", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FRefNo", this.FinePayRefNo);
            cmd.Parameters.AddWithValue("@FRefDate", this.FinePayRefDate);
            cmd.Parameters.AddWithValue("@FIFID", this.IFID);
            cmd.Parameters.AddWithValue("@FAmnt", this.FineAmnt);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }
    }
}

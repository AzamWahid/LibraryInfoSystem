using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInfoSystem.Borrow
{
    public class clsFineMembersReport
    {
        public string? UEmail { get; set; }
        public string? UName { get; set; }
        public string? UMobileNo { get; set; }
        public decimal? FineAmnt { get; set; }

        private readonly SqlConnection connection;
        public clsFineMembersReport()
        {
            string connectionString = clsGeneral.getConnectionString();
            connection = new SqlConnection(connectionString);
        }
        public List<clsFineMembersReport> GetImposeFineMember()
        {

            List<clsFineMembersReport> ImposeFineList = new List<clsFineMembersReport>();
            SqlCommand cmd = new SqlCommand("sp_Rpt_ImposeFineMember", connection);


            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null)
            {
                while (reader.Read())
                {
                    clsFineMembersReport ImposeFine = new clsFineMembersReport();

                    ImposeFine.UEmail = reader["UEmail"].ToString();
                    ImposeFine.UName = reader["UName"].ToString();
                    ImposeFine.UMobileNo = reader["UMobileNo"].ToString();
                    ImposeFine.FineAmnt = decimal.Parse(reader["IFAmnt"].ToString());

                    ImposeFineList.Add(ImposeFine);
                }
            }
            connection.Close();
            return ImposeFineList;
        }
   
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseOperations
{
   
    public static class DatabaseMethods
    {
        private static SqlConnection connection_ = new SqlConnection("Data Source=LA-178\\SQLEXPRESS; Initial Catalog=NEWDESIGN; User Id=testeruser; password=qwer1234;");

        public static DataTable Select(string Query_)
        {
            DataTable dt_ = new DataTable();
            connection_.Open();
            SqlDataAdapter adptr = new SqlDataAdapter(Query_, connection_);
            adptr.Fill(dt_);
            connection_.Close();
            return dt_;
        }
    }
}

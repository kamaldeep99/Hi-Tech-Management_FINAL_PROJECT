using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Configuration;

namespace Hi_Tech_Management_FINAL_PROJECT.DAL
{
    public static class UtilityDB
    {
        public static SqlConnection connectDB()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["connectDB"].ConnectionString;
            conn.Open();
            return conn;
        }
    }
}

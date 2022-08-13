using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hi_Tech_Management_FINAL_PROJECT.BLL;
using System.Data.SqlClient;

namespace Hi_Tech_Management_FINAL_PROJECT.DAL
{
    public static class JobPositionDB
    {
        public static JobPositions GetRecord(int getDataByJobId)
        {
            SqlConnection connectDB = UtilityDB.connectDB();
            JobPositions job = new JobPositions();
            SqlCommand cmdSearch = new SqlCommand("SELECT * FROM JobPositions WHERE JobID = @JobId", connectDB);
            cmdSearch.Parameters.AddWithValue("@JobId", getDataByJobId);
            SqlDataReader sqlRead = cmdSearch.ExecuteReader();
            if (sqlRead.Read())
            {
                job.JobId = Convert.ToInt32(sqlRead["JobID"]);
                job.JobTitle = sqlRead["JobTitle"].ToString();
            }
            else
            {
                job = null;
            }

            return job;
        }
        public static List<JobPositions> GetRecordList()
        {
            List<JobPositions> listJob = new List<JobPositions>();
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM JobPositions", connDB);
            SqlDataReader sqlReader = cmdSelectAll.ExecuteReader();
            JobPositions job;
            while (sqlReader.Read())
            {
                job = new JobPositions();
                job.JobId = Convert.ToInt32(sqlReader["JobID"]);
                job.JobTitle = sqlReader["JobTitle"].ToString();
                listJob.Add(job);

            }
            connDB.Close();
            return listJob;
        }
    }
}

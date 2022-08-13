using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hi_Tech_Management_FINAL_PROJECT.DAL;

namespace Hi_Tech_Management_FINAL_PROJECT.BLL
{
    public class JobPositions
    {
        private int jobId;
        private string jobTitle;

        public int JobId { get => jobId; set => jobId = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }


        public JobPositions SearchJob(int getDataByJobId)
        {
            return JobPositionDB.GetRecord(getDataByJobId);
        }

        public List<JobPositions> SearchJobList()
        {
            return JobPositionDB.GetRecordList();
        }

    }
}

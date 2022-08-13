using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Hi_Tech_Management_FINAL_PROJECT.BLL;
using Hi_Tech_Management_FINAL_PROJECT.VALIDATION;
using Hi_Tech_Management_FINAL_PROJECT.DAL;


namespace Hi_Tech_Management_FINAL_PROJECT.GUI
{
    public partial class FormEmployeeManagement : Form
    {
        public FormEmployeeManagement()
        {
            InitializeComponent();
        }

        private void FormEmployeeManagement_Load(object sender, EventArgs e)
        {
            JobPositions job = new JobPositions();
            List<JobPositions> listJob = new List<JobPositions>();
            listJob = job.SearchJobList();
            foreach (var j in listJob)
            {
                comboBoxJobID.Items.Add(j.JobId + ", " + j.JobTitle);
            }

            Status status = new Status();
            List<Status> listStatus = status.SearchStatusList("Customer");
            foreach (var item in listStatus)
            {
                comboBoxStatusID.Items.Add(item.StatusId + ". " + item.State);
            }

        }
    }
}

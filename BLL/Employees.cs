using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hi_Tech_Management_FINAL_PROJECT.DAL;
namespace Hi_Tech_Management_FINAL_PROJECT.BLL
{
    public class Employees
    {
        private int employeeId;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string email;
        private int jobId;
        private int statusId;

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public int JobId { get => jobId; set => jobId = value; }
        public int StatusId { get => statusId; set => statusId = value; }

        public Employees()
        {
            EmployeeId = 0;
            FirstName = "";
            LastName = "";
            PhoneNumber = "";
            email = "";
        }

        public void SaveEmployee(Employees saveEmployee)
        {
            EmployeeDB.SaveRecord(saveEmployee);
        }
        public void UpdateEmployee(Employees updateEmployee)
        {
            EmployeeDB.UpdateRecord(updateEmployee);
        }
        public void DeleteEmployee(int deleteEmployeeId)
        {
            EmployeeDB.DeleteRecord(deleteEmployeeId);
        }
        public Employees SearchEmployee(int searchEmployeeId)
        {
            return EmployeeDB.GetRecord(searchEmployeeId);
        }
        public List<Employees> SearchAllEmployee()
        {
            return EmployeeDB.GetRecordList();
        }

        public List<Employees> SearchEmployeeByName(string name, string select)
        {
            return EmployeeDB.GetRecordListbyName(name, select);
        }

    }
}

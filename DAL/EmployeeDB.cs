using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hi_Tech_Management_FINAL_PROJECT.BLL;
using System.Data.SqlClient;

namespace Hi_Tech_Management_FINAL_PROJECT.DAL
{
    public class EmployeeDB
    {
        public static void SaveRecord(Employees saveEmployee)
        {
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdInsert = new SqlCommand("INSERT INTO Employees(EmployeeID,FirstName,LastName,PhoneNumber,Email,JobID,StatusID) VALUES(@EmployeeId,@FirstName,@LastName,@PhoneNumber,@Email,@JobId,@StatusId);", connDB);
            cmdInsert.Parameters.AddWithValue("@EmployeeID", saveEmployee.EmployeeId);
            cmdInsert.Parameters.AddWithValue("@FirstName", saveEmployee.FirstName);
            cmdInsert.Parameters.AddWithValue("@LastName", saveEmployee.LastName);
            cmdInsert.Parameters.AddWithValue("@PhoneNumber", saveEmployee.PhoneNumber);
            cmdInsert.Parameters.AddWithValue("@Email", saveEmployee.Email);
            cmdInsert.Parameters.AddWithValue("@JobID", saveEmployee.JobId);
            cmdInsert.Parameters.AddWithValue("@StatusID", saveEmployee.StatusId);
            cmdInsert.ExecuteNonQuery();
            connDB.Close();
        }

        public static void UpdateRecord(Employees updateEmployee)
        {
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdUpdate = new SqlCommand("UPDATE Employees SET FirstName = @FirstName, LastName = @LastName,PhoneNumber = @PhoneNumber, Email = @Email, JobID = @JobID WHERE EmployeeID = @EmployeeID", connDB);
            cmdUpdate.Parameters.AddWithValue("@EmployeeID", updateEmployee.EmployeeId);
            cmdUpdate.Parameters.AddWithValue("@FirstName", updateEmployee.FirstName);
            cmdUpdate.Parameters.AddWithValue("@LastName", updateEmployee.LastName);
            cmdUpdate.Parameters.AddWithValue("@PhoneNumber", updateEmployee.PhoneNumber);
            cmdUpdate.Parameters.AddWithValue("@Email", updateEmployee.Email);
            cmdUpdate.Parameters.AddWithValue("@JobID", updateEmployee.JobId);
            cmdUpdate.Parameters.AddWithValue("@StatusID", updateEmployee.StatusId);
            cmdUpdate.ExecuteNonQuery();
            connDB.Close();

        }

        public static void DeleteRecord(int deleteEmployeeId)
        {
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdDelete = new SqlCommand("DELETE FROM Employees WHERE EmployeeID = @EmployeeID", connDB);
            cmdDelete.Parameters.AddWithValue("@EmployeeID", deleteEmployeeId);
            cmdDelete.ExecuteNonQuery();
            connDB.Close();
        }

        public static Employees GetRecord(int searchEmployeeId)
        {
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Employees WHERE EmployeeID = @EmployeeID", connDB);
            cmdSelect.Parameters.AddWithValue("@EmployeeID", searchEmployeeId);
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            Employees getEmployee = new Employees();
            if (sqlReader.Read())
            {
                getEmployee.EmployeeId = Convert.ToInt32(sqlReader["EmployeeID"]);
                getEmployee.FirstName = sqlReader["FirstName"].ToString();
                getEmployee.LastName = sqlReader["LastName"].ToString();
                getEmployee.PhoneNumber = sqlReader["PhoneNumber"].ToString();
                getEmployee.Email = sqlReader["Email"].ToString();
                getEmployee.JobId = Convert.ToInt32(sqlReader["JobID"]);
                getEmployee.StatusId = Convert.ToInt32(sqlReader["StatusId"]);
            }
            else
            {
                getEmployee = null;

            }
            connDB.Close();
            return getEmployee;
        }

        public static List<Employees> GetRecordList()
        {
            List<Employees> listEmployee = new List<Employees>();
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Employees", connDB);
            SqlDataReader sqlReader = cmdSelectAll.ExecuteReader();
            Employees getEmployee;
            while (sqlReader.Read())
            {
                getEmployee = new Employees();
                getEmployee.EmployeeId = Convert.ToInt32(sqlReader["EmployeeID"]);
                getEmployee.FirstName = sqlReader["FirstName"].ToString();
                getEmployee.LastName = sqlReader["LastName"].ToString();
                getEmployee.PhoneNumber = sqlReader["PhoneNumber"].ToString();
                getEmployee.Email = sqlReader["Email"].ToString();
                getEmployee.JobId = Convert.ToInt32(sqlReader["JobID"]);
                getEmployee.StatusId = Convert.ToInt32(sqlReader["StatusID"]);
                listEmployee.Add(getEmployee);

            }
            connDB.Close();
            return listEmployee;
        }


        public static List<Employees> GetRecordListbyName(string employeeName, string select)
        {
            List<Employees> listEmp = new List<Employees>();
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdSelectName = new SqlCommand("SELECT * FROM Employees " + "WHERE " + select + " = @Name ", connDB);
            cmdSelectName.Parameters.AddWithValue("@Name", employeeName);
            SqlDataReader sqlReader = cmdSelectName.ExecuteReader();
            Employees getEmployeeByName;
            while (sqlReader.Read())
            {
                getEmployeeByName = new Employees();
                getEmployeeByName.EmployeeId = Convert.ToInt32(sqlReader["EmployeeID"]);
                getEmployeeByName.FirstName = sqlReader["FirstName"].ToString();
                getEmployeeByName.LastName = sqlReader["LastName"].ToString();
                getEmployeeByName.PhoneNumber = sqlReader["PhoneNumber"].ToString();
                getEmployeeByName.Email = sqlReader["Email"].ToString();
                getEmployeeByName.JobId = Convert.ToInt32(sqlReader["JobID"]);
                getEmployeeByName.StatusId = Convert.ToInt32(sqlReader["StatusID"]);
                listEmp.Add(getEmployeeByName);

            }
            connDB.Close();
            return listEmp;
        }


    }
}

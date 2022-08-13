using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hi_Tech_Management_FINAL_PROJECT.BLL;
using System.Data.SqlClient;

namespace Hi_Tech_Management_FINAL_PROJECT.DAL
{
    public static class UserManagementDB
    {
        public static UserManagements SearchRecord(int UserId, string password)
        {
            SqlConnection connectDB = UtilityDB.connectDB();
            UserManagements searchUserByUserIdPassword = new UserManagements();
            SqlCommand cmdSearch = new SqlCommand("SELECT * FROM UserAccounts WHERE UserID = @UserID AND Password = @Password", connectDB);
            cmdSearch.Parameters.AddWithValue("@UserID", UserId);
            cmdSearch.Parameters.AddWithValue("@Password", password);
            SqlDataReader sqlRead = cmdSearch.ExecuteReader();
            if (sqlRead.Read())
            {
                searchUserByUserIdPassword.UserId = Convert.ToInt32(sqlRead["UserID"]);
                searchUserByUserIdPassword.Password = sqlRead["Password"].ToString();
                searchUserByUserIdPassword.EmployeeId = Convert.ToInt32(sqlRead["EmployeeID"]);
            }
            else
            {
                searchUserByUserIdPassword = null;
            }

            return searchUserByUserIdPassword;
        }
        public static UserManagements SearchRecord(int searchByUserId)
        {
            SqlConnection connectDB = UtilityDB.connectDB();
            UserManagements searchUserByUserId = new UserManagements();
            SqlCommand cmdSearch = new SqlCommand("SELECT * FROM UserAccounts WHERE UserID = @UserID", connectDB);
            cmdSearch.Parameters.AddWithValue("@UserID", searchByUserId);
            SqlDataReader sqlRead = cmdSearch.ExecuteReader();
            if (sqlRead.Read())
            {
                searchUserByUserId.UserId = Convert.ToInt32(sqlRead["UserID"]);
                searchUserByUserId.Password = sqlRead["Password"].ToString();
                searchUserByUserId.EmployeeId = Convert.ToInt32(sqlRead["EmployeeID"]);
            }
            else
            {
                searchUserByUserId = null;
            }

            return searchUserByUserId;
        }

        public static UserManagements SearchRecordByEmpId(int searchByEmployeeId)
        {
            SqlConnection connectDB = UtilityDB.connectDB();
            UserManagements searchUserByEmployeeId = new UserManagements();
            SqlCommand cmdSearch = new SqlCommand("SELECT * FROM UserAccounts WHERE EmployeeID = @EmployeeID", connectDB);
            cmdSearch.Parameters.AddWithValue("@EmployeeID", searchByEmployeeId);
            SqlDataReader sqlRead = cmdSearch.ExecuteReader();
            if (sqlRead.Read())
            {
                searchUserByEmployeeId.UserId = Convert.ToInt32(sqlRead["UserID"]);
                searchUserByEmployeeId.Password = sqlRead["Password"].ToString();
                searchUserByEmployeeId.EmployeeId = Convert.ToInt32(sqlRead["EmployeeID"]);

            }
            else
            {
                searchUserByEmployeeId = null;
            }

            return searchUserByEmployeeId;
        }

        public static void SaveRecord(UserManagements saveUser)
        {
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdInsert = new SqlCommand("INSERT INTO UserAccounts (UserId,Password,EmployeeID) VALUES(@UserID,@Password,@EmployeeID);", connDB);
            cmdInsert.Parameters.AddWithValue("@UserID", saveUser.UserId);
            cmdInsert.Parameters.AddWithValue("@Password", saveUser.Password);
            cmdInsert.Parameters.AddWithValue("@EmployeeID", saveUser.EmployeeId);
            cmdInsert.ExecuteNonQuery();
            connDB.Close();
        }
        public static void UpdateRecord(UserManagements updateUser)
        {
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdUpdate = new SqlCommand("UPDATE UserAccounts SET Password = @Password, EmployeeID = @EmployeeID WHERE UserID = @UserID", connDB);
            cmdUpdate.Parameters.AddWithValue("@UserID", updateUser.UserId);
            cmdUpdate.Parameters.AddWithValue("@Password", updateUser.Password);
            cmdUpdate.Parameters.AddWithValue("@EmployeeID", updateUser.EmployeeId);
            cmdUpdate.ExecuteNonQuery();
            connDB.Close();
        }

        public static void DeleteRecord(int deleteUserByID)
        {
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdDelete = new SqlCommand("DELETE FROM UserAccounts WHERE UserID = @UserID", connDB);
            cmdDelete.Parameters.AddWithValue("@UserID", deleteUserByID);
            cmdDelete.ExecuteNonQuery();
            connDB.Close();
        }
        public static List<UserManagements> GetRecordList()
        {
            List<UserManagements> listUser = new List<UserManagements>();
            SqlConnection connDB = UtilityDB.connectDB();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM UserAccounts", connDB);
            SqlDataReader sqlReader = cmdSelectAll.ExecuteReader();
            UserManagements getAllUser;
            while (sqlReader.Read())
            {
                getAllUser = new UserManagements();
                getAllUser.UserId = Convert.ToInt32(sqlReader["UserID"]);
                getAllUser.Password = sqlReader["Password"].ToString();
                getAllUser.EmployeeId = Convert.ToInt32(sqlReader["EmployeeID"]);
                listUser.Add(getAllUser);

            }
            connDB.Close();
            return listUser;
        }



    }
}

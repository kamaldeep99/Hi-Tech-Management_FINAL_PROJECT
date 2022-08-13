using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hi_Tech_Management_FINAL_PROJECT.DAL;

namespace Hi_Tech_Management_FINAL_PROJECT.BLL
{
    public class UserManagements
    {
        private int userId;
        private string password;
        private int employeeId;

        public int UserId { get => userId; set => userId = value; }
        public string Password { get => password; set => password = value; }
        public int EmployeeId { get => employeeId; set => employeeId = value; }


        public UserManagements SearchUserManagement(int UserId, string password)
        {
            return UserManagementDB.SearchRecord(UserId, password);
        }
        public UserManagements SearchUserManagement(int searchByUserId)
        {
            return UserManagementDB.SearchRecord(searchByUserId);
        }
        public UserManagements SearchUserManagementByEmpId(int searchByEmployeeId)
        {
            return UserManagementDB.SearchRecordByEmpId(searchByEmployeeId);
        }
        public void SaveUser(UserManagements saveUser)
        {
            UserManagementDB.SaveRecord(saveUser);
        }
        public void UpdateUser(UserManagements updateUser)
        {
            UserManagementDB.UpdateRecord(updateUser);
        }
        public void DeleteUser(int deleteUserByID)
        {
            UserManagementDB.DeleteRecord(deleteUserByID);
        }
        public List<UserManagements> SearchAllUser()
        {
            return UserManagementDB.GetRecordList();
        }

    }
}

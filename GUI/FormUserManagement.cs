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


namespace Hi_Tech_Management_FINAL_PROJECT.GUI
{
    public partial class FormUserManagement : Form
    {
        public FormUserManagement()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult ex = MessageBox.Show("\nDo you really want to exit ? ", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ex == DialogResult.Yes)
            {
                Application.ExitThread();
            }


        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string userId = textBoxUserID.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            string employeeId = textBoxEmployeeDetail.Text.Trim();
            if (Validator.IsEmpty(userId))
            {
                MessageBox.Show("User ID is empty.", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Focus();
                return;
            }

            if (Validator.IsEmpty(password))
            {
                MessageBox.Show("Password is empty.", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Focus();
                return;
            }

            if (Validator.IsEmpty(employeeId))
            {
                MessageBox.Show("Employee ID is empty.", "Error.....", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeDetail.Focus();
                return;
            }

            if (!Validator.IsValidId(userId, 4))
            {
                MessageBox.Show("User ID is a 4-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxUserID.Focus();
                return;
            }

            if (!Validator.IsValidId(employeeId, 4))
            {
                MessageBox.Show("Employee ID is a 4-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeDetail.Clear();
                textBoxEmployeeDetail.Focus();
                return;
            }

            UserManagements user = new UserManagements();
            user = user.SearchUserManagement(Convert.ToInt32(userId));
            if (user != null)
            {
                MessageBox.Show("This User ID already exist.", "Duplicate User ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxUserID.Focus();
                return;
            }

            Employees emp = new Employees();
            emp = emp.SearchEmployee(Convert.ToInt32(employeeId));
            if (emp == null)
            {
                MessageBox.Show("This Employee ID does not exist.", "Non-exist Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeDetail.Clear();
                textBoxEmployeeDetail.Focus();
                return;
            }

            UserManagements oldUser = new UserManagements();
            oldUser = oldUser.SearchUserManagementByEmpId(Convert.ToInt32(employeeId));
            if (oldUser != null)
            {
                MessageBox.Show("This Employee ID already has an User Account.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxPassword.Clear();
                textBoxEmployeeDetail.Clear();
                textBoxUserID.Focus();
                return;
            }

            if (MessageBox.Show("Do you want to save this user? ", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                UserManagements userSave = new UserManagements();
                userSave.EmployeeId = Convert.ToInt32(employeeId);
                userSave.Password = password;
                userSave.UserId = Convert.ToInt32(userId);
                userSave.SaveUser(userSave);
                MessageBox.Show("User has been saved successfully.", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("User has NOT been saved.", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxUserID.Clear();
            textBoxPassword.Clear();
            textBoxEmployeeDetail.Clear();
            textBoxUserID.Focus();


        }

        private void buttonListUser_Click(object sender, EventArgs e)
        {
            listViewUsers.Items.Clear();
            List<UserManagements> listUser = new List<UserManagements>();
            UserManagements user = new UserManagements();
            listUser = user.SearchAllUser();
            if (listUser.Count != 0)
            {
                foreach (UserManagements uA in listUser)
                {
                    ListViewItem item = new ListViewItem(uA.UserId.ToString());
                    item.SubItems.Add(uA.Password);
                    item.SubItems.Add(uA.EmployeeId.ToString());
                    listViewUsers.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("No user to list.", "Empty User Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            string User_Id = textBoxUserID.Text.Trim();
            string pw = textBoxPassword.Text.Trim();
            string empId = textBoxEmployeeDetail.Text.Trim();
            if (Validator.IsEmpty(User_Id))
            {
                MessageBox.Show("User ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Focus();
                return;
            }

            if (Validator.IsEmpty(pw))
            {
                MessageBox.Show("Password is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Focus();
                return;
            }

            if (Validator.IsEmpty(empId))
            {
                MessageBox.Show("Employee ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeDetail.Focus();
                return;
            }

            UserManagements user = new UserManagements();
            user = user.SearchUserManagement(Convert.ToInt32(User_Id));
            if (user == null)
            {
                MessageBox.Show("User ID does not exist.", "Non-exist User ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxUserID.Focus();
                return;
            }

            if (user.EmployeeId != Convert.ToInt32(empId))
            {
                MessageBox.Show("Employee ID cannot be updated.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeDetail.Clear();
                textBoxEmployeeDetail.Focus();
                return;
            }

            Employees emp = new Employees();
            emp = emp.SearchEmployee(Convert.ToInt32(empId));
            if (emp == null)
            {
                MessageBox.Show("This Employee ID does not exist", "Non-exist Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeDetail.Clear();
                textBoxEmployeeDetail.Focus();
                return;
            }

            if (MessageBox.Show("Do you want to update this User Information?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                UserManagements userUpdate = new UserManagements();
                userUpdate.UserId = Convert.ToInt32(User_Id);
                userUpdate.Password = pw;
                userUpdate.EmployeeId = Convert.ToInt32(empId);
                userUpdate.UpdateUser(userUpdate);
                MessageBox.Show("User has been updated.", "Update Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nothing has been updated.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxUserID.Clear();
            textBoxEmployeeDetail.Clear();
            textBoxPassword.Clear();
            textBoxUserID.Focus();

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string User_Id = textBoxUserID.Text.Trim();
            string pw = textBoxPassword.Text.Trim();
            string empId = textBoxEmployeeDetail.Text.Trim();
            if (Validator.IsEmpty(User_Id))
            {
                MessageBox.Show("User ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Focus();
                return;
            }

            if (Validator.IsEmpty(pw))
            {
                MessageBox.Show("Password is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Focus();
                return;
            }

            if (Validator.IsEmpty(empId))
            {
                MessageBox.Show("Employee ID is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeDetail.Focus();
                return;
            }

            if (!Validator.IsValidId(User_Id, 4))
            {
                MessageBox.Show("User ID is a 4-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxUserID.Focus();
                return;
            }

            if (!Validator.IsValidId(empId, 4))
            {
                MessageBox.Show("Employee ID is a 4-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeDetail.Clear();
                textBoxEmployeeDetail.Focus();
                return;
            }

            UserManagements user = new UserManagements();
            user = user.SearchUserManagement(Convert.ToInt32(User_Id));
            if (user == null)
            {
                MessageBox.Show("This User ID does not exist.", "Non-exist User ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxUserID.Focus();
                return;
            }

            Employees emp = new Employees();
            emp = emp.SearchEmployee(Convert.ToInt32(empId));
            JobPositions job = new JobPositions();
            job = job.SearchJob(emp.JobId);
            string jobTitle = job.JobTitle;
            if (jobTitle == "MIS Manager")
            {
                MessageBox.Show("Cannot delete a MIS Manager account. You may want to update this user account!", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxEmployeeDetail.Clear();
                textBoxPassword.Clear();
                textBoxUserID.Focus();
                return;
            }
            else if (jobTitle == "Order Clerks")
            {
                MessageBox.Show("Cannot delete an Order Clerk account. You may want to update this user account!", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxEmployeeDetail.Clear();
                textBoxPassword.Clear();
                textBoxUserID.Focus();
                return;
            }

            if (MessageBox.Show("Do you want to delete this user? ", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                user.DeleteUser(Convert.ToInt32(User_Id));
                MessageBox.Show("User has been deleted successfully.", "Delete Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("User has NOT been deleted.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBoxUserID.Clear();
            textBoxEmployeeDetail.Clear();
            textBoxPassword.Clear();
            textBoxUserID.Focus();


        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            textBoxUserID.Clear();
            textBoxPassword.Clear();
            textBoxEmployeeDetail.Clear();
            string input = textBoxSearchByInput.Text.Trim();
            if (Validator.IsEmpty(input))
            {
                MessageBox.Show("Input is empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSearchByInput.Focus();
                return;
            }
            if (!Validator.IsValidId(input, 4))
            {
                MessageBox.Show("Please input a 4-digit number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserID.Clear();
                textBoxUserID.Focus();
                return;
            }

            //When data is valid
            int select = comboBoxSearchBy.SelectedIndex;
            switch (select)
            {
                case -1:
                    MessageBox.Show("Please choose an option.", "Empty Option", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBoxSearchBy.Focus();
                    break;
                case 0:
                    int uId = Convert.ToInt32(input);
                    UserManagements userSearch = new UserManagements();
                    userSearch = userSearch.SearchUserManagement(uId);
                    if (userSearch == null)
                    {
                        MessageBox.Show("This User ID does not exist.", "Non-exist User ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSearchByInput.Clear();
                        textBoxSearchByInput.Focus();
                        return;
                    }
                    else
                    {
                        textBoxUserID.Text = userSearch.UserId.ToString();
                        textBoxPassword.Text = userSearch.Password;
                        textBoxEmployeeDetail.Text = userSearch.EmployeeId.ToString();
                        textBoxSearchByInput.Clear();
                        comboBoxSearchBy.SelectedIndex = -1;
                    }
                    break;
                case 1:
                    int eId = Convert.ToInt32(input);
                    UserManagements userSearch1 = new UserManagements();
                    userSearch1 = userSearch1.SearchUserManagementByEmpId(eId);
                    if (userSearch1 == null)
                    {
                        MessageBox.Show("This Employee ID does not exist or does not has an account.", "Non-exist Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSearchByInput.Clear();
                        textBoxSearchByInput.Focus();
                        return;
                    }
                    else
                    {
                        textBoxUserID.Text = userSearch1.UserId.ToString();
                        textBoxPassword.Text = userSearch1.Password;
                        textBoxEmployeeDetail.Text = userSearch1.EmployeeId.ToString();
                        textBoxSearchByInput.Clear();
                        comboBoxSearchBy.SelectedIndex = -1;
                    }
                    break;

            }
        }
    }
}

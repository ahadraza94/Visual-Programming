using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
namespace Lab05
{
    public partial class Form1 : Form
    {
        // SQL Connection 
        SqlConnection con =  new SqlConnection("Data Source=DESKTOP-VU440JU;Initial Catalog=LAB05; Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"INSERT INTO EmpTable (EmpID, EmployeeName, DateOfBirth, Email, Address, DepartmentID)
                         VALUES (@EmpID, @EmployeeName, @DateOfBirth, @Email, @Address, @DepartmentID)";

                string empID = textBox1.Text;
                string employeeName = textBox2.Text;
                string dateOfBirth = textBox3.Text;
                string email = textBox4.Text;
                string address = textBox5.Text;
                string departmentID = textBox6.Text;

                // Check if any of the text fields are empty
                if (string.IsNullOrWhiteSpace(employeeName) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(departmentID))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return; // Exit the method without performing the insertion
                }

                // Check if DepartmentID exists in DeptTable
                if (!CheckDepartmentIDExists(departmentID))
                {
                    MessageBox.Show("DepartmentID does not exist in DeptTable.");
                    return; // Exit the method without performing the insertion
                }

                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@EmpID", empID);
                cmd.Parameters.AddWithValue("@EmployeeName", employeeName);
                cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@DepartmentID", departmentID);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Employee record successfully inserted.");
                    // Call a method to update the UI or refresh the employee list
                }
                else
                {
                    MessageBox.Show("Failed to insert employee record.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private bool CheckDepartmentIDExists(string departmentID)
        {
            try
            {
                con.Open(); // Open the connection

                string query = "SELECT COUNT(*) FROM DeptTable WHERE DepartID = @DepartmentID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@DepartmentID", departmentID);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            finally
            {
                con.Close(); // Close the connection in a finally block to ensure it always happens, even if an exception occurs
            }
        }
    }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"INSERT INTO DeptTable (DepartID, DepartmentName, Location, Budget, StartDate, ManagerID)
                        VALUES (@DepartID, @DepartmentName, @Location, @Budget, @StartDate, @ManagerID)";

                string departID = textBox8.Text;
                string departmentName = textBox9.Text;
                string location = textBox10.Text;
                string budget = textBox11.Text;
                string startDate = textBox12.Text;
                string managerID = textBox7.Text;

                // Check if any of the text fields are empty
                if (string.IsNullOrWhiteSpace(departmentName) || string.IsNullOrWhiteSpace(location) || string.IsNullOrWhiteSpace(budget) || string.IsNullOrWhiteSpace(managerID))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return; // Exit the method without performing the insertion
                }

                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DepartID", departID);
                cmd.Parameters.AddWithValue("@DepartmentName", departmentName);
                cmd.Parameters.AddWithValue("@Location", location);
                cmd.Parameters.AddWithValue("@Budget", budget);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@ManagerID", managerID);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Department record successfully inserted.");
                    // Call a method to update the UI or refresh the department list
                }
                else
                {
                    MessageBox.Show("Failed to insert department record.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}

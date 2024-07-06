using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Assignment01
{
    public partial class Form1 : Form
    {
        // SQL Connection 
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VU440JU; Initial Catalog=Assignment01; Integrated Security=True");
        DataTable dt;

        public Form1()
        {
            dt = new DataTable();
            dt.Columns.Add("Dept Name");
            dt.Columns.Add("Dept Location");
            dt.Columns.Add("Dept Address");
            dt.Columns.Add("Dept Admin");
            dt.Columns.Add("Admin Occupation");
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string departmentName = textBox1.Text;
                string departmentLocation = textBox2.Text;
                string departmentAddress = textBox3.Text;
                string departmentAdmin = textBox4.Text;
                string adminoccupation = textBox5.Text;

                // Check if any of the text fields are empty
                if (string.IsNullOrWhiteSpace(departmentName) || string.IsNullOrWhiteSpace(departmentLocation) || string.IsNullOrWhiteSpace(departmentAddress))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return; // Exit the method without performing the insertion
                }

                con.Open();
                string q = "INSERT INTO database01 (DepartmentName, DepartmentLocation, DepartmentAddress, DepartmentAdmin, Occupation) VALUES (@DepartmentName, @DepartmentLocation, @DepartmentAddress, @DepartmentAdmin, @Occupation)";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@DepartmentName", departmentName);
                cmd.Parameters.AddWithValue("@DepartmentLocation", departmentLocation);
                cmd.Parameters.AddWithValue("@DepartmentAddress", departmentAddress);
                cmd.Parameters.AddWithValue("@DepartmentAdmin", departmentAdmin);
                cmd.Parameters.AddWithValue("@Occupation", adminoccupation);

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Record Successfully Inserted");
                    AddDataRow(departmentName, departmentLocation, departmentAddress, departmentAdmin, adminoccupation);
                }
                else
                {
                    MessageBox.Show("Record Not Successfully Inserted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void AddDataRow(string name, string location, string address, string admin, string occupation)
        {
            DataRow dr = dt.NewRow();
            dr["Dept Name"] = name;
            dr["Dept Location"] = location;
            dr["Dept Address"] = address;
            dr["Dept Admin"] = admin;
            dr["Admin Occupation"] = occupation;
            dt.Rows.Add(dr);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string departmentName = textBox1.Text;
                string departmentLocation = textBox2.Text;
                string departmentAddress = textBox3.Text;
                string departmentAdmin = textBox4.Text;
                string adminoccupation = textBox5.Text;

                // Check if department name is provided
                if (string.IsNullOrWhiteSpace(departmentName))
                {
                    MessageBox.Show("Please provide a department name.");
                    return;
                }

                con.Open();

                // Construct the SQL update statement
                string q = "UPDATE database01 SET DepartmentLocation = @DepartmentLocation, DepartmentAddress = @DepartmentAddress, DepartmentAdmin = @DepartmentAdmin, Occupation = @Occupation WHERE DepartmentName = @DepartmentName";

                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@DepartmentLocation", departmentLocation);
                cmd.Parameters.AddWithValue("@DepartmentAddress", departmentAddress);
                cmd.Parameters.AddWithValue("@DepartmentAdmin", departmentAdmin);
                cmd.Parameters.AddWithValue("@Occupation", adminoccupation);
                cmd.Parameters.AddWithValue("@DepartmentName", departmentName);

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Record Successfully Updated");
                    // Optional: Update the corresponding row in the DataTable
                    UpdateDataRow(departmentName, departmentLocation, departmentAddress, departmentAdmin, adminoccupation);
                }
                else
                {
                    MessageBox.Show("Record Not Found or Not Updated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        // Update corresponding DataRow in DataTable
        private void UpdateDataRow(string name, string location, string address, string admin, string occupation)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Dept Name"].ToString() == name)
                {
                    dr["Dept Location"] = location;
                    dr["Dept Address"] = address;
                    dr["Dept Admin"] = admin;
                    dr["Admin Occupation"] = occupation;
                    break; // Exit loop once DataRow is updated
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}

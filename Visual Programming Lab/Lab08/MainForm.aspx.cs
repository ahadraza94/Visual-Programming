using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Lab08
{
    public partial class MainForm : System.Web.UI.Page
    {
        string connectionString = @"Data Source=DESKTOP-1T09T6V\SQLEXPRESS01;Initial Catalog=crudform;Integrated Security=True;TrustServerCertificate=True";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("insertdata", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@EmployeeID", txtid.Text);
                command.Parameters.AddWithValue("@EmployeeName", txtname.Text);
                command.Parameters.AddWithValue("@Gender", rblGender.SelectedItem.Text);

                try
                {
                    con.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM crudform", con);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();

                        Response.Write("Employee added successfully");
                    }
                    else
                    {
                        Response.Write("Employee not added successfully");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("An error occurred: " + ex.Message);
                }
            }

            txtid.Text = "";
            txtname.Text = "";
        }


        protected void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            string employeeIDToUpdate = txtid.Text;
            string newEmployeeName = txtname.Text;

            if (!string.IsNullOrEmpty(employeeIDToUpdate) && !string.IsNullOrEmpty(newEmployeeName))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("UPDATE crudform SET EmployeeName = @NewEmployeeName WHERE EmployeeID = @EmployeeID", con);
                    command.Parameters.AddWithValue("@NewEmployeeName", newEmployeeName);
                    command.Parameters.AddWithValue("@EmployeeID", employeeIDToUpdate);

                    try
                    {
                        con.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Response.Write("Employee updated successfully");
                        }
                        else
                        {
                            Response.Write("No employee found with the given ID.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("An error occurred: " + ex.Message);
                    }
                }
            }
            else
            {
                Response.Write("Please enter both Employee ID and new Name to update.");
            }
        }

        protected void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            string employeeIDToDelete = txtid.Text.Trim();

            if (!string.IsNullOrEmpty(employeeIDToDelete))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("DELETE FROM YourTableName WHERE EmployeeID = @EmployeeID", con);
                    command.Parameters.AddWithValue("@EmployeeID", employeeIDToDelete);

                    try
                    {
                        con.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Response.Write("Employee deleted successfully");
                        }
                        else
                        {
                            Response.Write("No employee found with the given ID.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("An error occurred: " + ex.Message);
                    }
                }
            }
            else
            {
                Response.Write("Please enter an Employee ID to delete.");
            }
        }

        protected void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(searchTerm))
            {

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM YourTableName WHERE EmployeeName LIKE '%' + @SearchTerm + '%'", con);
                    command.Parameters.AddWithValue("@SearchTerm", searchTerm);

                    try
                    {
                        con.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            GridView1.DataSource = reader;
                            GridView1.DataBind();
                        }
                        else
                        {
                            Response.Write("No matching records found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("An error occurred: " + ex.Message);
                    }
                }
            }
            else
            {
                Response.Write("Please enter a search term.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VU440JU;Initial Catalog=ASSIGNMENT02;Integrated Security=True;");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            string id = txtid.Text;
            string name = txtname.Text;
            string gender = rblGender.SelectedValue;

            try
            {
                string query = "INSERT INTO tableassignment02 (ID, Name, Gender) VALUES (@ID, @Name, @Gender)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Gender", gender);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    txtid.Text = "";
                    txtname.Text = "";
                    if (rowsAffected > 0)
                    {
                        lblMessage.Text = "Employee added successfully";
                    }
                    else
                    {
                        lblMessage.Text = "Failed to add employee";
                    }
                }
            }
            catch (Exception ex)
            {
               lblMessage.Text = "An error occurred: " + ex.Message;
            }
        }

        protected void btnShowAllRecords_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tableassignment02", con); // Corrected table name
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridViewEmployees.DataSource = dt;
            GridViewEmployees.DataBind();
            con.Close();
        }
    }
}
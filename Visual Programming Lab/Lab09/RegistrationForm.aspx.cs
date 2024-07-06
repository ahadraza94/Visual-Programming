using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace Lab09
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1T09T6V\SQLEXPRESS01;Initial Catalog=Lab09;Integrated Security=True;TrustServerCertificate=True");
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string gender = "";
            if (ddlGender.SelectedIndex != -1) // Ensure an option is selected
            {
                if (ddlGender.SelectedIndex == 0) // Male
                {
                    gender = "Male";
                }
                else if (ddlGender.SelectedIndex == 1) // Female
                {
                    gender = "Female";
                }
            }
            SqlCommand cmd = new SqlCommand("registrationform", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", txtEmail.Value);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Value);
            cmd.Parameters.AddWithValue("@FirstName",txtFirstName.Value);
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Value);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@DateofBirth", txtDateOfBirth.Value);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if(i>0)
            {
                Response.Write("Login Successfully");
            }
            else
            {
                Response.Write("Not Successfully Login");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginForm.aspx");   
        }
    }
}
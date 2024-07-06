using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab09
{
    public partial class LoginForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1T09T6V\SQLEXPRESS01;Initial Catalog=Lab09;Integrated Security=True;TrustServerCertificate=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("selectdata", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", exampleInputEmail1.Value);
            DataTable dt = new DataTable();
            SqlDataAdapter a = new SqlDataAdapter(cmd);
            a.Fill(dt);

            bool loginSuccess = false;

            foreach (DataRow row in dt.Rows)
            {
                if (row["Email"].ToString() == exampleInputEmail1.Value && row["Password"].ToString() == exampleInputPassword1.Value)
                {
                    loginSuccess = true;
                    Session["Email"] = exampleInputEmail1.Value;
                    Response.Redirect("MainPage.aspx");
                    break; // Exit loop once login is successful
                }
            }

            if (!loginSuccess)
            {
                Response.Write("Not Successfully Login maybe you are not registration in this category pleasee registration yourself first");
            }

            con.Close();
        }
    }
}
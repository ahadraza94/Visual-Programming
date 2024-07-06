using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;

namespace _2_5_2024
{
    public partial class MainPage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1T09T6V\SQLEXPRESS01;Initial Catalog=2-5-2024;Integrated Security=True;TrustServerCertificate=True");
        private void BindCatagory()
        {
            string q = "select distinct ProductCategory from OnlineStore";
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                DropDownList1.Items.Add(rdr["ProductCategory"].ToString());
            con.Close();
        }
        private void insert()
        {
            string q = "insert into OnlineStore(ProductName, ProductCategory ,Price ,Quantity) values('" + DropDownList2.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "','" + Convert.ToInt32(TextBox1.Text) + "','" + Convert.ToInt32(TextBox2.Text) + "')";
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void BindName()
        {
            string q = "select ProductName from OnlineStore where ProductCategory='" + DropDownList1.SelectedItem.Text + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                DropDownList2.Items.Add(rdr["ProductName"].ToString());
            con.Close();
        }

        private void search()
        {
            string q = "select * from OnlineStore";
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            GridView1.DataSource = rdr;
            GridView1.DataBind();
            con.Close();

        }
        private void BindPrice()
        {
            string q = "select Price from OnlineStore where ProductName='" + DropDownList2.SelectedItem.Text + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
                TextBox1.Text = rdr["Price"].ToString();
            con.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                BindCatagory();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            insert();
            search();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            BindName();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindPrice();
        }
    }
}
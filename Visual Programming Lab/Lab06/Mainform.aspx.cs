using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab07
{
    public partial class Mainform : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Create an instance of BusinessClass and populate it with form data
                BusinessClass user = new BusinessClass();
                user.Name = txtname.Text;
                user.address = txAddress.Text;
                user.EmailID = txtEmailid.Text;
                user.Mobilenumber = txtmobile.Text;

                // Create an instance of DataClass to interact with the database
                DataClass data = new DataClass();

                // Call the method to add user details to the database
                int result = data.AddUserDetails(user);

                // Check if insertion was successful
                if (result > 0)
                {
                    // Insertion successful, you can show a success message or redirect to another page
                    Response.Write("User details added successfully!");
                }
                else
                {
                    // Insertion failed, show an error message
                    Response.Write("Failed to add user details!");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                Response.Write("An error occurred: " + ex.Message);
            }
        }
    }
}
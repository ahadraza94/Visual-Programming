using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LAB03
{
    public partial class Form1 : Form
    {
        //SQL Server Connection
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VU440JU; Initial Catalog=LAB03; Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("BSCS");
            comboBox1.Items.Add("BSSE");
            comboBox1.Items.Add("BSIT");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gender = radioButton1.Checked ? "Male" : "Female";

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                con.Open();
                string query = "INSERT INTO lab03 (ID, Name, Gender, Education) VALUES (@ID, @Name, @Gender, @Education)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Education", comboBox1.SelectedItem);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        MessageBox.Show("Record Successfully Inserted");
                    else
                        MessageBox.Show("Failed to insert record.");
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
        //Delete Button Operation
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string selectedID = textBox1.Text; // Assuming listBox1 displays IDs
                string query = "DELETE FROM lab03 WHERE ID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", selectedID);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record Successfully Deleted");
                    }
                    else
                        MessageBox.Show("Failed to delete record.");
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
        //Update Button Operation
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string selectedID = textBox1.Text; // Assuming listBox1 displays IDs
                string query = "UPDATE lab03 SET Name = @Name, Gender = @Gender, Education = @Education WHERE ID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", selectedID);
                    cmd.Parameters.AddWithValue("@Name", textBox2.Text);

                    string gender = radioButton1.Checked ? "Male" : "Female";
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Education", comboBox1.SelectedItem);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record Successfully Updated");
                        // Optionally, refresh the ListBox or any other UI component displaying records
                    }
                    else
                        MessageBox.Show("Failed to update record.");
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

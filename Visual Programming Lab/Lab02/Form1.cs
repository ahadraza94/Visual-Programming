using System.Data;

namespace Lab02
{
    public partial class Form1 : Form
    {
        DataTable dt;
        public Form1()
        {
            dt = new DataTable();
            dt.Columns.Add("Student Name");
            dt.Columns.Add("Father Name");
            dt.Columns.Add("Phone No");
            dt.Columns.Add("Email Address");
            dt.Columns.Add("Class Section");
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String studentname = textBox1.Text;
            string fathername = textBox2.Text;
            string phoneno = textBox3.Text;
            string email = textBox4.Text;


            DataRow dr = dt.NewRow();
            dr["Student Name"] = studentname;
            dr["Father Name"] = fathername;
            dr["Phone No"] = phoneno;
            dr["Email Address"] = email;
            dt.Rows.Add (dr);
            dataGridView1.DataSource = dt;
        }
    }
}

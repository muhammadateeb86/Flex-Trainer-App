using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Flextrainer
{
    public partial class Adminlogin : Form
    {
        public Adminlogin()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox3.Text;
            string password = textBox2.Text;

            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();

            SqlCommand cmd1 = new SqlCommand("SELECT Username, Admin_Password FROM admin WHERE dbo.Admin.Username = @username AND dbo.Admin.Admin_Password = @password;", conn1);
            cmd1.Parameters.AddWithValue("@username", username);
            cmd1.Parameters.AddWithValue("@password", password);

            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            if (DS.Tables[0].Rows.Count > 0)
            {
                // If username and password match, open the admin page
                Admin Adminpage = new Admin();
                this.Hide();
                Adminpage.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

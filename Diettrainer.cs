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

namespace Flextrainer
{
    public partial class Diettrainer : Form
    {
        public Diettrainer()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            SqlConnection conn = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");

            try
            {
                conn.Open();

                string Pre_Diet_Plan_Name = textBox1.Text;
                string Pre_Diet_Plan_Description = textBox3.Text;// Get the selected date and time from dateTimePicker2

                string query = "INSERT INTO Pre_Diet_Plan ( Pre_Diet_Plan_Name,  Pre_Diet_Plan_Description) " +
                               "VALUES (@Pre_Diet_Plan_Name, @Pre_Diet_Plan_Description)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Pre_Diet_Plan_Description", Pre_Diet_Plan_Description);
                    cmd.Parameters.AddWithValue("@Pre_Diet_Plan_Name", Pre_Diet_Plan_Name);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Plan Added Added");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

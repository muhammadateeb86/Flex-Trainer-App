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
    public partial class GYMRegistration : Form
    {
        private int Owner_ID;
        public GYMRegistration(int owner_ID)
        {
            InitializeComponent();
            Owner_ID = owner_ID;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");

            try
            {
                conn.Open();

                string Gym_Name = textBox1.Text;
                string Location = textBox2.Text;


                string query = "INSERT INTO REQUEST_REGISTRATION (Gym_Name, Location, Owner_ID) " +
                               "VALUES (@Gym_Name, @Location, @Owner_ID)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Gym_Name", Gym_Name);
                    cmd.Parameters.AddWithValue("@Location", Location);
                    cmd.Parameters.AddWithValue("@Owner_ID", Owner_ID);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Request Submiteed");
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
    }
}

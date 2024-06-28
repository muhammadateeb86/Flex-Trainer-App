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
    public partial class ScheduleAppointment : Form
    {
        private int Member_ID;
        public ScheduleAppointment(int Member_ID)
        {
            InitializeComponent();
            this.Member_ID = Member_ID;
        }

        private void ScheduleAppointment_Load(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from Trainer", conn1);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");

            try
            {
                conn.Open();

                string Trainer_ID = textBox3.Text;
                DateTime Appointment_Date = dateTimePicker2.Value; // Get the selected date and time from dateTimePicker2

                string query = "INSERT INTO Appointment (Appointment_Date, Trainer_ID, Member_ID) " +
                               "VALUES (@Appointment_Date, @Trainer_ID, @Member_ID)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Appointment_Date", Appointment_Date);
                    cmd.Parameters.AddWithValue("@Trainer_ID", Trainer_ID);
                    cmd.Parameters.AddWithValue("@Member_ID", Member_ID);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Appointment Added");
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

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flextrainer
{
    public partial class Appointment : Form
    {
        private int Member_ID;
        [DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
        int nLeftRect,      // x-coordinate of upper-left corner
        int nTopRect,       // y-coordinate of upper-left corner
        int nRightRect,     // x-coordinate of lower-right corner
        int nBottomRect,    // y-coordinate of lower-right corner
        int nWidthEllipse,  // width of ellipse
        int nHeightEllipse  // height of ellipse
        );
        public Appointment(int MemberID)
        {
            InitializeComponent();
            button2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button2.Width, button2.Height, 20, 20));
            button2.Invalidate();
            //button3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button3.Width, button3.Height, 20, 20));
            //button3.Invalidate();
            //button4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button4.Width, button4.Height, 20, 20));
            //button4.Invalidate();
            this.Member_ID = MemberID;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ScheduleAppointment sch_appointments = new ScheduleAppointment ( Member_ID);

            sch_appointments.ShowDialog();
        }

        private void Appointment_Load(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from Appointment Where Member_ID = @Member_ID", conn1);
            cmd1.Parameters.AddWithValue("@Member_ID", Member_ID);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Get the Appointment ID from textbox2
            int appointmentId;
            if (!int.TryParse(textBox2.Text, out appointmentId))
            {
                MessageBox.Show("Invalid Appointment ID. Please enter a valid integer ID.");
                return;
            }

            // Establish a connection to the database
            using (SqlConnection conn = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True"))
            {
                try
                {
                    // Open the connection
                    conn.Open();

                    // Create a SqlCommand to delete the record from the Appointment table
                    SqlCommand cmdDelete = new SqlCommand("DELETE FROM Appointment WHERE Appointment_Id = @AppointmentId", conn);

                    // Add parameter for Appointment ID
                    cmdDelete.Parameters.AddWithValue("@AppointmentId", appointmentId);

                    // Execute the delete command
                    int rowsAffected = cmdDelete.ExecuteNonQuery();

                    // Close the connection
                    conn.Close();

                    // Check if any rows were affected (record deleted)
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Appointment record deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No appointment record found with the provided ID.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from Appointment Where Member_ID = @Member_ID", conn1);
            cmd1.Parameters.AddWithValue("@Member_ID", Member_ID);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
        }
    }
}

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
    public partial class TrainerApointment : Form
    {
        private int Trainer_ID;
        public TrainerApointment(int trainerid)
        {
            InitializeComponent();
            this.Trainer_ID = trainerid;
        }

        private void TrainerApointment_Load(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from Appointment Where Trainer_ID = @Trainer_ID", conn1);
            cmd1.Parameters.AddWithValue("@Trainer_ID", Trainer_ID);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
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
            SqlCommand cmd1 = new SqlCommand("Select * from Appointment Where Trainer_ID = @Trainer_ID", conn1);
            cmd1.Parameters.AddWithValue("@Trainer_ID", Trainer_ID);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];



        }

    }
}

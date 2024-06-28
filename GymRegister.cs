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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Flextrainer
{
    public partial class GymRegister : Form
    {
        [DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
        int nLeftRect,      // x-coordinate of upper-left corner
        int nTopRect,       // y-coordinate of upper-left corner
        int nRightRect,     // x-coordinate of lower-right corner
        int nBottomRect,    // y-coordinate of lower-right corner
        int nWidthEllipse,  // width of ellipse
        int nHeightEllipse  // height of ellipse
       );
        public GymRegister()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string requestId = textBox3.Text;

            // Retrieve gym details from the Request_Registration table based on the request ID
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmdSelect = new SqlCommand("SELECT Gym_Name, Location, Owner_Id FROM REQUEST_REGISTRATION WHERE REQUEST_REGISTRATION_Id = @requestId", conn1);
            cmdSelect.Parameters.AddWithValue("@requestId", requestId);
            SqlDataReader reader = cmdSelect.ExecuteReader();

            if (reader.Read())
            {
                string gymName = reader["Gym_Name"].ToString();
                string location = reader["Location"].ToString();
                int ownerId = Convert.ToInt32(reader["Owner_Id"]);

                // Insert gym details into the Gym table
                SqlConnection conn2 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
                conn2.Open();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO Gym (Gym_Name, Location, Owner_Id) VALUES (@GymName, @Location, @OwnerId)", conn2);
                cmdInsert.Parameters.AddWithValue("@GymName", gymName);
                cmdInsert.Parameters.AddWithValue("@Location", location);
                cmdInsert.Parameters.AddWithValue("@OwnerId", ownerId);
                int rowsInserted = cmdInsert.ExecuteNonQuery();

                if (rowsInserted > 0)
                {
                    MessageBox.Show("New gym inserted successfully.");
                    // Create a connection to the database
                    using (SqlConnection connection = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True"))
                    {
                        try
                        {
                            // Open the connection
                            connection.Open();

                            // Create a SQL command to delete the record from the REQUEST_REGISTRATION table
                            string deleteQuery = "DELETE FROM REQUEST_REGISTRATION WHERE REQUEST_REGISTRATION_Id = @requestId";
                            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                            {
                                // Add the request ID parameter
                                command.Parameters.AddWithValue("@requestId", requestId);

                                // Execute the delete command
                                int rowsAffected = command.ExecuteNonQuery();

                                // Check if any rows were affected (deleted)
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Record deleted successfully.");
                                    SqlConnection conn3 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
                                    conn3.Open();
                                    SqlCommand cmd3 = new SqlCommand("Select * from Request_Registration", conn3);
                                    SqlDataAdapter DA3 = new SqlDataAdapter(cmd3);
                                    DataSet DS3 = new DataSet();
                                    DA3.Fill(DS3);
                                    dataGridView1.DataSource = DS3.Tables[0];
                                }
                                else
                                {
                                    MessageBox.Show("No record found with the given request ID.");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Failed to insert new gym.");
                }

                conn2.Close();
            }
            else
            {
                MessageBox.Show("No data found for the given request ID.");
            }

            reader.Close();
            conn1.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void GymRegister_Load(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from Request_Registration", conn1);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string requestId = textBox3.Text; // Assuming textBox1 contains the request ID

            // Create a connection to the database
            using (SqlConnection connection = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True"))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a SQL command to delete the record from the REQUEST_REGISTRATION table
                    string deleteQuery = "DELETE FROM REQUEST_REGISTRATION WHERE REQUEST_REGISTRATION_Id = @requestId";
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        // Add the request ID parameter
                        command.Parameters.AddWithValue("@requestId", requestId);

                        // Execute the delete command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if any rows were affected (deleted)
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record deleted successfully.");
                            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
                            conn1.Open();
                            SqlCommand cmd1 = new SqlCommand("Select * from Request_Registration", conn1);
                            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
                            DataSet DS = new DataSet();
                            DA.Fill(DS);
                            dataGridView1.DataSource = DS.Tables[0];
                        }
                        else
                        {
                            MessageBox.Show("No record found with the given request ID.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

    }
}

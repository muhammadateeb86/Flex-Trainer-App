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
    public partial class Diet : Form
    {
        private int Member_ID; // Declare a private member variable to store Member_ID

        public Diet(int MemberID)
        {
            InitializeComponent();
            this.Member_ID = MemberID; // Initialize memberID with the value of Member_ID from the Login form
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Diet_Load(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from Pre_Diet_Plan", conn1);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView2.DataSource = DS.Tables[0];

            SqlConnection conn2 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn2.Open();
            SqlCommand cmd2 = new SqlCommand("Select * from Diet_Plan where Member_ID = @Member_ID", conn2);
            cmd2.Parameters.AddWithValue("@Member_ID", Member_ID);
            SqlDataAdapter DA2 = new SqlDataAdapter(cmd2);
            DataSet DS2 = new DataSet();
            DA2.Fill(DS2);
            dataGridView1.DataSource = DS2.Tables[0];
        }

        private void label11_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void label12_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click_2(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is not a header and the clicked row index is valid
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Check if the clicked row is the currently selected row
                if (dataGridView2.Rows[e.RowIndex].Selected)
                {
                    try
                    {
                        // Connection string
                        string connectionString = "Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True";

                        // Get the DataGridViewRow corresponding to the clicked row
                        DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];

                        // Access the data from the cells of the selected row
                        string dietPlanName = selectedRow.Cells["ColumnNameForDietPlanName"].Value.ToString();
                        string dietPlanDescription = selectedRow.Cells["ColumnNameForDietPlanDescription"].Value.ToString();

                        // Open connection
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Insert into Diet_Plan table
                            InsertIntoDietPlan(connectionString, dietPlanName, dietPlanDescription);
                        }

                        MessageBox.Show("Data inserted into Diet_Plan successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    // Connection string
            //    string connectionString = "Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True";

            //    // SQL query to retrieve data from Pre_Diet_Plan
            //    string selectQuery = "SELECT * FROM Pre_Diet_Plan WHERE Pre_Diet_Plan_Name = 'High Carb Diet'";

            //    // Create connection and command objects
            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
            //        using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
            //        {
            //            // Open connection
            //            connection.Open();

            //            // Create a data adapter and dataset
            //            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand);
            //            DataSet dataSet = new DataSet();

            //            // Fill the dataset with data from Pre_Diet_Plan
            //            dataAdapter.Fill(dataSet, "Pre_Diet_Plan");

            //            // Loop through the retrieved rows
            //            foreach (DataRow row in dataSet.Tables["Pre_Diet_Plan"].Rows)
            //            {
            //                // Extract values from the row
            //                string dietPlanName = row["Pre_Diet_Plan_Name"].ToString();
            //                string dietPlanDescription = row["Pre_Diet_Plan_Description"].ToString();

            //                // Insert into Diet_Plan table
            //                InsertIntoDietPlan(connectionString, dietPlanName, dietPlanDescription);
            //            }
            //        }
            //    }

            //    MessageBox.Show("Data inserted into Diet_Plan successfully.");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: " + ex.Message);
            //}



            //SqlConnection conn2 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            //conn2.Open();
            //SqlCommand cmd2 = new SqlCommand("Select * from Diet_Plan", conn2);
            //SqlDataAdapter DA2 = new SqlDataAdapter(cmd2);
            //DataSet DS2 = new DataSet();
            //DA2.Fill(DS2);
            //dataGridView1.DataSource = DS2.Tables[0];

        }

        // Method to insert data into Diet_Plan table
        // Method to insert data into Diet_Plan table
        private void InsertIntoDietPlan(string connectionString, string dietPlanName, string dietPlanDescription)
        {
            // SQL query to insert data into Diet_Plan
            string insertQuery = "INSERT INTO Diet_Plan (Diet_Plan_Name, Diet_Plan_Description, Member_ID) VALUES (@Diet_Plan_Name, @Diet_Plan_Description, @Member_ID)";

            try
            {
                // Create connection and command objects
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters
                        insertCommand.Parameters.AddWithValue("@Diet_Plan_Name", dietPlanName);
                        insertCommand.Parameters.AddWithValue("@Diet_Plan_Description", dietPlanDescription);
                        insertCommand.Parameters.AddWithValue("@Member_ID", Member_ID);

                        // Open connection
                        connection.Open();

                        // Execute the insert command
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting data into Diet_Plan: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string Pre_Diet_Plan_ID = textBox1.Text;
            

            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();

            // Check if the member already has a diet plan
            SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM Diet_Plan WHERE Member_Id = @Member_Id", conn1);
            cmdCheck.Parameters.AddWithValue("@Member_Id", Member_ID);
            int dietPlanCount = (int)cmdCheck.ExecuteScalar();

            if (dietPlanCount > 0)
            {
                // Member already has a diet plan, update the existing one
                SqlCommand cmdUpdate = new SqlCommand("UPDATE Diet_Plan SET Diet_Plan_Name = (SELECT Pre_Diet_Plan_Name FROM Pre_Diet_Plan WHERE Pre_Diet_Plan_ID = @Pre_Diet_Plan_ID), Diet_Plan_Description = (SELECT Pre_Diet_Plan_Description FROM Pre_Diet_Plan WHERE Pre_Diet_Plan_ID = @Pre_Diet_Plan_ID) WHERE Member_Id = @Member_Id", conn1);
                cmdUpdate.Parameters.AddWithValue("@Pre_Diet_Plan_ID", Pre_Diet_Plan_ID);
                cmdUpdate.Parameters.AddWithValue("@Member_Id", Member_ID);
                int rowsUpdated = cmdUpdate.ExecuteNonQuery();

                if (rowsUpdated > 0)
                {
                    MessageBox.Show("Existing diet plan updated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to update existing diet plan.");
                }
            }
            else
            {
                // Member does not have a diet plan, insert a new one
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO Diet_Plan (Diet_Plan_Name, Diet_Plan_Description, Member_Id) SELECT Pre_Diet_Plan_Name, Pre_Diet_Plan_Description, @Member_Id FROM Pre_Diet_Plan WHERE Pre_Diet_Plan_ID = @Pre_Diet_Plan_ID", conn1);
                cmdInsert.Parameters.AddWithValue("@Pre_Diet_Plan_ID", Pre_Diet_Plan_ID);
                cmdInsert.Parameters.AddWithValue("@Member_ID", Member_ID);
                int rowsInserted = cmdInsert.ExecuteNonQuery();

                if (rowsInserted > 0)
                {
                    MessageBox.Show("New diet plan inserted successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to insert new diet plan.");
                }
            }

            // Close the connection
            conn1.Close();



            SqlConnection conn2 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn2.Open();
            SqlCommand cmd2 = new SqlCommand("Select * from Diet_Plan", conn2);
            SqlDataAdapter DA2 = new SqlDataAdapter(cmd2);
            DataSet DS2 = new DataSet();
            DA2.Fill(DS2);
            dataGridView1.DataSource = DS2.Tables[0];




        }




        private void label4_Click_1(object sender, EventArgs e)
        {

        }
    }
}

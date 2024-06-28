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
    public partial class ADDWORKOUT : Form
    {
        public ADDWORKOUT()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");

            try
            {
                conn.Open();

                string Trainer_WORKOUT_EXERCISE = textBox7.Text;
                string[] EXERCISE_ID = { textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text };

                for (int i = 0; i < EXERCISE_ID.Length; i++)
                {
                    string query = "INSERT INTO Trainer_WORKOUT_EXERCISE (Trainer_WORKOUT_PLAN_ID, EXERCISE_ID) VALUES (@Trainer_WORKOUT_EXERCISE, @EXERCISE_ID)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Trainer_WORKOUT_EXERCISE", Trainer_WORKOUT_EXERCISE);
                        cmd.Parameters.AddWithValue("@EXERCISE_ID", EXERCISE_ID[i]);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Exercise " + (i + 1) + " added to workout plan successfully");
                }
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

        private void button8_Click(object sender, EventArgs e)
        {


            SqlConnection conn = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");

            try
            {
                conn.Open();
                
                string TRAINER_Workout_Plan_Name = textBox1.Text;
                string TRAINER_WORKOUT_DAY = textBox2.Text;
                
                string query = "INSERT INTO TRAINER_Workout_Plan (TRAINER_WORKOUT_DAY, TRAINER_Workout_Plan_Name) " +
                               "VALUES (@TRAINER_WORKOUT_DAY, @TRAINER_Workout_Plan_Name)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TRAINER_WORKOUT_DAY", TRAINER_WORKOUT_DAY);
                    cmd.Parameters.AddWithValue("@TRAINER_Workout_Plan_Name", TRAINER_Workout_Plan_Name);
                    
                    cmd.ExecuteNonQuery();
                }
                
                MessageBox.Show("Workout Added");
                SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
                conn1.Open();
                SqlCommand cmd1 = new SqlCommand("Select * from Trainer_Workout_Plan", conn1);
                SqlDataAdapter DA = new SqlDataAdapter(cmd1);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
                

                conn1.Close();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ADDWORKOUT_Load(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from Trainer_Workout_Plan", conn1);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];

            conn1.Close();

            SqlConnection conn2 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd2 = new SqlCommand("Select * from Exercise", conn2);
            SqlDataAdapter DA2 = new SqlDataAdapter(cmd2);
            DataSet DS2 = new DataSet();
            DA2.Fill(DS2);
            dataGridView2.DataSource = DS2.Tables[0];
            conn2.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

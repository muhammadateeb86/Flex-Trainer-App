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
    public partial class Workout : Form
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
        public Workout(int Member_ID)
        {
            InitializeComponent();
            button2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button2.Width, button2.Height, 20, 20));
            button2.Invalidate();
            this.Member_ID = Member_ID;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string trainerWorkoutPlanId = textBox1.Text;

            using (SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True"))
            {
                conn1.Open();

                // Update or insert workout plan (existing or new)
                SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM Workout_Plan WHERE Member_Id = @Member_Id", conn1);
                cmdCheck.Parameters.AddWithValue("@Member_Id", Member_ID);
                int workoutPlanCount = (int)cmdCheck.ExecuteScalar();

                if (workoutPlanCount > 0)
                {
                    SqlCommand cmdUpdate = new SqlCommand("UPDATE Workout_Plan SET Workout_Plan_Name = (SELECT TRAINER_Workout_Plan_Name FROM TRAINER_Workout_Plan WHERE TRAINER_Plan_Id = @Trainer_Workout_Plan_Id), Workout_Day = (SELECT TRAINER_WORKOUT_DAY FROM TRAINER_Workout_Plan WHERE TRAINER_Plan_Id = @Trainer_Workout_Plan_Id) WHERE Member_Id = @Member_Id", conn1);
                    cmdUpdate.Parameters.AddWithValue("@Trainer_Workout_Plan_Id", trainerWorkoutPlanId);
                    cmdUpdate.Parameters.AddWithValue("@Member_Id", Member_ID);
                    int rowsUpdated = cmdUpdate.ExecuteNonQuery();

                    if (rowsUpdated > 0)
                    {
                        MessageBox.Show("Existing workout plan updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update existing workout plan.");
                    }
                }
                else
                {
                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO Workout_Plan (Workout_Plan_Name, Workout_Day, Member_Id) SELECT TRAINER_Workout_Plan_Name, TRAINER_WORKOUT_DAY, @Member_Id FROM TRAINER_Workout_Plan WHERE TRAINER_Plan_Id = @Trainer_Workout_Plan_Id", conn1);
                    cmdInsert.Parameters.AddWithValue("@Trainer_Workout_Plan_Id", trainerWorkoutPlanId);
                    cmdInsert.Parameters.AddWithValue("@Member_ID", Member_ID);
                    int rowsInserted = cmdInsert.ExecuteNonQuery();

                    if (rowsInserted > 0)
                    {
                        MessageBox.Show("New workout plan inserted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert new workout plan.");
                    }
                }

                // Fetch all exercises associated with the workout plan ID
                SqlDataAdapter DA2 = new SqlDataAdapter("SELECT STRING_AGG(E.Exercise_Name, ', ') AS Exercise_Names, STRING_AGG(E.Exercise_Description, ', ') AS Exercise_Descriptions, STRING_AGG(E.Muscle_Group, ', ') AS Muscle_Groups FROM WORKOUT_EXERCISE WE INNER JOIN Exercise E ON WE.EXERCISE_ID = E.Exercise_Id WHERE WE.WORKOUT_PLAN_ID = @Trainer_Workout_Plan_Id GROUP BY WE.WORKOUT_PLAN_ID", conn1);
                DA2.SelectCommand.Parameters.AddWithValue("@Trainer_Workout_Plan_Id", trainerWorkoutPlanId);
                DataSet DS2 = new DataSet();
                DA2.Fill(DS2);

                // Display the fetched exercises in the DataGridView
                dataGridView2.DataSource = DS2.Tables[0];
            }



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT TWP.TRAINER_Plan_Id, TWP.TRAINER_WORKOUT_DAY, TWP.TRAINER_Workout_Plan_Name, TE.Exercise_Name, TE.Exercise_Description, TE.Muscle_Group FROM TRAINER_Workout_Plan TWP INNER JOIN Trainer_WORKOUT_EXERCISE TWE ON TWP.TRAINER_Plan_Id = TWE.Trainer_WORKOUT_PLAN_ID INNER JOIN Exercise TE ON TWE.EXERCISE_ID = TE.Exercise_Id WHERE TWP.TRAINER_WORKOUT_DAY LIKE '%w%' OR TWP.TRAINER_WORKOUT_DAY LIKE '%W%'; ", conn1);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT TWP.TRAINER_Plan_Id, TWP.TRAINER_WORKOUT_DAY, TWP.TRAINER_Workout_Plan_Name, TE.Exercise_Name, TE.Exercise_Description, TE.Muscle_Group FROM TRAINER_Workout_Plan TWP INNER JOIN Trainer_WORKOUT_EXERCISE TWE ON TWP.TRAINER_Plan_Id = TWE.Trainer_WORKOUT_PLAN_ID INNER JOIN Exercise TE ON TWE.EXERCISE_ID = TE.Exercise_Id WHERE TWP.TRAINER_WORKOUT_DAY LIKE '%M%' OR TWP.TRAINER_WORKOUT_DAY LIKE '%m%'; ", conn1);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void label3_Click(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT TWP.TRAINER_Plan_Id, TWP.TRAINER_WORKOUT_DAY, TWP.TRAINER_Workout_Plan_Name, TE.Exercise_Name, TE.Exercise_Description, TE.Muscle_Group FROM TRAINER_Workout_Plan TWP INNER JOIN Trainer_WORKOUT_EXERCISE TWE ON TWP.TRAINER_Plan_Id = TWE.Trainer_WORKOUT_PLAN_ID INNER JOIN Exercise TE ON TWE.EXERCISE_ID = TE.Exercise_Id WHERE TWP.TRAINER_WORKOUT_DAY LIKE '%Tu%' OR TWP.TRAINER_WORKOUT_DAY LIKE '%tu%'; ", conn1);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT TWP.TRAINER_Plan_Id, TWP.TRAINER_WORKOUT_DAY, TWP.TRAINER_Workout_Plan_Name, TE.Exercise_Name, TE.Exercise_Description, TE.Muscle_Group FROM TRAINER_Workout_Plan TWP INNER JOIN Trainer_WORKOUT_EXERCISE TWE ON TWP.TRAINER_Plan_Id = TWE.Trainer_WORKOUT_PLAN_ID INNER JOIN Exercise TE ON TWE.EXERCISE_ID = TE.Exercise_Id WHERE TWP.TRAINER_WORKOUT_DAY LIKE '%th%' OR TWP.TRAINER_WORKOUT_DAY LIKE '%TH%'; ", conn1);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void label6_Click(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT TWP.TRAINER_Plan_Id, TWP.TRAINER_WORKOUT_DAY, TWP.TRAINER_Workout_Plan_Name, TE.Exercise_Name, TE.Exercise_Description, TE.Muscle_Group FROM TRAINER_Workout_Plan TWP INNER JOIN Trainer_WORKOUT_EXERCISE TWE ON TWP.TRAINER_Plan_Id = TWE.Trainer_WORKOUT_PLAN_ID INNER JOIN Exercise TE ON TWE.EXERCISE_ID = TE.Exercise_Id WHERE TWP.TRAINER_WORKOUT_DAY LIKE '%f%' OR TWP.TRAINER_WORKOUT_DAY LIKE '%F%'; ", conn1);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void label7_Click(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT TWP.TRAINER_Plan_Id, TWP.TRAINER_WORKOUT_DAY, TWP.TRAINER_Workout_Plan_Name, TE.Exercise_Name, TE.Exercise_Description, TE.Muscle_Group FROM TRAINER_Workout_Plan TWP INNER JOIN Trainer_WORKOUT_EXERCISE TWE ON TWP.TRAINER_Plan_Id = TWE.Trainer_WORKOUT_PLAN_ID INNER JOIN Exercise TE ON TWE.EXERCISE_ID = TE.Exercise_Id WHERE TWP.TRAINER_WORKOUT_DAY LIKE '%SAT%' OR TWP.TRAINER_WORKOUT_DAY LIKE '%sat%'; ", conn1);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Workout_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

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
    public partial class Query4 : Form
    {
        public Query4()
        {
            InitializeComponent();
        }
        

        private void Query4_Load(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT COUNT(DISTINCT Membership.Member_Id) AS Member_Count FROM Membership INNER JOIN Gym ON Membership.Gym_Id = Gym.Gym_Id INNER JOIN Workout_Plan ON Membership.Member_Id = Workout_Plan.Member_Id INNER JOIN WORKOUT_EXERCISE ON Workout_Plan.Plan_Id = WORKOUT_EXERCISE.WORKOUT_PLAN_ID INNER JOIN Exercise ON WORKOUT_EXERCISE.EXERCISE_ID = Exercise.Exercise_Id INNER JOIN Machine ON Exercise.Machine_Id = Machine.Machine_Id WHERE Gym.Gym_Name = 'Your_Gym_Name' AND Workout_Plan.Workout_Day = 'Your_Desired_Day' AND Machine.Machine_Name = 'Your_Desired_Machine_Name';   ", conn1);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView2.DataSource = DS.Tables[0];
        }
    }
}

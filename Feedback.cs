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
    public partial class Feedback : Form
    {
        private int Trainer_ID;
        public Feedback(int trainerid)
        {
            InitializeComponent();
            this.Trainer_ID = trainerid;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Feedback_Load(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();

            // Retrieve feedback data for the trainer
            SqlCommand cmd1 = new SqlCommand("SELECT F.Feedback_Rating, F.Feedback_Comments, F.Member_ID, M.Member_Name FROM Feedback F JOIN Member M ON F.Member_ID = M.Member_ID WHERE F.Trainer_ID = @Trainer_ID;", conn1);
            cmd1.Parameters.AddWithValue("@Trainer_ID", Trainer_ID);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            // Display feedback data in dataGridView1
            dataGridView1.DataSource = DS.Tables[0];

            // Calculate average rating
            SqlCommand cmdAvgRating = new SqlCommand("SELECT AVG(Feedback_Rating) AS AvgRating FROM Feedback WHERE Trainer_ID = @Trainer_ID;", conn1);
            cmdAvgRating.Parameters.AddWithValue("@Trainer_ID", Trainer_ID);
            double avgRating = Convert.ToDouble(cmdAvgRating.ExecuteScalar());

            // Display average rating in a separate textbox or grid
            textBox2.Text = avgRating.ToString();

            conn1.Close();




        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

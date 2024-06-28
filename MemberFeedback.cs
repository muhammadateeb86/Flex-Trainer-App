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
    public partial class MemberFeedback : Form
    {
        private int Member_ID;
        public MemberFeedback(int memberID)
        {
            InitializeComponent();
            this.Member_ID = memberID;
        }

        private void MemberFeedback_Load(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT T.Trainer_ID, T.Trainer_Name FROM Trainer T JOIN Appointment A ON T.Trainer_ID = A.Trainer_ID WHERE A.Member_ID = @Member_ID;", conn1);
            cmd1.Parameters.AddWithValue("@Member_ID", Member_ID);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");

            try
            {
                conn.Open();

                string Trainer_ID = textBox3.Text;
                float Feedback_Rating = Convert.ToSingle(textBox2.Text);
                string Feedback_Comments = textBox1.Text;
                string query = "INSERT INTO Feedback (Feedback_Rating, Trainer_ID, Member_ID , Feedback_Comments) " +
                               "VALUES (@Feedback_Rating, @Trainer_ID, @Member_ID, @Feedback_Comments)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Feedback_Rating", Feedback_Rating);
                    cmd.Parameters.AddWithValue("@Trainer_ID", Trainer_ID);
                    cmd.Parameters.AddWithValue("@Member_ID", Member_ID);
                    cmd.Parameters.AddWithValue("@Feedback_Comments", Feedback_Comments);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Feedback Submitted");
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class Addtrainer : Form
    {
        private int Owner_Id;
        [DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
                int nLeftRect,      // x-coordinate of upper-left corner
                int nTopRect,       // y-coordinate of upper-left corner
                int nRightRect,     // x-coordinate of lower-right corner
                int nBottomRect,    // y-coordinate of lower-right corner
                int nWidthEllipse,  // width of ellipse
                int nHeightEllipse  // height of ellipse
                );
        public Addtrainer(int Owner_Id)
        {
            this.Owner_Id = Owner_Id;
            InitializeComponent();
            button2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button2.Width, button2.Height, 20, 20));
            button2.Invalidate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Addtrainer_Load(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from Trainer", conn1);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];



            SqlConnection conn2 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn2.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT Gym_ID, GYM_Name FROM Gym WHERE Owner_ID = @Owner_Id", conn2);
            cmd2.Parameters.AddWithValue("@Owner_Id", Owner_Id);
            SqlDataAdapter DA2 = new SqlDataAdapter(cmd2);
            DataSet DS2 = new DataSet();

            DA2.Fill(DS2);
            dataGridView2.DataSource = DS2.Tables[0];




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");

            try
            {
                conn.Open();

                string Trainer_ID = textBox1.Text;
                string Gym_ID = textBox2.Text;

                string query = "INSERT INTO WorksFor (Trainer_ID, Gym_ID) " +
                               "VALUES (@Trainer_ID, @Gym_ID)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Trainer_ID", Trainer_ID);
                    cmd.Parameters.AddWithValue("@Gym_ID", Gym_ID);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Trainer Added to Gym");
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
    }
}

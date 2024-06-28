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
    public partial class RemoveMT : Form
    {
        private int Owner_ID;
        [DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
                int nLeftRect,      // x-coordinate of upper-left corner
                int nTopRect,       // y-coordinate of upper-left corner
                int nRightRect,     // x-coordinate of lower-right corner
                int nBottomRect,    // y-coordinate of lower-right corner
                int nWidthEllipse,  // width of ellipse
                int nHeightEllipse  // height of ellipse
                );
        public RemoveMT(int owner_ID)
        {

            InitializeComponent();
            button2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button2.Width, button2.Height, 20, 20));
            button2.Invalidate();
            button3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button3.Width, button3.Height, 20, 20));
            button3.Invalidate();
            this.Owner_ID = owner_ID;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Member_ID = textBox2.Text;
            //int Owner_ID = Owner_ID; // Assuming Owner_ID is accessible in this context

            SqlConnection conn = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn.Open();

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM Membership WHERE Member_ID = @Member_ID AND GYM_ID IN (SELECT GYM_ID FROM GYM WHERE Owner_ID = @Owner_ID)", conn);
            cmdDelete.Parameters.AddWithValue("@Member_ID", Member_ID);
            cmdDelete.Parameters.AddWithValue("@Owner_ID", Owner_ID);

            int rowsAffected = cmdDelete.ExecuteNonQuery();
            conn.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Record deleted successfully from Membership.");
                SqlConnection conn2 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
                conn2.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT M.* FROM Member M JOIN Membership MS ON M.Member_ID = MS.Member_ID JOIN Gym G ON MS.GYM_ID = G.GYM_ID WHERE G.Owner_ID = @Owner_ID; ", conn2);

                cmd2.Parameters.AddWithValue("@Owner_ID", Owner_ID); SqlDataAdapter DA2 = new SqlDataAdapter(cmd2);
                DataSet DS2 = new DataSet();
                DA2.Fill(DS2);
                dataGridView2.DataSource = DS2.Tables[0];
            }
            else
            {
                MessageBox.Show("No record found with the provided ID or the trainer is not registered in gyms owned by this owner.");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string trainerId = textBox1.Text;
            //int Owner_ID = Owner_ID; // Assuming Owner_ID is accessible in this context

            SqlConnection conn = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn.Open();

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM WORKSFOR WHERE TRAINER_ID = @Trainer_ID AND GYM_ID IN (SELECT GYM_ID FROM GYM WHERE Owner_ID = @Owner_ID)", conn);
            cmdDelete.Parameters.AddWithValue("@Trainer_ID", trainerId);
            cmdDelete.Parameters.AddWithValue("@Owner_ID", Owner_ID);

            int rowsAffected = cmdDelete.ExecuteNonQuery();
            conn.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Record deleted successfully from WORKSFOR table.");
                SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
                conn1.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT T.* FROM Trainer T JOIN WORKSFOR WF ON T.Trainer_ID = WF.TRAINER_ID JOIN Gym G ON WF.GYM_ID = G.GYM_ID WHERE G.Owner_ID = @Owner_ID; ", conn1);

                cmd1.Parameters.AddWithValue("@Owner_ID", Owner_ID);
                SqlDataAdapter DA = new SqlDataAdapter(cmd1);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
            }
            else
            {
                MessageBox.Show("No record found with the provided ID or the trainer is not registered in gyms owned by this owner.");
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RemoveMT_Load(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT T.* FROM Trainer T JOIN WORKSFOR WF ON T.Trainer_ID = WF.TRAINER_ID JOIN Gym G ON WF.GYM_ID = G.GYM_ID WHERE G.Owner_ID = @Owner_ID; ", conn1);

            cmd1.Parameters.AddWithValue("@Owner_ID", Owner_ID);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];


            SqlConnection conn2 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn2.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT M.* FROM Member M JOIN Membership MS ON M.Member_ID = MS.Member_ID JOIN Gym G ON MS.GYM_ID = G.GYM_ID WHERE G.Owner_ID = @Owner_ID; ", conn2);

            cmd2.Parameters.AddWithValue("@Owner_ID", Owner_ID); SqlDataAdapter DA2 = new SqlDataAdapter(cmd2);
            DataSet DS2 = new DataSet();
            DA2.Fill(DS2);
            dataGridView2.DataSource = DS2.Tables[0];

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

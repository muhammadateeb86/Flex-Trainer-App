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
    public partial class revokegym : Form
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
        public revokegym()
        {
            InitializeComponent();
            button3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button3.Width, button3.Height, 20, 20));
            button3.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string GYM_ID = textBox1.Text;

            SqlConnection conn = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn.Open();

            SqlCommand cmdDelete = new SqlCommand("DELETE FROM GYM WHERE GYM_ID = @GYM_ID ", conn);
            cmdDelete.Parameters.AddWithValue("@GYM_ID", GYM_ID);

            int rowsAffected = cmdDelete.ExecuteNonQuery();
            conn.Close();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Record deleted successfully from GYM RECORD.");
                SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
                conn1.Open();
                SqlCommand cmd1 = new SqlCommand("Select * from GYM", conn1);
                SqlDataAdapter DA = new SqlDataAdapter(cmd1);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
            }
            else
            {
                MessageBox.Show("No record found with the provided ID ");
            }
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string textBox1_TextChanged=textBox1.Text;
        }

        private void trainermember_Load(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from GYM", conn1);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

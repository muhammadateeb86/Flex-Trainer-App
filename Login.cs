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

    public partial class Login : Form
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
        public Login()
        {
            InitializeComponent();
            button1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 20, 20));
            button1.Invalidate();
            button2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button2.Width, button2.Height, 20, 20));
            button2.Invalidate();
            button3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button3.Width, button3.Height, 20, 20));
            button3.Invalidate();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox3.Text;
            string password = textBox2.Text;

            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();

            SqlCommand cmd1 = new SqlCommand("SELECT Member_Id, Username, Member_Password FROM Member WHERE Username = @username AND Member_Password = @password", conn1);
            cmd1.Parameters.AddWithValue("@username", username);
            cmd1.Parameters.AddWithValue("@password", password);

            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            if (DS.Tables[0].Rows.Count > 0)
            {
                // Retrieve the Member_ID from the DataSet
                int memberID = Convert.ToInt32(DS.Tables[0].Rows[0]["Member_Id"]);

                // If username and password match, open the member page
                this.Hide();  // Close the current form after LoginForm is closed

                // Pass the memberID to the Member form
                Member MemberPage = new Member(memberID);
                MemberPage.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           // this.Hide();  // Close the current form after LoginForm is closed

            Register RegisterForm = new Register();

            RegisterForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox3.Text;
            string password = textBox2.Text;

            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();

            SqlCommand cmd1 = new SqlCommand("SELECT Owner_Id, Username, Owner_Password FROM Gym_Owner WHERE Username = @username AND Owner_Password = @password", conn1);
            cmd1.Parameters.AddWithValue("@username", username);
            cmd1.Parameters.AddWithValue("@password", password);

            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            if (DS.Tables[0].Rows.Count > 0)
            {
                //int GymOwnerID = 1;
                int Owner_Id = Convert.ToInt32(DS.Tables[0].Rows[0]["Owner_Id"]);
                // If username and password match, open the gym owner page
                this.Hide();  // Close the current form after LoginForm is closed
                GymOwner ngymowner = new GymOwner(Owner_Id);
                ngymowner.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string username = textBox3.Text;
            string password = textBox2.Text;

            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();

            SqlCommand cmd1 = new SqlCommand("SELECT Trainer_ID, Username, Trainer_Password FROM Trainer WHERE Username = @username AND Trainer_Password = @password", conn1);
            cmd1.Parameters.AddWithValue("@username", username);
            cmd1.Parameters.AddWithValue("@password", password);

            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            if (DS.Tables[0].Rows.Count > 0)
            {
                int trainerID = Convert.ToInt32(DS.Tables[0].Rows[0]["Trainer_Id"]);
                // If username and password match, open the trainer page
                this.Hide();  // Close the current form after LoginForm is closed
                Trainer ntrainer = new Trainer(trainerID);
                ntrainer.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string username = textBox3.Text;
            string password = textBox2.Text;

            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();

            SqlCommand cmd1 = new SqlCommand("SELECT Admin_ID, Username, Admin_Password FROM Admin WHERE Username = @username AND Admin_Password = @password", conn1);
            cmd1.Parameters.AddWithValue("@username", username);
            cmd1.Parameters.AddWithValue("@password", password);

            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            if (DS.Tables[0].Rows.Count > 0)
            {
                int adminID = Convert.ToInt32(DS.Tables[0].Rows[0]["Admin_Id"]);
                // If username and password match, open the trainer page
                this.Hide();  // Close the current form after LoginForm is closed
                Admin adminform = new Admin();
                adminform.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Adminlogin adminloginform = new Adminlogin();
            adminloginform.ShowDialog();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}

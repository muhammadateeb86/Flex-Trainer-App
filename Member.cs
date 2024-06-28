using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flextrainer
{
    public partial class Member : Form
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
        public Member(int Member_ID)
        {
            InitializeComponent();
            this.Member_ID = Member_ID;
            button1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 20, 20));
            button1.Invalidate();
            button2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button2.Width, button2.Height, 20, 20));
            button2.Invalidate();
            //button3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button3.Width, button3.Height, 20, 20));
            //button3.Invalidate();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Member_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_3(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_2(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_3(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           // this.Hide();

            Workout workoutform = new Workout(Member_ID);

            workoutform.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();

            Diet dietform= new Diet(Member_ID); 

            dietform.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            membership membership=new membership(Member_ID);
                membership.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Appointment appointments = new Appointment(Member_ID);

            appointments.ShowDialog();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            MemberFeedback member_form = new MemberFeedback(Member_ID);

            member_form.ShowDialog();
        }
    }
}

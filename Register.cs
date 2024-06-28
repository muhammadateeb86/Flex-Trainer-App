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
    public partial class Register : Form
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
        public Register()
        {
            InitializeComponent();
            button2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button2.Width, button2.Height, 20, 20));
            button2.Invalidate();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();  // Close the current form after LoginForm is closed

            Login loginForm = new Login();

            loginForm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();  // Close the current form after LoginForm is closed

            RegisterasMember memform = new RegisterasMember();

            memform.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterasTrainer nregisterasTrainer = new RegisterasTrainer();
            nregisterasTrainer.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegisterasGymOwner nregisterasGymOwner=new RegisterasGymOwner();
            nregisterasGymOwner.ShowDialog();
             
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}

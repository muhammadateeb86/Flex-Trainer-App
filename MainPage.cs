using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flextrainer
{
    public partial class MainPage : Form
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
        public MainPage()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;

            //this.StartPosition = FormStartPosition.CenterScreen;
            //this.WindowState = FormWindowState.Maximized;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 20, 20));
            button1.Invalidate();
        }
     
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           // this.Hide();  // Close the current form after LoginForm is closed

            Login loginForm = new Login();

            loginForm.ShowDialog();  // Show LoginForm as a modal dialog


            //Adminlogin adminform=new Adminlogin();
           // adminform.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QueryReport rq = new QueryReport();
            rq.ShowDialog();
        }
    }
}



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
    public partial class Admin : Form
    {
        //private int Admin_ID;
        [DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
        int nLeftRect,      // x-coordinate of upper-left corner
        int nTopRect,       // y-coordinate of upper-left corner
        int nRightRect,     // x-coordinate of lower-right corner
        int nBottomRect,    // y-coordinate of lower-right corner
        int nWidthEllipse,  // width of ellipse
        int nHeightEllipse  // height of ellipse
        );
        public Admin()
        {
            InitializeComponent();
            button1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 20, 20));
            button1.Invalidate();
            button2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button2.Width, button2.Height, 20, 20));
            button2.Invalidate();
            button3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button3.Width, button3.Height, 20, 20));
            button3.Invalidate();
            //this.Admin_ID = adminID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();

            Perfomancepage nperfomancepage=new Perfomancepage();
            nperfomancepage.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();

            GymRegister nsymregisterpage = new GymRegister();
            nsymregisterpage.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Hide();
            revokegym nrevokegym=new revokegym();
            nrevokegym.ShowDialog();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }
    }
}

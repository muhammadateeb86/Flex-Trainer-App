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
    public partial class GymOwner : Form
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
        public GymOwner(int Owner_Id)
        {
            InitializeComponent();

            this.Owner_Id = Owner_Id;

            button1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 20, 20));
            button1.Invalidate();
            button2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button2.Width, button2.Height, 20, 20));
            button2.Invalidate();
            //button3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button3.Width, button3.Height, 20, 20));
            //button3.Invalidate();
        }

        private void GymOwner_Load(object sender, EventArgs e)
        {

        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    Addtrainer nAddtrainer=new Addtrainer(GymOwnerID);
        //    nAddtrainer.ShowDialog();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            RemoveMT nremoveMt= new RemoveMT(Owner_Id); 
            nremoveMt.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reports nreports= new Reports();
            nreports.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Addtrainer add_trainer = new Addtrainer(Owner_Id);
            add_trainer.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            GYMRegistration add_gym = new GYMRegistration(Owner_Id);
            add_gym.ShowDialog();
        }
    }
}

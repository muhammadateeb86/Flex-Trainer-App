using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flextrainer
{
    public partial class Trainer : Form
    {
        private int Trainer_ID;
        public Trainer(int trainerID)
        {
            InitializeComponent();
            this.Trainer_ID = trainerID;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ADDWORKOUT trainerWO = new ADDWORKOUT();
            trainerWO.ShowDialog();
        }

        private void Trainer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Feedback feedbackform = new Feedback(Trainer_ID);
            feedbackform.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Diettrainer ntrainer = new Diettrainer();
            ntrainer.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            TrainerApointment trainerapp = new TrainerApointment(Trainer_ID);
            trainerapp.ShowDialog();

        }
    }
}

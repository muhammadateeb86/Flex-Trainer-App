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
    public partial class QueryReport : Form
    {
        public QueryReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Query1 q1 = new Query1();
            q1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Query2 q2 = new Query2();
            q2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Query3 q3 = new Query3();
            q3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Query4 q4 = new Query4();
            q4.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Query5 q5 = new Query5();
            q5.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Query6 q6 = new Query6();
            q6.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Query7 q7 = new Query7();
            q7.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Query8 q8 = new Query8();
            q8.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Query9 q9 = new Query9();
            q9.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Query10 q10 = new Query10();
            q10.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Query11 q11 = new Query11();
            q11.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Query12 q12 = new Query12();
            q12.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Query13 q13 = new Query13();
            q13.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Query14 q14 = new Query14();
            q14.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Query15 q15 = new Query15();
            q15.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Query16 q16 = new Query16();
            q16.ShowDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Query17 q17 = new Query17();
            q17.ShowDialog();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Query18 q18 = new Query18();
            q18.ShowDialog();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Query19 q19 = new Query19();
            q19.ShowDialog();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Query20 q20 = new Query20();
            q20.ShowDialog();
        }

        private void QueryReport_Load(object sender, EventArgs e)
        {
            //1 Details of members of one specific gym that get training from 1 specific trainer.
            //2 Details of members from one specific gym that follow a specific diet plan.
            //3 Details of members across all gyms of a specific trainer that follow a specific diet plan.
            //4 Count of members who will be using specific machines on a given day in a specific gym.
            //5.List of Diet plans that have less than 500 calorie meals as breakfast.
            //6.List of diet plans in which total carbohydrate intake is less than 300 grams.
            //7.List of workout plans that don’t require using a specific machine.
            //8.List of diet plans which doesn’t have peanuts as allergens.
            //9.New membership data in last 3 months(Gym Owner).
            //10.Comparison of total members in multiple gyms, in the past 6 months.

            //11.Retrieve the names of gym owners who own more than 2 gyms.
            //12.Retrieve the names of trainers who have appointments with more than 5 members.
            //13.Retrieve the names of gyms where more than 5 members are enrolled in the 'Weight Loss Plan' workout.
            //14.Retrieve the names of members who have given feedback for more than 2 trainers
            //15.Find Trainers with Highest Average Feedback Ratings
            //16.Retrieves the names of members who have not provided any feedback
            //17.Find Members with Expired Memberships
            //18.Identify Trainers with the Most Diverse Specializations
            //19.Find the total number of appointments scheduled for each traine
            //20.Display the names of members who have not yet registered for any diet plan






        }
    }
}

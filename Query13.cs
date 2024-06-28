using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flextrainer
{
    public partial class Query13 : Form
    {
        public Query13()
        {
            InitializeComponent();
        }

        private void Query13_Load(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT Gym_Name FROM Gym WHERE Gym_Id IN (   SELECT Gym_Id   FROM Membership   WHERE Member_Id IN (     SELECT Member_Id     FROM Workout_Plan     WHERE Workout_Plan_Name = 'Weight Loss Plan'   )   GROUP BY Gym_Id   HAVING COUNT(Member_Id) > 5 );", conn1);

            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView2.DataSource = DS.Tables[0];

        }
    }
}

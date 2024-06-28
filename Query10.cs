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
    public partial class Query10 : Form
    {
        public Query10()
        {
            InitializeComponent();
        }

        private void Query10_Load(object sender, EventArgs e)
        {

            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT Gym_Id, COUNT(Member_Id) AS Total_Members FROM Membership WHERE Start_Date >= DATEADD(MONTH, -6, GETDATE()) GROUP BY Gym_Id);", conn1);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView2.DataSource = DS.Tables[0];
        }
    }
}

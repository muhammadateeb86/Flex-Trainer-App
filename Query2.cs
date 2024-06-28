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
    public partial class Query2 : Form
    {
        public Query2()
        {
            InitializeComponent();
        }

        private void Query2_Load(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT m.* FROM Member m INNER JOIN Diet_Plan dp ON m.Member_Id = dp.Member_Id INNER JOIN Membership s ON m.Member_ID = s.Member_Id WHERE s.Gym_Id = 1   AND dp.Diet_Plan_Name = 'Low Carb Diet'; ", conn1);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView2.DataSource = DS.Tables[0];
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

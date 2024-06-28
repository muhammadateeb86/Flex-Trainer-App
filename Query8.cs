using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flextrainer
{
    public partial class Query8 : Form
    {
        public Query8()
        {
            InitializeComponent();
        }

        private void Query8_Load(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT* FROM Diet_Plan WHERE Plan_Id NOT IN(     SELECT DISTINCT dp.Plan_Id     FROM Diet_Plan dp     INNER JOIN Meal m ON dp.Plan_Id = m.Diet_Plan_Id     WHERE m.Meal_Description LIKE '%peanuts%' );", conn1);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView2.DataSource = DS.Tables[0];
        }
    }
}

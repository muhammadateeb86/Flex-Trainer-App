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
    public partial class Query6 : Form
    {
        public Query6()
        {
            InitializeComponent();
        }
        

        private void Query6_Load(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT dp.* FROM Diet_Plan dp JOIN (     SELECT Diet_Plan_Id, SUM(Meal_Carb) AS Total_Carbs     FROM Meal     GROUP BY Diet_Plan_Id ) AS TotalCarbsPerPlan ON dp.Plan_Id = TotalCarbsPerPlan.Diet_Plan_Id WHERE TotalCarbsPerPlan.Total_Carbs< 300;", conn1);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView2.DataSource = DS.Tables[0];
        }
    }
}

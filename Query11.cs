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
    public partial class Query11 : Form
    {
        public Query11()
        {
            InitializeComponent();
        }

        private void Query11_Load(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT O.Owner_Id, O.Owner_Name, COUNT(G.Gym_Id) AS Gym_Count FROM Gym_Owner O JOIN Gym G ON O.Owner_Id = G.Owner_Id GROUP BY O.Owner_Id, O.Owner_Name HAVING COUNT(G.Gym_Id) > 1; ", conn1);

            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView2.DataSource = DS.Tables[0];


        }
    }
}

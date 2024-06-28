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
    public partial class Query12 : Form
    {
        public Query12()
        {
            InitializeComponent();
        }

        private void Query12_Load(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT Trainer_Name FROM Trainer WHERE Trainer_Id IN (   SELECT Trainer_Id   FROM Appointment   GROUP BY Trainer_Id   HAVING COUNT(Member_Id) > 5 ); ", conn1);

            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView2.DataSource = DS.Tables[0];

        }
    }
}

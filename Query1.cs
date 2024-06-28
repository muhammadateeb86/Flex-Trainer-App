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
    public partial class Query1 : Form
    {
        public Query1()
        {
            InitializeComponent();
        }

        private void Query1_Load(object sender, EventArgs e)
        {

            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT m.* FROM Member m INNER JOIN Appointment a ON m.Member_Id = a.Member_Id INNER JOIN Trainer t ON a.Trainer_Id = t.Trainer_Id INNER JOIN WORKSFOR w ON t.Trainer_Id = w.TRAINER_ID INNER JOIN Gym g ON w.GYM_ID = g.Gym_Id WHERE g.Gym_Id = 2   AND t.Trainer_Id = 1; ", conn1);
            SqlDataAdapter DA = new SqlDataAdapter(cmd1);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView2.DataSource = DS.Tables[0];
        }
    }
}

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
    public partial class Query3 : Form
    {
        public Query3()
        {
            InitializeComponent();
        }

        private void Query3_Load(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=HASSANNAQVI\\SQLEXPRESS;Initial Catalog=db_project;Integrated Security=True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT m.*  FROM Member m INNER JOIN Diet_Plan dp ON m.Member_Id = dp.Member_Id  INNER JOIN Appointment a ON m.Member_Id = a.Member_Id  INNER JOIN Trainer t ON a.Trainer_Id = t.Trainer_Id  WHERE t.Trainer_Id = 1    AND dp.Diet_Plan_Name = 'Low Carb Diet';  ", conn1);
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectB
{
    public partial class Studentportal : Form
    {
        public Studentportal()
        {
            InitializeComponent();
           
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        DataGridViewButtonColumn btn = new DataGridViewButtonColumn();

        DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();

        public static int current = 0 ;
        public static int current2 = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ViewStudents.Columns[e.ColumnIndex].Name == "Update")
            {
                DataGridViewRow edit = ViewStudents.Rows[e.RowIndex];
                string temp = edit.Cells[0].Value.ToString();
                current = Int32.Parse(temp);
                frmstudent f = new frmstudent();
                this.Hide();
                f.Show();
            }
            if (ViewStudents.Columns[e.ColumnIndex].Name == "Delete")
            {
                DataGridViewRow edit = ViewStudents.Rows[e.RowIndex];
                string temp = edit.Cells[0].Value.ToString();
                current2 = Int32.Parse(temp);
                MessageBox.Show("Are you sure you want to delete?");
                string cmd1 = string.Format("DELETE FROM StudentAttendance WHERE StudentId='{0}'", current2);
                int rows1 = Database_Connection.get_instance().Executequery(cmd1);
                string cmd2 = string.Format("DELETE FROM Student WHERE Id='{0}'",current2);
                int rows = Database_Connection.get_instance().Executequery(cmd2);
                MessageBox.Show(String.Format("{0} rows affected", rows));

                Studentportal f = new Studentportal();
                this.Hide();
                f.Show();
            }
        }

        private void Studentportal_Load(object sender, EventArgs e)
        {
            btn.Name = "Update";
            btn.Text = "EDIT";
            btn.UseColumnTextForButtonValue = true;
            btn2.Name = "Delete";
            btn2.Text = "DELETE";
            btn2.UseColumnTextForButtonValue = true;
            string cmd = "SELECT * FROM Student";
            BindingSource s = new BindingSource();
            s.DataSource = Database_Connection.get_instance().ListofStudents(cmd);
            ViewStudents.DataSource = s;
            DataGridViewColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = "STATUS";
            int colIndex = ViewStudents.Columns.Add(col);
            int index = 0;
            foreach (DataGridViewRow row in ViewStudents.Rows)
            {
                if (row.Cells[6].FormattedValue.ToString() == "5")
                {


                    row.Cells[7].Value = "Active";

                }
                if (row.Cells[6].FormattedValue.ToString() == "6")
                {
                    row.Cells[7].Value = "InActive";

                }
                index++;
            }
            ViewStudents.Columns.RemoveAt(6);
            ViewStudents.Columns.Add(btn);
            ViewStudents.Columns.Add(btn2);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            frmstudent f = new frmstudent();
            this.Hide();
            f.Show();
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            Dashboard f = new Dashboard();
            this.Hide();
            f.Show();
        }
    }
}

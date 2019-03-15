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
    public partial class addrubric : Form
    {
        public addrubric()
        {
            InitializeComponent();
        }
        Addrubrics r = new Addrubrics();
        bool n = false;
        int temp = viewclo.curr3;
        private void addrubric_Load(object sender, EventArgs e)
        {
           
            string cmd = string.Format("SELECT * FROM Rubric WHERE CloId='{0}'",temp);
            label2.Text = viewclo.details;
            BindingSource s = new BindingSource();
            s.DataSource = Database_Connection.get_instance().Listofrubric(cmd);
            Viewrub.DataSource = s;
            btn.Name = "Update";
            btn.Text = "EDIT";
            btn.UseColumnTextForButtonValue = true;
            btn2.Name = "Delete";
            btn2.Text = "DELETE";
            btn2.UseColumnTextForButtonValue = true;
            btn3.Name = "Manage_Rubric_level";
            btn3.Text = "Level";
            btn3.UseColumnTextForButtonValue = true;



            Viewrub.Columns.Add(btn);
            Viewrub.Columns.Add(btn2);
            Viewrub.Columns.Add(btn3);

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!n)
            {
                r.Detail = txt_detail.Text;
                string cmd2 = string.Format("INSERT INTO Rubric(Details,CloId) VALUES('{0}','{1}')", r.Detail, temp);
                int rows = Database_Connection.get_instance().Executequery(cmd2);
                MessageBox.Show(String.Format("{0} rows affected", rows));
                addrubric s = new addrubric();
                this.Hide();
                s.Show();
            }
            else
            {

                string cmd3 = string.Format("UPDATE  Rubric SET Details = '{0}', CloId ='{1}' WHERE Id= '{2}'", txt_detail.Text, temp, curr2);
                int rows = Database_Connection.get_instance().Executequery(cmd3);
                MessageBox.Show(String.Format("{0} rows affected", rows));
                addrubric s = new addrubric();
                this.Hide();
                s.Show();
            }
        }
        DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btn3 = new DataGridViewButtonColumn();
        public static string detail;       
        public static int curr2;
        private void Viewcl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Viewrub.Columns[e.ColumnIndex].Name == "Update")
            {
                DataGridViewRow edit = Viewrub.Rows[e.RowIndex];
                string tempr = edit.Cells[0].Value.ToString();
                string nm = edit.Cells[1].Value.ToString();
                txt_detail.Text = nm;
                curr2 = Int32.Parse(tempr);
                n = true;
              
            }
            if (Viewrub.Columns[e.ColumnIndex].Name == "Delete")
            {
                DataGridViewRow edit = Viewrub.Rows[e.RowIndex];
                string tempr = edit.Cells[0].Value.ToString();
                curr2 = Int32.Parse(tempr);
                MessageBox.Show("Are you sure you want to delete?");
                string list = string.Format("SELECT * FROM RubricLevel WHERE RubricId='{0}'", curr2);
                if (Database_Connection.get_instance().Listoflevel(list) != null)
                {
                    string cmd3 = string.Format("DELETE FROM RubricLevel WHERE RubricId='{0}'", curr2);
                    int rows = Database_Connection.get_instance().Executequery(cmd3);
                }
                string cmd2 = string.Format("DELETE FROM Rubric WHERE Id='{0}'", curr2);
                int row = Database_Connection.get_instance().Executequery(cmd2);
                MessageBox.Show(String.Format("{0} rows affected", row));
                addrubric rf = new addrubric();
                this.Hide();
                rf.Show();
            }
            if (Viewrub.Columns[e.ColumnIndex].Name == "Manage_Rubric_level")
            {
                DataGridViewRow edit = Viewrub.Rows[e.RowIndex];
                string temp = edit.Cells[0].Value.ToString();
                detail = edit.Cells[1].Value.ToString();
                curr2 = Int32.Parse(temp);
                rublevel f = new rublevel();
                this.Hide();
                f.Show();
            }

        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            Dashboard f = new Dashboard();
            this.Hide();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            viewclo s = new viewclo();
            this.Hide();
            s.Show();
        }
    }
}

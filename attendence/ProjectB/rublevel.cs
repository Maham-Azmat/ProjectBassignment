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
    public partial class rublevel : Form
    {
        public rublevel()
        {
            InitializeComponent();
        }
        int curr3;
        bool n;
        int temp = addrubric.curr2;
        private void Viewrublvl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Viewrublvl.Columns[e.ColumnIndex].Name == "Update")
            {
                DataGridViewRow edit = Viewrublvl.Rows[e.RowIndex];
                string tempr = edit.Cells[0].Value.ToString();
                string nm = edit.Cells[2].Value.ToString();
                string meas = edit.Cells[3].Value.ToString();
                txt_detail.Text = nm;
                txt_lvl.Text = meas;
                curr3 = Int32.Parse(tempr);
                n = true;

            }
            if (Viewrublvl.Columns[e.ColumnIndex].Name == "Delete")
            {
                DataGridViewRow edit = Viewrublvl.Rows[e.RowIndex];
                string tempr = edit.Cells[0].Value.ToString();
                curr3 = Int32.Parse(tempr);
                MessageBox.Show("Are you sure you want to delete?");
                string cmd2 = string.Format("DELETE FROM RubricLevel WHERE Id='{0}'", curr3);
                int rows = Database_Connection.get_instance().Executequery(cmd2);
                MessageBox.Show(String.Format("{0} rows affected", rows));
                rublevel rf = new rublevel();
                this.Hide();
                rf.Show();
            }

        }

        private void rublevel_Load(object sender, EventArgs e)
        {
            label2.Text = addrubric.detail;
            string cmd = string.Format("SELECT * FROM Rubriclevel WHERE RubricId='{0}'", temp);
            BindingSource s = new BindingSource();
            s.DataSource = Database_Connection.get_instance().Listoflevel(cmd);
            Viewrublvl.DataSource = s;
            btn.Name = "Update";
            btn.Text = "EDIT";
            btn.UseColumnTextForButtonValue = true;
            btn2.Name = "Delete";
            btn2.Text = "DELETE";
            btn2.UseColumnTextForButtonValue = true;

            Viewrublvl.Columns.Add(btn);
            Viewrublvl.Columns.Add(btn2);


        }
        rubriclevel r = new rubriclevel();

        DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btn3 = new DataGridViewButtonColumn();
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!n)
            {
                r.Details = txt_detail.Text;
                r.Measurementlevel = Int32.Parse(txt_lvl.Text);
                string cmd2 = string.Format("INSERT INTO RubricLevel(RubricId,Details,MeasurementLevel) VALUES('{0}','{1}','{2}')", temp, r.Details, r.Measurementlevel);
                int rows = Database_Connection.get_instance().Executequery(cmd2);
                MessageBox.Show(String.Format("{0} rows affected", rows));
                rublevel s = new rublevel();
                this.Hide();
                s.Show();
            }
            else
            {
                string cmd3 = string.Format("UPDATE  RubricLevel SET Details = '{0}', RubricId ='{1}', MeasurementLevel='{2}' WHERE Id= '{3}'", txt_detail.Text, temp, Int32.Parse(txt_lvl.Text), curr3);
                int rows = Database_Connection.get_instance().Executequery(cmd3);
                MessageBox.Show(String.Format("{0} rows affected", rows));

                rublevel s = new rublevel();
                this.Hide();
                s.Show();
            }
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            Dashboard s = new Dashboard();
            this.Hide();
            s.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addrubric r = new addrubric();
            this.Hide();
            r.Show();
        }
    }
}

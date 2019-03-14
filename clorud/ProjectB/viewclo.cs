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
    public partial class viewclo : Form
    {
        public viewclo()
        {
            InitializeComponent();
        }
        
        public static int curr2;
        public static int curr3;

        public static string details;
        private void Viewcl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
            if (Viewcl.Columns[e.ColumnIndex].Name == "Action")
            {
                DataGridViewRow edit = Viewcl.Rows[e.RowIndex];
                string temp = edit.Cells[0].Value.ToString();
                curr2 = Int32.Parse(temp);
                Addclo f = new Addclo();
                this.Hide();
                f.Show();
            }
            if (Viewcl.Columns[e.ColumnIndex].Name == "Action3")
            {
                DataGridViewRow edit = Viewcl.Rows[e.RowIndex];
                string temp = edit.Cells[0].Value.ToString();
                details= edit.Cells[1].Value.ToString();
                curr3 = Int32.Parse(temp);
                addrubric f = new addrubric();
                this.Hide();
                f.Show();
            }
            if (Viewcl.Columns[e.ColumnIndex].Name == "Action2")
            {
                DataGridViewRow edit = Viewcl.Rows[e.RowIndex];
                string temp = edit.Cells[0].Value.ToString();
                curr2 = Int32.Parse(temp);
                MessageBox.Show("Are you sure you want to delete?");
                string cmd2 = string.Format("DELETE FROM Clo WHERE Id='{0}'", curr2);
                int rows = Database_Connection.get_instance().Executequery(cmd2);
                MessageBox.Show(String.Format("{0} rows affected", rows));

                viewclo f = new viewclo();
                this.Hide();
                f.Show();
            }
            //if (Viewcl.Columns[e.ColumnIndex].C=="Name" || Viewcl.Columns[e.ColumnIndex].Name == "DateCreted" || Viewcl.Columns[e.ColumnIndex].Name == "DateUpdated")
            //if(Viewcl.SelectedRows)
            //{

            //    Addclo f = new Addclo();
            //    this.Hide();
            //    f.Show();
            //}

            }
        DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btn3 = new DataGridViewButtonColumn();

        private void viewclo_Load(object sender, EventArgs e)
        {
            btn.Name = "Action";
            btn.Text = "EDIT";
            btn.UseColumnTextForButtonValue = true;
            btn2.Name = "Action2";
            btn2.Text = "DELETE";
            btn2.UseColumnTextForButtonValue = true;
            btn3.Name = "Action3";
            btn3.Text = "Add Rubric";
            btn3.UseColumnTextForButtonValue = true;
            string cmd = "SELECT * FROM Clo";
            BindingSource s = new BindingSource();
            s.DataSource = Database_Connection.get_instance().ListofClos(cmd);
            Viewcl.DataSource = s;
            Viewcl.Columns.Add(btn);
            Viewcl.Columns.Add(btn2);
            Viewcl.Columns.Add(btn3);

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Addclo a = new Addclo();
            this.Hide();
            a.Show();
        }
    }
}

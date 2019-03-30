using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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
                MessageBox.Show("Are you sure you want to delete CLO and All of its Rubrics?");
                string list = string.Format("SELECT * FROM Rubric WHERE CloId='{0}'", curr2);
                if (Database_Connection.get_instance().Listofrubric(list) != null)
                {
                    string list2 = string.Format("SELECT Id FROM Rubric WHERE CloId='{0}'", curr2);
                    SqlDataReader rowlist = Database_Connection.get_instance().Getdata(list2);
                    while (rowlist.Read())
                    {
                        int rowlist2 = rowlist.GetInt32(0);


                        string list3 = string.Format("SELECT * FROM RubricLevel WHERE RubricId='{0}'", rowlist2);
                        if (Database_Connection.get_instance().Listoflevel(list3) != null)
                        {
                            string cmd4 = string.Format("DELETE FROM RubricLevel WHERE RubricId='{0}'", rowlist2);
                            int row1 = Database_Connection.get_instance().Executequery(cmd4);
                           
                        }

                        string listasscom = string.Format("SELECT * FROM AssessmentComponent WHERE RubricId='{0}'", rowlist2);
                        if (Database_Connection.get_instance().Listofassessmentcomp(listasscom) != null)
                        {
                            string cmdasscomp = string.Format("DELETE FROM AssessmentComponent WHERE RubricId='{0}'", rowlist2);
                            int rowsasscomp = Database_Connection.get_instance().Executequery(cmdasscomp);
                            string cmd2 = string.Format("DELETE FROM Rubric WHERE CloId='{0}'", curr2);
                            int row = Database_Connection.get_instance().Executequery(cmd2);
                        }
                    }
                }             
                string cmd3 = string.Format("DELETE FROM Clo WHERE Id='{0}'", curr2);
                
                int rows = Database_Connection.get_instance().Executequery(cmd3);
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
            btn3.Text = "Manage Rubric";
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            this.Hide();
            d.Show();
        }
    }
}

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
    public partial class frmassesment : Form
    {
        public frmassesment()
        {
            InitializeComponent();
        }
        assesment a = new assesment();
        bool n = false;
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!n)
            {
                a.Title = txt_title.Text;
                a.Totalmarks = int.Parse(txt_marks.Text);
                a.Totalweightage = int.Parse(textBox1.Text);
                a.Datecreated = DateTime.Now;
                SqlConnection connection = new SqlConnection("Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("INSERT INTO Assessment (Title,DateCreated,TotalMarks,TotalWeightage) VALUES (@title, @Date, @marks, @wght)", connection);
                cmd.Parameters.AddWithValue("@title", a.Title);
                cmd.Parameters.AddWithValue("@Date", a.Datecreated);
                cmd.Parameters.AddWithValue("@marks", a.Totalmarks);
                cmd.Parameters.AddWithValue("@wght", a.Totalweightage);
                connection.Open();
                cmd.ExecuteNonQuery();
                frmassesment s = new frmassesment();
                this.Hide();
                s.Show();
            }
            else
            {
                SqlConnection connection = new SqlConnection("Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True");

                SqlCommand cmd = new SqlCommand("UPDATE Assessment SET Title = @name,TotalMarks = @mark,TotalWeightage = @wght WHERE Id= @id", connection);
                cmd.Parameters.AddWithValue("@name", txt_title.Text);
                cmd.Parameters.AddWithValue("@mark", txt_marks.Text);
                cmd.Parameters.AddWithValue("@wght", textBox1.Text);
                cmd.Parameters.AddWithValue("@id", current);
                connection.Open();
                cmd.ExecuteNonQuery();
                n = false;
                current = 0;
                frmassesment s = new frmassesment();
                this.Hide();
                s.Show();
            }
        }
        DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btn3 = new DataGridViewButtonColumn();
        private void frmassesment_Load(object sender, EventArgs e)
        {
            string cmd = string.Format("SELECT * FROM Assessment");
            BindingSource s = new BindingSource();
            s.DataSource = Database_Connection.get_instance().Listofassessment(cmd);
            assesmentview.DataSource = s;

            btn.Name = "Update";
            btn.Text = "EDIT";
            btn.UseColumnTextForButtonValue = true;
            btn2.Name = "Delete";
            btn2.Text = "DELETE";
            btn2.UseColumnTextForButtonValue = true;
            btn3.Name = "Add";
            btn3.Text = "Add";
            btn3.UseColumnTextForButtonValue = true;
            assesmentview.Columns.Add(btn);
            assesmentview.Columns.Add(btn2);
            assesmentview.Columns.Add(btn3);
        }
        public static int current;
        public static string temp2;
        private void assesmentview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (assesmentview.Columns[e.ColumnIndex].Name == "Update")
            {
                DataGridViewRow edit = assesmentview.Rows[e.RowIndex];
                string tempr = edit.Cells[0].Value.ToString();
                string nm = edit.Cells[1].Value.ToString();
                string nm2 = edit.Cells[3].Value.ToString();
                string nm3 = edit.Cells[4].Value.ToString();
                txt_title.Text = nm;
                txt_marks.Text = nm2;
                textBox1.Text = nm3;
                current = Int32.Parse(tempr);
                n = true;

            }
            if (assesmentview.Columns[e.ColumnIndex].Name == "Delete")
            {
                DataGridViewRow edit = assesmentview.Rows[e.RowIndex];
                string tempr = edit.Cells[0].Value.ToString();
                current = Int32.Parse(tempr);
                MessageBox.Show("Are you sure you want to delete?");
                string cmd2 = string.Format("DELETE FROM Assessment WHERE Id='{0}'", current);
                int row = Database_Connection.get_instance().Executequery(cmd2);
                MessageBox.Show(String.Format("{0} rows affected", row));
                current = 0;
                frmassesment rf = new frmassesment();
                this.Hide();
                rf.Show();
            }
            if (assesmentview.Columns[e.ColumnIndex].Name == "Add")
            {
                DataGridViewRow edit = assesmentview.Rows[e.RowIndex];
                string temp = edit.Cells[0].Value.ToString();
                temp2 = edit.Cells[1].Value.ToString();
                current = Int32.Parse(temp);
                frmasscomp f = new frmasscomp();
                this.Hide();
                f.Show();
            }
        }
    }
}

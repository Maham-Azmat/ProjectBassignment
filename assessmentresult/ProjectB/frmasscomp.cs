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
    public partial class frmasscomp : Form
    {
        public frmasscomp()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
        private void frmasscomp_Load(object sender, EventArgs e)
        {
            string cmd2 = "SELECT * FROM Assessment";
            SqlDataReader reader2 = Database_Connection.get_instance().Getdata(cmd2);
            List<string> name2 = new List<string>();
            while (reader2.Read())
            {
                name2.Add(reader2.GetString(1));

            }
            txt_assessment.DataSource = name2;
            if (frmassesment.temp2 != null)
            {
                txt_assessment.Text = frmassesment.temp2.ToString();
                frmassesment.temp2 = null;
            }
            else
            {
                txt_assessment.Text = " ";
            }
            string cmd = "SELECT * FROM Rubric";
            SqlDataReader reader = Database_Connection.get_instance().Getdata(cmd);
            List<string> name = new List<string>();
            while (reader.Read())
            {
                name.Add(reader.GetString(1));

            }
            txt_rub.DataSource = name;
            txt_rub.Text = " ";

            string cmd3 = string.Format("SELECT * FROM AssessmentComponent");
            BindingSource s = new BindingSource();
            s.DataSource = Database_Connection.get_instance().Listofassessmentcomp(cmd3);
            asscompview.DataSource = s;

            btn.Name = "Update";
            btn.Text = "EDIT";
            btn.UseColumnTextForButtonValue = true;
            btn2.Name = "Delete";
            btn2.Text = "DELETE";
            btn2.UseColumnTextForButtonValue = true;



            asscompview.Columns.Add(btn);
            asscompview.Columns.Add(btn2);
        }
        asscomp a = new asscomp();
        bool n = false;
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!n)
            {
                a.Name = txt_name.Text;
                string cmd = "SELECT * FROM Rubric";
                SqlDataReader reader = Database_Connection.get_instance().Getdata(cmd);
                while (reader.Read())
                {
                    if (reader.GetString(1) == txt_rub.Text)
                    {
                        a.Rubricid = reader.GetInt32(0);

                    }
                }

                a.Totalmarks = Convert.ToInt32(txt_marks.Text);
                a.Datecreated = DateTime.Now;
                a.Dateupdated = DateTime.Now;

                string cmd1 = "SELECT * FROM Assessment";
                SqlDataReader reader1 = Database_Connection.get_instance().Getdata(cmd1);
                while (reader1.Read())
                {
                    if (reader1.GetString(1) == txt_assessment.Text)
                    {
                        a.Assessmentid = reader1.GetInt32(0);

                    }
                }
                SqlConnection connection = new SqlConnection("Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True");
                SqlCommand cmd2 = new SqlCommand("INSERT INTO AssessmentComponent (Name,RubricId,TotalMarks,DateCreated,DateUpdated,AssessmentId) VALUES (@name,@rubric,@marks, @Date,@dateup ,@assessment)", connection);
                cmd2.Parameters.AddWithValue("@name", a.Name);
                cmd2.Parameters.AddWithValue("@Date", a.Datecreated);
                cmd2.Parameters.AddWithValue("@dateup", a.Dateupdated);
                cmd2.Parameters.AddWithValue("@marks", a.Totalmarks);
                cmd2.Parameters.AddWithValue("@rubric", a.Rubricid);
                cmd2.Parameters.AddWithValue("@assessment", a.Assessmentid);
                connection.Open();
                cmd2.ExecuteNonQuery();
                frmasscomp s = new frmasscomp();
                this.Hide();
                s.Show();
            }
            else
            {
                SqlConnection connection = new SqlConnection("Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True");
                a.Dateupdated = DateTime.Now.Date;
                string cmd = "SELECT * FROM Rubric";
                SqlDataReader reader = Database_Connection.get_instance().Getdata(cmd);
                while (reader.Read())
                {
                    if (reader.GetString(1) == txt_rub.Text)
                    {
                        a.Rubricid = reader.GetInt32(0);

                    }
                }
                string cmd1 = "SELECT * FROM Assessment";
                SqlDataReader reader1 = Database_Connection.get_instance().Getdata(cmd1);
                while (reader1.Read())
                {
                    if (reader1.GetString(1) == txt_assessment.Text)
                    {
                        a.Assessmentid = reader1.GetInt32(0);

                    }
                }
                SqlCommand cmd2 = new SqlCommand("UPDATE  AssessmentComponent SET Name = @name,DateUpdated = @date, RubricId=@rub, TotalMarks=@mark,AssessmentId=@ass WHERE Id= @id", connection);
                cmd2.Parameters.AddWithValue("@name", txt_name.Text);
                cmd2.Parameters.AddWithValue("@date", a.Dateupdated);
                cmd2.Parameters.AddWithValue("@rub", a.Rubricid);
                cmd2.Parameters.AddWithValue("@ass", a.Assessmentid);
                cmd2.Parameters.AddWithValue("@mark", txt_marks.Text);
                cmd2.Parameters.AddWithValue("@id", current);
                connection.Open();
                cmd2.ExecuteNonQuery();
                n = false;
                current = 0;
                frmasscomp s = new frmasscomp();
                this.Hide();
                s.Show();

            }
        }
        int current;
        private void asscompview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (asscompview.Columns[e.ColumnIndex].Name == "Update")
            {
                DataGridViewRow edit = asscompview.Rows[e.RowIndex];
                string tempr = edit.Cells[0].Value.ToString();
                string nm = edit.Cells[1].Value.ToString();
                string nm1 = edit.Cells[2].Value.ToString();
                string nm2 = edit.Cells[3].Value.ToString();
                string nm3 = edit.Cells[6].Value.ToString();
                txt_name.Text = nm;
                string cmd = "SELECT * FROM Rubric";
                SqlDataReader reader = Database_Connection.get_instance().Getdata(cmd);
                while (reader.Read())
                {
                    if (reader.GetInt32(0) == Int32.Parse(nm1))
                    {
                        txt_rub.Text = reader.GetString(1);

                    }
                }
                string cmd1 = "SELECT * FROM Assessment";
                SqlDataReader reader1 = Database_Connection.get_instance().Getdata(cmd1);
                while (reader1.Read())
                {
                    if (reader1.GetInt32(0) == Int32.Parse(nm3))
                    {
                        txt_assessment.Text = reader1.GetString(1);

                    }
                }
                txt_marks.Text = nm2;
                current = Int32.Parse(tempr);
                n = true;

            }
            if (asscompview.Columns[e.ColumnIndex].Name == "Delete")
            {
                DataGridViewRow edit = asscompview.Rows[e.RowIndex];
                string tempr = edit.Cells[0].Value.ToString();
                current = Int32.Parse(tempr);
                MessageBox.Show("Are you sure you want to delete?");

                string cmd1 = string.Format("DELETE FROM StudentResult WHERE AssessmentComponentId='{0}'", current);
                int row1 = Database_Connection.get_instance().Executequery(cmd1);

                string cmd2 = string.Format("DELETE FROM AssessmentComponent WHERE Id='{0}'", current);
                int row = Database_Connection.get_instance().Executequery(cmd2);
                MessageBox.Show(String.Format("{0} rows affected", row));
                current = 0;
                frmasscomp rf = new frmasscomp();
                this.Hide();
                rf.Show();

            }
        }
            private void panel16_Paint(object sender, PaintEventArgs e)
            {


            }

        private void button1_Click(object sender, EventArgs e)
        {
            frmassesment a = new frmassesment();
            this.Hide();
            a.Show();

        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            this.Hide();
            d.Show();
        }
    }
    }

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
            string cmd = "SELECT * FROM Rubric";
            SqlDataReader reader = Database_Connection.get_instance().Getdata(cmd);
            List<string> name = new List<string>();
            while (reader.Read())
            {
                name.Add(reader.GetString(1));

            }
            txt_rub.DataSource = name;

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

            }
        }
    }
}

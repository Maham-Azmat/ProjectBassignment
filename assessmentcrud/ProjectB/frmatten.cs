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
    public partial class frmatten : Form
    {
        public frmatten()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        DataGridViewComboBoxColumn sta = new DataGridViewComboBoxColumn();
        attendence a = new attendence();
        private void btn_save_Click(object sender, EventArgs e)
        {
            Attendencelist a = new Attendencelist();
            this.Hide();
            a.Show();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmatten_Load(object sender, EventArgs e)
        {
            

            string cmd = string.Format("SELECT * FROM Student WHERE Status='{0}'", 5);

            BindingSource s = new BindingSource();
            s.DataSource = Database_Connection.get_instance().ListofStudents(cmd);
            markattendance.DataSource = s;
            sta.Name = "STATUS";

            sta.HeaderText = "STATUS";
            sta.MaxDropDownItems = 4;
            sta.Items.Add("Present");
            sta.Items.Add("Absent");
            sta.Items.Add("Leave");
            sta.Items.Add("Late");
            markattendance.Columns.Add(sta);
            markattendance.Columns.RemoveAt(3);
            markattendance.Columns.RemoveAt(3);
            markattendance.Columns.RemoveAt(4);
            // cmb_stulist.DisplayMember = "Name";
        }

        private void markattendance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("INSERT INTO ClassAttendance(AttendanceDate) VALUES (@Date)", connection);

            cmd.Parameters.AddWithValue("@Date", DateTime.Now.Date);

            connection.Open();
            cmd.ExecuteNonQuery();

            for (int ptr = 0; ptr < markattendance.Rows.Count-1; ptr++)
            {
               string temp = markattendance.Rows[ptr].Cells[0].Value.ToString();
                a.Studentid = Int32.Parse(temp);
                string tempr = markattendance.Rows[ptr].Cells[4].Value.ToString();
                string cmdtemp = "SELECT * FROM Lookup";
                SqlDataReader reader = Database_Connection.get_instance().Getdata(cmdtemp);
                while (reader.Read())
                {
                    if (reader.GetString(1) == tempr)
                    {
                        a.Status = reader.GetInt32(0);

                    }
                }

                string id = "SELECT * from ClassAttendance";
                SqlDataReader reader1 = Database_Connection.get_instance().Getdata(id);
                while (reader1.Read())
                {
                    if (reader1.GetDateTime(1) == DateTime.Now.Date)
                    {
                        a.Attenid = reader1.GetInt32(0);

                    }
                }
                string cmd1 = string.Format("INSERT INTO StudentAttendance(AttendanceId,StudentId,AttendanceStatus) VALUES('{0}','{1}','{2}')", a.Attenid, a.Studentid, a.Status);
                int rows = Database_Connection.get_instance().Executequery(cmd1);
                MessageBox.Show("Attendence marked!!!");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard a = new Dashboard();
            this.Hide();
            a.Show();
        }
    }
}
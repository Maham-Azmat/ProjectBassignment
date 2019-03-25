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
        attendence a = new attendence();
        private void btn_save_Click(object sender, EventArgs e)
        {
            string cmd = "SELECT * FROM Student";
            SqlDataReader reader = Database_Connection.get_instance().Getdata(cmd);
            while (reader.Read())
            {
                if (reader.GetString(1) == cmb_stulist.Text)
                {
                    a.Studentid = reader.GetInt32(0);

                }
            }
            string check = "SELECT * FROM ClassAttendance";
            SqlDataReader checker= Database_Connection.get_instance().Getdata(check);
            while(checker.Read())
            {
                if (checker.GetDateTime(1) == Convert.ToDateTime(dateTimePicker1.Text))
                {
                    break;
                }
                else
                {
                    string temp = dateTimePicker1.Text;
                    a.Date = Convert.ToDateTime(temp);

                    SqlConnection connection = new SqlConnection("Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True");
                    SqlCommand cmd4 = new SqlCommand("INSERT INTO ClassAttendance(AttendanceDate) VALUES (@Date)", connection);

                    cmd4.Parameters.AddWithValue("@Date", a.Date);

                    connection.Open();
                    cmd4.ExecuteNonQuery();

                }
            }
            string cmd2 = "SELECT * FROM Lookup";
            SqlDataReader reader2 = Database_Connection.get_instance().Getdata(cmd2);
            while (reader2.Read())
            {
                if (reader.GetString(1) == attenstatus.Text)
                {
                    a.Status = reader.GetInt32(0);

                }
            }

            string id = string.Format("SELECT Id from ClassAttendance WHERE AttendenceDate='{0}'",a.Date);



            string cmd3 = string.Format("INSERT INTO StudentAttendence(StudentId,AttendanceStatus) VALUES('{0}','{1}')", a.Studentid, a.Status);
            int rows = Database_Connection.get_instance().Executequery(cmd3);
            MessageBox.Show("Attendence marked!!!");

           

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmatten_Load(object sender, EventArgs e)
        {
            string cmd = "SELECT * FROM Student";
            SqlDataReader reader = Database_Connection.get_instance().Getdata(cmd);
            List<string> name = new List<string>();
            while(reader.Read())
            {
                name.Add(reader.GetString(1));

            }
            cmb_stulist.DataSource = name;
           // cmb_stulist.DisplayMember = "Name";
        }
    }
}

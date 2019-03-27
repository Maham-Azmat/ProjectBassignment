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
    public partial class Attendencelist : Form
    {
        public Attendencelist()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            int attenid = 0;
            string cmd = "SELECT * FROM ClassAttendance";
            SqlDataReader reader = Database_Connection.get_instance().Getdata(cmd);
            while (reader.Read())
            {
                if (reader.GetDateTime(1) == Convert.ToDateTime(dateTimePicker1.Text))
                {
                    attenid = reader.GetInt32(0);

                }
            }
            SqlDataReader reader1 = Database_Connection.get_instance().Getdata(String.Format("SELECT FirstName,RegistrationNumber, Contact,AttendanceStatus From StudentAttendance SA JOIN Student S ON SA.StudentId=S.Id WHERE AttendanceId='{0}'",attenid));
            BindingSource s = new BindingSource();
            s.DataSource = reader1;
            attendancelist.DataSource = s;

            DataGridViewColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = "STATUS";
            int colIndex = attendancelist.Columns.Add(col);
            int index = 0;
            foreach (DataGridViewRow row in attendancelist.Rows)
            {
                if (row.Cells[3].FormattedValue.ToString() == "1")
                {
                    row.Cells[4].Value = "Present";

                }
                if (row.Cells[3].FormattedValue.ToString() == "2")
                {
                    row.Cells[4].Value = "Absent";

                }
                if (row.Cells[3].FormattedValue.ToString() == "3")
                {
                    row.Cells[4].Value = "Leave";

                }
                if (row.Cells[3].FormattedValue.ToString() == "4")
                {
                    row.Cells[4].Value = "Late";

                }
                index++;
            }
            attendancelist.Columns.RemoveAt(3);
        }

        private void attendancelist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            this.Hide();
            d.Show();
        }
    }
}

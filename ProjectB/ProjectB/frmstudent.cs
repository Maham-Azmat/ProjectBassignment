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
    public partial class frmstudent : Form
    {
       
        public frmstudent()
        {
            InitializeComponent();
            Database_Connection.get_instance().connectionstring = "Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True";
            try
            {
                var con = Database_Connection.get_instance().Getconnection();
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        Student stu = new Student();
        bool n = false;
        private void frmstudent_Load(object sender, EventArgs e)
        {
            string cmd = "SELECT * FROM Student";


            if (Studentportal.current != 0)
            {
                foreach (Student stu in Database_Connection.get_instance().ListofStudents(cmd))
                {
                    if (stu.Id == Studentportal.current)
                    {
                        txt_name.Text = stu.FirstName ;
                       txt_lname.Text = stu.LastName;
                        txt_reg.Text= stu.RegistrationNo;
                         txt_email.Text = stu.Email;
                       txt_contact.Text = stu.Contact;
                       

                    }
                }
            }
            else
            {
                n = true;
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmb_status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (n)
            {
                stu.FirstName = txt_name.Text;
                stu.LastName = txt_lname.Text;
                stu.RegistrationNo = txt_reg.Text;
                stu.Email = txt_email.Text;
                stu.Contact = txt_contact.Text;
               
                string cmd = "SELECT * FROM Lookup";
                SqlDataReader reader = Database_Connection.get_instance().Getdata(cmd);
                while(reader.Read())
                {
                    if(reader.GetString(1)==cmb_status.Text)
                    {
                        stu.Status = reader.GetInt32(0);

                    }
                }

                string cmd2 = string.Format("INSERT INTO Student(FirstName,LastName,Contact,Email,RegistrationNumber,Status) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", stu.FirstName, stu.LastName, stu.Contact, stu.Email, stu.RegistrationNo,stu.Status);
                int rows = Database_Connection.get_instance().Executequery(cmd2);
                MessageBox.Show(String.Format("{0} rows affected", rows));
                Studentportal s = new Studentportal();
                this.Hide();
                s.Show();

            }
            else
            {
                string cmd = "SELECT * FROM Lookup";
                SqlDataReader reader = Database_Connection.get_instance().Getdata(cmd);
                while (reader.Read())
                {
                    if (reader.GetString(1) == cmb_status.Text)
                    {
                        stu.Status = reader.GetInt32(0);

                    }
                }
                int ys = Studentportal.current;
                string cmd3 = string.Format("UPDATE  Student SET FirstName = '{0}', LastName ='{1}',Contact = '{2}',Email ='{3}', RegistrationNumber = '{4}', Status='{5}' WHERE Id= '{6}'", txt_name.Text, txt_lname.Text, txt_contact.Text, txt_email.Text, txt_reg.Text, stu.Status,ys);
                int rows = Database_Connection.get_instance().Executequery(cmd3);
                MessageBox.Show(String.Format("{0} rows affected", rows));
                Studentportal s = new Studentportal();
                this.Hide();
                s.Show();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do you want to cancel?");
     
            txt_name.Clear();
            txt_lname.Clear();
            txt_contact.Clear();
            txt_email.Clear();
            txt_reg.Clear();
          
            Studentportal s = new Studentportal();
            this.Hide();
            s.Show();
        }
    }
}

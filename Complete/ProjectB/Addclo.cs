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
    public partial class Addclo : Form
    {
        public Addclo()
        {
            InitializeComponent();

        }
        CLO c = new CLO();
        bool n = false;
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (n)
            {
                c.Name = txt_name.Text;
                c.Datecreated = DateTime.Now;
                c.Dateupdated = DateTime.Now;
                
                
                SqlConnection connection = new SqlConnection("Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("INSERT INTO Clo (Name,DateCreated,DateUpdated) VALUES (@name, @Date, @update)", connection);
                cmd.Parameters.AddWithValue("@name", c.Name);
                cmd.Parameters.AddWithValue("@Date", c.Datecreated);
                cmd.Parameters.AddWithValue("@update", c.Dateupdated);
                connection.Open();
                cmd.ExecuteNonQuery();
                viewclo s = new viewclo();
                this.Hide();
                s.Show();
            }
            else
            {
                SqlConnection connection = new SqlConnection("Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True");
                int ys = viewclo.curr2;
                c.Dateupdated = DateTime.Now;
                SqlCommand cmd = new SqlCommand("UPDATE  Clo SET Name = @name,DateUpdated = @date WHERE Id= @id",connection);
                cmd.Parameters.AddWithValue("@name", txt_name.Text);
                cmd.Parameters.AddWithValue("@date", c.Dateupdated);
                cmd.Parameters.AddWithValue("@id", ys);
                connection.Open();
                cmd.ExecuteNonQuery();
                n = true;
                viewclo.curr2 = 0;
                viewclo s = new viewclo();
                this.Hide();
                s.Show();

            }
        }

        private void Addclo_Load(object sender, EventArgs e)
        {
            string cmd = "SELECT * FROM Clo";


            if (viewclo.curr2 != 0)
            {
                foreach (CLO stu in Database_Connection.get_instance().ListofClos(cmd))
                {
                    if (stu.Id == viewclo.curr2)
                    {
                        txt_name.Text = stu.Name;
                    }
                }
            }
            else
            {
                n = true;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do you want to cancel?");

            txt_name.Clear();
            viewclo s = new viewclo();
            this.Hide();
            s.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            viewclo v = new viewclo();
            this.Hide();
            v.Show();
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            this.Hide();
            d.Show();
        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

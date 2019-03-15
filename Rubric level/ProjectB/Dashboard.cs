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
    public partial class Dashboard : Form
    {
        public Dashboard()
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

        private void btn_stu_Click(object sender, EventArgs e)
        {
            Studentportal s = new Studentportal();
            this.Hide();
            s.Show();
        }

        private void btn_clo_Click(object sender, EventArgs e)
        {
            viewclo c = new viewclo();
            this.Hide();
            c.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_stu_Click_1(object sender, EventArgs e)
        {
            Studentportal s = new Studentportal();
            this.Hide();
            s.Show();
        }
    }
}

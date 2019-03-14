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
    public partial class addrubric : Form
    {
        public addrubric()
        {
            InitializeComponent();
        }
        Addrubrics r = new Addrubrics();

        int temp = viewclo.curr3;
        private void addrubric_Load(object sender, EventArgs e)
        {

            string cmd = string.Format("SELECT * FROM Rubric WHERE CloId='{0}'",temp);
            label2.Text = viewclo.details;
            BindingSource s = new BindingSource();
            s.DataSource = Database_Connection.get_instance().Listofrubric(cmd);
            Viewrub.DataSource = s;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            r.Detail= txt_detail.Text;
            string cmd2 = string.Format("INSERT INTO Rubric(Details,CloId) VALUES('{0}','{1}')",r.Detail,temp);
            int rows = Database_Connection.get_instance().Executequery(cmd2);
            MessageBox.Show(String.Format("{0} rows affected", rows));
            addrubric s = new addrubric();
            this.Hide();
            s.Show();
        }

        private void Viewcl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

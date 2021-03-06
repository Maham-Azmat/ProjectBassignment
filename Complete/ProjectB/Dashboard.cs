﻿using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            string check = "SELECT * FROM ClassAttendance";

            SqlDataReader reader = Database_Connection.get_instance().Getdata(check);
            while (reader.Read())
            {
                if (reader.GetDateTime(1) == DateTime.Now.Date)
                {
                    MessageBox.Show("Attendence already marked");
                    
                    return;


                }
            }
            frmatten a = new frmatten();
            this.Hide();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            frmasscomp a = new frmasscomp();
            this.Hide();
            a.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmassesment a = new frmassesment();
            this.Hide();
            a.Show();

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Attendencelist a = new Attendencelist();
            this.Hide();
            a.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Studentresult s = new Studentresult();
            this.Hide();
            s.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmresult f = new frmresult();
            this.Hide();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmcloresult c = new frmcloresult();
            this.Hide();
            c.Show();
        }
    }
}

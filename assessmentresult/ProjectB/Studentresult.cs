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
    public partial class Studentresult : Form
    {
        public Studentresult()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            this.Hide();
            d.Show();
        }

        private void Studentresult_Load(object sender, EventArgs e)
        {
            string cmd = "SELECT * FROM Student";
            SqlDataReader reader = Database_Connection.get_instance().Getdata(cmd);
            List<string> name = new List<string>();
            while (reader.Read())
            {
                name.Add(reader.GetString(5));

            }
            txt_reg.DataSource = name;
            txt_reg.Text = " ";
            string cmd1 = "SELECT * FROM Assessment";
            SqlDataReader reader1 = Database_Connection.get_instance().Getdata(cmd1);
            List<string> name1 = new List<string>();
            while (reader1.Read())
            {
                name1.Add(reader1.GetString(1));

            }
            txt_assess.DataSource = name1;
            txt_assess.Text = " ";
        }

        private void txt_assess_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int temp = 0;
            //string cmd = "SELECT * FROM Assessment";
            //SqlDataReader reader = Database_Connection.get_instance().Getdata(cmd);
            //while (reader.Read())
            //{
            //    if (reader.GetString(1) == txt_assess.Text)
            //    {
            //        temp = reader.GetInt32(0);

            //    }
            //}

            //string cmd1 = string.Format("SELECT * FROM AssessmentComponent WHERE AssessmentId='{0}'", temp);
            //SqlDataReader reader1 = Database_Connection.get_instance().Getdata(cmd1);
            //List<string> name1 = new List<string>();
            //while (reader1.Read())
            //{
            //    name1.Add(reader1.GetString(1));

            //}
            //txt_reg.DataSource = name1;
            //txt_reg.Text = " ";
        }

        private void txt_comp_SelectedIndexChanged(object sender, EventArgs e)
        {

           
        }
        frmstudentresult a = new frmstudentresult(); 
        private void btn_save_Click(object sender, EventArgs e)
        {
            string cmd9 = "SELECT * FROM Student";
            SqlDataReader reader9 = Database_Connection.get_instance().Getdata(cmd9);
            while (reader9.Read())
            {
                if (reader9.GetString(5) == txt_reg.Text)
                {
                    a.Studentid = reader9.GetInt32(0);

                }
            }
            int tempassescom = 0;
            string cmd11 = "SELECT * FROM Assessment";
            SqlDataReader reader11 = Database_Connection.get_instance().Getdata(cmd11);
            while (reader11.Read())
            {
                if (reader11.GetString(1) == txt_assess.Text)
                {
                    tempassescom = reader11.GetInt32(0);

                }
            }
            int temp = 0;
            bool x=true;
            string cmd10 = string.Format("Select * FROM StudentResult WHERE StudentId='{0}'", a.Studentid);
            SqlDataReader reader10 = Database_Connection.get_instance().Getdata(cmd10);
            while (reader10.Read())
            {
                temp = reader10.GetInt32(1);
                if(temp==tempassescom)
                { x = false; }
            }
            if (x)
            {

                //Getting Assessment id from the value selected in combobox
                int id = 0;
            string cmd2 = "SELECT * FROM Assessment";
            SqlDataReader reader = Database_Connection.get_instance().Getdata(cmd2);
            while (reader.Read())
            {
                if (reader.GetString(1) == txt_assess.Text)
                {
                    id = reader.GetInt32(0);

                }
            }


            string cmd =string.Format( "SELECT * FROM AssessmentComponent WHERE AssessmentId='{0}'",id);
            BindingSource s = new BindingSource();
            s.DataSource = Database_Connection.get_instance().Listofassessmentcomp(cmd);
            markresult.DataSource = s;
            
            DataGridViewColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Rubric Detail";
            int colIndex = markresult.Columns.Add(col);
            string name1;
            for (int ptr = 0; ptr < markresult.Rows.Count - 1; ptr++)
            {
                string Id = markresult.Rows[ptr].Cells[2].Value.ToString();
                int temptr = Int32.Parse(Id);
                string cmd1 = string.Format("SELECT * FROM Rubric WHERE Id='{0}'", temptr);
                SqlDataReader reader1 = Database_Connection.get_instance().Getdata(cmd1);
               
                while (reader1.Read())
                {
                    name1 = reader1.GetString(1);
                    markresult.Rows[ptr].Cells[7].Value = name1;

                }
                
            }
            
            markresult.Columns.RemoveAt(2);
            markresult.Columns.RemoveAt(3);
            markresult.Columns.RemoveAt(3);
            markresult.Columns.RemoveAt(3);



            //DataGridViewColumn col1 = new DataGridViewTextBoxColumn();
            //col1.HeaderText = "Assessment Component";
            //int colIndex1 = markresult.Columns.Add(col1);
            //DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
            //col2.HeaderText = "Rubric";
            //int colIndex2 = markresult.Columns.Add(col2);
            //for (int ptr = 0; ptr < markresult.Rows.Count - 1; ptr++)
            //{
            //    markresult.Rows[ptr].Cells[4].Value = txt_reg.Text;
            //    markresult.Rows[ptr].Cells[5].Value = name1[0];
            //}
           
                DataGridViewComboBoxColumn sta = new DataGridViewComboBoxColumn();
                sta.Name = "RubricLevel";

                sta.HeaderText = "Rubric Level";
                sta.MaxDropDownItems = 4;
                sta.Items.Add("4");
                sta.Items.Add("3");
                sta.Items.Add("2");
                sta.Items.Add("1");
                markresult.Columns.Add(sta);
            }
            else
            {
                MessageBox.Show("Rubric levels already marked!!!!");
               


            }
            // markresult.DataSource = txt_comp.Text;
            // markresult.DataSource = name1;
            
           
            //SqlConnection connection = new SqlConnection("Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True");
            //SqlCommand cmd1 = new SqlCommand("INSERT INTO StudentResult (StudentId,AssessmentComponentId,DateCreated,DateUpdated) VALUES (@name,@comp, @Date, @update)", connection);
            //cmd1.Parameters.AddWithValue("@name", a.Studentid);
            //cmd1.Parameters.AddWithValue("@Date", c.Datecreated);
            //cmd1.Parameters.AddWithValue("@comp", a.Assmentcomponentid);
            //connection.Open();
            //cmd1.ExecuteNonQuery();

        }
        DataGridViewColumn col = new DataGridViewTextBoxColumn();
        
        private void button1_Click(object sender, EventArgs e)
        {
            if(markresult.Columns.Count!=0)
            { 
            col.HeaderText = "Obatined Marks";
            int colIndex = markresult.Columns.Add(col);
            string cmd = "SELECT * FROM Student";
                SqlDataReader reader = Database_Connection.get_instance().Getdata(cmd);
                while (reader.Read())
                {
                    if (reader.GetString(5) == txt_reg.Text)
                    {
                        a.Studentid = reader.GetInt32(0);

                    }
                }

                int id = 0;
                string cmd1 = "SELECT * FROM Assessment";
                SqlDataReader reader1 = Database_Connection.get_instance().Getdata(cmd1);
                while (reader1.Read())
                {
                    if (reader1.GetString(1) == txt_assess.Text)
                    {
                        id = reader1.GetInt32(0);

                    }
                }
                string cmd2 = string.Format("SELECT * FROM AssessmentComponent WHERE AssessmentId='{0}'",id);
                SqlDataReader reader2 = Database_Connection.get_instance().Getdata(cmd2);
                int index = 0;
                while (reader2.Read())
                {

                    a.Assmentcomponentid = reader2.GetInt32(0);
                    a.Evaluationdate = DateTime.Now.Date;
                    string rubriclvl = markresult.Rows[index].Cells[4].Value.ToString();
                    string cmd3 = string.Format("SELECT * FROM RubricLevel WHERE MeasurementLevel='{0}'", rubriclvl);
                    SqlDataReader reader3 = Database_Connection.get_instance().Getdata(cmd3);
                    while (reader3.Read())
                    {

                        a.Rubricmeasurementid = reader3.GetInt32(0);

                    }
                    SqlConnection connection = new SqlConnection("Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True");
                    SqlCommand cmd4 = new SqlCommand("INSERT INTO StudentResult (StudentId,AssessmentComponentId,RubricMeasurementId,EvaluationDate) VALUES (@name,@comp,@rub ,@Date)", connection);
                    cmd4.Parameters.AddWithValue("@name", a.Studentid);
                    cmd4.Parameters.AddWithValue("@rub", a.Rubricmeasurementid);
                    cmd4.Parameters.AddWithValue("@Date", a.Evaluationdate);
                    cmd4.Parameters.AddWithValue("@comp", a.Assmentcomponentid);
                    connection.Open();
                    cmd4.ExecuteNonQuery();

                    string compmarks = markresult.Rows[index].Cells[2].Value.ToString();
                    float obt = (float.Parse(rubriclvl) / 4) * (float.Parse(compmarks));
                    markresult.Rows[index].Cells[5].Value = obt.ToString();


                    index++;
                }
               
            }
            else
            {
                MessageBox.Show("Already Obtained. To view result go to Class result!!!");

            }
        }
        
    }
}

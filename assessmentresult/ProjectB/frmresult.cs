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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace ProjectB
{
    public partial class frmresult : Form
    {
        public frmresult()
        {
            InitializeComponent();
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            Dashboard d = new Dashboard();
            this.Hide();
            d.Show();
        }

        private void assessmentresult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmresult_Load(object sender, EventArgs e)
        {
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
        frmstudentresult a = new frmstudentresult();
        private void button2_Click(object sender, EventArgs e)
        {
            int temp = 0;
            string cmd = "SELECT * FROM Assessment";
            SqlDataReader reader = Database_Connection.get_instance().Getdata(cmd);
            while (reader.Read())
            {
                if (reader.GetString(1) == txt_assess.Text)
                {
                    temp = reader.GetInt32(0);


                }
            }
            SqlDataReader reader2;
            string cmd1 = string.Format("SELECT * FROM AssessmentComponent Where AssessmentId='{0}'",temp);
            SqlDataReader reader1 = Database_Connection.get_instance().Getdata(cmd1);
            while (reader1.Read())
            {
                
                    a.Assmentcomponentid = reader1.GetInt32(0);
                                                                   
                    reader2 = Database_Connection.get_instance().Getdata(String.Format("SELECT StudentId,AssessmentComponentId, RubricMeasurementId,EvaluationDate, Name,TotalMarks, MeasurementLevel From StudentResult SR JOIN AssessmentComponent AC ON SR.AssessmentComponentId=AC.Id JOIN RubricLevel RL ON SR.RubricMeasurementId = RL.Id WHERE AssessmentComponentId='{0}'", a.Assmentcomponentid));
                    BindingSource s = new BindingSource();
                    s.DataSource = reader2;
                    assessmentresult.DataSource = s;

                
            }
            assessmentresult.Columns.RemoveAt(1);
            assessmentresult.Columns.RemoveAt(1);

            DataGridViewColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Obatined Marks";
            int colIndex = assessmentresult.Columns.Add(col);
            for (int index = 0; index < assessmentresult.Rows.Count; index++)
            {

                string compmarks = assessmentresult.Rows[index].Cells[3].Value.ToString();
                float obt = (float.Parse(assessmentresult.Rows[index].Cells[4].Value.ToString()) / 4) * (float.Parse(compmarks));
                assessmentresult.Rows[index].Cells[5].Value = obt.ToString();

            }


        }
        public void exportpdf(DataGridView assessment, string filename)
        {
            BaseFont b = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable table = new PdfPTable(assessment.Columns.Count);
            table.DefaultCell.Padding = 3;
            table.WidthPercentage = 100;
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            table.DefaultCell.BorderWidth = 1;
            iTextSharp.text.Font txt = new iTextSharp.text.Font(b, 10, iTextSharp.text.Font.NORMAL);


            foreach(DataGridViewColumn dwgcolumn in assessment.Columns )
            {
                PdfPCell c = new PdfPCell(new Phrase(dwgcolumn.HeaderText, txt));
                //c.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                table.AddCell(c);
            }
            foreach (DataGridViewRow dwgrow in assessment.Rows)
            {
                foreach (DataGridViewCell cell in dwgrow.Cells)
                {
                    table.AddCell(new Phrase(cell.Value.ToString(), txt));

                }
            }
            var save = new SaveFileDialog();
            save.FileName = filename;
            save.DefaultExt = ".pdf";
            if(save.ShowDialog()==DialogResult.OK)
            {
                using (FileStream str = new FileStream(save.FileName, FileMode.Create))
                {
                    Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(doc, str);
                    doc.Open();
                    doc.Add(table);
                    doc.Close();
                    str.Close();

                }
            }

            }
        private void button1_Click(object sender, EventArgs e)
        {
            exportpdf(assessmentresult, "test");
        }
    }
}

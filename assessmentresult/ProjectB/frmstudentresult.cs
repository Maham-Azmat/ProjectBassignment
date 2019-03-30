using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    class frmstudentresult
    {
        private int studentid;
        private int assmentcomponentid;
        private int rubricmeasurementid;
        private DateTime evaluationdate;

        public int Studentid { get => studentid; set => studentid = value; }
        public int Assmentcomponentid { get => assmentcomponentid; set => assmentcomponentid = value; }
        public int Rubricmeasurementid { get => rubricmeasurementid; set => rubricmeasurementid = value; }
        public DateTime Evaluationdate { get => evaluationdate; set => evaluationdate = value; }
    }
}

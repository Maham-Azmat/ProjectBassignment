using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    class attendence
    {
        private int attenid;
        private int studentid;
        private int status;
        private DateTime date;

        public int Attenid { get => attenid; set => attenid = value; }
        public int Studentid { get => studentid; set => studentid = value; }
        public int Status { get => status; set => status = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}

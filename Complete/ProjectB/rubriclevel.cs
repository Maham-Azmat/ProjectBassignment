using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    class rubriclevel
    {
        private int id;
        private int rubricid;
        private string details;
        private int measurementlevel;

        public int Id { get => id; set => id = value; }
        public int Rubricid { get => rubricid; set => rubricid = value; }
        public string Details { get => details; set => details = value; }
        public int Measurementlevel { get => measurementlevel; set => measurementlevel = value; }
    }
}

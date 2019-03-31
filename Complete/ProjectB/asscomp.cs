using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    class asscomp
    {
        private int id;
        private string name;
        private int rubricid;
        private int totalmarks;
        private DateTime datecreated;
        private DateTime dateupdated;
        private int assessmentid;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Rubricid { get => rubricid; set => rubricid = value; }
        public int Totalmarks { get => totalmarks; set => totalmarks = value; }
        public DateTime Datecreated { get => datecreated; set => datecreated = value; }
        public DateTime Dateupdated { get => dateupdated; set => dateupdated = value; }
        public int Assessmentid { get => assessmentid; set => assessmentid = value; }
    }
}

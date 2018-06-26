using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstMgmtClassLibrary.Domain
{
    public class Course
    {
        public int CourseId { get; set; }

        public int CourseTypeId { get; set; }

        public string CourseName { get; set; }

        public string Duration { get; set; }

        public int Fees { get; set; }

    }

}

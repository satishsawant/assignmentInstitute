using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstMgmtClassLibrary.Domain
{
   public class Department
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }
        public DateTime DepartmentStartDate { get; set; }
        public int StudentCapacity { get; set; }
        public string DepartmentDetail { get; set; }
    }
}
 
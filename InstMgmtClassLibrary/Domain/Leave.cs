using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstMgmtClassLibrary.Domain
{
    public class Leave
    {
        public int LeavesID { get; set; }
        public int LeaveTypeID { get; set; }
        public int LoginID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Reason { get; set; }
        public bool IsApproved { get; set; }
    }
    public class LeaveType
    {
        public int LeaveTypeID { get; set; }
        public string LeaveTypeName { get; set; }
    }
}

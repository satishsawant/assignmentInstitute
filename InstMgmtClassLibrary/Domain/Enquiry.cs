using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstMgmtClassLibrary.Domain
{
    public class Enquiry
    {
        public int ID { get; set; }

        public string EnquiryName { get; set; }

        public string Course { get; set; }

        public string Other { get; set; }

        public DateTime DateOfEnq { get; set; }

        public DateTime FollowUpDate { get; set; }

        public string Remark { get; set; }

    }
}

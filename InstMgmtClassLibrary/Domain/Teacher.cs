using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstMgmtClassLibrary.Domain
{
    class Teacher
    {
        public Teacher() { }
        public Teacher(int id, string Name) { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string MobileNo { get; set; }
        public string PhoneNo { get; set; }
        public int ZipCode { get; set; }
        public int RoleId { get; set; }
        public int DeptId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}

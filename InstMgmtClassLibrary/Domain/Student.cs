using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstMgmtClassLibrary.Domain
{
    public class Student
    {
        public Student() { }
        public Student(int id, string name)
        {
            Name = name;
            SudentId = id;
        }
        public int SudentId { get; set; }
        public int RoolId { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string MobileNo { get; set; }
        public string PhoneNo { get; set; }
        public int PinCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }

    }
}

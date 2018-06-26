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
            First_Name = name;
            StudentID = id;
        }
        public int StudentID { get; set; }
        public int LoginID { get; set; }
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Last_Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string Country { get; set; }
        public string EmergencyContactNo { get; set; }
        public string ContactNo { get; set; }
        public string EmailID { get; set; }
        public string BloodGroup { get; set; }
        public string Photo { get; set; }
        public int DeptId { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ParentsName { get; set; }
        public string ParentsMobileNo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }



    }
}

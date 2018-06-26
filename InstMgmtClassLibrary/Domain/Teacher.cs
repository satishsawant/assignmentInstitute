using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstMgmtClassLibrary.Domain
{
    public class Teacher
    {
        public Teacher() { }
        public Teacher(int id, string Name) {
            TeacherId = id;
            this.First_Name = Name;
        }

        public int TeacherId { get; set; }

        [Required(ErrorMessage = "First_Name is Required")]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "Midde_Name is Required")]
        public string Midde_Name { get; set; }

        [Required(ErrorMessage = "Last_Name is Required")]
        public string Last_Name { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Date Of Birth is Required")]
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        public string City { get; set; }

        public string Pin { get; set; }
        public string Country { get; set; }
        public string EmergencyContactId { get; set; }
        [Required(ErrorMessage = "Mobile Number is Required")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "EmailId is Required")]
        public string EmailID { get; set; }
        public string BloodGroup { get; set; }

        public string Designation { get; set; }
        public decimal Payment { get; set; }
        public string Photo { get; set; }
        public string Resume { get; set; }

        [Required(ErrorMessage = "Select The Department")]
        public int DeptId { get; set; }

        public string Gender { get; set; }

        [Required(ErrorMessage = "UserName is Required")]
        [StringLength(15, ErrorMessage = "User Name cannot be more than 15 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(11, MinimumLength = 5, ErrorMessage = "Minimum Length of Password is 5 letters or Max Length is of 11 letters..")]
        public string Password { get; set; }
    }
}

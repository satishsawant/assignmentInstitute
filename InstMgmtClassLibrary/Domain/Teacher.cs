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

        [Required(ErrorMessage = "First Name is Required")]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "Middle Name is Required")]
        public string Middle_Name { get; set; }
        
        [Required(ErrorMessage = "Last Name is Required")]
        public string Last_Name { get; set; }

        [Required(ErrorMessage = "Address1 is Required")]
        public string Address1 { get; set; }

        [Required(ErrorMessage ="City is Required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Pin Code is Required")]
        public int Pin { get; set; }

        [Required(ErrorMessage = "Country is Required")]
        public string Country { get; set; }

        [Required(ErrorMessage ="Emergency Contact required")]
        public string EmergencyContactId { get; set; }

        [Required(ErrorMessage ="Contact No Required")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Please enter valid Email Id")]
        public string EmailID { get; set; }

        [Required(ErrorMessage = "Blood Group is required")]
        public string BloogGroup { get; set; }

        public string JobType { get; set; }

        public string WorkType { get; set; }

        public decimal Payment { get; set; }

        [Required(ErrorMessage = "Date Of Birth is Required")]
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage ="Gender is Required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "UserName is Required")]
        [StringLength(15, ErrorMessage = "User Name cannot be more than 15 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(11, MinimumLength = 5, ErrorMessage = "Minimum Length of Password is 5 letters or Max Length is of 11 letters..")]
        public string Password { get; set; }

        public int RoleId { get; set; }

        public bool IsResume { get; set; }

        [Required(ErrorMessage = "Select The Department")]
        public int DeptId { get; set; }
    }
}

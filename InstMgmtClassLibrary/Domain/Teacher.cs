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
            Id = id;
            this.Name = Name;
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }        

        [Required(ErrorMessage = "Date Of Birth is Required")]
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage ="Gender is Required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Address1 is Required")]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        [Required(ErrorMessage = "Mobile Number is Required")]
        public string MobileNo { get; set; }

        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "UserName is Required")]
        [StringLength(15, ErrorMessage = "User Name cannot be more than 15 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(11, MinimumLength = 5, ErrorMessage = "Minimum Length of Password is 5 letters or Max Length is of 11 letters..")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "ZipCode is Required")]
        public int ZipCode { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Please enter valid Email Id")]
        public string EmailId { get; set; }

        public int RoleId { get; set; }

        [Required(ErrorMessage ="Blood Group is required")]
        public string BloogGroup { get; set; }


        [Required(ErrorMessage = "Select The Department")]
        public int DeptId { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }
    }
}

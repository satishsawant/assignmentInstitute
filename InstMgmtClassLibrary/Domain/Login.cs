using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstMgmtClassLibrary.Domain
{
   public class Login
    {
        [Required(ErrorMessage = "User Name Required")]
        [DisplayName("Username")]
        [StringLength(15, ErrorMessage = "Less than 15 characters")]
        public string Username{get; set;}

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password Required")]
        [DisplayName("Password")]
        [StringLength(30, ErrorMessage = ":Less than 30 characters")]
        public string Password{get; set;}
    }
}

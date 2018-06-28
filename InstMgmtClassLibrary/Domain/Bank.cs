using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstMgmtClassLibrary.Domain
{
    public class Bank
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Bank Name is Required")]
        public string BankName { get; set; }

        [Required(ErrorMessage = "Account No is Required")]
        public int AccountNumber { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Contact No is Required")]
        public int ContactNo1 { get; set; }

        public int ContactNo2 { get; set; }
    }
}

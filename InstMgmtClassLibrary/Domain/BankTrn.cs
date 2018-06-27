using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstMgmtClassLibrary.Domain
{
    public class BankTrn
    {
        public int ID { get; set; }

        public int BankID { get; set; }

        public string TransactionType { get; set; }

        public int Amount { get; set; }

        public DateTime DateOfTrn { get; set; }

        public string TrnDoneBy { get; set; }
    }
}

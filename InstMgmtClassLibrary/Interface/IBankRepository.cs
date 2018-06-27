using InstMgmtClassLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstMgmtClassLibrary.Interface
{
    public interface IBankRepository
    {
       
        /// <summary>
        /// Get all bank list
        /// </summary>
        /// <returns></returns>
        IList<Bank> GetAll();

        /// <summary>
        /// Create new bank
        /// </summary>
        /// <param name="Course"></param>
        /// <returns></returns>
        int CreateBank(Bank bank);

        int CreateBankTrn(BankTrn banktrn);

    }
}

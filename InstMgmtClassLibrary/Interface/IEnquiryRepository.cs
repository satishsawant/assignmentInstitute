using InstMgmtClassLibrary.Domain;
using InstMgmtClassLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstMgmtClassLibrary.Interface
{
    public  interface IEnquiryRepository
    {
        /// <summary>
        /// Get all bank list
        /// </summary>
        /// <returns></returns>
        IList<Enquiry> GetAll();

        /// <summary>
        /// Create new Course
        /// </summary>
        /// <param name="Course"></param>
        /// <returns></returns>
        int CreateEnquiry(Enquiry enquiry);
    }
}

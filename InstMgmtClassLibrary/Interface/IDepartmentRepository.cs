using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstMgmtClassLibrary.Domain;

namespace InstMgmtClassLibrary.Interfaces
{
   public interface IDepartmentRepository
    {
        /// <summary>
        /// Get Department by Department Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Department Get(int id);

        /// <summary>
        /// Get all Department list
        /// </summary>
        /// <returns></returns>
        IList<Department> GetAll();

        /// <summary>
        /// Create new department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        int CreateDepartment(Department department);

        /// <summary>
        /// Update Existing Department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        int UpdateDepartment(Department department);

    }
}

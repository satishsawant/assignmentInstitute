using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstMgmtClassLibrary.Domain;

namespace InstMgmtClassLibrary.Interfaces
{
    public interface IRoleRepository
    {
        /// <summary>
        /// Get Role by Role Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Role Get(int id);

        /// <summary>
        /// Get all Role list
        /// </summary>
        /// <returns></returns>
        IList<Role> GetAll();

        /// <summary>
        /// Create new Role
        /// </summary>
        /// <param name="Course"></param>
        /// <returns></returns>
        int CreateRole(Role role);

        /// <summary>
        /// Update Existing Role
        /// </summary>
        /// <param name="Course"></param>
        /// <returns></returns>
        int UpdateRole(Role role);
    }
}

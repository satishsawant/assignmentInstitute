using InstMgmtClassLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstMgmtClassLibrary.Interfaces
{
    //Interface for 
    public interface ITeacherRepository
    {
        /// <summary>
        /// Get Teacher by Teacher Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Teacher Get(int id);

        /// <summary>
        /// Get all teacher list
        /// </summary>
        /// <returns></returns>
        IList<Teacher> GetAll();

        /// <summary>
        /// Create new teacher
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        string CreateTeacher(Teacher teacher);

        /// <summary>
        /// Update Existing Teacher
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        int UpdateTeacher(Teacher teacher);

        /// <summary>
        /// Delete Existing Teacher
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteTeacher(int id);
    }
}

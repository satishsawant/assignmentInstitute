using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstMgmtClassLibrary.Domain;

namespace InstMgmtClassLibrary.Interfaces
{
    public interface ICourseRepository
    {
        /// <summary>
        /// Get Course by Course Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Course Get(int id);

        /// <summary>
        /// Get all Course list
        /// </summary>
        /// <returns></returns>
        IList<Course> GetAll();

        /// <summary>
        /// Create new Course
        /// </summary>
        /// <param name="Course"></param>
        /// <returns></returns>
        int CreateCourse(Course course);

        /// <summary>
        /// Update Existing Course
        /// </summary>
        /// <param name="Course"></param>
        /// <returns></returns>
        int UpdateCourse(Course course);
    }
}

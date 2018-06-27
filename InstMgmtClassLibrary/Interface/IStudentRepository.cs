using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstMgmtClassLibrary.Domain;

namespace InstMgmtClassLibrary.Interfaces
{
   public interface IStudentRepository
    {
        /// <summary>
        /// Get a single Student by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //Student Get(int id);
        /// <summary>
        ///  Get a list of all active Students with all mapped properties
        /// </summary>
        /// <returns></returns>
        IList<Student> GetStudent(int id);
        /// <summary>
        ///  Update the student
        /// </summary>
        /// <param name="student"></param>

        int UpdateStudent(Student student);

        /// <summary>
        /// create a student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        int CreateStudent(Student student);
        /// <summary>
        /// Delete a student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        bool DeleteStudent(int id);

    }
}

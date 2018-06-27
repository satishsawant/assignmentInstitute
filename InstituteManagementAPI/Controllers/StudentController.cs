using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InstMgmtClassLibrary.Domain;
using InstMgmtClassLibrary.Interfaces;


namespace InstituteManagementAPI.Controllers
{
    [RoutePrefix("api/Student")]
    public class StudentController : ApiController
    {
        IStudentRepository _repository;
        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Get a student by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpGet]
        //[Route("Get/{id}")]
        //public HttpResponseMessage Get(int id)
        //{
        //    StudentResponseModel responseModel = new StudentResponseModel();
        //    Student student = _repository.Get(id);
        //    if (student == null)
        //    {
        //        responseModel.Success = "false";
        //    }
        //    else
        //    {
        //        responseModel.Success = "true";
        //        responseModel.Student.Add(student);
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, responseModel);
        //}
        /// <summary>
        ///  Get all Department list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetStudent/{id}")]
        public HttpResponseMessage GetStudent(int id)
        {
            StudentResponseModel responseM = new StudentResponseModel();
            IList<Student> students = _repository.GetStudent(id);
            if (students.Count>0)
            {
                responseM.Success= "true";
                responseM.Student = students;
            }
            else
            {
                responseM.Success = "false";
                responseM.Student = students;
            }
            return Request.CreateResponse(HttpStatusCode.OK, responseM);
        }
        /// <summary>
        ///  Add new student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateStudent")]
        public bool CreateStudent(Student student)
        {
            var success = _repository.CreateStudent(student);
            return Convert.ToBoolean(success);
        }
        /// <summary>
        /// Update Existing Department
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateStudent")]
        public bool UpdateStudent(Student student)
        {
            var success=_repository.UpdateStudent(student);
            return Convert.ToBoolean(success);
        }

    }
}

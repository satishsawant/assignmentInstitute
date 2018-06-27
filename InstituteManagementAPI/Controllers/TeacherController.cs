using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InstMgmtClassLibrary;
using InstMgmtClassLibrary.Domain;
using InstMgmtClassLibrary.Interfaces;

namespace InstituteManagementAPI.Controllers
{
    [RoutePrefix("api/Teacher")]
    public class TeacherController : ApiController
    {
        ITeacherRepository _repository;

        public TeacherController(ITeacherRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Get a teacher by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            TeacherResponseModel response = new TeacherResponseModel();
            Teacher teacher = _repository.Get(id);
            if (teacher == null)
            {
                response.Success = "false";
            }
            else { response.Success = "true";
                response.Teacher.Add(teacher);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        /// <summary>
        ///  Get all Teachers list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTeacher/{id}")]
        public HttpResponseMessage GetTeacher(int id)
        {
            TeacherResponseModel response = new TeacherResponseModel();
            IList<Teacher> teachers = _repository.GetTeacher(id);
            if (teachers.Count>0)
            {
                response.Success = "true";
                response.Teacher = teachers;
            }
            else { response.Success = "false";
                response.Teacher = teachers;
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        /// <summary>
        ///  Create new Department
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateTeacher")]
        public bool CreateTeacher(Teacher teacher)
        {
            var success = _repository.CreateTeacher(teacher);
            return Convert.ToBoolean(success);
        }
        /// <summary>
        /// Update Existing Teacher Info
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateTeacher")]
        public bool UpdateTeacher(Teacher teacher)
        {
            var success= _repository.UpdateTeacher(teacher);
            return Convert.ToBoolean(success);
        }

    }
}

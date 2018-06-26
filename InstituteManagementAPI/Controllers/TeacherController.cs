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
        public IHttpActionResult Get(int id)
        {

            Teacher teacher = _repository.Get(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }
        /// <summary>
        ///  Get all Teachers list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var teachers = _repository.GetAll();
            return Ok(teachers);
        }
        /// <summary>
        ///  Create new Department
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateTeacher")]
        public IHttpActionResult CreateTeacher(Teacher teacher)
        {
            var NewTeacher = _repository.CreateTeacher(teacher);
            return Ok(NewTeacher);
        }
        /// <summary>
        /// Update Existing Teacher Info
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateTeacher")]
        public IHttpActionResult UpdateTeacher(Teacher teacher)
        {
            _repository.UpdateTeacher(teacher);
            return Ok();
        }

    }
}

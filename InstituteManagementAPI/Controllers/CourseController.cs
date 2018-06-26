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
    [RoutePrefix("api/Course")]
    public class CourseController : ApiController
    {
        ICourseRepository _repository;
        public CourseController(ICourseRepository repository)
         {
                _repository = repository;
         }
        /// <summary>
        /// Get a Course by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
            [Route("Get/{id}")]
            public IHttpActionResult Get(int id)
            {
                Course course = _repository.Get(id);

                if (course == null)
                {
                    return NotFound();
                }

                return Ok(course);
            }

        /// <summary>
        ///  Get all courses list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
            [Route("GetAll")]
            public IHttpActionResult GetAll()
            {
                var courses = _repository.GetAll();
                return Ok(courses);
            }
        /// <summary>
        ///  Create new course
        /// </summary>
        /// <param name="Course"></param>
        /// <returns></returns>
           [HttpPost]
            [Route("CreateCourse")]
            public IHttpActionResult CreateCourse(Course course)
            {
                var NewCourse = _repository.CreateCourse(course);
                return Ok(NewCourse);
            }
        /// <summary>
        /// Update Existing Course
        /// </summary>
        /// <param name="Course"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateCourse")]
        public IHttpActionResult UpdateCourse(Course course)
         {
           _repository.UpdateCourse(course);
            return Ok();
         }
        }
}


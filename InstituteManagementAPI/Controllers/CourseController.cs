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


        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var courses = _repository.GetAll();
            return Ok(courses);
        }

        [HttpPost]
        [Route("CreateCourse")]
        public IHttpActionResult CreateCourse(Course course)
        {
            var NewCourse = _repository.CreateCourse(course);
            return Ok(NewCourse);
        }

        [HttpPost]
        [Route("UpdateCourse")]
        public IHttpActionResult UpdateCourse(Course course)
        {
            _repository.UpdateCourse(course);
            return Ok();
        }

        //Course Type Details

        [HttpGet]
        [Route("GetCourseType/{id}")]
        public IHttpActionResult GetCourseType(int id)
        {
            CourseType course = _repository.GetCourseType(id);

            if (course == null)
            {
                return Ok("No Course Found");
            }

            return Ok(course);
        }

        [HttpGet]
        [Route("GetAllCourseType")]
        public IHttpActionResult GetAllCourseType()
        {
            var courses = _repository.GetAllCourseType();
            return Ok(courses);
        }

        [HttpPost]
        [Route("CreateCourseType")]
        public IHttpActionResult CreateCourseType(CourseType course)
        {
            int success = _repository.CreateCourseType(course);
            if (success > 0)
            {
                return Ok("Course Type Added Successfully");
            }
            else
            {
                return Ok("Error Adding Course Type");
            }

        }

        [HttpPost]
        [Route("UpdateCourseType")]
        public IHttpActionResult UpdateCourseType(CourseType course)
        {
            int success = _repository.CreateCourseType(course);
            if (success > 0)
            {
                return Ok("Course Type Updated Successfully");
            }
            else
            {
                return Ok("Error updating Course Type");
            }

        }
    }
}


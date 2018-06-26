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

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(Teacher teacher)
        {
            int res = _repository.CreateTeacher(teacher);
            if ( res > 0)
            {
                return Ok();
            }
            else { return NotFound(); }
        }

        [HttpPost]
        [Route("Update")]
        public IHttpActionResult Update(Teacher teacher)
        {
            int res = _repository.UpdateTeacher(teacher);
            if (res > 0)
            {
                return Ok();
            }
            else { return NotFound(); }
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(Teacher teacher)
        {
            int res = _repository.CreateTeacher(teacher);
            if (res > 0)
            {
                return Ok();
            }
            else { return NotFound(); }
        }

    }
}

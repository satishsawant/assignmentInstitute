using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InstMgmtClassLibrary.Domain;
using InstMgmtClassLibrary.Repository;
using InstMgmtClassLibrary.Interface;
    
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
        /// Get a client by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(int id)
        {
            Student student = _repository.Get(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }


    }
}

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
    [RoutePrefix("api/Department")]
    public class DepartmentController : ApiController
    {
        IDepartmentRepository _repository;
        public DepartmentController(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Get a Department by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/{id}")]
        public IHttpActionResult Get(int id)
        {
            Department department = _repository.Get(id);

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        /// <summary>
        ///  Get all Department list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var departments = _repository.GetAll();
            return Ok(departments);
        }
        /// <summary>
        ///  Create new Department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateDepartment")]
        public IHttpActionResult CreateDepartment(Department department)
        {
            var NewDepartment = _repository.CreateDepartment(department);
            return Ok(NewDepartment);
        }
        /// <summary>
        /// Update Existing Department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateDepartment")]
        public IHttpActionResult UpdateDepartment(Department department)
        {
            _repository.UpdateDepartment(department);
            return Ok();
        }
    }
}


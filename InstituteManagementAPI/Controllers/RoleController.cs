using InstMgmtClassLibrary.Domain;
using InstMgmtClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InstituteManagementAPI.Controllers
{
    [RoutePrefix("api/Role")]
    public class RoleController : ApiController
    {
        IRoleRepository _repository;
        public RoleController(IRoleRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Get a Role by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/{id}")]
        public IHttpActionResult Get(int id)
        {
            Role role = _repository.Get(id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        /// <summary>
        ///  Get all Role list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var roles = _repository.GetAll();
            return Ok(roles);
        }
        /// <summary>
        ///  Create new role
        /// </summary>
        /// <param name="Course"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateRole")]
        public IHttpActionResult CreateRole(Role role)
        {
            var NewRole = _repository.CreateRole(role);
            return Ok(NewRole);
        }
        /// <summary>
        /// Update Existing role
        /// </summary>
        /// <param name="Course"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateRole")]
        public IHttpActionResult UpdateRole(Role role)
        {
            _repository.UpdateRole(role);
            return Ok();
        }
    }
}


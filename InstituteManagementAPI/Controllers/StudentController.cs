﻿using System;
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
        [HttpGet]
        [Route("Get/{id}")]
        public IHttpActionResult Get(int id)
        {
            Student student = _repository.Get(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }
        /// <summary>
        ///  Get all Department list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var students = _repository.GetAll();
            return Ok(students);
        }
        /// <summary>
        ///  Add new student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateStudent")]
        public IHttpActionResult CreateStudent(Student student)
        {
            var NewStudent = _repository.CreateStudent(student);
            return Ok(NewStudent);
        }
        /// <summary>
        /// Update Existing Department
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateStudent")]
        public IHttpActionResult UpdateStudent(Student student)
        {
            _repository.UpdateStudent(student);
            return Ok();
        }

    }
}

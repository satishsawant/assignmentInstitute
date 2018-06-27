using InstMgmtClassLibrary.Domain;
using InstMgmtClassLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InstituteManagementAPI.Controllers
{
    [RoutePrefix("api/Enquiry")]
    public class EnquiryController : ApiController
    {
        IEnquiryRepository _repository;
        public EnquiryController(IEnquiryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var enquiries = _repository.GetAll();
            return Ok(enquiries);
        }
        /// <summary>
        ///  Create new enquiry
        /// </summary>
        /// <param name="Course"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateEnquiry")]
        public IHttpActionResult CreateEnquiry(Enquiry enquiry)
        {
            var NewEnquiry = _repository.CreateEnquiry(enquiry);
            return Ok(NewEnquiry);
        }
    }
}

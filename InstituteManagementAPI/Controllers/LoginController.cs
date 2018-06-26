using InstMgmtClassLibrary.Domain;
using InstMgmtClassLibrary.Interfaces;
using InstMgmtClassLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InstituteManagementAPI.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        ILoginRepository _loginRepo;
        public LoginController(ILoginRepository loginRepo)
        {
            _loginRepo = loginRepo;
        }

        public IHttpActionResult LoginResult(Login log)
        {
            string result = _loginRepo.Login(log);
            if (!result.Equals(""))
            {
                return Ok(result);
            }
            else { return NotFound(); }
        }

    }
}

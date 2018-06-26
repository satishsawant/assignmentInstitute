using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstituteManagement.Controllers
{
    public class CourseTypeController : Controller
    {
        // GET: CourseType
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CourseTypeCreate()
        {
            return View();
        }
        public ActionResult CourseTypeList()
        {
            return View();
        }
    }
}
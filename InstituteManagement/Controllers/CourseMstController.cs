using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstituteManagement.Controllers
{
    public class CourseMstController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CourseCreate()
        {
            return View();
        }
        public ActionResult CourseList()
        {
            return View();
        }
    }
}
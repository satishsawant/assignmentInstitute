using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstituteManagement.Controllers
{
    public class LeaveController : Controller
    {
        // GET: Leave
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LeaveCreate()
        {
            return View();
        }
        public ActionResult LeaveList()
        {
            return View();
        }
        public ActionResult LiveUpdate()
        {
            return View();
        }
    }
}
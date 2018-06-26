using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstituteManagement.Controllers
{
    public class LeaveTypeController : Controller
    {
        // GET: LeaveType
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LeaveTypeCreate()
        {
            return View();
        }
        public ActionResult LeaveTypeList()
        {
            return View();
        }
    }
}
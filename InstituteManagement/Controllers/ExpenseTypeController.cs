using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstituteManagement.Controllers
{
    public class ExpenseTypeController : Controller
    {
        // GET: Expense
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ExpenseTypeCreate()
        {
            return View();
        }
        public ActionResult ExpenseTypeList()
        {
            return View();
        }
    }
}
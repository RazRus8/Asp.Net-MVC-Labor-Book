using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.INSERT;

namespace WebApp.Controllers
{
    public class AddEmployeeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View("~/Views/AddEmployee/AddEmployee.cshtml");
        }

        [HttpPost]
        public ActionResult InsertEmployee(EmployeeModel newEmployee)
        {
            if (InsertData.InsertEmployee(newEmployee))
            {
                return Json(new { success = true }, JsonRequestBehavior.DenyGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.DenyGet);
            }
        }
    }
}
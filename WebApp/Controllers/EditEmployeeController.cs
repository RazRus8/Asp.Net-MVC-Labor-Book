using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.UPDATE;
using WebApp.Models.DELETE;

namespace WebApp.Controllers
{
    public class EditEmployeeController : Controller
    {
        public ActionResult Index()
        {
            EmployeeModel employee = new EmployeeModel();

            int id = Convert.ToInt32(Session["EmployeeId"]);

            using (EmployeeContext db = new EmployeeContext())
            {
                employee = db.Employees.Where(emp => emp.EmployeeId == id).First();

                ViewBag.Employee = employee;
            }

            return View("~/Views/EditEmployee/EditEmployee.cshtml");
        }

        [HttpPost]
        public JsonResult Res(int selectedEmployeeId)
        {
            Session["EmployeeId"] = selectedEmployeeId;

            return Json(new { success = true }, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult UpdateEmployee(EmployeeModel editEmployee)
        {
            if (UpdateData.UpdateEmployee(editEmployee))
            {
                return Json(new { success = true }, JsonRequestBehavior.DenyGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        public JsonResult DeleteEmployee(EmployeeModel deleteEmployee)
        {
            if (DeleteData.DeleteEmployee(deleteEmployee))
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
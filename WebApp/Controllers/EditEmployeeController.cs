using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.SELECT;
using WebApp.Models.UPDATE;
using WebApp.Models.DELETE;

namespace WebApp.Controllers
{
    public class EditEmployeeController : Controller
    {
        public ActionResult Index()
        {
            int employeeId = Convert.ToInt32(Session["EmployeeId"]);
            var employee = SelectInstance.SelectEmployee(employeeId);

            ViewBag.Employee = employee;

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
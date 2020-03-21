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
    public class EditEmployeeRecordController : Controller
    {
        public ActionResult Index()
        {
            int employeeId = Convert.ToInt32(Session["EmployeeId"]);
            int recordId = Convert.ToInt32(Session["EmployeeRecordId"]);

            var employee = SelectInstance.SelectEmployee(employeeId);
            var employeeRecord = SelectInstance.SelectRecord(recordId);

            ViewBag.Employee = employee;
            ViewBag.EmployeeRecord = employeeRecord;

            return View("~/Views/EditEmployeeRecord/EditEmployeeRecord.cshtml");
        }

        [HttpPost]
        public JsonResult Res(EmployeeRecordModel record)
        {
            Session["EmployeeId"] = record.EmployeeId;
            Session["EmployeeRecordId"] = record.RecordId;

            return Json(new { success = true }, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult UpdateEmployeeRecord(EmployeeRecordModel editEmployeeRecord)
        {
            if (UpdateData.UpdateEmployeeRecord(editEmployeeRecord))
            {
                return Json(new { success = true }, JsonRequestBehavior.DenyGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        public JsonResult DeleteEmployeeRecord(EmployeeRecordModel deleteEmployeeRecord)
        {
            if (DeleteData.DeleteEmployeeRecord(deleteEmployeeRecord))
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
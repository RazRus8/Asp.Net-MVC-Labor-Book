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
    public class EditEmployeeRecordController : Controller
    {
        public ActionResult Index()
        {
            int employeeId = Convert.ToInt32(Session["EmployeeId"]);
            int recordId = Convert.ToInt32(Session["EmployeeRecordId"]);

            using (EmployeeContext db = new EmployeeContext())
            {
                var employee = db.Employees.Where(emp => emp.EmployeeId == employeeId).First();
                var employeeRecord = db.EmployeeRecords.Where(rec => rec.RecordId == recordId).First();

                ViewBag.Employee = employee;
                ViewBag.EmployeeRecord = employeeRecord;
            }

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
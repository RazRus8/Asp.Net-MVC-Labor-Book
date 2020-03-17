using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebApp.Models;
using WebApp.Models.INSERT;

namespace WebApp.Controllers
{
    public class AddEmployeeRecordController : Controller
    {
        public ActionResult Index()
        {
            EmployeeModel employee = new EmployeeModel();

            int id = Convert.ToInt32(Session["EmployeeId"]);

            using (EmployeeContext db = new EmployeeContext())
            {
                employee = db.Employees.Where(emp => emp.EmployeeId == id).First();

                ViewBag.Data = $"{employee.DisplayEmployees}";
                ViewBag.Id = Session["EmployeeId"];
            }

            return View("~/Views/AddEmployeeRecord/EmployeeRecord.cshtml");
        }

        [HttpPost]
        public JsonResult Res(int selectedEmployeeId)
        {
            Session["EmployeeId"] = selectedEmployeeId;

            return Json(new { success = true }, JsonRequestBehavior.DenyGet);
        }


        [HttpPost]
        public JsonResult InsertRecord(EmployeeRecordModel newRecord)
        {
            if (InsdertData.InsertRecord(newRecord))
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
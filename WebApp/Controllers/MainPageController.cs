using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Data.Entity;
using WebApp.Models;
using WebApp.Models.SELECT;

namespace WebApp.Controllers
{
    public class MainPageController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View("~/Views/MainPage/MainPage.cshtml");
        }

        [HttpPost]
        public JsonResult GetEmployees()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();

            using (EmployeeContext db = new EmployeeContext())
            {
                foreach (EmployeeModel employee in db.Employees)
                {
                    employees.Add(employee);
                }

                return Json(employees, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        public JsonResult GetRecords(int selectedEmployeeId)
        {
            List<EmployeeRecordModel> records = new List<EmployeeRecordModel>();

            using (EmployeeContext db = new EmployeeContext())
            {
                if (db.EmployeeRecords.Where(emp => emp.EmployeeId == selectedEmployeeId).Any())
                {
                    foreach (EmployeeRecordModel record in db.EmployeeRecords.Where(emp => emp.EmployeeId == selectedEmployeeId))
                    {
                        records.Add(record);
                    }
                }
            }

            return Json(records, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GetFieldsData(int selectedRecordId)
        {
            List<EmployeeRecordModel> records = new List<EmployeeRecordModel>();

            using (EmployeeContext db = new EmployeeContext())
            {
                if (db.EmployeeRecords.Where(rec => rec.RecordId == selectedRecordId).Any())
                {
                    var record = db.EmployeeRecords.Where(rec => rec.RecordId == selectedRecordId).First();
                    records.Add(record);
                }
            }

            return Json(records, JsonRequestBehavior.DenyGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var employees = SelectInstance.SelectEmployees();

            return Json(employees, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GetRecords(int selectedEmployeeId)
        {
            var records = SelectInstance.SelectRecords(selectedEmployeeId);

            return Json(records, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult GetFieldsData(int selectedRecordId)
        {
            var records = SelectInstance.FillFields(selectedRecordId);

            return Json(records, JsonRequestBehavior.DenyGet);
        }
    }
}
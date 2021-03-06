﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebApp.Models;
using WebApp.Models.SELECT;
using WebApp.Models.INSERT;

namespace WebApp.Controllers
{
    public class AddEmployeeRecordController : Controller
    {
        public ActionResult Index()
        {
            int employeeId = Convert.ToInt32(Session["EmployeeId"]);
            var employee = SelectInstance.SelectEmployee(employeeId);

            ViewBag.Data = $"{employee.DisplayEmployees}";
            ViewBag.Id = Session["EmployeeId"];

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
            if (InsertData.InsertRecord(newRecord))
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApp.Models;

namespace WebApp.Models.INSERT
{
    public class InsertData
    {
        public static bool InsertEmployee(EmployeeModel newEmployee)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                db.Employees.Add(newEmployee);
                db.SaveChanges();

                return true;
            }
        }

        public static bool InsertRecord(EmployeeRecordModel newRecord)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                db.EmployeeRecords.Add(newRecord);
                db.SaveChanges();

                return true;
            }
        }
    }
}
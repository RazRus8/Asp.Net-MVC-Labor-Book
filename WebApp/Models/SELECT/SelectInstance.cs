using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApp.Models;

namespace WebApp.Models.SELECT
{
    public class SelectInstance
    {
        public static List<EmployeeModel> SelectEmployees()
        {
            var employees = new List<EmployeeModel>();

            using (EmployeeContext db = new EmployeeContext())
            {
                foreach (EmployeeModel employee in db.Employees)
                {
                    employees.Add(employee);
                }

                return employees;
            }
        }

        public static EmployeeModel SelectEmployee(int employeeId)
        {
            var employee = new EmployeeModel();

            using (EmployeeContext db = new EmployeeContext())
            {
                employee = db.Employees.Where(emp => emp.EmployeeId == employeeId).First();

                return employee;
            }
        }

        public static List<EmployeeRecordModel> SelectRecords(int selectedEmployeeId)
        {
            var records = new List<EmployeeRecordModel>();

            using (EmployeeContext db = new EmployeeContext())
            {
                if (db.EmployeeRecords.Where(emp => emp.EmployeeId == selectedEmployeeId).Any())
                {
                    foreach (EmployeeRecordModel record in db.EmployeeRecords.Where(emp => emp.EmployeeId == selectedEmployeeId))
                    {
                        records.Add(record);
                    }
                }

                return records;
            }
        }

        public static EmployeeRecordModel SelectRecord(int selectedRecordId)
        {
            var record = new EmployeeRecordModel();

            using (EmployeeContext db = new EmployeeContext())
            {
                record = db.EmployeeRecords.Where(rec => rec.RecordId == selectedRecordId).First();

                return record;
            }
        }

        public static List<EmployeeRecordModel> FillFields(int selectedRecordId)
        {
            var records = new List<EmployeeRecordModel>();

            using (EmployeeContext db = new EmployeeContext())
            {
                if (db.EmployeeRecords.Where(rec => rec.RecordId == selectedRecordId).Any())
                {
                    var record = db.EmployeeRecords.Where(rec => rec.RecordId == selectedRecordId).First();
                    records.Add(record);
                }

                return records;
            }
        }
    }
}
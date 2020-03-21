using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApp.Models;

namespace WebApp.Models.DELETE
{
    public class DeleteData
    {
        public static bool DeleteEmployee(EmployeeModel deleteEmployee)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                var employee = db.Employees.Where(emp => emp.EmployeeId == deleteEmployee.EmployeeId).First();
                var employeeRecord = db.EmployeeRecords.Where(rec => rec.EmployeeId == deleteEmployee.EmployeeId).FirstOrDefault();

                if (employee != null)
                {
                    db.Entry(employee).State = EntityState.Deleted;

                    if (employeeRecord != null)
                    {
                        foreach (EmployeeRecordModel md in db.EmployeeRecords)
                        {
                            db.Entry(employeeRecord).State = EntityState.Deleted;
                        }
                    }

                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public static bool DeleteEmployeeRecord(EmployeeRecordModel deleteEmployeeRecord)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                var employeeRecord = db.EmployeeRecords.Where(rec => rec.RecordId == deleteEmployeeRecord.RecordId).First();

                if (employeeRecord != null)
                {
                    db.Entry(employeeRecord).State = EntityState.Deleted;
                    db.SaveChanges();

                    return true;
                }

                return false;
            }
        }
    }
}
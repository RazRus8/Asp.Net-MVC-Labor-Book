using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApp.Models;

namespace WebApp.Models.UPDATE
{
    public class UpdateData
    {
        public static bool UpdateEmployee(EmployeeModel editEmployee)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                var employee = db.Employees.Where(emp => emp.EmployeeId == editEmployee.EmployeeId).First();
                
                if (employee != null)
                {
                    employee.FirstName = editEmployee.FirstName;
                    employee.LastName = editEmployee.LastName;
                    employee.Patronymic = editEmployee.Patronymic;
                    employee.Birthday = editEmployee.Birthday;
                    employee.EducationLevel = editEmployee.EducationLevel;
                    employee.EducationDegree = editEmployee.EducationDegree;
                    employee.RegistrationDate = editEmployee.RegistrationDate;

                    db.Entry(employee).State = EntityState.Modified;
                    db.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public static bool UpdateEmployeeRecord(EmployeeRecordModel editEmployeeRecord)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                var employeeRecord = db.EmployeeRecords.Where(rec => rec.RecordId == editEmployeeRecord.RecordId).First();

                if (employeeRecord != null)
                {
                    employeeRecord.RecordDate = editEmployeeRecord.RecordDate;
                    employeeRecord.Action = editEmployeeRecord.Action;
                    employeeRecord.Description = editEmployeeRecord.Description;
                    employeeRecord.Position = editEmployeeRecord.Position;
                    employeeRecord.ConfirmDocument = editEmployeeRecord.ConfirmDocument;

                    db.Entry(employeeRecord).State = EntityState.Modified;
                    db.SaveChanges();

                    return true;
                }

                return false;
            }
        }
    }
}
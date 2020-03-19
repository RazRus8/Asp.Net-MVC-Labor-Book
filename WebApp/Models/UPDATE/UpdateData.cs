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

                    db.Entry(employee).State = EntityState.Modified;
                    db.SaveChanges();

                    return true;
                }

                return false;
            }
        }
    }
}
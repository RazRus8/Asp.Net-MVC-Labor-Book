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

                if (employee != null)
                {
                    db.Entry(employee).State = EntityState.Deleted;
                    db.SaveChanges();

                    return true;
                }

                return false;
            }
        }
    }
}
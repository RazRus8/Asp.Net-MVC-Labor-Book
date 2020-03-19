﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace WebApp.Models.DBInitializer
{
    public class DBInitializer : DropCreateDatabaseAlways<EmployeeContext>
    {
        protected override void Seed(EmployeeContext db)
        {
            db.SigninUsers.AddOrUpdate(x => x.UserId,
                new SigninUserModel { UserId = 1, Username = "admin", Password = "1234" }
                );

            db.Employees.AddOrUpdate(x => x.EmployeeId,
                new EmployeeModel { EmployeeId = 1, FirstName = "Robert", LastName = "Martin", Patronymic = "Cecil", Birthday = new DateTime(1952, 12, 5), EducationLevel = "Higher", EducationDegree = "Sc.D.", RegistrationDate = DateTime.Now}
                );

            base.Seed(db);
        }
    }
}
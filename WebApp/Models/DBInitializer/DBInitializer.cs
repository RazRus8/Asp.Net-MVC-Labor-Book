using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApp.Models.DBInitializer
{
    public class DBInitializer : DropCreateDatabaseAlways<EmployeeContext>
    {
        protected override void Seed(EmployeeContext db)
        {
            db.SigninUsers.Add(new SigninUserModel { Username = "admin", Password = "1234" });

            base.Seed(db);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApp.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("CustomConnection") { }

        public DbSet<SigninUserModel> SigninUsers { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<EmployeeRecordModel> EmployeeRecords { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public string EducationLevel { get; set; }
        public string EducationDegree { get; set; }
        public DateTime RegistrationDate { get; set; }

        public string DisplayEmployees { get { return $"{FirstName} {LastName}"; } }

        public ICollection<EmployeeRecordModel> Records { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class EmployeeRecordModel
    {
        [Key]
        public int RecordId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime RecordDate { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public string ConfirmDocument { get; set; }
        public string RecDate { get { return RecordDate.ToString(); } }

        public EmployeeModel EmployeeModel { get; set; }
    }
}
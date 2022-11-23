using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class Employee
    {
        [Required(ErrorMessage ="EmpId is required.")]
        [RegularExpression(@"[0-9]{4}",ErrorMessage ="Enter 4 digit EmpId")]
        public int? EmpId { get; set; }
        [Required(ErrorMessage ="EmpName is required.")]
        public string EmpName { get; set; }
        public decimal? Salary { get; set; }
    }
}
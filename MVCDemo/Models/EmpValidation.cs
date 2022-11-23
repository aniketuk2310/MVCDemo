using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class EmpValidation
    {
        [Required(ErrorMessage = "Empno is a primary key")]
        public int EMPNO { get; set; }
        [Required(ErrorMessage = "Empname is a primary key")]
        public string ENAME { get; set; }
    }
}
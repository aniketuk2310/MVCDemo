using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Greet()
        {
            //return Content ("Welcome To MVC");
            return View();  //returns Greet view
        }

        //take id value in url from user and print same in browser
        public ActionResult GetData(int? id)
        {
            //to pass data from controller action to view use ViewBag or ViewData
            ViewBag.msg = "Id Value : " + id;
            //ViewData["msg"] = "Id Value : " + id;
            return View();
            //http://localhost:58681/home/getdata?id=22 query string
        }

        //take name of the person as a parameter to greet method 
        //parameter name is personname type string
        //print msg on view
        //welcome aniket
        [Route("Home/GreetPerson/{name?}")]
        public ActionResult GreetPerson(string name)
        {
            ViewBag.msg ="Welcome : " + name;
            return View();  //returns Greet view
        }

        //write an action which takes  two integer values
        //print addition of two numbers
        //use html textboxes for taking values
        public ActionResult AddOperation(int num1=0,int num2=0)
        {
            int sum = num1 + num2;
            ViewBag.msg = $"Addition of {num1} and {num2} is {sum}";
            return View();  //returns Greet view
        }

        public ActionResult ModelDemo()
        {
            Employee employee = new Employee()
            {
                EmpId = 101,
                EmpName = "Aniket",
                Salary = 100000
            };
            ViewBag.emp = employee;
            return View();
        }

        //take user input using model binder approach
        public ActionResult EmployeeForm()
        {
            return View(new Employee());
        }
        //display data
        public ActionResult DisplayEmployee(Employee emp)
        {
            if (ModelState.IsValid)
            {
                return View(emp);
            }
            return View("EmployeeForm");
        }
    }
}
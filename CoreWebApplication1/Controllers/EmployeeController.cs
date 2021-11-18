using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CoreWebApplication1.Models;

namespace CoreWebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeModel empObj = new EmployeeModel();

        public IActionResult Index()
        {
            empObj = new EmployeeModel();
            List<EmployeeModel> lst = empObj.getData();


            return View(lst);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeModel emp)
        {
            bool res;
            if (ModelState.IsValid)
            {
                empObj = new EmployeeModel();
                res = empObj.AddEmp(emp);
                if (res)
                {
                    TempData["msg"] = "Added successfully";
                }
            }
            else
            {
                TempData["msg"] = "Not Added. something went wrong..!!";
            }

            return View();
        }

        [HttpGet]
        public IActionResult EditEmployee(string id)
        {
            EmployeeModel emp = empObj.getData(id);

            return View(emp);
        }
    }
}

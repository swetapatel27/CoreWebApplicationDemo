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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeModel emp)
        {
            if (ModelState.IsValid)
            {
                RedirectToAction("Index");
                return View();
            }
            else
            {
                return View();
            }


        }
    }
}

﻿using CoreWebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApplication1.Controllers
{
    public class StudentController : Controller
    {
        StudentModel obj = new StudentModel();
        public IActionResult Index()
        {
            List<StudentModel> stud = obj.getData();


            return View(stud);
        }

        public IActionResult AddStudent()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddStudent(StudentModel stud)
        {
            StudentModel obj = new StudentModel();

            if (ModelState.IsValid)
            {
                //bool res = true;
                bool res = obj.Save(stud);
                if (res)
                {
                    TempData["msg"] = "Success";

                }

            }
            else
            {
                TempData["msg"] = "Not OK";

            }

            return View();
        }

        public IActionResult Result()
        {
            return View();
        }
    }
}

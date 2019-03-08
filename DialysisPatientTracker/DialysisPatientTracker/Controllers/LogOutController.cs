﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialysisPatientTracker.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DialysisPatientTracker.Controllers
{
    public class LogOutController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            UserAccount name = new UserAccount();

            ViewBag.Message = ($"{name.UserName}");

            return View();
        }
    }
}
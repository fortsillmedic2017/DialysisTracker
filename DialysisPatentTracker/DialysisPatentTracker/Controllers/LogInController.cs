// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using DialysisPatentTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DialysisPatentTracker.Controllers
{
    public class LogInController : Controller
    {
        static private List<LogIn> LogIn = new List<LogIn>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.login = LogIn;

            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            return Redirect("/SearchOptions");
        }
    }
}
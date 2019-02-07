using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialysisPatientTracker.Models.SignUp;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DialysisPatientTracker.Controllers
{
    public class SignUpController : Controller
    {
        static private List<SignUp> SignupInfo = new List<SignUp>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.sigUpInfo = SignupInfo;
            return View();
        }

        [HttpPost]
        public IActionResult Index(string firstName, string lastName, string email, string username, string password, string confirm)
        {
            return View("/LogIn");
        }
    }
}
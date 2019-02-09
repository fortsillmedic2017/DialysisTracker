// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using DialysisPatientTracker.Models;
using DialysisPatientTracker.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DialysisPatientTracker.Controllers
{
    public class LogInController : Controller
    {
        static private List<LogIn> logIn = new List<LogIn>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            AddLogInViewModel addLogInViewModel = new AddLogInViewModel();

            return View(addLogInViewModel);
        }

        [HttpPost]
        public IActionResult Index(AddLogInViewModel addLogInViewModel)
        {
            if (ModelState.IsValid)
            {
                LogIn newLogIn = new LogIn
                {
                    UserName = addLogInViewModel.UserName,
                    Password = addLogInViewModel.Password
                };

                logIn.Add(newLogIn);

                return Redirect("/SearchOptions");
            }

            return View(addLogInViewModel);
        }
    }
}
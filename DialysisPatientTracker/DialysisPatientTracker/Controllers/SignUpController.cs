using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialysisPatientTracker.Models.SignUp;
using DialysisPatientTracker.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DialysisPatientTracker.Controllers
{
    public class SignUpController : Controller
    {
        static private List<SignUp> signUp = new List<SignUp>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            AddSignUpViewModel addSignUpViewMode = new AddSignUpViewModel();
            return View(addSignUpViewMode);
        }

        [HttpPost]
        public IActionResult Index(AddSignUpViewModel addSignUpViewMode)
        {
            if (ModelState.IsValid)
            {
                SignUp newSignUp = new SignUp
                {
                    FirstName = addSignUpViewMode.FirstName,
                    LastName = addSignUpViewMode.LastName,
                    UserName = addSignUpViewMode.UserName,
                    Password = addSignUpViewMode.Password,
                    ComfirmPassword = addSignUpViewMode.ComfirmPassword,
                    Email = addSignUpViewMode.Email
                };

                signUp.Add(newSignUp);

                return Redirect("/LogIn/Index");
            }

            return View(addSignUpViewMode);
        }
    }
}
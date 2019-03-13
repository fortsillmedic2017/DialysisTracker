using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialysisPatientTracker.Data;
using DialysisPatientTracker.Models;
using DialysisPatientTracker.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DialysisPatientTracker.Controllers
{
    public class UserAccountController : Controller
    {
        private DialysisAppDbContext context;

        public UserAccountController(DialysisAppDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Register()
        {
            UserAccount userAccount = new UserAccount();
            return View(userAccount);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                //UserAccount user = new UserAccount
                //{
                //    FirstName = userAccount.FirstName,
                //    LastName = userAccount.LastName,
                //    Email = userAccount.Email,
                //    UserName = userAccount.UserName,
                //    Password = userAccount.Password,
                //    ConfirmPassword = userAccount.ConfirmPassword
                //};
                context.UserAccounts.Add(userAccount);
                context.SaveChanges();
                ModelState.Clear();

                ViewBag.SuccessMessage = userAccount.UserName + " " + "Registration Successful.";
            }
            return View();
        }

        public IActionResult LogIn()
        {
            AddUserAccountViewModel addUserAccountViewModel = new AddUserAccountViewModel();

            return View(addUserAccountViewModel);
        }

        [HttpPost]
        public IActionResult LogIn(AddUserAccountViewModel addUserAccountViewModel)
        {
            if (ModelState.IsValid)
            {
                UserAccount user = new UserAccount
                {
                    UserName = addUserAccountViewModel.UserName,
                    Password = addUserAccountViewModel.Password
                };
            }

            return Redirect("/SearchOptions/Index");
        }
    }
}
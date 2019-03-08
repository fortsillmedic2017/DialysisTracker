using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DialysisPatientTracker.Data;
using DialysisPatientTracker.Models;
using DialysisPatientTracker.ViewModels;

namespace DialysisPatientTracker.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly DialysisAppDbContext context;

        public UserAccountController(DialysisAppDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: UserAccount
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            AddUserAccountViewModel addUseAccountViewModel = new AddUserAccountViewModel();
            return View(addUseAccountViewModel);
        }

        //Register******************************************
        [HttpPost]
        public ActionResult Register(AddUserAccountViewModel addUserAccountViewModel)
        {
            if (ModelState.IsValid)
            {
                UserAccount theUserAccount = new UserAccount
                {
                    FirstName = addUserAccountViewModel.FirstName,
                    LastName = addUserAccountViewModel.LastName,
                    UserName = addUserAccountViewModel.UserName,
                    Email = addUserAccountViewModel.Email,
                    Password = addUserAccountViewModel.Password,
                    ConfirmPassword = addUserAccountViewModel.ConfirmPassword
                };

                context.UserAccounts.Add(theUserAccount);
                context.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = ($"{addUserAccountViewModel.FirstName} {addUserAccountViewModel.LastName}");
                return Redirect("/UserAccount/Register");
            }

            return View();
        }

        //LogIn**************************************

        // GET: /<controller>/
        public IActionResult LogIn()
        {
            AddUserAccountViewModel addUseAccountViewModel = new AddUserAccountViewModel();

            return View(addUseAccountViewModel);
        }

        [HttpPost]
        public IActionResult LogIn(AddUserAccountViewModel addUseAccountViewModel)
        {
            if (ModelState.IsValid)
            {
                UserAccount newLogIn = new UserAccount
                {
                    UserName = addUseAccountViewModel.UserName,
                    Password = addUseAccountViewModel.Password
                };
                context.UserAccounts.Add(newLogIn);//From Dbset
                context.SaveChanges();//*****always have to save******

                return Redirect("/SearchOptions");
            };

            return View(addUseAccountViewModel);
        }

        //*************************************************************************************************
        // GET: UserAccount/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccount = await context.UserAccounts
                .FirstOrDefaultAsync(m => m.UserAccountID == id);
            if (userAccount == null)
            {
                return NotFound();
            }

            return View(userAccount);
        }

        // GET: UserAccount/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserAccount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserAccountID,FirstName,LastName,Email,UserName,Password,ConfirmPassword")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                context.Add(userAccount);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userAccount);
        }

        // GET: UserAccount/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccount = await context.UserAccounts.FindAsync(id);
            if (userAccount == null)
            {
                return NotFound();
            }
            return View(userAccount);
        }

        // POST: UserAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserAccountID,FirstName,LastName,Email,UserName,Password,ConfirmPassword")] UserAccount userAccount)
        {
            if (id != userAccount.UserAccountID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(userAccount);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAccountExists(userAccount.UserAccountID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userAccount);
        }

        // GET: UserAccount/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccount = await context.UserAccounts
                .FirstOrDefaultAsync(m => m.UserAccountID == id);
            if (userAccount == null)
            {
                return NotFound();
            }

            return View(userAccount);
        }

        // POST: UserAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userAccount = await context.UserAccounts.FindAsync(id);
            context.UserAccounts.Remove(userAccount);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserAccountExists(int id)
        {
            return context.UserAccounts.Any(e => e.UserAccountID == id);
        }

        //*****************Remove************************

        public IActionResult RemoveUser()
        {
            ViewBag.userAccounts = context.UserAccounts.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult RemoveUser(int[] userAccountsIds)
        {
            foreach (int userAccountId in userAccountsIds)
            {
                UserAccount theUser = context.UserAccounts.Single(t => t.UserAccountID == userAccountId);

                context.UserAccounts.Remove(theUser);
            }

            context.SaveChanges();
            return Redirect("/UserAccount");
        }
    }
}
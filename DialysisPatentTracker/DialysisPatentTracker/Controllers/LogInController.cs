// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DialysisPatentTracker.Controllers
{
    public class LogInController : Controller
    {
        static private List<string> Usernames = new List<string>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.usernames = Usernames;

            return View();
        }

        //Display Form only
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string username)
        {
            Usernames.Add(username);

            return Redirect("/SearchOptions");
        }
    }
}
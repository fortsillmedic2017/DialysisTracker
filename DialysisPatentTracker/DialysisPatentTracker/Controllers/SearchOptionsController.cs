using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DialysisPatentTracker.Controllers
{
    public class SearchOptionsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add()
        {
            /* TODO  Figure out how to  have page redirect to serch option selection*/

            return View("/PatientMasterList");
        }
    }
}
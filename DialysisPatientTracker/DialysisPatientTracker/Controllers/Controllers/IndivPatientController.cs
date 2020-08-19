using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialysisPatientTracker.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DialysisPatientTracker.Controllers
{
    public class IndivPatientController : Controller
    {
        private PatientMasterListDbContext context;

        public IndivPatientController(PatientMasterListDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.title = "Individual Patient";
            ViewBag.patientMasterList = context.PatientMasterLists.ToList(); //From Db Context

            return View();
        }
    }
}
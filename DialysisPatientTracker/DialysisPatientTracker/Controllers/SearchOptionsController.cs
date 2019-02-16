using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialysisPatientTracker.Data;
using DialysisPatientTracker.Models;
using DialysisPatientTracker.Models.SearchOptions;
using DialysisPatientTracker.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DialysisPatientTracker.Controllers
{
    public class SearchOptionsController : Controller
    {
        // Reference to the data store
        private static PatientMasterListDbContext context;

        public SearchOptionsController(PatientMasterListDbContext dbContext)//customized contoller
        {
            context = dbContext;
        }

        // GET: /<controller>/
        //( Display the search form)
        public IActionResult Index()
        {
            return View();
        }

        /* TODO  Figure out how to  have page redirect to serch option selection*/

        [HttpPost]
        public IActionResult FindByMedicalRecord(string searchString)
        {
            var theMedicalRecord = from m in context.PatientMasterLists
                                   where m.MedicalRecord.Contains(searchString)
                                   select m;

            //return View(theMedicalRecord.ToList());
            return Redirect("/PatientMasterList");
        }
    }
}
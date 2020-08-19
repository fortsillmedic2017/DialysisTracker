using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialysisPatientTracker.Data;
using Microsoft.AspNetCore.Mvc;
using DialysisPatientTracker.ViewModels;
using DialysisPatientTracker.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace DialysisPatientTracker.Controllers
{
    public class SearchOptionsController : Controller
    {
        private DialysisAppDbContext context;

        public SearchOptionsController(DialysisAppDbContext dbContext)//customized contoller
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            UserAccount name = new UserAccount();
            SearchOptions searchOptions = new SearchOptions();

            ViewBag.Message = ($"{name.UserName}");
            return View();
        }

        public IActionResult FindByMedicalRecord(string search)
        {
            var medicalRecord = from m in context.CompleteLists //create a Variable
                                select m;
            if (!String.IsNullOrEmpty(search))
            {
                medicalRecord = medicalRecord.Where(m => m.MedicalRecord.Contains(search));
            }
            return View(medicalRecord.ToList());
        }

        public IActionResult FindByLastName(string search)
        {
            var lastName = from l in context.CompleteLists
                           select l;
            if (!String.IsNullOrEmpty(search))
            {
                lastName = lastName.Where(l => l.LastName.Contains(search));
            }

            return View(lastName.ToList());
        }

        public IActionResult FindByPhysician(string search)
        {
            var physician = from p in context.CompleteLists
                            select p;
            if (!String.IsNullOrEmpty(search))
            {
                physician = physician.Where(p => p.Physician.Contains(search));
            }

            return View(physician.ToList());
        }
    }
}
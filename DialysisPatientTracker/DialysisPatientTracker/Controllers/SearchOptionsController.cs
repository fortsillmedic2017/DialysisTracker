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
            AddSearchOptionsViewModel searchOptions = new AddSearchOptionsViewModel();
            return View(searchOptions);
        }

        public IActionResult FindByMedicalRecord(string search)
        {
            if (ModelState.IsValid)
            {
                var medicalRecord = from m in context.CompleteLists
                                    select m;
                medicalRecord = medicalRecord.Where(m => m.MedicalRecord.Equals(search));

                return View(medicalRecord.ToList());
            }
            return View();
        }

        public IActionResult FindByLastName(string search)
        {
            if (ModelState.IsValid)
            {
                var lastName = from m in context.CompleteLists
                               select m;
                lastName = lastName.Where(m => m.LastName.Equals(search));

                return View(lastName.ToList());
            }
            return View();
        }

        public IActionResult FindByPhysician(string search)
        {
            if (ModelState.IsValid)
            {
                var physician = from m in context.CompleteLists
                                select m;
                physician = physician.Where(m => m.Physician.Equals(search));

                return View(physician.ToList());
            }
            return View();
        }
    }
}
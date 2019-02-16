using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialysisPatientTracker.Data;
using DialysisPatientTracker.Models;
using DialysisPatientTracker.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DialysisPatientTracker.Controllers
{
    public class TreatmentMasterListController : Controller
    {
        private PatientDbContext context;

        public TreatmentMasterListController(PatientDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<TreatmentMasterList> treatmentMasterLists = context.TreatmentMasterLists.ToList();

            return View(treatmentMasterLists);
        }

        public IActionResult AddTreatment()
        {
            AddTreatmentMasterListViewModel addTreatmentMasterListViewModel = new AddTreatmentMasterListViewModel();

            return View(addTreatmentMasterListViewModel);
        }

        [HttpPost]
        public IActionResult AddTreatment(AddTreatmentMasterListViewModel addTreatmentMasterListViewModel)
        {
            if (ModelState.IsValid)
            {
                TreatmentMasterList newTreatmentMasterList = new TreatmentMasterList
                {
                    MedicalRecord = addTreatmentMasterListViewModel.MedicalRecord,
                    LastName = addTreatmentMasterListViewModel.LastName,
                    FirstName = addTreatmentMasterListViewModel.FirstName,
                    Physician = addTreatmentMasterListViewModel.Physician,
                    TreatmentDays = addTreatmentMasterListViewModel.TreatmentDays,
                    TreatmentTime = addTreatmentMasterListViewModel.TreatmentTime,
                    AccessType = addTreatmentMasterListViewModel.AccessType,
                    KBath = addTreatmentMasterListViewModel.KBath,
                    CaBath = addTreatmentMasterListViewModel.CaBath,
                    NaBath = addTreatmentMasterListViewModel.NaBath,
                    BiCarb = addTreatmentMasterListViewModel.BiCarb,
                    Temp = addTreatmentMasterListViewModel.Temp,
                    DialyzerSize = addTreatmentMasterListViewModel.DialyzerSize,
                    Comments = addTreatmentMasterListViewModel.Comments
                };

                context.TreatmentMasterLists.Add(newTreatmentMasterList);
                context.SaveChanges();

                return Redirect("/TreatmentMasterList");
            }

            return View(addTreatmentMasterListViewModel);
        }

        //*****************Remove************************

        public IActionResult RemoveTreatment()
        {
            ViewBag.treatmentMasterList = context.TreatmentMasterLists.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult RemoveTreatment(int[] patientTreatmentListMasterIds)
        {
            foreach (int patientTreatmentMasterListId in patientTreatmentListMasterIds)
            {
                TreatmentMasterList theTreatmnet = context.TreatmentMasterLists.Single(t => t.ID == patientTreatmentMasterListId);

                context.TreatmentMasterLists.Remove(theTreatmnet);
            }

            context.SaveChanges();
            return Redirect("/TreatmentMasterList");
        }
    }
}
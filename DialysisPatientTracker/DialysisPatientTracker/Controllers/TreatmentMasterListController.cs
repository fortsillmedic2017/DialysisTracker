using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialysisPatientTracker.Models;
using DialysisPatientTracker.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DialysisPatientTracker.Controllers
{
    public class TreatmentMasterListController : Controller
    {
        static public List<TreatmentMasterList> treatmentMasterList = new List<TreatmentMasterList>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<TreatmentMasterList> treatmentMasterLists = treatmentMasterList;

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

                treatmentMasterList.Add(newTreatmentMasterList);

                return Redirect("/TreatmentMasterList");
            }

            return View(addTreatmentMasterListViewModel);
        }

        //*****************Remove************************

        public IActionResult RemoveTreatment()
        {
            ViewBag.treatmentMasterList = treatmentMasterList;
            return View();
        }

        [HttpPost]
        public IActionResult RemoveTreatment(int[] patientTreatmentListMasterIds)
        {
            foreach (int patientTreatmentMasterListId in patientTreatmentListMasterIds)
            {
                treatmentMasterList.RemoveAll(t => t.PatientId == patientTreatmentMasterListId);
            }

            return Redirect("/TreatmentMasterList");
        }
    }
}
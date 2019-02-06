using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialysisPatentTracker.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DialysisPatentTracker.Controllers
{
    public class TreatmentMasterListController : Controller
    {
        static public List<TreatmentMasterList> TreatmentMasterLists = new List<TreatmentMasterList>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.treatmentMasterLists = TreatmentMasterLists;
            return View();
        }

        public IActionResult AddTreatment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTreatment(TreatmentMasterList newTreatmentMasterList)

        {
            TreatmentMasterLists.Add(newTreatmentMasterList);

            return Redirect("/TreatmentMasterList");
        }

        //*****************Remove************************

        public IActionResult RemoveTreatment()
        {
            ViewBag.treatmentMasterList = TreatmentMasterLists;
            return View();
        }

        [HttpPost]
        public IActionResult RemoveTreatment(int[] patientTreatmentListMasterIds)
        {
            foreach (int patientTreatmentMasterListId in patientTreatmentListMasterIds)
            {
                TreatmentMasterLists.RemoveAll(t => t.PatientId == patientTreatmentMasterListId);
            }

            return Redirect("/TreatmentMasterList");
        }
    }
}
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
        public IActionResult AddTreatment(string medicalRecord, string lastName, string firstName, string treatmentDays,
                                          string treatmentTime, string accessType, string kBath, string caBath, string naBath,
                                          string biCarb, string temp, string dialyzerSize, string comments)

        {
            TreatmentMasterList newTreatmentMasterList = new TreatmentMasterList
            {
                MedicalRecord = medicalRecord,
                LastName = lastName,
                FirstName = firstName,
                Physician = lastName,
                TreatmentDays = treatmentDays,
                TreatmentTime = treatmentTime,
                AccessType = accessType,
                KBath = kBath,
                CaBath = caBath,
                NaBath = naBath,
                BiCarb = biCarb,
                Temp = temp,
                DialyzerSize = dialyzerSize,
                Comments = comments
            };

            TreatmentMasterLists.Add(newTreatmentMasterList);

            return Redirect("/TreatmentMasterList");
        }
    }
}
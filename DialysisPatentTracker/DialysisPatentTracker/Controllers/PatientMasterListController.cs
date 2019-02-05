using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialysisPatentTracker.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DialysisPatentTracker.Controllers
{
    public class PatientMasterListController : Controller
    {
        static private List<PatientMasterList> PatientMasterLists = new List<PatientMasterList>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.patientMasterList = PatientMasterLists;
            return View();
        }

        public IActionResult AddPatient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPatient(int medicalRecord, string firstName, string lastName, string physician, string treatmentDays, string comments)
        {
            //created a new list object(constructor)
            PatientMasterList newPatientMasterList = new PatientMasterList
            {
                MedicalRecord = medicalRecord,
                FirstName = firstName,
                LastName = lastName,
                Physician = physician,
                TreatmentDays = treatmentDays,
                Comments = comments
            };

            //Add new Patient to exsisting patient list
            PatientMasterLists.Add(newPatientMasterList);

            return Redirect("/PatientMasterList");
        }

        public IActionResult RemovePatient()
        {
            ViewBag.title = "Remove Patient";
            ViewBag.patientMasterList = PatientMasterLists;

            return View();
        }

        [HttpPost]
        public IActionResult RemovePatient(int[] patientIds) //Comes from piatientIds in checkbox id =""  in  Remove View
        {
            //Remove patient from List
            //Loop through list created from int[] patientIds
            foreach (int patientId in patientIds)
            {
                PatientMasterLists.Single(p => p.PatientId == patientId); //List itself not (PatientMasterList Class)
            }
            return Redirect("/");
        }
    }
}
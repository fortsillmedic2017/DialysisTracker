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
    public class PatientMasterListController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<PatientMasterList> patientMasterLists = PatientMasterListData.GetAll();//From Data Model
            return View(patientMasterLists);
        }

        public IActionResult AddPatient()
        {
            AddPatientViewModel addPatientViewModel = new AddPatientViewModel();

            return View(addPatientViewModel);
        }

        //Model Rendering ===> property of class must match name = "" in form.

        [HttpPost]
        public IActionResult AddPatient(AddPatientViewModel addPatientViewModel)
        {
            if (ModelState.IsValid)
            {
                //Add new Patient to existing patient list
                PatientMasterList newPatientMasterList = new PatientMasterList
                {
                    MedicalRecord = addPatientViewModel.MedicalRecord,
                    FirstName = addPatientViewModel.FirstName,
                    LastName = addPatientViewModel.LastName,
                    Physician = addPatientViewModel.Physician,
                    TreatmentDays = addPatientViewModel.TreatmentDays,
                    Comments = addPatientViewModel.Comments
                };
                PatientMasterListData.Add(newPatientMasterList);//From Data Model

                return Redirect("/PatientMasterList");
            }

            return View(addPatientViewModel);
        }

        // Remove Patient From List**************************************************************

        public IActionResult RemovePatient()
        {
            ViewBag.title = "Remove Patient";
            ViewBag.patientMasterList = PatientMasterListData.GetAll(); //From Data Model

            return View();
        }

        [HttpPost]
        public IActionResult RemovePatient(int[] patientIds) //Comes from piatientIds in checkbox id =""  in  Remove View
        {
            //Remove patient from List
            //Loop through list created from int[] patientIds
            foreach (int patientId in patientIds)
            {
                PatientMasterListData.Remove(patientId);
            }

            return Redirect("/PatientMasterList");
        }
    }
}
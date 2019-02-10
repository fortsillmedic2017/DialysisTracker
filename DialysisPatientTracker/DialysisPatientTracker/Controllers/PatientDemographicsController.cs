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
    public class PatientDemographicsController : Controller
    {
        static public List<PatientDemographics> patientDemographic = new List<PatientDemographics>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<PatientDemographics> patientDemographics = patientDemographic;

            return View(patientDemographics);
        }

        public IActionResult AddDemographics()
        {
            AddPatientDemographicsViewModel addPatientDemographicsViewModel = new AddPatientDemographicsViewModel();

            return View(addPatientDemographicsViewModel);
        }

        [HttpPost]
        public IActionResult AddDemographics(AddPatientDemographicsViewModel addPatientDemographicsViewModel)
        {
            if (ModelState.IsValid)
            {
                //Add new Patient to existing patient list
                PatientDemographics newPatientDemographics = new PatientDemographics
                {
                    MedicalRecord = addPatientDemographicsViewModel.MedicalRecord,
                    FirstName = addPatientDemographicsViewModel.FirstName,
                    LastName = addPatientDemographicsViewModel.LastName,
                    Age = addPatientDemographicsViewModel.Age,
                    Gender = addPatientDemographicsViewModel.Gender,
                    Address = addPatientDemographicsViewModel.Address,
                    PhoneNumber = addPatientDemographicsViewModel.PhoneNumber,
                    Email = addPatientDemographicsViewModel.Email
                };

                patientDemographic.Add(newPatientDemographics);

                return Redirect("/PatientDemographics");
            }

            return View(addPatientDemographicsViewModel);
        }

        // Remove Patient From List**************************************************************
        public IActionResult RemoveDemographics()
        {
            ViewBag.title = "Remove DemoGraphics";
            ViewBag.patientDemographics = patientDemographic;

            return View();
        }

        [HttpPost]
        public IActionResult RemoveDemographics(int[] demographicIds)
        {
            foreach (int demographicId in demographicIds)
            {
                patientDemographic.RemoveAll(d => d.PatientId == demographicId);
            }
            return Redirect("/PatientDemographics");
        }
    }
}
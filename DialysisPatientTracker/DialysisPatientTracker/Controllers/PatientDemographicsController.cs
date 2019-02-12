using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialysisPatientTracker.Data;
using DialysisPatientTracker.Models;
using DialysisPatientTracker.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DialysisPatientTracker.Controllers
{
    public class PatientDemographicsController : Controller
    {
        private PatientDemographicsDbContext context;

        public PatientDemographicsController(PatientDemographicsDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<PatientDemographics> patientDemographics = context.PatientDemographic.ToList();//****

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

                context.PatientDemographic.Add(newPatientDemographics);//****
                context.SaveChanges();//*** must save

                return Redirect("/PatientDemographics");
            }

            return View(addPatientDemographicsViewModel);
        }

        // Remove Patient From List**************************************************************
        public IActionResult RemoveDemographics()
        {
            ViewBag.title = "Remove DemoGraphics";
            ViewBag.patientDemographics = context.PatientDemographic.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult RemoveDemographics(int[] demographicIds)
        {
            foreach (int demographicId in demographicIds)
            {
                PatientDemographics theDemographic = context.PatientDemographic.Single(d => d.ID == demographicId);
                context.PatientDemographic.Remove(theDemographic);
            }
            context.SaveChanges();

            return Redirect("/PatientDemographics");
        }
    }
}
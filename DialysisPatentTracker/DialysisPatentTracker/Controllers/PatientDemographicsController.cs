using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialysisPatentTracker.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DialysisPatentTracker.Controllers
{
    public class PatientDemographicsController : Controller
    {
        static public List<PatientDemographics> PatientDemographic = new List<PatientDemographics>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.patientDemographics = PatientDemographic;

            return View();
        }

        public IActionResult AddDemographics()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDemographics(int medicalRecord, string lastName, string firstName, int age, string gender, string address, int phoneNumber, string email)
        {
            PatientDemographics newPatientDemographic = new PatientDemographics
            {
                MedicalRecord = medicalRecord,
                LastName = lastName,
                FirstName = firstName,
                Age = age,
                Gender = gender,
                Address = address,
                PhoneNumber = phoneNumber,
                Email = email
            };

            PatientDemographic.Add(newPatientDemographic);

            //Add new Patient to exsisting patient list
            return Redirect("/PatientDemographics");
        }
    }
}
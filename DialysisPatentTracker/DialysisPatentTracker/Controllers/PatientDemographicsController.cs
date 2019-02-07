using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialysisPatientTracker.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DialysisPatientTracker.Controllers
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

        //Model Rendering ===> property of class must mach name = "" in form.
        [HttpPost]
        public IActionResult AddDemographics(PatientDemographics newPatientDemographic)
        {
            //Add new Patient to exsisting patient list
            PatientDemographic.Add(newPatientDemographic);

            return Redirect("/PatientDemographics");
        }

        // Remove Patient From List**************************************************************
        public IActionResult RemoveDemographics()
        {
            ViewBag.title = "Remove DemoGraphics";
            ViewBag.patientDemographics = PatientDemographic;

            return View();
        }

        [HttpPost]
        public IActionResult RemoveDemographics(int[] demographicIds)
        {
            foreach (int demographicId in demographicIds)
            {
                PatientDemographic.RemoveAll(d => d.PatientId == demographicId);
            }
            return Redirect("/PatientDemographics");
        }
    }
}
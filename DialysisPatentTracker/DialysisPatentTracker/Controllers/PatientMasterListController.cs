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
        public IActionResult Add(int patientid, string firstName, string lastName, string physician, string treatmentDays, string comments)
        {
            PatientMasterList newPatientMasterList = new PatientMasterList
            {
                PatientId = patientid,
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

        //************************** Patient Demo **************************     (TODO)
        public IActionResult PatientDemoGraphics()
        {
            return View();
        }

        //***************** Patient Treatment List ***************       (TODO)
        public IActionResult TreatmentMasterList()
        {
            return View();
        }

        //******************** Physician  List *******************       (TODO)
        public IActionResult PhysicianList()
        {
            return View();
        }
    }
}
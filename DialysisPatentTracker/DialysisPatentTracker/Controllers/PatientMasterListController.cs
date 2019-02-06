using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialysisPatentTracker.Models;
using DialysisPatientTracker.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DialysisPatentTracker.Controllers
{
    public class PatientMasterListController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.patientMasterList = PatientMasterListData.GetAll();//From Data Model
            return View();
        }

        public IActionResult AddPatient()
        {
            return View();
        }


        //Model Rendering ===> property of class must mach name = "" in form.

        [HttpPost]
        public IActionResult AddPatient(PatientMasterList newPatientMasterList)
        {

            //Add new Patient to exsisting patient list
            PatientMasterListData.Add(newPatientMasterList);//From Data Model

            return Redirect("/PatientMasterList");
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
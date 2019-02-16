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
    public class PatientMasterListController : Controller
    {
        //Ctreated an Instance of PatientMasterListDBContext(context)
        private PatientDbContext context;

        /*Created a Constructor from PatientMasterListController and set
         *the parameters to a instance of PatientMasterListDbContent and
         * set context = to that.
        */

        public PatientMasterListController(PatientDbContext dbContext)//customized contoller
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<PatientMasterList> patientMasterLists = context.PatientMasterLists.ToList();//From Dbset
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
                context.PatientMasterLists.Add(newPatientMasterList);//From Dbset
                context.SaveChanges();//*****always have to save******

                return Redirect("/PatientMasterList");
            }

            return View(addPatientViewModel);
        }

        // Remove Patient From List**************************************************************

        public IActionResult RemovePatient()
        {
            ViewBag.title = "Remove Patient";
            ViewBag.patientMasterList = context.PatientMasterLists.ToList(); //From Db Context

            return View();
        }

        [HttpPost]
        public IActionResult RemovePatient(int[] patientIds) //Comes from piatientIds in checkbox id =""  in  Remove View
        {
            //Remove patient from List
            //Loop through list created from int[] patientIds
            foreach (int patientId in patientIds)
            {
                //Still can use same arry of Ids but you are matching them with PatientMasterLists (from DbContext)
                //Create a instance of PatientMasterlist(thePatient) and use linq qurey to draw what you want
                PatientMasterList thePatient = context.PatientMasterLists.Single(p => p.ID == patientId);
                context.PatientMasterLists.Remove(thePatient);
            }

            context.SaveChanges();

            return Redirect("/PatientMasterList");
        }
    }
}
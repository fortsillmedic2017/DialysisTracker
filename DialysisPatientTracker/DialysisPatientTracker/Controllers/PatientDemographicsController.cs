using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DialysisPatientTracker.Data;
using DialysisPatientTracker.Models;
using DialysisPatientTracker.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DialysisPatientTracker.Controllers
{
    public class PatientDemographicsController : Controller
    {
        private DialysisAppDbContext context;

        public PatientDemographicsController(DialysisAppDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<CompleteList> patientDemographics = context.CompleteLists.ToList();//****

            return View(patientDemographics);
        }

        // GET: CompleteList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var completeList = await context.CompleteLists
                .FirstOrDefaultAsync(m => m.CompleteListID == id);
            if (completeList == null)
            {
                return NotFound();
            }

            return View(completeList);
        }

        // GET: CompleteList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var completeList = await context.CompleteLists.FindAsync(id);
            if (completeList == null)
            {
                return NotFound();
            }
            return View(completeList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompleteListID,MedicalRecord,LastName,FirstName,Physician,DOB,TreatmentDays,Age,Gender,Address,PhoneNumber,Email,TreatmentTime,AccessType,KBath,CaBath,NaBath,BiCarb,Temp,DialyzerSize,Comments")] CompleteList completeList)
        {
            if (id != completeList.CompleteListID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(completeList);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompleteListExists(completeList.CompleteListID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(completeList);
        }

        // GET: CompleteList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var completeList = await context.CompleteLists
                .FirstOrDefaultAsync(m => m.CompleteListID == id);
            if (completeList == null)
            {
                return NotFound();
            }

            return View(completeList);
        }

        // POST: CompleteList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var completeList = await context.CompleteLists.FindAsync(id);
            context.CompleteLists.Remove(completeList);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompleteListExists(int id)
        {
            return context.CompleteLists.Any(e => e.CompleteListID == id);
        }
    }
}

//public IActionResult AddDemographics()
//{
//    AddPatientDemographicsViewModel addPatientDemographicsViewModel = new AddPatientDemographicsViewModel();

//    return View(addPatientDemographicsViewModel);
//}

//[HttpPost]
//public IActionResult AddDemographics(AddPatientDemographicsViewModel addPatientDemographicsViewModel)
//{
//    if (ModelState.IsValid)
//    {
//        //Add new Patient to existing patient list
//        PatientDemographics newPatientDemographics = new PatientDemographics
//        {
//            MedicalRecord = addPatientDemographicsViewModel.MedicalRecord,
//            FirstName = addPatientDemographicsViewModel.FirstName,
//            LastName = addPatientDemographicsViewModel.LastName,
//            Age = addPatientDemographicsViewModel.Age,
//            Gender = addPatientDemographicsViewModel.Gender,
//            Address = addPatientDemographicsViewModel.Address,
//            PhoneNumber = addPatientDemographicsViewModel.PhoneNumber,
//            Email = addPatientDemographicsViewModel.Email
//        };

//        context.PatientDemographic.Add(newPatientDemographics);//****
//        context.SaveChanges();//*** must save

//        return Redirect("/PatientDemographics");
//    }

//    return View(addPatientDemographicsViewModel);
//}

//// Remove Patient From List**************************************************************
//public IActionResult RemoveDemographics()
//{
//    ViewBag.title = "Remove DemoGraphics";
//    ViewBag.patientDemographics = context.PatientDemographic.ToList();

//    return View();
//}

//[HttpPost]
//        public IActionResult RemoveDemographics(int[] demographicIds)
//        {
//            foreach (int demographicId in demographicIds)
//            {
//                CompleteList theDemographic = context.CompleteLists.Single(d => d.CompleteListID == demographicId);
//                context.CompleteList.Remove(theDemographic);
//            }
//            context.SaveChanges();

//            return Redirect("/PatientDemographics/Index");
//        }
//    }
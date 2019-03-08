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
    public class TreatmentMasterListController : Controller
    {
        private DialysisAppDbContext context;

        public TreatmentMasterListController(DialysisAppDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<CompleteList> treatmentMasterLists = context.CompleteLists.ToList();

            return View(treatmentMasterLists);
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

        // POST: CompleteList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

//===============================================================================================================
//public IActionResult AddTreatment()
//{
//    AddTreatmentMasterListViewModel addTreatmentMasterListViewModel = new AddTreatmentMasterListViewModel();

//    return View(addTreatmentMasterListViewModel);
//}

//[HttpPost]
//public IActionResult AddTreatment(AddTreatmentMasterListViewModel addTreatmentMasterListViewModel)
//{
//    if (ModelState.IsValid)
//    {
//        TreatmentMasterList newTreatmentMasterList = new TreatmentMasterList
//        {
//            MedicalRecord = addTreatmentMasterListViewModel.MedicalRecord,
//            LastName = addTreatmentMasterListViewModel.LastName,
//            FirstName = addTreatmentMasterListViewModel.FirstName,
//            Physician = addTreatmentMasterListViewModel.Physician,
//            TreatmentDays = addTreatmentMasterListViewModel.TreatmentDays,
//            TreatmentTime = addTreatmentMasterListViewModel.TreatmentTime,
//            AccessType = addTreatmentMasterListViewModel.AccessType,
//            KBath = addTreatmentMasterListViewModel.KBath,
//            CaBath = addTreatmentMasterListViewModel.CaBath,
//            NaBath = addTreatmentMasterListViewModel.NaBath,
//            BiCarb = addTreatmentMasterListViewModel.BiCarb,
//            Temp = addTreatmentMasterListViewModel.Temp,
//            DialyzerSize = addTreatmentMasterListViewModel.DialyzerSize,
//            Comments = addTreatmentMasterListViewModel.Comments
//        };

//        context.TreatmentMasterLists.Add(newTreatmentMasterList);
//        context.SaveChanges();

//        return Redirect("/TreatmentMasterList");
//    }

//    return View(addTreatmentMasterListViewModel);
//}

////*****************Remove************************

//public IActionResult RemoveTreatment()
//{
//    ViewBag.treatmentMasterList = context.TreatmentMasterLists.ToList();

//    return View();
//}

//[HttpPost]
//public IActionResult RemoveTreatment(int[] patientTreatmentListMasterIds)
//{
//    foreach (int patientTreatmentMasterListId in patientTreatmentListMasterIds)
//    {
//        TreatmentMasterList theTreatmnet = context.TreatmentMasterLists.Single(t => t.CompleteListID == patientTreatmentMasterListId);

//        context.TreatmentMasterLists.Remove(theTreatmnet);
//    }

//    context.SaveChanges();
//    return Redirect("/TreatmentMasterList");
//}
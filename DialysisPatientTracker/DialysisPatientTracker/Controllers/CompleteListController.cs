using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DialysisPatientTracker.Data;
using DialysisPatientTracker.Models;
using DialysisPatientTracker.ViewModels;

namespace DialysisPatientTracker.Controllers
{
    public class CompleteListController : Controller
    {
        private DialysisAppDbContext context;

        public CompleteListController(DialysisAppDbContext dbContext)//customized contoller
        {
            context = dbContext;
        }

        // GET: CompleteList
        public async Task<IActionResult> Index()
        {
            return View(await context.CompleteLists.ToListAsync());
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

        //GET DEMOGRAPHICS------------------

        public async Task<IActionResult> DemoGraphic(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demographics = await context.CompleteLists
                .FirstOrDefaultAsync(m => m.CompleteListID == id);
            if (demographics == null)
            {
                return NotFound();
            }

            return View(demographics);
        }

        //GET Treatments-----------------

        public async Task<IActionResult> Treatment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatments = await context.CompleteLists
                .FirstOrDefaultAsync(m => m.CompleteListID == id);
            if (treatments == null)
            {
                return NotFound();
            }

            return View(treatments);
        }

        // GET: CompleteList/Create
        public IActionResult AddPatient()
        {
            return View();
        }

        // POST: CompleteList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult AddPatient(AddCompleteListViewModle addCompleteListViewModle)
        {
            if (ModelState.IsValid)
            {
                //Add new Patient to existing patient list
                CompleteList newCompletList = new CompleteList
                {
                    MedicalRecord = addCompleteListViewModle.MedicalRecord,
                    FirstName = addCompleteListViewModle.FirstName,
                    LastName = addCompleteListViewModle.LastName,
                    Physician = addCompleteListViewModle.Physician,
                    TreatmentDays = addCompleteListViewModle.TreatmentDays,
                    Age = addCompleteListViewModle.Age,
                    DOB = addCompleteListViewModle.DOB,
                    Gender = addCompleteListViewModle.Gender,
                    Address = addCompleteListViewModle.Address,
                    PhoneNumber = addCompleteListViewModle.PhoneNumber,
                    Email = addCompleteListViewModle.Email,
                    TreatmentTime = addCompleteListViewModle.TreatmentTime,
                    AccessType = addCompleteListViewModle.AccessType,
                    KBath = addCompleteListViewModle.KBath,
                    CaBath = addCompleteListViewModle.CaBath,
                    NaBath = addCompleteListViewModle.NaBath,
                    BiCarb = addCompleteListViewModle.BiCarb,
                    Temp = addCompleteListViewModle.Temp,
                    DialyzerSize = addCompleteListViewModle.DialyzerSize,
                    Comments = addCompleteListViewModle.Comments
                };

                context.CompleteLists.Add(newCompletList);//From Dbset
                context.SaveChanges();//*****always have to save******

                return Redirect("/PatientMasterList/Index");
            }

            return View(addCompleteListViewModle);
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
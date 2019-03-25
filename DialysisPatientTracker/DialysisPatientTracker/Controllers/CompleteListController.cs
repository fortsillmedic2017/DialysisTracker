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

        public CompleteListController(DialysisAppDbContext dbContext)//customized controller
        {
            context = dbContext;
        }

        // GET: CompleteList
        public async Task<IActionResult> Index()
        {
            return View(await context.CompleteLists.OrderBy(c => c.LastName).ToListAsync());
        }

        // GET: CompleteList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var completeList = await context.CompleteLists.OrderBy(c => c.LastName)
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

            var demographics = await context.CompleteLists.OrderBy(c => c.LastName)
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

            var treatments = await context.CompleteLists.OrderBy(c => c.LastName)
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
            return Redirect("PatientMasterList");
        }

        //**********************************************************************************
        //EDit Indv Demo tables----------

        // GET: CompleteList/Edit/5
        public async Task<IActionResult> EditIndvDemo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indvDemoList = await context.CompleteLists.FindAsync(id);
            if (indvDemoList == null)
            {
                return NotFound();
            }
            return View(indvDemoList);
        }

        // POST: CompleteList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditIndvDemo(int id, [Bind("CompleteListID,MedicalRecord,LastName,FirstName,Physician,DOB,TreatmentDays,Age,Gender,Address,PhoneNumber,Email,TreatmentTime,AccessType,KBath,CaBath,NaBath,BiCarb,Temp,DialyzerSize,Comments")] CompleteList completeList)
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
            return Redirect("/PatientMasterList/Index");
        }

        //EDit IndvTreatment tables--------------------------------

        // GET: CompleteList/Edit/5
        public async Task<IActionResult> EditIndvTreatment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indvTreatment = await context.CompleteLists.FindAsync(id);
            if (indvTreatment == null)
            {
                return NotFound();
            }
            return View(indvTreatment);
        }

        // POST: CompleteList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditIndvTreatment(int id, [Bind("CompleteListID,MedicalRecord,LastName,FirstName,Physician,DOB,TreatmentDays,Age,Gender,Address,PhoneNumber,Email,TreatmentTime,AccessType,KBath,CaBath,NaBath,BiCarb,Temp,DialyzerSize,Comments")] CompleteList completeList)
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
            return View("/TreatmentMasterList/Index");
        }

        //EDit IndvPatient(Patient Gen Info) tables-------------------------------

        // GET: CompleteList/Edit/5
        public async Task<IActionResult> EditIndvPatient(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indvPatient = await context.CompleteLists.FindAsync(id);
            if (indvPatient == null)
            {
                return NotFound();
            }
            return View(indvPatient);
        }

        // POST: CompleteList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditIndvpatient(int id, [Bind("CompleteListID,MedicalRecord,LastName,FirstName,Physician,DOB,TreatmentDays,Age,Gender,Address,PhoneNumber,Email,TreatmentTime,AccessType,KBath,CaBath,NaBath,BiCarb,Temp,DialyzerSize,Comments")] CompleteList completeList)
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
            return Redirect("/PatientMasterList/Index");
        }

        //*********************************************************************************
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

        //Find pat By Physician

        public IActionResult FindByPhysician(string search)
        {
            var physician = from p in context.CompleteLists
                            select p;
            if (!String.IsNullOrEmpty(search))
            {
                physician = physician.Where(p => p.Physician.Equals(search));
            }

            return View(physician.ToList());
        }

        //**************************************************************************************
        //Remove Patients

        public IActionResult RemovePatient()
        {
            ViewBag.title = "Remove Patient";
            ViewBag.completeList = context.CompleteLists.OrderBy(c => c.LastName).ToList(); //From Db Context

            return View();
        }

        [HttpPost]
        public IActionResult RemovePatient(int[] patientIds) //Comes from piatientIds in checkbox id =""  in  Remove View
        {
            //Remove patient from List
            //Loop through list created from int[] patientIds
            foreach (int patientId in patientIds)
            {
                //Still can use same array of Ids but you are matching them with PatientMasterLists (from DbContext)
                //Create a instance of PatientMasterlist(thePatient) and use linq qurey to draw what you want
                CompleteList thePatient = context.CompleteLists.Single(p => p.CompleteListID == patientId);
                context.CompleteLists.Remove(thePatient);
            }

            context.SaveChanges();

            return Redirect("/PatientMasterList/Index");
        }
    }
}
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
    public class PatientMasterListController : Controller
    {
        //Ctreated an Instance of PatientMasterListDBContext(context)
        private DialysisAppDbContext context;

        /*Created a Constructor from PatientMasterListController and set
         *the parameters to a instance of PatientMasterListDbContent and
         * set context = to that.
        */

        public PatientMasterListController(DialysisAppDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/

        public IActionResult Index()
        {
            //////return View(await context.CompleteLists.ToListAsync());
            List<CompleteList> patientMasterLists = context.CompleteLists.ToList();//From Dbset

            return View(patientMasterLists);
        }

        //=====================================================================================================

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

        //// GET: CompleteList/Create
        //public IActionResult AddPatient()
        //{
        //    return View();
        //}

        //// POST: CompleteList/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //public IActionResult AddPatient(addCompleteListViewModle addCompleteListViewModle)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //Add new Patient to existing patient list
        //        CompleteList newCompletList = new CompleteList
        //        {
        //            MedicalRecord = addCompleteListViewModle.MedicalRecord,
        //            FirstName = addCompleteListViewModle.FirstName,
        //            LastName = addCompleteListViewModle.LastName,
        //            Physician = addCompleteListViewModle.Physician,
        //            TreatmentDays = addCompleteListViewModle.TreatmentDays,
        //            Age = addCompleteListViewModle.Age,
        //            DOB = addCompleteListViewModle.DOB,
        //            Gender = addCompleteListViewModle.Gender,
        //            Address = addCompleteListViewModle.Address,
        //            PhoneNumber = addCompleteListViewModle.PhoneNumber,
        //            Email = addCompleteListViewModle.Email,
        //            TreatmentTime = addCompleteListViewModle.TreatmentTime,
        //            AccessType = addCompleteListViewModle.AccessType,
        //            KBath = addCompleteListViewModle.KBath,
        //            CaBath = addCompleteListViewModle.CaBath,
        //            NaBath = addCompleteListViewModle.NaBath,
        //            BiCarb = addCompleteListViewModle.BiCarb,
        //            Temp = addCompleteListViewModle.Temp,
        //            DialyzerSize = addCompleteListViewModle.DialyzerSize,
        //            Comments = addCompleteListViewModle.Comments
        //        };

        //        context.CompleteLists.Add(newCompletList);//From Dbset
        //        context.SaveChanges();//*****always have to save******

        //        return Redirect("/CompleteList/Index");
        //    }

        //    return View(addCompleteListViewModle);
        //}

        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("CompleteListID,MedicalRecord,LastName,FirstName,Physician,DOB,TreatmentDays,Age,Gender,Address,PhoneNumber,Email,TreatmentTime,AccessType,KBath,CaBath,NaBath,BiCarb,Temp,DialyzerSize,Comments")] CompleteList completeList)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Add(completeList);
        //        await context.SaveChangesAsync();
        //        return RedirectToAction("CompleteList/Index");
        //    }
        //    return View(completeList);
        //}

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

//=====================================================================================================
//public IActionResult AddPatient()
//{
//    AddPatientMasterListViewModel AddPatietMasterListViewModel = new AddPatientMasterListViewModel();

//    return View(AddPatietMasterListViewModel);
//}

////Model Rendering ===> property of class must match name = "" in form.

//[HttpPost]
//public IActionResult AddPatient(AddPatientMasterListViewModel AddPatietMasterListViewModel)
//{
//    if (ModelState.IsValid)
//    {
//        //Add new Patient to existing patient list
//        PatientMasterList newPatientMasterList = new PatientMasterList
//        {
//            MedicalRecord = AddPatietMasterListViewModel.MedicalRecord,
//            FirstName = AddPatietMasterListViewModel.FirstName,
//            LastName = AddPatietMasterListViewModel.LastName,
//            Physician = AddPatietMasterListViewModel.Physician,
//            TreatmentDays = AddPatietMasterListViewModel.TreatmentDays,
//            Comments = AddPatietMasterListViewModel.Comments
//        };
//        context.PatientMasterLists.Add(newPatientMasterList);//From Dbset
//        context.SaveChanges();//*****always have to save******

//        return Redirect("/PatientMasterList");
//    }

//    return View(AddPatietMasterListViewModel);
//}

// Remove Patient From List**************************************************************

//public IActionResult RemovePatient()
//        {
//            ViewBag.title = "Remove Patient";
//            ViewBag.patientMasterList = context.CompleteLists.ToList(); //From Db Context

//            return View();
//        }

//        [HttpPost]
//        public IActionResult RemovePatient(int[] patientIds) //Comes from piatientIds in checkbox id =""  in  Remove View
//        {
//            //Remove patient from List
//            //Loop through list created from int[] patientIds
//            foreach (int patientId in patientIds)
//            {
//                //Still can use same arry of Ids but you are matching them with PatientMasterLists (from DbContext)
//                //Create a instance of PatientMasterlist(thePatient) and use linq qurey to draw what you want
//                CompleteList thePatient = context.CompleteLists.Single(p => p.CompleteListID == patientId);
//                context.CompleteLists.Remove(thePatient);
//            }

//            context.SaveChanges();

//            return Redirect("/PatientMasterList/Index");
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DialysisPatientTracker.Data;
using DialysisPatientTracker.Models;

namespace DialysisPatientTracker.Controllers
{
    public class PhysicianController : Controller
    {
        private DialysisAppDbContext context;

        public PhysicianController(DialysisAppDbContext dbContext)//customized contoller
        {
            context = dbContext;
        }

        // GET: CompleteList
        public IActionResult Index()
        {
            List<Physician> physicians = context.Physicians.ToList();//****

            return View(physicians);
        }

        // GET: Physician/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var physician = await context.Physicians
                .FirstOrDefaultAsync(m => m.PhysicianID == id);
            if (physician == null)
            {
                return NotFound();
            }

            return View(physician);
        }

        // GET: Physician/Create
        public IActionResult AddPhysician()
        {
            return View();
        }

        // POST: Physician/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhysicianID,LastName,FirstName,CellPhone,OfficePhone")] Physician physician)
        {
            if (ModelState.IsValid)
            {
                context.Add(physician);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(physician);
        }

        // GET: Physician/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var physician = await context.Physicians.FindAsync(id);
            if (physician == null)
            {
                return NotFound();
            }
            return View(physician);
        }

        // POST: Physician/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PhysicianID,LastName,FirstName,CellPhone,OfficePhone")] Physician physician)
        {
            if (id != physician.PhysicianID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(physician);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhysicianExists(physician.PhysicianID))
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
            return View(physician);
        }

        // GET: Physician/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var physician = await context.Physicians
                .FirstOrDefaultAsync(m => m.PhysicianID == id);
            if (physician == null)
            {
                return NotFound();
            }

            return View(physician);
        }

        // POST: Physician/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var physician = await context.Physicians.FindAsync(id);
            context.Physicians.Remove(physician);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhysicianExists(int id)
        {
            return context.Physicians.Any(e => e.PhysicianID == id);
        }
    }
}
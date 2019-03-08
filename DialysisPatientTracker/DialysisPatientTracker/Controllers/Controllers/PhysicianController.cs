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
    public class PhysicianController : Controller
    {
        private DialysisAppDbContext context;

        public PhysicianController(DialysisAppDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: Physician
        public ActionResult Index()
        {
            List<Physician> physicians = context.Physicians.ToList();
            return View(physicians);
        }
    }
}
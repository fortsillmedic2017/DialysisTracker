using DialysisPatientTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DialysisPatientTracker.Data
{
    public class TreatmentMasterListDbContext : DbContext
    {
        public DbSet<TreatmentMasterList> TreatmentMasterLists { get; set; }

        public TreatmentMasterListDbContext(DbContextOptions<TreatmentMasterListDbContext> options)
           : base(options)
        { }
    }
}
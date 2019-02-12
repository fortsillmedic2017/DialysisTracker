using DialysisPatientTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DialysisPatientTracker.Data
{
    public class PatientDemographicsDbContext : DbContext
    {
        public DbSet<PatientDemographics> PatientDemographic { get; set; }

        public PatientDemographicsDbContext(DbContextOptions<PatientDemographicsDbContext> options)
            : base(options)
        { }
    }
}
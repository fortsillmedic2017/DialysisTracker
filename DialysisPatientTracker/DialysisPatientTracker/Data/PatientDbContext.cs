using DialysisPatientTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DialysisPatientTracker.Data
{
    public class PatientDbContext : DbContext //DbContext is a build in class which is a part of Enity framework)
    {
        //Created a property "PatientMasterLists" from DbSet(which is a part of Enity framework)
        public DbSet<PatientMasterList> PatientMasterLists { get; set; }

        public DbSet<PatientDemographics> PatientDemographic { get; set; }
        public DbSet<TreatmentMasterList> TreatmentMasterLists { get; set; }

        //Constructor for PatientMasterListDbContent
        public PatientDbContext(DbContextOptions<PatientDbContext> options)
            : base(options)
        { }
    }
}
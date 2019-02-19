using DialysisPatientTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace DialysisPatientTracker.Data
{
    public class PatientMasterListDbContext : DbContext //DbContext is a build in class which is a part of Enity framework)
    {
        //Created a property "PatientMasterLists" from DbSet(which is a part of Enity framework)
        public DbSet<PatientMasterList> PatientMasterLists { get; set; }

        public DbSet<SearchOptions> SearchOptions { get; set; }

        public DbSet<PatientDemographics> PatientDemographic { get; set; }
        public DbSet<TreatmentMasterList> TreatmentMasterLists { get; set; }

        //Constructor for PatientMasterListDbContent
        public PatientMasterListDbContext(DbContextOptions<PatientMasterListDbContext> options)
            : base(options)
        { }
    }
}
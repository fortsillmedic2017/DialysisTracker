using DialysisPatientTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace DialysisPatientTracker.Data
{
    public class DialysisAppDbContext : DbContext //DbContext is a build in class which is a part of Enity framework)
    {
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<SearchOptions> SearchOptions { get; set; }
        public DbSet<CompleteList> CompleteLists { get; set; }
        public DbSet<Physician> Physicians { get; set; }
        public DbSet<PatientMasterList> PatientMasterLists { get; set; }
        public DbSet<PatientDemographics> PatientDemographic { get; set; }
        public DbSet<TreatmentMasterList> TreatmentMasterLists { get; set; }

        //-----------------------------------------------------------------------------

        //Constructor for PatientMasterListDbContent
        public DialysisAppDbContext(DbContextOptions<DialysisAppDbContext> options)
            : base(options)
        { }

        //-------------------------------------------------------------------------------

        //This sets up the Primary key for CompletList Class (only need when building many to many relationships
        //    protected override void OnModelCreating(ModelBuilder modelBuilder)
        //    {
        //        modelBuilder.Entity<Physician>()
        //            .HasMany(p => p.CompleteLists)
        //            .WithOne(c => c.Physician);
        //    }
        //}
    }
}

//modelBuilder.Entity<PatientDetail>()
//    .HasKey(c => new { c.CheeseID, c.MenuID });

// modelBuilder.Entity<PatientDetail>()
// .ToTable("PatientDetails")
// .HasKey(p => p.PatientDetailID);

// modelBuilder.Entity<PatientDemographics>()
//.ToTable("PatientDetails")
//.HasKey(p => p.PatientDetailID);        
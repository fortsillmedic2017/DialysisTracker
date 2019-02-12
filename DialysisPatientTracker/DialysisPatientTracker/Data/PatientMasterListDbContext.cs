using DialysisPatientTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DialysisPatientTracker.Data
{
    public class PatientMasterListDbContext : DbContext //DbContext is a build in class which is a part of Enity framework)
    {
        //Created a property "PatientMasterLists" from DbSet(which is a part of Enity framework)
        public DbSet<PatientMasterList> PatientMasterLists { get; set; }

        //Constructor for PatientMasterListDbContent
        public PatientMasterListDbContext(DbContextOptions<PatientMasterListDbContext> options)
            : base(options)
        { }
    }
}
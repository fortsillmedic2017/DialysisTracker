using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DialysisPatientTracker.Models
{
    public class PatientMasterList
    {
        public string MedicalRecord { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Physician { get; set; }
        public TreatmentDaysEnum TreatmentDays { get; set; }
        public string Comments { get; set; }

        public int PatientId { get; set; }
        private static int nextId = 1;

        public PatientMasterList()
        {
            PatientId = nextId;
            nextId++;
        }
    }
}
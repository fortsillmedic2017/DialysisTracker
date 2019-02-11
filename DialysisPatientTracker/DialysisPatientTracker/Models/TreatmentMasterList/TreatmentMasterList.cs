using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DialysisPatientTracker.Models
{
    public class TreatmentMasterList
    {
        public string MedicalRecord { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Physician { get; set; }
        public TreatmentDaysEnum TreatmentDays { get; set; }
        public string TreatmentTime { get; set; }
        public AccessTypeEnum AccessType { get; set; }
        public string KBath { get; set; }
        public string CaBath { get; set; }
        public string NaBath { get; set; }
        public string BiCarb { get; set; }
        public string Temp { get; set; }
        public string DialyzerSize { get; set; }
        public string Comments { get; set; }

        public int PatientId { get; set; }
        private static int nextId { get; set; }

        public TreatmentMasterList()
        {
            PatientId = nextId;
            nextId++;
        }
    }
}
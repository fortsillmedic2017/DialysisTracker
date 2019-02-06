using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DialysisPatentTracker.Models
{
    public class PatientMasterList
    {
        public int MedicalRecord { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Physician { get; set; }
        public string TreatmentDays { get; set; }
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
using DialysisPatientTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DialysisPatientTracker.Models
{
    public class CompleteList
    {
        public int CompleteListID { get; set; }
        public string MedicalRecord { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Physician { get; set; }
        public DateTime DOB { get; set; }
        public string TreatmentDays { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }

        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string TreatmentTime { get; set; }
        public string AccessType { get; set; }
        public string KBath { get; set; }
        public string CaBath { get; set; }
        public string NaBath { get; set; }
        public string BiCarb { get; set; }
        public string Temp { get; set; }
        public string DialyzerSize { get; set; }
        public string Comments { get; set; }

        public CompleteList()
        {
        }
    }
}
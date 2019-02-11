using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DialysisPatientTracker.Models
{
    public class PatientDemographics
    {
        public string MedicalRecord { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Age { get; set; }
        public GenderEnum Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int PatientId { get; set; }
        private static int nextId = 1;

        public PatientDemographics()
        {
            PatientId = nextId;
            nextId++;
        }
    }
}
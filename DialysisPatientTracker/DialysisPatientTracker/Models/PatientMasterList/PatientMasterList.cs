﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DialysisPatientTracker.Models
{
    public class PatientMasterList
    {
        public int ID { get; set; }
        public string MedicalRecord { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Physician { get; set; }
        public TreatmentDaysEnum TreatmentDays { get; set; }
        public string Comments { get; set; }
    }
}
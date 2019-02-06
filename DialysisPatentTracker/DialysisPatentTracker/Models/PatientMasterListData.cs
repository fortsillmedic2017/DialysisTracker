using DialysisPatentTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DialysisPatientTracker.Models
{
    public class PatientMasterListData
    {
        static private List<PatientMasterList> patientMasterLists = new List<PatientMasterList>();

        //Get all of patients
        public static List<PatientMasterList> GetAll()
        {
            return patientMasterLists;
        }

        //Add Patients
        public static void Add(PatientMasterList newPatientMasterList)
        {
            patientMasterLists.Add(newPatientMasterList);
        }

        //Get By Id
        public static PatientMasterList GetById(int id)
        {
            return patientMasterLists.Single(p => p.PatientId == id);
        }

        //Remove Patients
        public static void Remove(int id)
        {
            PatientMasterList removePatient = GetById(id);
            patientMasterLists.Remove(removePatient);
        }
    }
}
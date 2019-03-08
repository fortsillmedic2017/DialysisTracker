using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DialysisPatientTracker.Models
{
    public class SearchOptions
    {
        public int ID { get; set; }

        [Required]
        public string MedicalRecord { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Physician { get; set; }

        public SearchOptions()
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DialysisPatientTracker.ViewModels
{
    public class AddSearchOptionsViewModel
    {
        [Required]
        [Display(Name = "MRN")]
        public string MedicalRecord { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Physician { get; set; } //need to add selection for physicians
    }
}
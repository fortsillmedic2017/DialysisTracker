using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DialysisPatientTracker.ViewModels
{
    public class AddPatientViewModel
    {
        [Required(ErrorMessage = "You must Add Paient Medical Record Number")]
        [Display(Name = "MRN")]
        public int MedicalRecord { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Physician { get; set; } //need to add selection for physicians

        [Required(ErrorMessage = "Use MWF or TThS")]
        [StringLength(4)]
        public string TreatmentDays { get; set; }  //need to add selection for TreatmentDays(MWF.TTHS)

        [Required(ErrorMessage = "If no comments enter NA or None")]
        [StringLength(1000)]
        public string Comments { get; set; }
    }
}
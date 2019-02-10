using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DialysisPatientTracker.ViewModels
{
    public class AddPatientDemographicsViewModel
    {
        [Required]
        [Display(Name = "MRN")]
        public string MedicalRecord { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        [Range(18, 100)]
        public string Age { get; set; }

        [Required(ErrorMessage = "Please Enter M for (Male) or F for (Female)")]
        [StringLength(1)]
        [Display(Name = "Gender (M/F)")]
        public string Gender { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }
    }
}
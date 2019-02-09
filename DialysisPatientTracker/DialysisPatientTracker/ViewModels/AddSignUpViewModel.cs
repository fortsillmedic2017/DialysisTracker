using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DialysisPatientTracker.ViewModels
{
    public class AddSignUpViewModel
    {
        [Required]
        [Display(Name = " ")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = " ")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = " ")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = " ")]
        public string Password { get; set; }

        [Required]
        [Display(Name = " ")]
        public string ComfirmPassword { get; set; }

        [Required]
        [Display(Name = " ")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
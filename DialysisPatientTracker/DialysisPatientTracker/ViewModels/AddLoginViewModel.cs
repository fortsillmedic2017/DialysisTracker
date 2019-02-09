using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DialysisPatientTracker.ViewModels
{
    public class AddLogInViewModel
    {
        [Required]
        [Display(Name = " ")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = " ")]
        public string Password { get; set; }
    }
}
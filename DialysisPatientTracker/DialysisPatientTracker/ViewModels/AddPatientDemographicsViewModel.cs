using DialysisPatientTracker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public DateTime DOB { get; set; }

        [Required]
        [Range(18, 100)]
        public string Age { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter M for (Male) or F for (Female)")]
        [Display(Name = "Gender")]
        public GenderEnum Gender { get; set; }

        public List<SelectListItem> GenderOptions { get; set; }

        public AddPatientDemographicsViewModel()
        {
            GenderOptions = new List<SelectListItem>(); //Generate list for Option choices (need to add for loop)

            //<options value="">Male</options>(option choices)
            GenderOptions.Add(new SelectListItem
            {
                Value = ((int)GenderEnum.Male).ToString(),
                Text = GenderEnum.Male.ToString()
            });

            GenderOptions.Add(new SelectListItem
            {
                Value = ((int)GenderEnum.Female).ToString(),
                Text = GenderEnum.Female.ToString()
            });

            GenderOptions.Add(new SelectListItem
            {
                Value = ((int)GenderEnum.Other).ToString(),
                Text = GenderEnum.Other.ToString()
            });
        }
    }
}
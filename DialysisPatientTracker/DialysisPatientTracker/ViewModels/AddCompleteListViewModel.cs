using DialysisPatientTracker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DialysisPatientTracker.ViewModels
{
    public class AddCompleteListViewModle
    {
        public int CompleteListID { get; set; }

        [Required]
        public string MedicalRecord { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Physician { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Use MWF or TThS")]
        public string TreatmentDays { get; set; }  //need to add selection for TreatmentDays(MWF.TTHS)

        [Required]
        public string Age { get; set; }

        [Required(ErrorMessage = "Please Enter M for (Male) or F for (Female)")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string TreatmentTime { get; set; }

        [Required]
        public string AccessType { get; set; }

        [Required]
        public string KBath { get; set; }

        [Required]
        public string CaBath { get; set; }

        [Required]
        public string NaBath { get; set; }

        [Required]
        public string BiCarb { get; set; }

        [Required]
        public string Temp { get; set; }

        [Required]
        public string DialyzerSize { get; set; }

        [Required]
        public string Comments { get; set; }
    }
}
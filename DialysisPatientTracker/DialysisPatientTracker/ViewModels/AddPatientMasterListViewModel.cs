using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DialysisPatientTracker.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace DialysisPatientTracker.ViewModels
{
    public class AddPatientMasterListViewModel : AddCompleteListViewModle
    {
        //[Required(ErrorMessage = "You must Add Patient Medical Record Number")]
        //[Display(Name = "MRN")]
        //public int MedicalRecord { get; set; }

        //[Required]
        //public string LastName { get; set; }

        //[Required]
        //public string FirstName { get; set; }

        //[Required]
        //public string Physician { get; set; } //need to add selection for physicians

        //[Required(ErrorMessage = "If no comments enter NA or None")]
        //[StringLength(1000)]
        //public string Comments { get; set; }

        //[Required(ErrorMessage = "Use MWF or TThS")]
        //public string TreatmentDays { get; set; }

        //public TreatmentDaysEnum TreatmentDays { get; set; }  //need to add selection for TreatmentDays(MWF.TTHS)

        //public List<SelectListItem> TreatmentDayOptions { get; set; }

        ////Using a constructor to populate above( List<SelectListItem> TreatmentDayOptions )
        ////Initiate a empty List of List<SelectListItem>  items with the following constructor below
        //public AddPatietMasterListViewModel()
        //{
        //    TreatmentDayOptions = new List<SelectListItem>();

        //    //<option value ="0">MWF</option>
        //    TreatmentDayOptions.Add(new SelectListItem
        //    {
        //        Value = ((int)TreatmentDaysEnum.MWF).ToString(), //Casting property then set ToString()
        //        Text = TreatmentDaysEnum.MWF.ToString()
        //    });

        //    //<option value ="1">TTHS</option>
        //    TreatmentDayOptions.Add(new SelectListItem
        //    {
        //        Value = ((int)TreatmentDaysEnum.TTHS).ToString(), //Casting property then set ToString()
        //        Text = TreatmentDaysEnum.TTHS.ToString()
        //    });

        //    //<option value ="2">NonSpecific</option>
        //    TreatmentDayOptions.Add(new SelectListItem
        //    {
        //        Value = ((int)TreatmentDaysEnum.NonSpecific).ToString(), //Casting property then set ToString()
        //        Text = TreatmentDaysEnum.NonSpecific.ToString()
        //    });
    }
}
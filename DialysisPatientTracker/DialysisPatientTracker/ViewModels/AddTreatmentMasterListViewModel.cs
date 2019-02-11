using DialysisPatientTracker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DialysisPatientTracker.ViewModels
{
    public class AddTreatmentMasterListViewModel
    {
        [Required]
        public string MedicalRecord { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Physician { get; set; }
//*******************************************************************************************
        [Required]
        public TreatmentDaysEnum TreatmentDays { get; set; }
        [Required]
        public AccessTypeEnum AccessType { get; set; }
        [Required]
        public KBathEnum KBath { get; set; }

        public List<SelectListItem> TreatmentDayOptions { get; set; }
        public List<SelectListItem> AccessTypeOptions { get; set; }
        public List<SelectListItem> KBathOptions { get; set; }

        public AddTreatmentMasterListViewModel() {

            TreatmentDayOptions = new List<SelectListItem>();

            //<option value ="0">MWF</option>
            TreatmentDayOptions.Add(new SelectListItem
            {
                Value = ((int)TreatmentDaysEnum.MWF).ToString(), //Casting property then set ToString()
                Text = TreatmentDaysEnum.MWF.ToString()
            });

            //<option value ="1">TTHS</option>
            TreatmentDayOptions.Add(new SelectListItem
            {
                Value = ((int)TreatmentDaysEnum.TTHS).ToString(), //Casting property then set ToString()
                Text = TreatmentDaysEnum.TTHS.ToString()
            });

            //<option value ="2">NonSpecific</option>
            TreatmentDayOptions.Add(new SelectListItem
            {
                Value = ((int)TreatmentDaysEnum.NonSpecific).ToString(), //Casting property then set ToString()
                Text = TreatmentDaysEnum.NonSpecific.ToString()
            });
            //===========  Options for AccessTypes      ============================================
            AccessTypeOptions = new List<SelectListItem>();

            //<option value ="0">AVFistula</option>
            AccessTypeOptions.Add(new SelectListItem
            {
                Value = ((int)AccessTypeEnum.AVFistula).ToString(), //Casting property then set ToString()
                Text = AccessTypeEnum.AVFistula.ToString()
            });

            //<option value ="1">AvGraph</option>
            AccessTypeOptions.Add(new SelectListItem
            {
                Value = ((int)AccessTypeEnum.AVGraph).ToString(), //Casting property then set ToString()
                Text = AccessTypeEnum.AVGraph.ToString()
            });

            //<option value ="2">CVC</option>
            AccessTypeOptions.Add(new SelectListItem
            {
                Value = ((int)AccessTypeEnum.CVC).ToString(), //Casting property then set ToString()
                Text = AccessTypeEnum.CVC.ToString()
            });

            //===========  Options for KBath   ============================================
           KBathOptions = new List<SelectListItem>();

            KBathOptions.Add(new SelectListItem
            {
                Value = ((int)KBathEnum._1K).ToString(),
                Text =KBathEnum._1K.ToString()
            });
            KBathOptions.Add(new SelectListItem
            {
                Value = ((int)KBathEnum._2K).ToString(),
                Text = KBathEnum._2K.ToString()
            });
            KBathOptions.Add(new SelectListItem
            {
                Value = ((int)KBathEnum._3K).ToString(),
                Text = KBathEnum._3K.ToString()
            });
            KBathOptions.Add(new SelectListItem
            {
                Value = ((int)KBathEnum._4K).ToString(),
                Text = KBathEnum._4K.ToString()
            });

        }
        //**********************************************************************************************************
        [Required]
        [Display(Name = "Treatment Time (HRS)")]
        public string TreatmentTime { get; set; }
        
        //**************************************************************************************************
      

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

        public string Comments { get; set; }
    }
}




//public AddTreatmentMasterListViewModel()
//{ }

//    public AddTreatmentMasterListViewModel(IEnumerable<TreatmentDaysEnum> treatmentDays)
//{
//    TreatmentDayOptions = new List<SelectListItem>();

//    foreach (var treatmentDay in treatmentDays)
//    {
//        TreatmentDayOptions.Add(new SelectListItem
//        {
//            Value = treatmentDay.ID.ToString(),
//            Text = treatmentDay.
//                });
//    }
//}
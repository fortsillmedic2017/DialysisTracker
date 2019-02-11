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
        public List<SelectListItem> TreatmentDayOptions { get; set; }
        public List<SelectListItem> AccessTypeOptions { get; set; }

        public AddTreatmentMasterListViewModel()
        {
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

        }
        //**********************************************************************************************************
        [Required]
        [Display(Name = "Treatment Time (HRS)")]
        public string TreatmentTime { get; set; }
        //**************************************************************************************************
        

      

        

        

        //**************************************************************************************************
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

        public string Comments { get; set; }
    }
}
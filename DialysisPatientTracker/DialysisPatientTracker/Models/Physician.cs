using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DialysisPatientTracker.Models
{
    public class Physician
    {
        [Required]
        public int PhysicianID { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string CellPhone { get; set; }

        [Required]
        public string OfficePhone { get; set; }
    }
}
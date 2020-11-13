using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionChevauxBlazor.Models
{
    public class ValidationPlanningRepriseModel
    {
        [Key]
        public int IdValidation { get; set; }

        [ForeignKey("Id")]
        public int IdCheval_v { get; set; }

        [ForeignKey("Id")]
        public int ProgramID_v { get; set; }

        public string HorseName_v { get; set; }

        public string MonitorID_v { get; set; }
        public string MonitorFirstname_v { get; set; }
        public string MonitorLastname_v { get; set; }
        public string RiderID_v { get; set; }
        public string RiderFirstname_v { get; set; }
        public string RiderLastname_v { get; set; }

        [Required(ErrorMessage = "La date est requise.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date_v { get; set; }

        [Required(ErrorMessage = "L'heure est requise.")]
        public DateTime Time_v { get; set; }

        public bool Available_v { get; set; }
    }
}

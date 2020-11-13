using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionChevauxBlazor.Models
{
    public class AjoutPlanningReprisesModel
    {
        [Key]
        public int IdProgram { get; set; }
        
        [ForeignKey("Id")]
        public string MonitorId { get; set; }

        public string MonitorFisrtname { get; set; }

        public string MonitorLastname { get; set; }

        [Required(ErrorMessage = "La date est requise.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "L'heure est requise.")]        
        public DateTime Time { get; set; }

        public bool Available { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionChevauxBlazor.Models
{
    public class AjoutChevauxModel
    {
        [Key]
        public int IdCheval { get; set; }
        
        [Required(ErrorMessage = "Le nom du cheval est requis.")]
        [StringLength(25, ErrorMessage = "Le nom du cheval est trop long.")]
        public string HorseName { get; set; }

        [Required(ErrorMessage = "L'âge du cheval est requis.")]        
        public int Age { get; set; }

        [Required(ErrorMessage = "Le pays du cheval est requis.")]
        [StringLength(15, ErrorMessage = "Le pays du cheval est trop long.")]
        public string Country { get; set; }

        public bool Available { get; set; }

    }
}

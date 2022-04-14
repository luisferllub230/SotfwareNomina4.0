using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CapaAdmin.Models.ViewModel
{
    public class DataGestionDeduccionesLlenar
    {

        [Required]
        [Display(Name = "Nombre")]
        public string NOMBRE { set; get; }
        [Required]
        [Display(Name = "Depende del salario")]
        public string DEPENDE_SALARIO { set; get; }
        [Required]
        [Display(Name = "Estado")]
        public string ESTADO { set; get; }
    }
}
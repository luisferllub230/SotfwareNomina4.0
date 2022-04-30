using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capa_de_presentacion.Models
{
    public class Usuario
    {
        public int ID_USER { get; set; } 
        public string NOMBRES { get; set; }
        public string USUARIO { get; set; }
        public string CONTRASEÑA { get; set; }
        public string TIPO_USUARIO { get; set; }
        public string Confir_Clave { get; set; }
    }
}
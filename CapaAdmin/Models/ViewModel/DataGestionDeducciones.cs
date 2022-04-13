using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaAdmin.Models.ViewModel
{
    public class DataGestionDeducciones
    {
        public int ID_TPDEDU { set; get; }
        public string NOMBRE { set; get; }
        public string DEPENDE_SALARIO { set; get; }
        public string ESTADO { set; get; }
    }
}
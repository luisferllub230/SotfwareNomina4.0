//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaAdmin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RG_TRANSACCIONES
    {
        public int ID_RGTRANS { get; set; }
        public int ID_EMPLEADO { get; set; }
        public int ID_INGRESO { get; set; }
        public int ID_DEDUCCION { get; set; }
        public int ID_TIPO_TRANSACCION { get; set; }
        public System.DateTime FECHA { get; set; }
        public decimal MONTO { get; set; }
        public string ESTADO { get; set; }
    
        public virtual EMPLEADO EMPLEADO { get; set; }
        public virtual TP_DEDUCCIONES TP_DEDUCCIONES { get; set; }
        public virtual TIPO_INGRESO TIPO_INGRESO { get; set; }
        public virtual TRANSACCION TRANSACCION { get; set; }
    }
}

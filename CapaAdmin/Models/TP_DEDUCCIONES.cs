//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaAdmin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TP_DEDUCCIONES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TP_DEDUCCIONES()
        {
            this.RG_TRANSACCIONES = new HashSet<RG_TRANSACCIONES>();
        }
    
        public int ID_TPDEDU { get; set; }
        public string NOMBRE { get; set; }
        public string DEPENDE_SALARIO { get; set; }
        public string ESTADO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RG_TRANSACCIONES> RG_TRANSACCIONES { get; set; }
    }
}
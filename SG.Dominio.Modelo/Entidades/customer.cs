//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SG.Dominio.Modelo.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customer()
        {
            this.credit = new HashSet<credit>();
        }
    
        public int customer_id { get; set; }
        public string customer_first_name { get; set; }
        public string customer_last_name { get; set; }
        public bool customer_state { get; set; }
        public string customer_address { get; set; }
        public string customer_ci { get; set; }
        public string customer_phone { get; set; }
        public string customer_email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<credit> credit { get; set; }
    }
}

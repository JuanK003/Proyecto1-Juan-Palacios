//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto1_Juan_Palacios.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EncargadoEvento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EncargadoEvento()
        {
            this.Shows = new HashSet<Show>();
        }
    
        public int ID_Encargado { get; set; }
        public string NombreEncargado { get; set; }
        public string TelefonoEncargado { get; set; }
        public string EmailEncargado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Show> Shows { get; set; }
    }
}

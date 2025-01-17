//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrudAhorroPrestamos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class prestamos1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public prestamos1()
        {
            this.CuotaPr = new HashSet<CuotaPr>();
            this.GarantiaPr = new HashSet<GarantiaPr>();
        }
    
        public int id_prestamo { get; set; }
        public string CodigoPrestamo { get; set; }
        public Nullable<System.DateTime> FechaSolicitud { get; set; }
        public Nullable<System.DateTime> FechaAprobacion { get; set; }
        public Nullable<double> MontoPrestamo { get; set; }
        public Nullable<double> TasaInteres { get; set; }
        public Nullable<int> Plazo { get; set; }
        public Nullable<int> id_cliente { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CuotaPr> CuotaPr { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GarantiaPr> GarantiaPr { get; set; }
    }
}

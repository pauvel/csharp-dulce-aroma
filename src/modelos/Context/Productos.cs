//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace modelos.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class Productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Productos()
        {
            this.Detalle_Entradas = new HashSet<Detalle_Entradas>();
            this.Detalle_Ventas = new HashSet<Detalle_Ventas>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public string codigo { get; set; }
        public decimal precio { get; set; }
        public decimal costo { get; set; }
        public int existencias { get; set; }
        public System.DateTime fecha { get; set; }
        public System.TimeSpan hora { get; set; }
        public int idProveedor { get; set; }
        public int idEstatus { get; set; }
    
        public virtual cProductoEstatus cProductoEstatus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_Entradas> Detalle_Entradas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_Ventas> Detalle_Ventas { get; set; }
        public virtual Proveedores Proveedores { get; set; }
    }
}

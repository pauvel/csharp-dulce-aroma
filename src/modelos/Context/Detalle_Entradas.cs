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
    
    public partial class Detalle_Entradas
    {
        public int id { get; set; }
        public int idEntrada { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal costo { get; set; }
        public decimal importe { get; set; }
    
        public virtual Entradas Entradas { get; set; }
        public virtual Productos Productos { get; set; }
    }
}

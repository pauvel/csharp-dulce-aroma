﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dulce_aroma_db : DbContext
    {
        public dulce_aroma_db()
            : base("name=dulce_aroma_db")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cEmpleadoEstatus> cEmpleadoEstatus { get; set; }
        public virtual DbSet<cEmpleadoNivel> cEmpleadoNivel { get; set; }
        public virtual DbSet<cProductoEstatus> cProductoEstatus { get; set; }
        public virtual DbSet<cProveedorEstatus> cProveedorEstatus { get; set; }
        public virtual DbSet<cVentaEstatus> cVentaEstatus { get; set; }
        public virtual DbSet<Detalle_Ventas> Detalle_Ventas { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }
    }
}
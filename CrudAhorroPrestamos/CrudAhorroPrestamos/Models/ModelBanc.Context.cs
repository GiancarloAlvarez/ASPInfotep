﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ADBPrestamosEntities : DbContext
    {
        public ADBPrestamosEntities()
            : base("name=ADBPrestamosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<CuentaBancaria> CuentaBancaria { get; set; }
        public virtual DbSet<Cuota> Cuota { get; set; }
        public virtual DbSet<Garantia> Garantia { get; set; }
        public virtual DbSet<inversion> inversion { get; set; }
        public virtual DbSet<prestamos> prestamos { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Rol_Cliente> Rol_Cliente { get; set; }
        public virtual DbSet<Rol_usuario> Rol_usuario { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Rol_Cliente2> Rol_Cliente2 { get; set; }
        public virtual DbSet<Rol2> Rol2 { get; set; }
        public virtual DbSet<Rol_Cliente3> Rol_Cliente3 { get; set; }
        public virtual DbSet<Rol3> Rol3 { get; set; }
        public virtual DbSet<CuotaP> CuotaP { get; set; }
    }
}

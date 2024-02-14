using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProfeTours.Server.Models
{
    public partial class SENAContext : DbContext
    {
        public SENAContext()
        {
        }

        public SENAContext(DbContextOptions<SENAContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();  
        }

        public DbSet<Tipodocumento> TipoDocumentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>() 
                .HasOne(u => u.Tipodocumento)
                .WithMany()
                .HasForeignKey(u => u.IdTipoDocumento)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Tipodocumento)
                .WithMany()
                .HasForeignKey(c => c.IdTipoDocumento)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Venta>()
            //        .HasOne(v => v.Usuario)  // Relación con Usuario
            //        .WithMany(u => u.Ventas) // Un usuario puede tener varias ventas
            //        .HasForeignKey(v => v.IdCliente)
            //        .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Venta>()
            //    .HasOne(v => v.Paquete)  // Relación con Paquete
            //    .WithMany(p => p.Ventas) // Un paquete puede tener varias ventas
            //    .HasForeignKey(v => v.IdPaquete)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }

}

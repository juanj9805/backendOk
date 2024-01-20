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

        public virtual DbSet<Tipodocumento> Tipodocumentos { get; set; } = null!;
        public virtual DbSet<Tiporole> Tiporoles { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tipodocumento>(entity =>
            {
                entity.HasKey(e => e.IdTipoDocumento)
                    .HasName("PK__TIPODOCU__3AB3332F141EA8E0");

                entity.ToTable("TIPODOCUMENTO");

                entity.Property(e => e.TipoDocumento1)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TipoDocumento");
            });

            modelBuilder.Entity<Tiporole>(entity =>
            {
                entity.HasKey(e => e.IdTipoRoles)
                    .HasName("PK__TIPOROLE__EFE553C20E91EF96");

                entity.ToTable("TIPOROLES");

                entity.Property(e => e.TipoRoles)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIOS__5B65BF97941FCFB5");

                entity.ToTable("USUARIOS");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.oTipodocumento)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .HasConstraintName("FK_TipoDocumento");

                entity.HasOne(d => d.oTiporole)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoRoles)
                    .HasConstraintName("FK_TipoRoles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

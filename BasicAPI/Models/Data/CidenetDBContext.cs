using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BasicAPI.Models.Data
{
    public partial class CidenetDBContext : DbContext
    {
        public CidenetDBContext()
        {
        }

        public CidenetDBContext(DbContextOptions<CidenetDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Funcionario> Funcionarios { get; set; } = null!;

        /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          {
              if (!optionsBuilder.IsConfigured)
              {
  #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                  optionsBuilder.UseSqlServer("Server=localhost;Database=CidenetDB;persist security info=True;user id=sa;password=B{B4/]Q8kMuw=Qn{;MultipleActiveResultSets=True");
              }
          }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>(entity =>
            {
              //  entity.HasNoKey();

                entity.ToTable("FUNCIONARIOS");

                entity.Property(e => e.Area)
                    .HasMaxLength(50)
                    .HasColumnName("area");

                entity.Property(e => e.Correo)
                    .HasMaxLength(300)
                    .HasColumnName("correo");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_actualizacion");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("date")
                    .HasColumnName("fecha_ingreso");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(20)
                    .HasColumnName("identificacion");

                entity.Property(e => e.Pais)
                    .HasMaxLength(150)
                    .HasColumnName("pais");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(20)
                    .HasColumnName("primer_apellido");

                entity.Property(e => e.PrimerNombre)
                    .HasMaxLength(20)
                    .HasColumnName("primer_nombre");

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(20)
                    .HasColumnName("segundo_apellido");

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(20)
                    .HasColumnName("segundo_nombre");

                entity.Property(e => e.TipoIdentificacion)
                    .HasMaxLength(20)
                    .HasColumnName("tipo_identificacion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

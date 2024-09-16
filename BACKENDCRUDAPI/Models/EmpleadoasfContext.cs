using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BACKENDCRUDAPI.Models;

public partial class EmpleadoasfContext : DbContext
{
    public EmpleadoasfContext()
    {
    }

    public EmpleadoasfContext(DbContextOptions<EmpleadoasfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Idcargo).HasName("PK__CARGO__1B43683D1433981A");

            entity.ToTable("CARGO");

            entity.Property(e => e.Idcargo).HasColumnName("IDCARGO");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHAREGISTRO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Idempleado).HasName("PK__EMPLEADO__E014C31680BE7CD8");

            entity.ToTable("EMPLEADO");

            entity.Property(e => e.Idempleado).HasColumnName("IDEMPLEADO");
            entity.Property(e => e.Afp)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("AFP");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDOS");
            entity.Property(e => e.Cargo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CARGO");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("date")
                .HasColumnName("FECHA_INGRESO");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("FECHA_NACIMIENTO");
            entity.Property(e => e.Idcargo).HasColumnName("IDCARGO");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRES");
            entity.Property(e => e.Sueldo).HasColumnName("SUELDO");

            entity.HasOne(d => d.IdcargoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.Idcargo)
                .HasConstraintName("FK__EMPLEADO__IDCARG__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_API_KevinRodriguez.Models;

public partial class ProyectoKevinContext : DbContext
{
    public ProyectoKevinContext()
    {
    }

    public ProyectoKevinContext(DbContextOptions<ProyectoKevinContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Moto> Motos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Cliente__71ABD0A7C7ED4A80");

            entity.ToTable("Cliente");

            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.ApellidoC)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NombreC)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PK__Empleado__958BE6F06B0201B3");

            entity.ToTable("Empleado");

            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.ApellidoE)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Cargo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NombreE)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Moto>(entity =>
        {
            entity.HasKey(e => e.MotoId).HasName("PK__Moto__54F53998A6426F99");

            entity.ToTable("Moto");

            entity.Property(e => e.MotoId).HasColumnName("MotoID");
            entity.Property(e => e.Color)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Marca)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.PedidoId).HasName("PK__Pedido__09BA14102BBA3106");

            entity.ToTable("Pedido");

            entity.Property(e => e.PedidoId).HasColumnName("PedidoID");
            entity.Property(e => e.Fecha).HasColumnType("smalldatetime");
            entity.Property(e => e.MotoId).HasColumnName("MotoID");
            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");

            entity.HasOne(d => d.Moto).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.MotoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKPedido800537");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKPedido166542");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.ProveedorId).HasName("PK__Proveedo__61266BB9F1664DF5");

            entity.ToTable("Proveedor");

            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.VentaId).HasName("PK__Venta__5B41514CCAE9B6D4");

            entity.Property(e => e.VentaId).HasColumnName("VentaID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.Fecha).HasColumnType("smalldatetime");
            entity.Property(e => e.MotoId).HasColumnName("MotoID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Venta)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKVenta420639");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Venta)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKVenta411346");

            entity.HasOne(d => d.Moto).WithMany(p => p.Venta)
                .HasForeignKey(d => d.MotoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKVenta18932");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

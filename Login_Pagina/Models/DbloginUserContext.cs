using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Login_Pagina.Models;

public partial class DbloginUserContext : DbContext
{
    public DbloginUserContext()
    {
    }

    public DbloginUserContext(DbContextOptions<DbloginUserContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<Compra> Compras { get; set; }
    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PK__usuario__523111692C4A2469");

            entity.ToTable("usuario");

            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            entity.Property(e => e.ApellidoUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaNa)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroTel)
                .HasMaxLength(50)
                .IsUnicode(false);
        });
        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.Idcompra).HasName("PK__compra__1EDB610D2C4A2469");

            entity.ToTable("compra");

            entity.Property(e => e.Idcompra).HasColumnName("IDCompra");
            entity.Property(e => e.FechaCompra)
                .HasColumnType("datetime");

            // Relaciones con las otras tablas
            entity.HasOne(d => d.Usuario)
                .WithMany(p => p.Compras)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compra_Usuario");

            entity.HasOne(d => d.Producto)
                .WithMany(p => p.Compras)
                .HasForeignKey(d => d.Idproducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compra_Producto");
        });
        OnModelCreatingPartial(modelBuilder);
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Idproducto).HasName("PK__producto__7C5D41F0201DA1A7");

            entity.ToTable("Productos");

            entity.Property(e => e.Idproducto).HasColumnName("IDProducto");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 2)");
        });
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

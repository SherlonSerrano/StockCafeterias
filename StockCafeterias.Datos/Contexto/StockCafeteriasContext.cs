using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StockCafeterias.Entidades.Modelos;

namespace StockCafeterias.Datos.Contexto;

public partial class StockCafeteriasContext : DbContext
{
    public StockCafeteriasContext(DbContextOptions<StockCafeteriasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alerta> Alerta { get; set; }

    public virtual DbSet<CategoriaProducto> CategoriaProducto { get; set; }

    public virtual DbSet<CierreDia> CierreDia { get; set; }

    public virtual DbSet<DetalleCierre> DetalleCierre { get; set; }

    public virtual DbSet<Insumo> Insumo { get; set; }

    public virtual DbSet<Local> Local { get; set; }

    public virtual DbSet<MovimientoStock> MovimientoStock { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    public virtual DbSet<Receta> Receta { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<StockLocal> StockLocal { get; set; }

    public virtual DbSet<UnidadMedida> UnidadMedida { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<VwAlertasStockActual> VwAlertasStockActual { get; set; }

    public virtual DbSet<VwMovimientosDetallado> VwMovimientosDetallado { get; set; }

    public virtual DbSet<VwStockPorLocal> VwStockPorLocal { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alerta>(entity =>
        {
            entity.HasKey(e => e.IdAlerta).HasName("PK__Alerta__D2CDBC4FCD2A496D");

            entity.Property(e => e.FechaAlerta).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.TipoAlerta)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.IdStockLocalNavigation).WithMany(p => p.Alerta)
                .HasForeignKey(d => d.IdStockLocal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Alerta__IdStockL__07C12930");
        });

        modelBuilder.Entity<CategoriaProducto>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A1046CF3C4F");

            entity.HasIndex(e => e.Nombre, "UQ__Categori__75E3EFCFF8D1DA04").IsUnique();

            entity.Property(e => e.Estado).HasDefaultValue((byte)1);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("Fecha_Registro");
            entity.Property(e => e.FechaUltModificacion).HasColumnName("Fecha_Ult_Modificacion");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(50)
                .HasDefaultValue("admin")
                .HasColumnName("Usuario_Registro");
            entity.Property(e => e.UsuarioUltModificacion)
                .HasMaxLength(50)
                .HasColumnName("Usuario_Ult_Modificacion");
        });

        modelBuilder.Entity<CierreDia>(entity =>
        {
            entity.HasKey(e => e.IdCierreDia).HasName("PK__CierreDi__EC30875D50936406");

            entity.Property(e => e.Estado).HasDefaultValue((byte)1);
            entity.Property(e => e.FechaCierre).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Observacion).HasMaxLength(200);

            entity.HasOne(d => d.IdLocalNavigation).WithMany(p => p.CierreDia)
                .HasForeignKey(d => d.IdLocal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CierreDia__IdLoc__7D439ABD");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.CierreDia)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CierreDia__IdUsu__7E37BEF6");
        });

        modelBuilder.Entity<DetalleCierre>(entity =>
        {
            entity.HasKey(e => e.IdDetalleCierre).HasName("PK__DetalleC__05AB36A134A04417");

            entity.Property(e => e.CantidadEsperada).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CantidadFinal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCierreDiaNavigation).WithMany(p => p.DetalleCierre)
                .HasForeignKey(d => d.IdCierreDia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleCi__IdCie__01142BA1");

            entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.DetalleCierre)
                .HasForeignKey(d => d.IdInsumo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleCi__IdIns__02084FDA");
        });

        modelBuilder.Entity<Insumo>(entity =>
        {
            entity.HasKey(e => e.IdInsumo).HasName("PK__Insumo__F378A2AF590E2A00");

            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.Property(e => e.Estado).HasDefaultValue((byte)1);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("Fecha_Registro");
            entity.Property(e => e.FechaUltModificacion).HasColumnName("Fecha_Ult_Modificacion");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.StockActual).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.StockMinimo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(50)
                .HasDefaultValue("admin")
                .HasColumnName("Usuario_Registro");
            entity.Property(e => e.UsuarioUltModificacion)
                .HasMaxLength(50)
                .HasColumnName("Usuario_Ult_Modificacion");

            entity.HasOne(d => d.IdUnidadMedidaNavigation).WithMany(p => p.Insumo)
                .HasForeignKey(d => d.IdUnidadMedida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Insumo__IdUnidad__5535A963");
        });

        modelBuilder.Entity<Local>(entity =>
        {
            entity.HasKey(e => e.IdLocal).HasName("PK__Local__C287B9BBE8476C36");

            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.Estado).HasDefaultValue((byte)1);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("Fecha_Registro");
            entity.Property(e => e.FechaUltModificacion).HasColumnName("Fecha_Ult_Modificacion");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(50)
                .HasDefaultValue("admin")
                .HasColumnName("Usuario_Registro");
            entity.Property(e => e.UsuarioUltModificacion)
                .HasMaxLength(50)
                .HasColumnName("Usuario_Ult_Modificacion");
        });

        modelBuilder.Entity<MovimientoStock>(entity =>
        {
            entity.HasKey(e => e.IdMovimiento).HasName("PK__Movimien__881A6AE046B245CA");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FechaMovimiento).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Observacion).HasMaxLength(200);
            entity.Property(e => e.TipoMovimiento)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.MovimientoStock)
                .HasForeignKey(d => d.IdInsumo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movimient__IdIns__778AC167");

            entity.HasOne(d => d.IdLocalNavigation).WithMany(p => p.MovimientoStock)
                .HasForeignKey(d => d.IdLocal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movimient__IdLoc__76969D2E");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.MovimientoStock)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movimient__IdUsu__787EE5A0");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__09889210F1DA6339");

            entity.Property(e => e.CostoPromedio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Estado).HasDefaultValue((byte)1);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("Fecha_Registro");
            entity.Property(e => e.FechaUltModificacion).HasColumnName("Fecha_Ult_Modificacion");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.PrecioVenta).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(50)
                .HasDefaultValue("admin")
                .HasColumnName("Usuario_Registro");
            entity.Property(e => e.UsuarioUltModificacion)
                .HasMaxLength(50)
                .HasColumnName("Usuario_Ult_Modificacion");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Producto)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Producto__IdCate__4CA06362");
        });

        modelBuilder.Entity<Receta>(entity =>
        {
            entity.HasKey(e => new { e.IdProducto, e.IdInsumo }).HasName("PK__Receta__E6BF183AF1E262D5");

            entity.Property(e => e.CantidadRequerida).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.Estado).HasDefaultValue((byte)1);

            entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.Receta)
                .HasForeignKey(d => d.IdInsumo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Receta__IdInsumo__5AEE82B9");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Receta)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Receta__IdProduc__59FA5E80");

            entity.HasOne(d => d.IdUnidadMedidaNavigation).WithMany(p => p.Receta)
                .HasForeignKey(d => d.IdUnidadMedida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Receta__IdUnidad__5BE2A6F2");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__2A49584C5A639BFE");

            entity.Property(e => e.Estado).HasDefaultValue((byte)1);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("Fecha_Registro");
            entity.Property(e => e.FechaUltModificacion).HasColumnName("Fecha_Ult_Modificacion");
            entity.Property(e => e.Nombre).HasMaxLength(30);
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(50)
                .HasDefaultValue("admin")
                .HasColumnName("Usuario_Registro");
            entity.Property(e => e.UsuarioUltModificacion)
                .HasMaxLength(50)
                .HasColumnName("Usuario_Ult_Modificacion");
        });

        modelBuilder.Entity<StockLocal>(entity =>
        {
            entity.HasKey(e => e.IdStockLocal).HasName("PK__StockLoc__628DF9E092E12CED");

            entity.HasIndex(e => new { e.IdLocal, e.IdInsumo }, "UQ_LocalInsumo").IsUnique();

            entity.Property(e => e.CantidadActual).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Estado).HasDefaultValue((byte)1);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("Fecha_Registro");
            entity.Property(e => e.FechaUltModificacion).HasColumnName("Fecha_Ult_Modificacion");
            entity.Property(e => e.Ubicacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(50)
                .HasDefaultValue("admin")
                .HasColumnName("Usuario_Registro");
            entity.Property(e => e.UsuarioUltModificacion)
                .HasMaxLength(50)
                .HasColumnName("Usuario_Ult_Modificacion");

            entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.StockLocal)
                .HasForeignKey(d => d.IdInsumo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StockLoca__IdIns__71D1E811");

            entity.HasOne(d => d.IdLocalNavigation).WithMany(p => p.StockLocal)
                .HasForeignKey(d => d.IdLocal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StockLoca__IdLoc__70DDC3D8");
        });

        modelBuilder.Entity<UnidadMedida>(entity =>
        {
            entity.HasKey(e => e.IdUnidadMedida).HasName("PK__UnidadMe__18F83A93C5D8AA2D");

            entity.Property(e => e.Abreviatura).HasMaxLength(10);
            entity.Property(e => e.Estado).HasDefaultValue((byte)1);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("Fecha_Registro");
            entity.Property(e => e.FechaUltModificacion).HasColumnName("Fecha_Ult_Modificacion");
            entity.Property(e => e.Nombre).HasMaxLength(30);
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(50)
                .HasDefaultValue("admin")
                .HasColumnName("Usuario_Registro");
            entity.Property(e => e.UsuarioUltModificacion)
                .HasMaxLength(50)
                .HasColumnName("Usuario_Ult_Modificacion");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF971CF470F7");

            entity.HasIndex(e => e.NombreUsuario, "UQ__Usuario__6B0F5AE0F8D1DEAB").IsUnique();

            entity.HasIndex(e => e.Dni, "UX_Usuario_DNI")
                .IsUnique()
                .HasFilter("([DNI] IS NOT NULL)");

            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DNI");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Estado).HasDefaultValue((byte)1);
            entity.Property(e => e.FechaIngreso).HasDefaultValueSql("(CONVERT([date],getdate()))");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("Fecha_Registro");
            entity.Property(e => e.FechaUltModificacion).HasColumnName("Fecha_Ult_Modificacion");
            entity.Property(e => e.NombreUsuario).HasMaxLength(50);
            entity.Property(e => e.Nombres).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(200);
            entity.Property(e => e.Telefono).HasMaxLength(15);
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(50)
                .HasDefaultValue("admin")
                .HasColumnName("Usuario_Registro");
            entity.Property(e => e.UsuarioUltModificacion)
                .HasMaxLength(50)
                .HasColumnName("Usuario_Ult_Modificacion");

            entity.HasOne(d => d.IdLocalNavigation).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdLocal)
                .HasConstraintName("FK__Usuario__IdLocal__693CA210");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__IdRol__68487DD7");
        });

        modelBuilder.Entity<VwAlertasStockActual>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_AlertasStockActual");

            entity.Property(e => e.CantidadActual).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DescripcionAlerta)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Insumo).HasMaxLength(100);
            entity.Property(e => e.Local).HasMaxLength(100);
            entity.Property(e => e.StockMinimo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TipoAlerta)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Unidad).HasMaxLength(10);
        });

        modelBuilder.Entity<VwMovimientosDetallado>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_MovimientosDetallado");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Insumo).HasMaxLength(100);
            entity.Property(e => e.Local).HasMaxLength(100);
            entity.Property(e => e.Observacion).HasMaxLength(200);
            entity.Property(e => e.TipoMovimiento)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Unidad).HasMaxLength(10);
            entity.Property(e => e.Usuario).HasMaxLength(201);
        });

        modelBuilder.Entity<VwStockPorLocal>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_StockPorLocal");

            entity.Property(e => e.CantidadActual).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Insumo).HasMaxLength(100);
            entity.Property(e => e.Local).HasMaxLength(100);
            entity.Property(e => e.StockMinimo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Ubicacion).HasMaxLength(50);
            entity.Property(e => e.Unidad).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

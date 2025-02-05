using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using RootKube.Models.Entidades; // ✅ Usa el namespace correcto de los modelos

namespace RootKube.DAL.Contexto // ✅ Asegura que está en `RootKube.DAL.Contexto`
{ 
public partial class RootKubeDbContext : DbContext
{
    public RootKubeDbContext()
    {
    }

    public RootKubeDbContext(DbContextOptions<RootKubeDbContext> options)
        : base(options)
    {
    }

        public virtual DbSet<Caja> Cajas { get; set; }

        public virtual DbSet<Categoria> Categorias { get; set; }

        public virtual DbSet<ClavesProducto> ClavesProductos { get; set; }

        public virtual DbSet<DetalleVentum> DetalleVenta { get; set; }

        public virtual DbSet<Locale> Locales { get; set; }

        public virtual DbSet<Producto> Productos { get; set; }

        public virtual DbSet<Sesione> Sesiones { get; set; }

        public virtual DbSet<StockLocal> StockLocals { get; set; }

        public virtual DbSet<Token> Tokens { get; set; }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        public virtual DbSet<UsuarioLocale> UsuarioLocales { get; set; }

        public virtual DbSet<Venta> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=RootKube;Integrated Security=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caja>(entity =>
            {
                entity.HasKey(e => e.IdMovimiento).HasName("PK__Caja__2A071C2448E533F3");

                entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdLocalNavigation).WithMany(p => p.Cajas).HasConstraintName("FK__Caja__id_local__60A75C0F");

                entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Cajas)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Caja__id_usuario__619B8048");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__CD54BC5ACB32A0EB");
            });

            modelBuilder.Entity<ClavesProducto>(entity =>
            {
                entity.HasKey(e => e.IdClave).HasName("PK__Claves_P__2352E6FF4C0A9259");
            });

            modelBuilder.Entity<DetalleVentum>(entity =>
            {
                entity.HasKey(e => e.IdDetalle).HasName("PK__Detalle___4F1332DE3BFE309E");

                entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleVenta).HasConstraintName("FK__Detalle_V__id_pr__5BE2A6F2");

                entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleVenta).HasConstraintName("FK__Detalle_V__id_ve__5AEE82B9");
            });

            modelBuilder.Entity<Locale>(entity =>
            {
                entity.HasKey(e => e.IdLocal).HasName("PK__Locales__1ECD02104F4DB27D");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto).HasName("PK__Producto__FF341C0DFDBAB92B");

                entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos).HasConstraintName("FK__Productos__id_ca__49C3F6B7");
            });

            modelBuilder.Entity<Sesione>(entity =>
            {
                entity.HasKey(e => e.IdSesion).HasName("PK__Sesiones__8D3F9DFEFE7E523B");

                entity.Property(e => e.FechaInicio).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Sesiones).HasConstraintName("FK__Sesiones__id_usu__656C112C");
            });

            modelBuilder.Entity<StockLocal>(entity =>
            {
                entity.HasKey(e => e.IdStock).HasName("PK__Stock_Lo__3A39590AA79628B0");

                entity.HasOne(d => d.IdLocalNavigation).WithMany(p => p.StockLocals).HasConstraintName("FK__Stock_Loc__id_lo__5070F446");

                entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.StockLocals).HasConstraintName("FK__Stock_Loc__id_pr__5165187F");
            });

            modelBuilder.Entity<Token>(entity =>
            {
                entity.HasKey(e => e.IdToken).HasName("PK__Tokens__3C2FA9C403CAA142");

                entity.Property(e => e.IdToken).HasDefaultValueSql("(newid())");
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Tokens).HasConstraintName("FK__Tokens__id_usuar__3E52440B");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__4E3E04AD9AAADBCC");

                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<UsuarioLocale>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioLocal).HasName("PK__Usuario___C5BF543EE6661C34");

                entity.HasOne(d => d.IdLocalNavigation).WithMany(p => p.UsuarioLocales).HasConstraintName("FK__Usuario_L__id_lo__440B1D61");

                entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioLocales).HasConstraintName("FK__Usuario_L__id_us__4316F928");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.IdVenta).HasName("PK__Ventas__459533BF12CC17A0");

                entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdLocalNavigation).WithMany(p => p.Venta).HasConstraintName("FK__Ventas__id_local__5629CD9C");

                entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Venta)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Ventas__id_usuar__571DF1D5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
}
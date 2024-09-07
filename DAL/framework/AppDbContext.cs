using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CR_YPTO_TPF.Domain;
using System.Data.SqlClient;


namespace CR_YPTO_TPF.DAL.framework
{
	public partial class AppDbContext : DbContext
	{
		public AppDbContext() { }

		public AppDbContext(DbContextOptions<AppDbContext> options)
	   : base(options)
		{
		}

		public virtual DbSet<usuario> usuario { get; set; }
		public virtual DbSet<alerta> alerta { get; set; }
		public virtual DbSet<cryptohistoria> CryptoHistorias { get; set; }
		public virtual DbSet<usuariocrypto> UsuarioCryptos { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				//optionsBuilder.UseSqlServer("Server=LAPTOP-J6UIOHBN\\Carolina r;Database=CRYPTO_DB;User Id=sa;Password=12345678;");
				optionsBuilder.UseSqlServer("Server=LAPTOP-J6UIOHBN;Database=CRYPTO_DB;User Id=sa;Password=12345678;Encrypt=False;");

			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<alerta>(entity =>
			{
				entity.HasKey(e => new { e.idUsuario, e.idCrypto }).HasName("alerta_pkey");
				entity.ToTable("alerta");
				entity.Property(e => e.idUsuario).HasMaxLength(50).HasColumnName("idUsuario");
				entity.Property(e => e.idCrypto).HasMaxLength(50).HasColumnName("idCrypto");
				entity.Property(e => e.umbralAlerta).HasColumnName("umbralAlerta");
				entity.Property(e => e.fecha).HasColumnName("fecha");
			});

			modelBuilder.Entity<usuario>(entity =>
			{
				entity.HasKey(e => e.idUsuario).HasName("usuario_pk");
				entity.ToTable("usuario");
				entity.Property(e => e.idUsuario).HasColumnName("idUsuario");
				entity.Property(e => e.nombre).HasMaxLength(100).HasColumnName("nombre");
				entity.Property(e => e.apellido).HasMaxLength(100).HasColumnName("apellido");
				entity.Property(e => e.correo).HasMaxLength(100).HasColumnName("correo");
				entity.Property(e => e.clave).HasMaxLength(255).HasColumnName("clave");
				entity.Property(e => e.umbral).HasColumnName("umbral");
				entity.Property(e => e.activo).HasColumnName("activo");
			});


			modelBuilder.Entity<cryptohistoria>(entity =>
			{
				entity.HasKey(e => e.idcryptohistoria).HasName("cryptohistoria_pkey");
				entity.ToTable("cryptohistoria");
				entity.Property(e => e.idcryptohistoria).HasColumnName("idcryptohistoria");
				entity.Property(e => e.idUsuario).HasMaxLength(50).HasColumnName("idUsuario");
				entity.Property(e => e.idCrypto).HasMaxLength(50).HasColumnName("idCrypto");
				entity.Property(e => e.precio).HasMaxLength(50).HasColumnName("precio");
				entity.Property(e => e.fecha).HasColumnName("fecha");
			});

			modelBuilder.Entity<usuariocrypto>(entity =>
			{
				entity.HasKey(e => new { e.idUsuario, e.idCrypto }).HasName("usuarioCrypto_pkey");
				entity.ToTable("usuarioCrypto");
				entity.Property(e => e.idUsuario).HasMaxLength(50).HasColumnName("IdUsuario");
				entity.Property(e => e.idCrypto).HasMaxLength(50).HasColumnName("IdCrypto");

				// Configurar la relación con la tabla usuario
				entity.HasOne(e => e.usuario)
					  .WithMany(u => u.CriptomonedasFavoritas)
					  .HasForeignKey(e => e.idUsuario)
					  .HasConstraintName("FK_UsuarioCrypto_Usuario");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}

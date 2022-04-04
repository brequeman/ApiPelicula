using System;
using System.Collections.Generic;
using AccesoBD.Models.BD;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AccesoBD.Models.BDContext
{
    public partial class bd_cinemaContext : DbContext
    {
        public bd_cinemaContext()
        {
        }

        public bd_cinemaContext(DbContextOptions<bd_cinemaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; } = null!;
        public virtual DbSet<Categoria> Categoria { get; set; } = null!;
        public virtual DbSet<Clasificacion> Clasificacions { get; set; } = null!;
        public virtual DbSet<Director> Directors { get; set; } = null!;
        public virtual DbSet<Pelicula> Peliculas { get; set; } = null!;
        public virtual DbSet<PeliculaActor> PeliculaActors { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=bd_cinema;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("Actor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Clasificacion>(entity =>
            {
                entity.ToTable("Clasificacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(10)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.ToTable("Director");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.ToTable("Pelicula");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Duracion).HasColumnName("duracion");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.IdClasificacion).HasColumnName("idClasificacion");

                entity.Property(e => e.IdDirector).HasColumnName("idDirector");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Sinopsis).HasColumnName("sinopsis");

                entity.HasOne(d => d.CategoriaNavigation)
                    .WithMany(p => p.Peliculas)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pelicula_Categoria");

                entity.HasOne(d => d.ClasificacionNavigation)
                    .WithMany(p => p.Peliculas)
                    .HasForeignKey(d => d.IdClasificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pelicula_Clasificacion");

                entity.HasOne(d => d.DirectorNavigation)
                    .WithMany(p => p.Peliculas)
                    .HasForeignKey(d => d.IdDirector)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pelicula_Director");
            });

            modelBuilder.Entity<PeliculaActor>(entity =>
            {
                entity.HasKey(e => new { e.IdActor, e.IdPelicula });

                entity.ToTable("PeliculaActor");

                entity.Property(e => e.IdActor).HasColumnName("idActor");

                entity.Property(e => e.IdPelicula).HasColumnName("idPelicula");

                entity.HasOne(d => d.ActorNavigation)
                    .WithMany(p => p.PeliculaActors)
                    .HasForeignKey(d => d.IdActor)
                    .HasConstraintName("FK_PeliculaActor_Actor");

                entity.HasOne(d => d.PeliculaNavigation)
                    .WithMany(p => p.PeliculaActors)
                    .HasForeignKey(d => d.IdPelicula)
                    .HasConstraintName("FK_PeliculaActor_Pelicula");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clave)
                    .HasMaxLength(50)
                    .HasColumnName("clave");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .HasColumnName("correo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIControlEstudiantil.Models
{
    public partial class ControlEstudiantilContext : DbContext
    {
        public ControlEstudiantilContext()
        {
        }

        public ControlEstudiantilContext(DbContextOptions<ControlEstudiantilContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asistencium> Asistencia { get; set; } = null!;
        public virtual DbSet<Calificacion> Calificacions { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asistencium>(entity =>
            {
                entity.Property(e => e.Estado)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.Estudiante)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.EstudianteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asistenci__Estud__403A8C7D");
            });

            modelBuilder.Entity<Calificacion>(entity =>
            {
                entity.ToTable("Calificacion");

                entity.HasIndex(e => e.EstudianteId, "UQ__Califica__6F7682D95D299F81")
                    .IsUnique();

                entity.HasOne(d => d.Estudiante)
                    .WithOne(p => p.Calificacion)
                    .HasForeignKey<Calificacion>(d => d.EstudianteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Calificac__Estud__3D5E1FD2");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.ToTable("Estudiante");

                entity.HasIndex(e => e.Matricula, "UQ__Estudian__0FB9FB4F0FD9AF42")
                    .IsUnique();

                entity.HasIndex(e => e.Telefono, "UQ__Estudian__4EC504800FF810F0")
                    .IsUnique();

                entity.HasIndex(e => e.Correo, "UQ__Estudian__60695A192FB6CC4C")
                    .IsUnique();

                entity.HasIndex(e => e.Cedula, "UQ__Estudian__B4ADFE3860E23756")
                    .IsUnique();

                entity.Property(e => e.Apellido)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Matricula)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

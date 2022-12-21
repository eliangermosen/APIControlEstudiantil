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

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS; Database=ControlEstudiantil; Trusted_Connection=True;");
//            }
//        }

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
                    .HasConstraintName("FK__Asistenci__Estud__5441852A");
            });

            modelBuilder.Entity<Calificacion>(entity =>
            {
                entity.ToTable("Calificacion");

                entity.HasOne(d => d.Estudiante)
                    .WithMany(p => p.Calificacions)
                    .HasForeignKey(d => d.EstudianteId)
                    .HasConstraintName("FK__Calificac__Estud__5165187F");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.ToTable("Estudiante");

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

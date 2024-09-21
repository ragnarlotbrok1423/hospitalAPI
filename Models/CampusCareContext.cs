using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace campusCareAPI.Models;

public partial class CampusCareContext : DbContext
{
    public CampusCareContext()
    {
    }

    public CampusCareContext(DbContextOptions<CampusCareContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CitasMedica> CitasMedicas { get; set; }

    public virtual DbSet<Doctores> Doctores { get; set; }

    public virtual DbSet<InformacionesMedica> InformacionesMedicas { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<TipajesSanguineo> TipajesSanguineos { get; set; }

    public virtual DbSet<TiposConsulta> TiposConsultas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=campus_care;uid=root;pwd=1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<CitasMedica>(entity =>
        {
            entity.HasKey(e => e.IdcitasMedicas).HasName("PRIMARY");

            entity.ToTable("citas_medicas");

            entity.HasIndex(e => e.Doctor, "doctor_fk_idx");

            entity.HasIndex(e => e.Servicio, "servicios_fk_idx");

            entity.HasIndex(e => e.TipoConsulta, "tipos_consultas_idx");

            entity.HasIndex(e => e.Paciente, "usuarios_fk_idx");

            entity.Property(e => e.IdcitasMedicas).HasColumnName("idcitas_medicas");
            entity.Property(e => e.Doctor).HasColumnName("doctor");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Paciente).HasColumnName("paciente");
            entity.Property(e => e.Servicio).HasColumnName("servicio");
            entity.Property(e => e.TipoConsulta).HasColumnName("tipoConsulta");
            entity.Property(e => e.Visible).HasColumnName("visible");

            entity.HasOne(d => d.DoctorNavigation).WithMany(p => p.CitasMedicas)
                .HasForeignKey(d => d.Doctor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("doctor_fk");

            entity.HasOne(d => d.PacienteNavigation).WithMany(p => p.CitasMedicas)
                .HasForeignKey(d => d.Paciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuarios_fk");

            entity.HasOne(d => d.ServicioNavigation).WithMany(p => p.CitasMedicas)
                .HasForeignKey(d => d.Servicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("servicios_fk");

            entity.HasOne(d => d.TipoConsultaNavigation).WithMany(p => p.CitasMedicas)
                .HasForeignKey(d => d.TipoConsulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tipos_consultas_fk");
        });

        modelBuilder.Entity<Doctores>(entity =>
        {
            entity.HasKey(e => e.IdDoctores).HasName("PRIMARY");

            entity.ToTable("doctores");

            entity.HasIndex(e => e.InformacionMedica, "infoMedica_fk_idx");

            entity.Property(e => e.IdDoctores).HasColumnName("idDoctores");
            entity.Property(e => e.Cedula)
                .HasMaxLength(45)
                .HasColumnName("cedula");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(45)
                .HasColumnName("contraseña");
            entity.Property(e => e.Diploma).HasColumnName("diploma");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(45)
                .HasColumnName("especialidad");
            entity.Property(e => e.InformacionMedica).HasColumnName("informacion_medica");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(45)
                .HasColumnName("nombreCompleto");
            entity.Property(e => e.Perfil).HasColumnName("perfil");

            entity.HasOne(d => d.InformacionMedicaNavigation).WithMany(p => p.Doctores)
                .HasForeignKey(d => d.InformacionMedica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("infoMedica_fk");
        });

        modelBuilder.Entity<InformacionesMedica>(entity =>
        {
            entity.HasKey(e => e.IdinformacionesMedicas).HasName("PRIMARY");

            entity.ToTable("informaciones_medicas");

            entity.HasIndex(e => e.Tipaje, "tipaje_fk_idx");

            entity.Property(e => e.IdinformacionesMedicas).HasColumnName("idinformaciones_medicas");
            entity.Property(e => e.Alergia)
                .HasColumnType("text")
                .HasColumnName("alergia");
            entity.Property(e => e.NumeroSecundario)
                .HasMaxLength(45)
                .HasColumnName("numero_secundario");
            entity.Property(e => e.Tipaje).HasColumnName("tipaje");

            entity.HasOne(d => d.TipajeNavigation).WithMany(p => p.InformacionesMedicas)
                .HasForeignKey(d => d.Tipaje)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tipaje_fk");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdUsuarios).HasName("PRIMARY");

            entity.ToTable("pacientes");

            entity.HasIndex(e => e.InformacionMedica, "informacion_medica_fk_idx");

            entity.Property(e => e.IdUsuarios).HasColumnName("idUsuarios");
            entity.Property(e => e.Apellido)
                .HasMaxLength(30)
                .HasColumnName("apellido");
            entity.Property(e => e.Cedula)
                .HasMaxLength(10)
                .HasColumnName("cedula");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(45)
                .HasColumnName("contraseña");
            entity.Property(e => e.InformacionMedica).HasColumnName("informacion_medica");
            entity.Property(e => e.Nombre)
                .HasMaxLength(10)
                .HasColumnName("nombre");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(45)
                .HasColumnName("nombreUsuario");
            entity.Property(e => e.Visible).HasColumnName("visible");

            entity.HasOne(d => d.InformacionMedicaNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.InformacionMedica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("informacion_medica_fk");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.Idservicios).HasName("PRIMARY");

            entity.ToTable("servicios");

            entity.Property(e => e.Idservicios).HasColumnName("idservicios");
            entity.Property(e => e.CertificadoBuenaSalud).HasColumnName("certificado_buena_Salud");
            entity.Property(e => e.GlisemiaCapilar).HasColumnName("glisemia_capilar");
            entity.Property(e => e.Inhaloterapias).HasColumnName("inhaloterapias");
            entity.Property(e => e.Inyecciones)
                .HasMaxLength(45)
                .HasColumnName("inyecciones");
            entity.Property(e => e.Peso).HasColumnName("peso");
            entity.Property(e => e.ReferenciaMedica)
                .HasColumnType("text")
                .HasColumnName("referencia_medica");
        });

        modelBuilder.Entity<TipajesSanguineo>(entity =>
        {
            entity.HasKey(e => e.IdtipajesSanguineos).HasName("PRIMARY");

            entity.ToTable("tipajes_sanguineos");

            entity.Property(e => e.IdtipajesSanguineos)
                .ValueGeneratedNever()
                .HasColumnName("idtipajes_sanguineos");
            entity.Property(e => e.TipoSanguineo)
                .HasMaxLength(3)
                .HasColumnName("tipo_sanguineo");
        });

        modelBuilder.Entity<TiposConsulta>(entity =>
        {
            entity.HasKey(e => e.IdtiposConsultas).HasName("PRIMARY");

            entity.ToTable("tipos_consultas");

            entity.Property(e => e.IdtiposConsultas).HasColumnName("idtipos_consultas");
            entity.Property(e => e.TipoConsulta)
                .HasMaxLength(45)
                .HasColumnName("tipo_consulta");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

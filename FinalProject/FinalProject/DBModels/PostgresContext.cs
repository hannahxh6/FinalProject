using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.DBModels;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Professor> Professors { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=127.0.0.1; Port=5432; Database=postgres; Username=postgres; Password=postgresql");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("professor_pkey");

            entity.ToTable("professor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Fname)
                .HasMaxLength(20)
                .HasColumnName("fname");
            entity.Property(e => e.Lname)
                .HasMaxLength(20)
                .HasColumnName("lname");
            entity.Property(e => e.Password)
                .HasMaxLength(90)
                .HasColumnName("password");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(15)
                .HasColumnName("subject_name");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("results_pkey");

            entity.ToTable("results");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProfId)
                .HasMaxLength(10)
                .HasColumnName("prof_id");
            entity.Property(e => e.Score)
                .HasMaxLength(10)
                .HasColumnName("score");
            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .HasColumnName("student_id");
            entity.Property(e => e.TestType)
                .HasMaxLength(10)
                .HasColumnName("test_type");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("student_pkey");

            entity.ToTable("student");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Fname)
                .HasMaxLength(20)
                .HasColumnName("fname");
            entity.Property(e => e.Lname)
                .HasMaxLength(30)
                .HasColumnName("lname");
            entity.Property(e => e.NrAme)
                .HasMaxLength(30)
                .HasColumnName("nr_ame");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoExz;

public partial class DbTechnoserviceContext : DbContext
{
    public DbTechnoserviceContext()
    {
    }

    public DbTechnoserviceContext(DbContextOptions<DbTechnoserviceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<TypeFault> TypeFaults { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=1234;database=db_technoservice", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Idapplication).HasName("PRIMARY");

            entity.ToTable("application");

            entity.HasIndex(e => e.Equipment, "fk_equipment_idx");

            entity.HasIndex(e => e.Executor, "fk_executor_idx");

            entity.HasIndex(e => e.TypeFault, "fk_fault_idx");

            entity.Property(e => e.Idapplication)
                .ValueGeneratedNever()
                .HasColumnName("idapplication");
            entity.Property(e => e.Client)
                .HasMaxLength(45)
                .HasColumnName("client");
            entity.Property(e => e.Comment)
                .HasColumnType("text")
                .HasColumnName("comment");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.DateAddition).HasColumnName("date_addition");
            entity.Property(e => e.DateCompletion).HasColumnName("date_completion");
            entity.Property(e => e.DescriptionProblem)
                .HasColumnType("text")
                .HasColumnName("description_problem");
            entity.Property(e => e.Equipment).HasColumnName("equipment");
            entity.Property(e => e.EquipmentName)
                .HasMaxLength(45)
                .HasColumnName("equipment_name");
            entity.Property(e => e.EquipmentNumber)
                .HasMaxLength(30)
                .HasColumnName("equipment_number");
            entity.Property(e => e.ExecutionTime)
                .HasColumnType("time")
                .HasColumnName("execution_time");
            entity.Property(e => e.Executor).HasColumnName("executor");
            entity.Property(e => e.Status)
                .HasMaxLength(45)
                .HasColumnName("status");
            entity.Property(e => e.TypeFault).HasColumnName("type_fault");

            entity.HasOne(d => d.EquipmentNavigation).WithMany(p => p.Applications)
                .HasForeignKey(d => d.Equipment)
                .HasConstraintName("fk_equipment");

            entity.HasOne(d => d.ExecutorNavigation).WithMany(p => p.Applications)
                .HasForeignKey(d => d.Executor)
                .HasConstraintName("fk_executor");

            entity.HasOne(d => d.TypeFaultNavigation).WithMany(p => p.Applications)
                .HasForeignKey(d => d.TypeFault)
                .HasConstraintName("fk_fault");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Idequipment).HasName("PRIMARY");

            entity.ToTable("equipment");

            entity.Property(e => e.Idequipment)
                .ValueGeneratedNever()
                .HasColumnName("idequipment");
            entity.Property(e => e.Title)
                .HasMaxLength(45)
                .HasColumnName("title");
        });

        modelBuilder.Entity<TypeFault>(entity =>
        {
            entity.HasKey(e => e.IdtypeFault).HasName("PRIMARY");

            entity.ToTable("type_fault");

            entity.Property(e => e.IdtypeFault)
                .ValueGeneratedNever()
                .HasColumnName("idtype_fault");
            entity.Property(e => e.Title)
                .HasMaxLength(45)
                .HasColumnName("title");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Iduser).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.Iduser)
                .ValueGeneratedNever()
                .HasColumnName("iduser");
            entity.Property(e => e.Login)
                .HasMaxLength(45)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(45)
                .HasColumnName("patronymic");
            entity.Property(e => e.Role)
                .HasMaxLength(45)
                .HasColumnName("role");
            entity.Property(e => e.Surname)
                .HasMaxLength(45)
                .HasColumnName("surname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

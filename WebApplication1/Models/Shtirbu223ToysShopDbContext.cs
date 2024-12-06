using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class Shtirbu223ToysShopDbContext : DbContext
{
    public Shtirbu223ToysShopDbContext()
    {
    }

    public Shtirbu223ToysShopDbContext(DbContextOptions<Shtirbu223ToysShopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Curator> Curators { get; set; }

    public virtual DbSet<ItEnglish> ItEnglishes { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=83.147.246.87;Port=5432;Database=shtirbu_223_toys_shop_db;Username=shtirbu_223_toys_shop;Password=12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Idcourses).HasName("courses_pkey");

            entity.ToTable("courses");

            entity.HasIndex(e => e.Idmanager, "courses_pk").IsUnique();

            entity.Property(e => e.Idcourses)
                .ValueGeneratedNever()
                .HasColumnName("idcourses");
            entity.Property(e => e.Idmanager).HasColumnName("idmanager");
            entity.Property(e => e.Idteacher).HasColumnName("idteacher");

            entity.HasOne(d => d.IdcoursesNavigation).WithOne(p => p.Course)
                .HasPrincipalKey<ItEnglish>(p => p.IdCourses)
                .HasForeignKey<Course>(d => d.Idcourses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("courses_it-english_idCourses _fk");
        });

        modelBuilder.Entity<Curator>(entity =>
        {
            entity.HasKey(e => e.Idcurator).HasName("curator_pk");

            entity.ToTable("curator");

            entity.HasIndex(e => e.Iduser, "curator_pk_2").IsUnique();

            entity.Property(e => e.Idcurator)
                .ValueGeneratedNever()
                .HasColumnName("idcurator ");
            entity.Property(e => e.Iduser).HasColumnName("iduser");
            entity.Property(e => e.Paymentuser).HasColumnName("paymentuser");
            entity.Property(e => e.Visiruser).HasColumnName("visiruser");

            entity.HasOne(d => d.IdcuratorNavigation).WithOne(p => p.Curator)
                .HasForeignKey<Curator>(d => d.Idcurator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("curator_it-english_idcurator_fk");
        });

        modelBuilder.Entity<ItEnglish>(entity =>
        {
            entity.HasKey(e => e.Idcurator).HasName("it-english_pkey");

            entity.ToTable("it-english");

            entity.HasIndex(e => e.Iduser, "it-english_pk").IsUnique();

            entity.HasIndex(e => e.Idteacher, "it-english_pk_2").IsUnique();

            entity.HasIndex(e => e.Idmanager, "it-english_pk_3").IsUnique();

            entity.HasIndex(e => e.IdCourses, "it-english_pk_4").IsUnique();

            entity.Property(e => e.Idcurator)
                .ValueGeneratedNever()
                .HasColumnName("idcurator");
            entity.Property(e => e.IdCourses).HasColumnName("idCourses ");
            entity.Property(e => e.Idmanager).HasColumnName("idmanager");
            entity.Property(e => e.Idteacher).HasColumnName("idteacher");
            entity.Property(e => e.Iduser).HasColumnName("iduser");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.Idmanager).HasName("manager_pk_2");

            entity.ToTable("manager");

            entity.HasIndex(e => e.Iduser, "manager_pk").IsUnique();

            entity.Property(e => e.Idmanager)
                .ValueGeneratedNever()
                .HasColumnName("idmanager");
            entity.Property(e => e.Iduser).HasColumnName("iduser");

            entity.HasOne(d => d.IdmanagerNavigation).WithOne(p => p.Manager)
                .HasPrincipalKey<Course>(p => p.Idmanager)
                .HasForeignKey<Manager>(d => d.Idmanager)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("manager_courses_idmanager_fk");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Idteacher).HasName("teacher_pk");

            entity.ToTable("teacher");

            entity.Property(e => e.Idteacher)
                .ValueGeneratedNever()
                .HasColumnName("idteacher");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Diplomas)
                .HasMaxLength(50)
                .HasColumnName("diplomas");
            entity.Property(e => e.Idcourses).HasColumnName("idcourses");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Workexperience).HasColumnName("workexperience");

            entity.HasOne(d => d.IdteacherNavigation).WithOne(p => p.Teacher)
                .HasForeignKey<Teacher>(d => d.Idteacher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("teacher_courses_idcourses_fk");

            entity.HasOne(d => d.Idteacher1).WithOne(p => p.Teacher)
                .HasPrincipalKey<ItEnglish>(p => p.Idteacher)
                .HasForeignKey<Teacher>(d => d.Idteacher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("teacher_it-english_idteacher_fk");

            entity.HasOne(d => d.Idteacher2).WithOne(p => p.Teacher)
                .HasForeignKey<Teacher>(d => d.Idteacher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("teacher_user_iduser_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Iduser).HasName("user_pk");

            entity.ToTable("User");

            entity.Property(e => e.Iduser)
                .ValueGeneratedNever()
                .HasColumnName("iduser");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.EMail)
                .HasMaxLength(70)
                .HasColumnName("e-mail");
            entity.Property(e => e.Idteacher).HasColumnName("idteacher");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(15)
                .HasColumnName("password");
            entity.Property(e => e.Surname)
                .HasMaxLength(35)
                .HasColumnName("surname");

            entity.HasOne(d => d.IduserNavigation).WithOne(p => p.User)
                .HasPrincipalKey<Curator>(p => p.Iduser)
                .HasForeignKey<User>(d => d.Iduser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_curator_iduser_fk");

            entity.HasOne(d => d.Iduser1).WithOne(p => p.User)
                .HasPrincipalKey<ItEnglish>(p => p.Iduser)
                .HasForeignKey<User>(d => d.Iduser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("User_it-english_iduser_fk");

            entity.HasOne(d => d.Iduser2).WithOne(p => p.User)
                .HasPrincipalKey<Manager>(p => p.Iduser)
                .HasForeignKey<User>(d => d.Iduser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_manager_iduser_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

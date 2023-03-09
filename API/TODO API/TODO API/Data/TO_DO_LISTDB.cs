using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TODO_API.Data.Models;

namespace TODO_API.Data;

public partial class TO_DO_LISTDB : DbContext
{
    public TO_DO_LISTDB()
    {
    }

    public TO_DO_LISTDB(DbContextOptions<TO_DO_LISTDB> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorias> Categorias { get; set; }

    public virtual DbSet<Tareas> Tareas { get; set; }

    public virtual DbSet<TareasCompletadas> TareasCompletadas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=TO_DO_LISTDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.CategoriasId).HasName("PK__Categori__A68E1ECA78403C94");

            entity.Property(e => e.CategoriasId).HasColumnName("CategoriasID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tareas>(entity =>
        {
            entity.HasKey(e => e.Descripcion).HasName("PK__Tareas__92C53B6D4C92853F");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CategoriasId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CategoriasID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Categorias).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.CategoriasId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CategoriasID_FK");
        });

        modelBuilder.Entity<TareasCompletadas>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tareas_Completadas");

            entity.Property(e => e.CategoriasId).HasColumnName("CategoriasID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaCompletada)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Completada");

            entity.HasOne(d => d.Categorias).WithMany()
                .HasForeignKey(d => d.CategoriasId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Tareas_Completadas_CategoriasID_FK");

            entity.HasOne(d => d.DescripcionNavigation).WithMany()
                .HasForeignKey(d => d.Descripcion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Descripcion_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

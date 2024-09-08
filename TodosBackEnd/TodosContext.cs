using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TodosBackEnd.Entities;

namespace TodosBackEnd;

public partial class TodosContext : DbContext
{
    public TodosContext()
    {
    }

    public TodosContext(DbContextOptions<TodosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=LAPTOP-4EB8UC8S\\SQLEXPRESS;Database= todos;UID=sa;PWD=12345;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TodoItem__3213E83F9CADAEAD");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsComplete).HasDefaultValue(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

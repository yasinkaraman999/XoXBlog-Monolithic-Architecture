using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace XoXBlogMono.DBModels;

public partial class YasinkaNarchContext : DbContext
{
    public YasinkaNarchContext()
    {
    }

    public YasinkaNarchContext(DbContextOptions<YasinkaNarchContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
        if (!optionsBuilder.IsConfigured)
        {
            // fallback configuration if needed
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_turkish_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Order).HasColumnType("int(11)");
            entity.Property(e => e.Status).HasColumnType("tinyint(4)");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CategoryId, "CategoryId");

            entity.HasIndex(e => e.OwnerId, "OwnerId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.BannerImage).HasMaxLength(250);
            entity.Property(e => e.CategoryId).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Keywords).HasMaxLength(1000);
            entity.Property(e => e.Order).HasColumnType("int(11)");
            entity.Property(e => e.OwnerId).HasColumnType("int(11)");
            entity.Property(e => e.Status).HasColumnType("tinyint(11)");
            entity.Property(e => e.Text).HasColumnType("text");
            entity.Property(e => e.Title).HasMaxLength(500);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.Posts)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Posts_ibfk_2");

            entity.HasOne(d => d.Owner).WithMany(p => p.Posts)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Posts_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.NameSurname).HasMaxLength(200);
            entity.Property(e => e.Password).HasMaxLength(200);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

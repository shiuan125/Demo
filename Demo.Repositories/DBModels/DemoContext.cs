using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories.DBModels;

public partial class DemoContext : DbContext
{
    public DemoContext()
    {
    }

    public DemoContext(DbContextOptions<DemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ogimage> Ogimages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ogimage>(entity =>
        {
            entity.ToTable("OGImage");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Ext)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LocalExt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Local Ext");
            entity.Property(e => e.LocalMirrorFile).HasColumnName("Local Mirror File");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

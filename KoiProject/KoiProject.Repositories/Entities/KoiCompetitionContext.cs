using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoiProject.Repositories.Entities;

public partial class KoiCompetitionContext : DbContext
{
    public KoiCompetitionContext()
    {
    }

    public KoiCompetitionContext(DbContextOptions<KoiCompetitionContext> options)
        : base(options)
    {
    }
    public DbSet<Ranking> Rankings { get; set; }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Đoạn mã này có thể xóa hoặc bình luận
            // => optionsBuilder.UseSqlServer("Data Source=DESKTOP-D3GEO91\\NTOANSQL;Initial Catalog=KoiCompetition;Persist Security Info=True;User ID=sa;Password=123456789;MultipleActiveResultSets=True;TrustServerCertificate=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370FC19E26D1");

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E6164EB598A49").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

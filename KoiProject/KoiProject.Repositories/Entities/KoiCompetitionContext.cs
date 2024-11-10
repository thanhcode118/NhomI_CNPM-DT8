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

    public virtual DbSet<KoiManagement> KoiManagements { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-D3GEO91\\NTOANSQL;Initial Catalog=KoiCompetition;Persist Security Info=True;User ID=sa;Password=123456789;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KoiManagement>(entity =>
        {
            entity.HasKey(e => e.KoiId).HasName("PK__KoiManag__E03435B84C3B6298");

            entity.ToTable("KoiManagement");

            entity.Property(e => e.KoiId).HasColumnName("KoiID");
            entity.Property(e => e.Breed).HasMaxLength(50);
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.Gpa)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("GPA");
            entity.Property(e => e.HealthStatus).HasMaxLength(50);
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Origin).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Size).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(255)
                .HasColumnName("user_email");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.KoiManagementIdUserNavigations)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_KoiManagement_Users");

            entity.HasOne(d => d.UserEmailNavigation).WithMany(p => p.KoiManagementUserEmailNavigations)
                .HasPrincipalKey(p => p.Email)
                .HasForeignKey(d => d.UserEmail)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KoiManage__user___239E4DCF");
        });

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

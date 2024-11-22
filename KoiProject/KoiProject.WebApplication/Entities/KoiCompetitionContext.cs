using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoiProject.WebApplication.Entities;

public partial class KoiCompetitionContext : DbContext
{
    public KoiCompetitionContext()
    {
    }

    public KoiCompetitionContext(DbContextOptions<KoiCompetitionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<KoiCheckIn> KoiCheckIns { get; set; }

    public virtual DbSet<KoiManagement> KoiManagements { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vote> Votes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-OPC7O76\\SQLEXPRESS01; DataBase=KoiCompetition;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KoiCheckIn>(entity =>
        {
            entity.HasKey(e => e.CheckInId).HasName("PK__KoiCheck__E64976A447F8AEFC");

            entity.ToTable("KoiCheckIn");

            entity.Property(e => e.CheckInId).HasColumnName("CheckInID");
            entity.Property(e => e.CheckInTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.HealthStatus).HasMaxLength(50);
            entity.Property(e => e.KoiId).HasColumnName("KoiID");
            entity.Property(e => e.Notes).HasMaxLength(255);

            entity.HasOne(d => d.Koi).WithMany(p => p.KoiCheckIns)
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("FK__KoiCheckI__KoiID__6477ECF3");
        });

        modelBuilder.Entity<KoiManagement>(entity =>
        {
            entity.HasKey(e => e.KoiId).HasName("PK__KoiManag__E03435B820750C38");

            entity.ToTable("KoiManagement");

            entity.Property(e => e.KoiId).HasColumnName("KoiID");
            entity.Property(e => e.Breed).HasMaxLength(50);
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.ContestCategory).HasMaxLength(100);
            entity.Property(e => e.ContestStatus)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");
            entity.Property(e => e.DateOfEntry).HasDefaultValueSql("(getdate())");
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
                .HasConstraintName("FK_UserID");

            entity.HasOne(d => d.UserEmailNavigation).WithMany(p => p.KoiManagementUserEmailNavigations)
                .HasPrincipalKey(p => p.Email)
                .HasForeignKey(d => d.UserEmail)
                .HasConstraintName("FK_UserEmail");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370F5D84AB02");

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E6164D3D46F21").IsUnique();

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

        modelBuilder.Entity<Vote>(entity =>
        {
            entity.HasKey(e => e.VoteId).HasName("PK__Votes__52F015E262B9DAF0");

            entity.Property(e => e.VoteId).HasColumnName("VoteID");
            entity.Property(e => e.KoiId).HasColumnName("KoiID");
            entity.Property(e => e.VoteDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.VoterEmail).HasMaxLength(255);

            entity.HasOne(d => d.Koi).WithMany(p => p.Votes)
                .HasForeignKey(d => d.KoiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Votes__KoiID__5CD6CB2B");

            entity.HasOne(d => d.VoterEmailNavigation).WithMany(p => p.Votes)
                .HasPrincipalKey(p => p.Email)
                .HasForeignKey(d => d.VoterEmail)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Votes__VoterEmai__5DCAEF64");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

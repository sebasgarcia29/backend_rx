using Microsoft.EntityFrameworkCore;

namespace Rxlightning.WebApi.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("UserInfo");
                entity.Property(e => e.userId).HasColumnName("userId");
                entity.Property(e => e.displayName).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.userName).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.email).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.password).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.createdDate).IsUnicode(false);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patients");
                entity.HasKey(e => e.patientId);
                //entity.Property(e => e.patiendId).HasColumnName("patiendId");
                entity.Property(e => e.firstName).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.lastName).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.gender).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.dateOfBirth).IsUnicode(false);
                entity.Property(e => e.addressLine1).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.addressLine2).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.city).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.state).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.postalCode).HasMaxLength(20).IsUnicode(false);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
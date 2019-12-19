using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PlanC.Client.Pages.Identity.Pages.Models
{
    public partial class SecretContext : DbContext
    {
        public SecretContext()
        {
        }

        public SecretContext(DbContextOptions<SecretContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<RolesSecretKeys> RolesSecretKeys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=database-1.cai5lbxs9ofy.us-east-1.rds.amazonaws.com,1433;User ID=dbo802668235;Password=Nemesis2123%*;Initial Catalog=PCU001;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");
            });


            modelBuilder.Entity<RolesSecretKeys>(entity =>
            {
                entity.Property(e => e.Key).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateGenerated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolesSecretKeys)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_RolesSecretKeys_AspNetRoles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

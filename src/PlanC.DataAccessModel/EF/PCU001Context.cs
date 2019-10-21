using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PlanC.DataAccessModel.Records;

namespace PlanC.EF
{
    public partial class PCU001Context : DbContext
    {
        public PCU001Context()
        {
        }

        public PCU001Context(DbContextOptions<PCU001Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CourseTemplateRecord> CourseTemplates { get; set; }
        public virtual DbSet<SkillRecord> Skills { get; set; }
        public virtual DbSet<SkillElementRecord> SkillElements { get; set; }

        // Unable to generate entity type for table 'dbo.TSKLTMPLT'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=localhost; Database=PCU001; User Id=sa; Password=sql");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<CourseTemplateRecord>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("TCRS_TMPLT_PK");

                entity.ToTable("TCRS_TMPLT");

                entity.Property(e => e.Id)
                    .HasColumnName("CRS_ID")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.BoardApprovalDate)
                    .HasColumnName("BOARD_APPROVL_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.ComiteeApprovalDate)
                    .HasColumnName("CMTE_APPRVL_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("CRS_DESC")
                    .HasColumnType("ntext");

                entity.Property(e => e.Title)
                    .HasColumnName("CRS_TITLE")
                    .HasMaxLength(50);

                entity.Property(e => e.DepartmentId).HasColumnName("DPTMNT_ID");

                entity.Property(e => e.DepartmentApprovalDate)
                    .HasColumnName("DPTMT_APPRVL_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Intent)
                    .HasColumnName("INTENT")
                    .HasColumnType("ntext");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("RECORD_CDTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRACKING_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Units)
                    .HasColumnName("UNITS")
                    .HasColumnType("decimal(3, 2)");
            });

            modelBuilder.Entity<SkillRecord>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("TSKL_PK");

                entity.ToTable("TSKL");

                entity.Property(e => e.Id)
                    .HasColumnName("SKL_ID")
                    .HasMaxLength(4)
                    .ValueGeneratedNever();

                entity.Property(e => e.Attd)
                    .HasColumnName("ATTD")
                    .HasColumnType("ntext");

                entity.Property(e => e.Timestamp)
                    .HasColumnName("RECORD_CDTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasColumnName("SKL_TITLE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRACKING_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SkillElementRecord>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SklElemSqnbr })
                    .HasName("TSKLELEM_PK");

                entity.ToTable("TSKLELEM");

                entity.Property(e => e.Id)
                    .HasColumnName("SKL_ID")
                    .HasMaxLength(4);

                entity.Property(e => e.SklElemSqnbr).HasColumnName("SKL_ELEM_SQNBR");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("RECORD_CDTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("SKL_ELEM_DESC")
                    .HasColumnType("ntext");

                entity.Property(e => e.Title)
                    .HasColumnName("SKL_ELEM_TITLE")
                    .HasMaxLength(50);

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRACKING_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Skl)
                    .WithMany(p => p.Tsklelem)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TSKLELEM__TSKL_FK");
            });
        }
    }
}

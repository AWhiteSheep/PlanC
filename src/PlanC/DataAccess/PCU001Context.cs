using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PlanC.DataAccess
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

        public virtual DbSet<TcrsTmplt> TcrsTmplt { get; set; }
        public virtual DbSet<Tskl> Tskl { get; set; }
        public virtual DbSet<Tsklelem> Tsklelem { get; set; }
        public virtual DbSet<Tskltmplt> Tskltmplt { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=LocalTest");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<TcrsTmplt>(entity =>
            {
                entity.HasKey(e => e.CrsId)
                    .HasName("TCRS_TMPLT_PK");

                entity.ToTable("TCRS_TMPLT");

                entity.Property(e => e.CrsId)
                    .HasColumnName("CRS_ID")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.BoardApprovlDt)
                    .HasColumnName("BOARD_APPROVL_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CmteApprvlDt)
                    .HasColumnName("CMTE_APPRVL_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.CrsDesc)
                    .HasColumnName("CRS_DESC")
                    .HasColumnType("ntext");

                entity.Property(e => e.CrsTitle)
                    .HasColumnName("CRS_TITLE")
                    .HasMaxLength(50);

                entity.Property(e => e.DptmntId).HasColumnName("DPTMNT_ID");

                entity.Property(e => e.DptmtApprvlDt)
                    .HasColumnName("DPTMT_APPRVL_DT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Intent)
                    .HasColumnName("INTENT")
                    .HasColumnType("ntext");

                entity.Property(e => e.RecordCdttm)
                    .HasColumnName("RECORD_CDTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.TrackingUid)
                    .HasColumnName("TRACKING_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Units)
                    .HasColumnName("UNITS")
                    .HasColumnType("decimal(3, 2)");
            });

            modelBuilder.Entity<Tskl>(entity =>
            {
                entity.HasKey(e => e.SklId)
                    .HasName("TSKL_PK");

                entity.ToTable("TSKL");

                entity.Property(e => e.SklId)
                    .HasColumnName("SKL_ID")
                    .HasMaxLength(4)
                    .ValueGeneratedNever();

                entity.Property(e => e.Attd)
                    .HasColumnName("ATTD")
                    .HasColumnType("ntext");

                entity.Property(e => e.RecordCdttm)
                    .HasColumnName("RECORD_CDTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.SklTitle)
                    .HasColumnName("SKL_TITLE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TrackingUid)
                    .HasColumnName("TRACKING_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tsklelem>(entity =>
            {
                entity.HasKey(e => new { e.SklId, e.SklElemSqnbr })
                    .HasName("TSKLELEM_PK");

                entity.ToTable("TSKLELEM");

                entity.Property(e => e.SklId)
                    .HasColumnName("SKL_ID")
                    .HasMaxLength(4);

                entity.Property(e => e.SklElemSqnbr).HasColumnName("SKL_ELEM_SQNBR");

                entity.Property(e => e.RecordCdttm)
                    .HasColumnName("RECORD_CDTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.SklElemDesc)
                    .HasColumnName("SKL_ELEM_DESC")
                    .HasColumnType("ntext");

                entity.Property(e => e.SklElemTitle)
                    .HasColumnName("SKL_ELEM_TITLE")
                    .HasMaxLength(50);

                entity.Property(e => e.TrackingUid)
                    .HasColumnName("TRACKING_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Skl)
                    .WithMany(p => p.Tsklelem)
                    .HasForeignKey(d => d.SklId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TSKLELEM__TSKL_FK");
            });

            modelBuilder.Entity<Tskltmplt>(entity =>
            {
                entity.HasKey(e => new { e.CrsId, e.SklId, e.SklElemSqnbr })
                    .HasName("TSKLTMPLT_PK");

                entity.ToTable("TSKLTMPLT");

                entity.Property(e => e.CrsId)
                    .HasColumnName("CRS_ID")
                    .HasMaxLength(10);

                entity.Property(e => e.SklId)
                    .HasColumnName("SKL_ID")
                    .HasMaxLength(4);

                entity.Property(e => e.SklElemSqnbr).HasColumnName("SKL_ELEM_SQNBR");

                entity.HasOne(d => d.Crs)
                    .WithMany(p => p.Tskltmplt)
                    .HasForeignKey(d => d.CrsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TSKLTMPLT_TCRS_TMPLT_FK");

                entity.HasOne(d => d.Skl)
                    .WithMany(p => p.Tskltmplt)
                    .HasForeignKey(d => new { d.SklId, d.SklElemSqnbr })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TSKLTMPLT_TSKLELEM_FK");
            });
        }
    }
}

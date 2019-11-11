using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PlanC.Web.Client.Models2
{
    public partial class PCU001Context2 : DbContext
    {
        public PCU001Context2()
        {
        }

        public PCU001Context2(DbContextOptions<PCU001Context2> options)
            : base(options)
        {
        }

        public virtual DbSet<Tactelem> Tactelem { get; set; }
        public virtual DbSet<Tcd> Tcd { get; set; }
        public virtual DbSet<Tcdty> Tcdty { get; set; }
        public virtual DbSet<Tcertexam> Tcertexam { get; set; }
        public virtual DbSet<Tcrsactvt> Tcrsactvt { get; set; }
        public virtual DbSet<Tcrsmtrl> Tcrsmtrl { get; set; }
        public virtual DbSet<Tcrspln> Tcrspln { get; set; }
        public virtual DbSet<Tcrsreq> Tcrsreq { get; set; }
        public virtual DbSet<Tcrssklelem> Tcrssklelem { get; set; }
        public virtual DbSet<Tcrstmplt> Tcrstmplt { get; set; }
        public virtual DbSet<Tdptmnt> Tdptmnt { get; set; }
        public virtual DbSet<Texam> Texam { get; set; }
        public virtual DbSet<Texamsklelem> Texamsklelem { get; set; }
        public virtual DbSet<Tfnlexam> Tfnlexam { get; set; }
        public virtual DbSet<Tpgm> Tpgm { get; set; }
        public virtual DbSet<Trole> Trole { get; set; }
        public virtual DbSet<Tskl> Tskl { get; set; }
        public virtual DbSet<Tsklcntxt> Tsklcntxt { get; set; }
        public virtual DbSet<Tsklelem> Tsklelem { get; set; }
        public virtual DbSet<Tsklelemcrt> Tsklelemcrt { get; set; }
        public virtual DbSet<Tsmstr> Tsmstr { get; set; }
        public virtual DbSet<Tuser> Tuser { get; set; }
        public virtual DbSet<Tuseravl> Tuseravl { get; set; }
        public virtual DbSet<Tuserrole> Tuserrole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=database-1.cai5lbxs9ofy.us-east-1.rds.amazonaws.com,1433;Initial Catalog=PCU001;User ID=dbo802668235;Password=Nemesis2123%*;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tactelem>(entity =>
            {
                entity.HasKey(e => new { e.SklelemSqnbr, e.SklId, e.CrsId, e.TchrUid, e.PlnVsnCdttm, e.SmstrId, e.ActvtSqnbr });

                entity.ToTable("TACTELEM");

                entity.HasComment("Association activité -- élément de compétence");

                entity.Property(e => e.SklelemSqnbr).HasColumnName("SKLELEM_SQNBR");

                entity.Property(e => e.SklId)
                    .HasColumnName("SKL_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CrsId)
                    .HasColumnName("CRS_ID")
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.TchrUid)
                    .HasColumnName("TCHR_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.PlnVsnCdttm)
                    .HasColumnName("PLN_VSN_CDTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.SmstrId)
                    .HasColumnName("SMSTR_ID")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ActvtSqnbr).HasColumnName("ACTVT_SQNBR");

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Skl)
                    .WithMany(p => p.Tactelem)
                    .HasForeignKey(d => new { d.SklId, d.SklelemSqnbr })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TACTELEM_TSKLELEM");

                entity.HasOne(d => d.Tcrsactvt)
                    .WithMany(p => p.Tactelem)
                    .HasForeignKey(d => new { d.CrsId, d.TchrUid, d.PlnVsnCdttm, d.SmstrId, d.ActvtSqnbr })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TACTELEM_TCRSACTVT");
            });

            modelBuilder.Entity<Tcd>(entity =>
            {
                entity.HasKey(e => new { e.CdTy, e.Cd });

                entity.ToTable("TCD");

                entity.Property(e => e.CdTy)
                    .HasColumnName("CD_TY")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cd)
                    .HasColumnName("CD")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CdDesc)
                    .HasColumnName("CD_DESC")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.TrkUid)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.CdTyNavigation)
                    .WithMany(p => p.Tcd)
                    .HasForeignKey(d => d.CdTy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCD_TCDTY");
            });

            modelBuilder.Entity<Tcdty>(entity =>
            {
                entity.HasKey(e => e.CdTy);

                entity.ToTable("TCDTY");

                entity.Property(e => e.CdTy)
                    .HasColumnName("CD_TY")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CdTyDesc)
                    .HasColumnName("CD_TY_DESC")
                    .HasMaxLength(250);

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.TrkUid)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tcertexam>(entity =>
            {
                entity.HasKey(e => new { e.CrsId, e.TchrUid, e.PlnVsnCdttm, e.SmstrId, e.ExamId });

                entity.ToTable("TCERTEXAM");

                entity.HasComment("Examen certificatif");

                entity.Property(e => e.CrsId)
                    .HasColumnName("CRS_ID")
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.TchrUid)
                    .HasColumnName("TCHR_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.PlnVsnCdttm)
                    .HasColumnName("PLN_VSN_CDTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.SmstrId)
                    .HasColumnName("SMSTR_ID")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExamId).HasColumnName("EXAM_ID");

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Tcertexam)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCERTEXAM_TEXAM");

                entity.HasOne(d => d.Tcrspln)
                    .WithMany(p => p.Tcertexam)
                    .HasForeignKey(d => new { d.CrsId, d.TchrUid, d.PlnVsnCdttm, d.SmstrId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCERTEXAM_TCRSPLN");
            });

            modelBuilder.Entity<Tcrsactvt>(entity =>
            {
                entity.HasKey(e => new { e.CrsId, e.TchrUid, e.PlnVsnCdttm, e.SmstrId, e.ActvtSqnbr });

                entity.ToTable("TCRSACTVT");

                entity.HasComment("Calendrier des activités");

                entity.Property(e => e.CrsId)
                    .HasColumnName("CRS_ID")
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.TchrUid)
                    .HasColumnName("TCHR_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.PlnVsnCdttm)
                    .HasColumnName("PLN_VSN_CDTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.SmstrId)
                    .HasColumnName("SMSTR_ID")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ActvtSqnbr).HasColumnName("ACTVT_SQNBR");

                entity.Property(e => e.ActvtDesc)
                    .HasColumnName("ACTVT_DESC")
                    .HasColumnType("ntext");

                entity.Property(e => e.ActvtLgnth)
                    .HasColumnName("ACTVT_LGNTH")
                    .HasComment("Nombre de semaines consacrées à cette activité");

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Tcrspln)
                    .WithMany(p => p.Tcrsactvt)
                    .HasForeignKey(d => new { d.CrsId, d.TchrUid, d.PlnVsnCdttm, d.SmstrId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCRSACTVT_TCRSPLN");
            });

            modelBuilder.Entity<Tcrsmtrl>(entity =>
            {
                entity.HasKey(e => new { e.CrsId, e.TchrUid, e.PlnVsnCdttm, e.SmstrId, e.CrsMtrlSqnbr });

                entity.ToTable("TCRSMTRL");

                entity.HasComment("Matériel requis");

                entity.Property(e => e.CrsId)
                    .HasColumnName("CRS_ID")
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.TchrUid)
                    .HasColumnName("TCHR_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.PlnVsnCdttm)
                    .HasColumnName("PLN_VSN_CDTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.SmstrId)
                    .HasColumnName("SMSTR_ID")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CrsMtrlSqnbr).HasColumnName("CRS_MTRL_SQNBR");

                entity.Property(e => e.CrsMtrlDesc)
                    .HasColumnName("CRS_MTRL_DESC")
                    .HasMaxLength(255);

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Tcrspln)
                    .WithMany(p => p.Tcrsmtrl)
                    .HasForeignKey(d => new { d.CrsId, d.TchrUid, d.PlnVsnCdttm, d.SmstrId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCRSMTRL_TCRSPLN");
            });

            modelBuilder.Entity<Tcrspln>(entity =>
            {
                entity.HasKey(e => new { e.CrsId, e.TchrUid, e.PlnVsnCdttm, e.SmstrId });

                entity.ToTable("TCRSPLN");

                entity.HasComment("Plan de cours");

                entity.Property(e => e.CrsId)
                    .HasColumnName("CRS_ID")
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.TchrUid)
                    .HasColumnName("TCHR_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.PlnVsnCdttm)
                    .HasColumnName("PLN_VSN_CDTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.SmstrId)
                    .HasColumnName("SMSTR_ID")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Smstr)
                    .WithMany(p => p.Tcrspln)
                    .HasForeignKey(d => d.SmstrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCRSPLN_TSMSTR");
            });

            modelBuilder.Entity<Tcrsreq>(entity =>
            {
                entity.HasKey(e => new { e.CrsId, e.VsnCdttm, e.ReqCrsId });

                entity.ToTable("TCRSREQ");

                entity.HasComment("Prérequis; corequis");

                entity.Property(e => e.CrsId)
                    .HasColumnName("CRS_ID")
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.VsnCdttm)
                    .HasColumnName("VSN_CDTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReqCrsId)
                    .HasColumnName("REQ_CRS_ID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CrsReqTyCd)
                    .HasColumnName("CRS_REQ_TY_CD")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Tcrstmplt)
                    .WithMany(p => p.Tcrsreq)
                    .HasForeignKey(d => new { d.CrsId, d.VsnCdttm })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCRSREQ_TCRSTMPLT");
            });

            modelBuilder.Entity<Tcrssklelem>(entity =>
            {
                entity.HasKey(e => new { e.CrsId, e.VsnCdttm, e.SklId, e.SklelemSqnbr })
                    .HasName("PK_TTMPLTSKLELEM");

                entity.ToTable("TCRSSKLELEM");

                entity.HasComment("Association plan-cadre -- élément de compétence");

                entity.Property(e => e.CrsId)
                    .HasColumnName("CRS_ID")
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.VsnCdttm)
                    .HasColumnName("VSN_CDTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.SklId)
                    .HasColumnName("SKL_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SklelemSqnbr).HasColumnName("SKLELEM_SQNBR");

                entity.Property(e => e.AddtnlDesc)
                    .HasColumnName("ADDTNL_DESC")
                    .HasColumnType("ntext");

                entity.Property(e => e.PrtlSklInd)
                    .HasColumnName("PRTL_SKL_IND")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.TxnmyCd)
                    .HasColumnName("TXNMY_CD")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Tcrstmplt)
                    .WithMany(p => p.Tcrssklelem)
                    .HasForeignKey(d => new { d.CrsId, d.VsnCdttm })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTMPLTSKLELEM_TCRSTMPLT");

                entity.HasOne(d => d.Skl)
                    .WithMany(p => p.Tcrssklelem)
                    .HasForeignKey(d => new { d.SklId, d.SklelemSqnbr })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTMPLTSKLELEM_TSKLELEM");
            });

            modelBuilder.Entity<Tcrstmplt>(entity =>
            {
                entity.HasKey(e => new { e.CrsId, e.VsnCdttm });

                entity.ToTable("TCRSTMPLT");

                entity.HasComment("Plan-cadre");

                entity.Property(e => e.CrsId)
                    .HasColumnName("CRS_ID")
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.VsnCdttm)
                    .HasColumnName("VSN_CDTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.BoardApprvDt)
                    .HasColumnName("BOARD_APPRV_DT")
                    .HasColumnType("date");

                entity.Property(e => e.CmteApprvDt)
                    .HasColumnName("CMTE_APPRV_DT")
                    .HasColumnType("date");

                entity.Property(e => e.CrsDesc)
                    .HasColumnName("CRS_DESC")
                    .HasColumnType("ntext");

                entity.Property(e => e.CrsEduIntent)
                    .HasColumnName("CRS_EDU_INTENT")
                    .HasColumnType("ntext");

                entity.Property(e => e.CrsPdgIntent)
                    .HasColumnName("CRS_PDG_INTENT")
                    .HasColumnType("ntext");

                entity.Property(e => e.CrsTitle)
                    .HasColumnName("CRS_TITLE")
                    .HasMaxLength(50);

                entity.Property(e => e.DptmntApprvDt)
                    .HasColumnName("DPTMNT_APPRV_DT")
                    .HasColumnType("date");

                entity.Property(e => e.HomeHrs).HasColumnName("HOME_HRS");

                entity.Property(e => e.PgmId)
                    .HasColumnName("PGM_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PrctHrs).HasColumnName("PRCT_HRS");

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TheoryHrs).HasColumnName("THEORY_HRS");

                entity.Property(e => e.TrkUid)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Units)
                    .HasColumnName("UNITS")
                    .HasColumnType("decimal(3, 2)");

                entity.HasOne(d => d.Pgm)
                    .WithMany(p => p.Tcrstmplt)
                    .HasForeignKey(d => d.PgmId)
                    .HasConstraintName("FK_TCRSTMPLT_TPGM");
            });

            modelBuilder.Entity<Tdptmnt>(entity =>
            {
                entity.HasKey(e => e.DptmntId);

                entity.ToTable("TDPTMNT");

                entity.HasComment("Département");

                entity.Property(e => e.DptmntId).HasColumnName("DPTMNT_ID");

                entity.Property(e => e.DptmntPlcy)
                    .HasColumnName("DPTMNT_PLCY")
                    .HasColumnType("ntext");

                entity.Property(e => e.DptmntTitle)
                    .HasColumnName("DPTMNT_TITLE")
                    .HasMaxLength(250);

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Texam>(entity =>
            {
                entity.HasKey(e => e.ExamId);

                entity.ToTable("TEXAM");

                entity.HasComment("Entité de base pour un examen");

                entity.Property(e => e.ExamId)
                    .HasColumnName("EXAM_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ExamTitle)
                    .HasColumnName("EXAM_TITLE")
                    .HasMaxLength(150);

                entity.Property(e => e.ExamTyCd)
                    .HasColumnName("EXAM_TY_CD")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExamWght)
                    .HasColumnName("EXAM_WGHT")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Texamsklelem>(entity =>
            {
                entity.HasKey(e => new { e.ExamId, e.SklId, e.SklelemSqnbr });

                entity.ToTable("TEXAMSKLELEM");

                entity.HasComment("Association examen -- élément de compétence");

                entity.Property(e => e.ExamId).HasColumnName("EXAM_ID");

                entity.Property(e => e.SklId)
                    .HasColumnName("SKL_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SklelemSqnbr).HasColumnName("SKLELEM_SQNBR");

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SklelemWght)
                    .HasColumnName("SKLELEM_WGHT")
                    .HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Texamsklelem)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TEXAMSKLELEM_TEXAM");

                entity.HasOne(d => d.Skl)
                    .WithMany(p => p.Texamsklelem)
                    .HasForeignKey(d => new { d.SklId, d.SklelemSqnbr })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TEXAMSKLELEM_TSKLELEM");
            });

            modelBuilder.Entity<Tfnlexam>(entity =>
            {
                entity.HasKey(e => new { e.CrsId, e.VsnCdttm, e.ExamId });

                entity.ToTable("TFNLEXAM");

                entity.HasComment("Examen certificatif final");

                entity.Property(e => e.CrsId)
                    .HasColumnName("CRS_ID")
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.VsnCdttm)
                    .HasColumnName("VSN_CDTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExamId).HasColumnName("EXAM_ID");

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Tfnlexam)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TFNLEXAM_TEXAM");

                entity.HasOne(d => d.Tcrstmplt)
                    .WithMany(p => p.Tfnlexam)
                    .HasForeignKey(d => new { d.CrsId, d.VsnCdttm })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TFNLEXAM_TCRSTMPLT");
            });

            modelBuilder.Entity<Tpgm>(entity =>
            {
                entity.HasKey(e => e.PgmId);

                entity.ToTable("TPGM");

                entity.HasComment("Programme d'études");

                entity.Property(e => e.PgmId)
                    .HasColumnName("PGM_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DptmntId).HasColumnName("DPTMNT_ID");

                entity.Property(e => e.PgmDesc)
                    .HasColumnName("PGM_DESC")
                    .HasColumnType("ntext");

                entity.Property(e => e.PgmTitle)
                    .HasColumnName("PGM_TITLE")
                    .HasMaxLength(50);

                entity.Property(e => e.PgmTyCd)
                    .HasColumnName("PGM_TY_CD")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dptmnt)
                    .WithMany(p => p.Tpgm)
                    .HasForeignKey(d => d.DptmntId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TPGM_TDPTMNT");
            });

            modelBuilder.Entity<Trole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("TROLE");

                entity.Property(e => e.RoleId)
                    .HasColumnName("ROLE_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RoleNm)
                    .HasColumnName("ROLE_NM")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tskl>(entity =>
            {
                entity.HasKey(e => e.SklId);

                entity.ToTable("TSKL");

                entity.HasComment("Compétence");

                entity.Property(e => e.SklId)
                    .HasColumnName("SKL_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AsscAttd)
                    .HasColumnName("ASSC_ATTD")
                    .HasColumnType("ntext");

                entity.Property(e => e.PgmId)
                    .IsRequired()
                    .HasColumnName("PGM_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SklTitle)
                    .HasColumnName("SKL_TITLE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TrkUid)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Pgm)
                    .WithMany(p => p.Tskl)
                    .HasForeignKey(d => d.PgmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TSKL_TPGM");
            });

            modelBuilder.Entity<Tsklcntxt>(entity =>
            {
                entity.HasKey(e => new { e.SklId, e.SklCntxtSqnbr });

                entity.ToTable("TSKLCNTXT");

                entity.HasComment("Contextes de réalisation associés à une compétence");

                entity.Property(e => e.SklId)
                    .HasColumnName("SKL_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SklCntxtSqnbr).HasColumnName("SKL_CNTXT_SQNBR");

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SklCntxtTitle)
                    .HasColumnName("SKL_CNTXT_TITLE")
                    .HasMaxLength(512);

                entity.Property(e => e.TrkUid)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Skl)
                    .WithMany(p => p.Tsklcntxt)
                    .HasForeignKey(d => d.SklId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TSKLCNTXT_TSKL");
            });

            modelBuilder.Entity<Tsklelem>(entity =>
            {
                entity.HasKey(e => new { e.SklId, e.SklelemSqnbr });

                entity.ToTable("TSKLELEM");

                entity.HasComment("Élément de compétence");

                entity.Property(e => e.SklId)
                    .HasColumnName("SKL_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SklelemSqnbr).HasColumnName("SKLELEM_SQNBR");

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SklelemDesc)
                    .HasColumnName("SKLELEM_DESC")
                    .HasColumnType("ntext");

                entity.Property(e => e.SklelemTitle)
                    .HasColumnName("SKLELEM_TITLE")
                    .HasMaxLength(255);

                entity.Property(e => e.TrkUid)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Skl)
                    .WithMany(p => p.Tsklelem)
                    .HasForeignKey(d => d.SklId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TSKLELEM_TSKL");
            });

            modelBuilder.Entity<Tsklelemcrt>(entity =>
            {
                entity.HasKey(e => new { e.SklId, e.SklElemSqnbr, e.SklElemCrtSqnbr });

                entity.ToTable("TSKLELEMCRT");

                entity.Property(e => e.SklId)
                    .HasColumnName("SKL_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SklElemSqnbr).HasColumnName("SKL_ELEM_SQNBR");

                entity.Property(e => e.SklElemCrtSqnbr).HasColumnName("SKL_ELEM_CRT_SQNBR");

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SklElemCrtTitle)
                    .HasColumnName("SKL_ELEM_CRT_TITLE")
                    .HasMaxLength(255);

                entity.Property(e => e.TrkUid)
                    .IsRequired()
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Skl)
                    .WithMany(p => p.Tsklelemcrt)
                    .HasForeignKey(d => new { d.SklId, d.SklElemSqnbr })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TSKLELEMCRT_TSKLELEM");
            });

            modelBuilder.Entity<Tsmstr>(entity =>
            {
                entity.HasKey(e => e.SmstrId);

                entity.ToTable("TSMSTR");

                entity.HasComment("Session");

                entity.Property(e => e.SmstrId)
                    .HasColumnName("SMSTR_ID")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SmstrDesc)
                    .HasColumnName("SMSTR_DESC")
                    .HasMaxLength(50);

                entity.Property(e => e.SmstrNdt)
                    .HasColumnName("SMSTR_NDT")
                    .HasColumnType("date");

                entity.Property(e => e.SmstrSdt)
                    .HasColumnName("SMSTR_SDT")
                    .HasColumnType("date");

                entity.Property(e => e.TrkUid)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tuser>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.ToTable("TUSER");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.DptmntId).HasColumnName("DPTMNT_ID");

                entity.Property(e => e.GvnNm)
                    .HasColumnName("GVN_NM")
                    .HasMaxLength(50);

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Snm)
                    .HasColumnName("SNM")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Dptmnt)
                    .WithMany(p => p.Tuser)
                    .HasForeignKey(d => d.DptmntId)
                    .HasConstraintName("FK_TUSER_TDPTMNT");
            });

            modelBuilder.Entity<Tuseravl>(entity =>
            {
                entity.HasKey(e => new { e.Uid, e.UserAvlSqnbr });

                entity.ToTable("TUSERAVL");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.UserAvlSqnbr)
                    .HasColumnName("USER_AVL_SQNBR")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AvlNtm).HasColumnName("AVL_NTM");

                entity.Property(e => e.AvlStm).HasColumnName("AVL_STM");

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.WeekdayNbr).HasColumnName("WEEKDAY_NBR");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Tuseravl)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TUSERAVL_TUSER");
            });

            modelBuilder.Entity<Tuserrole>(entity =>
            {
                entity.HasKey(e => new { e.Uid, e.RoleId });

                entity.ToTable("TUSERROLE");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Tuserrole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TUSERROLE_TROLE");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Tuserrole)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TUSERROLE_TUSER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

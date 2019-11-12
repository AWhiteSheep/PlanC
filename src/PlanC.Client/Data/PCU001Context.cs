using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PlanC.EntityDataModel;
using PlanC.WebApi.Models;

namespace PlanC.WebApi.Server.DataAccess
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

        public virtual DbSet<Code> Tcd { get; set; }
        public virtual DbSet<CodeType> Tcdty { get; set; }
        public virtual DbSet<NonFinalCertificativeExam> Tcertexam { get; set; }
        public virtual DbSet<CoursePlan> Tcrspln { get; set; }
        public virtual DbSet<CourseRequirement> Tcrsreq { get; set; }
        public virtual DbSet<Course_SkillElement> Tcrssklelem { get; set; }
        public virtual DbSet<CourseTemplate> Tcrstmplt { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<ExamInfo> Exams { get; set; }
        public virtual DbSet<Exam_SkillElement> Exam_SkillElements { get; set; }
        public virtual DbSet<FinalCertificativeExam> Tfnlexam { get; set; }
        public virtual DbSet<Tpgm> Tpgm { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<SkillAchievementContext> SkillAchievementContexts { get; set; }
        public virtual DbSet<SkillElement> SkillElements { get; set; }
        public virtual DbSet<Semester> Tsmstr { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=database-1.cai5lbxs9ofy.us-east-1.rds.amazonaws.com,1433;Initial Catalog=PCU001;User ID=dbo802668235;Password=Nemesis2123%*;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseActivityElement>(entity =>
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

                entity.HasOne(d => d.SkillElement)
                    .WithMany(p => p.CourseActivityElements)
                    .HasForeignKey(d => new { d.SklId, d.SklelemSqnbr })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TACTELEM_TSKLELEM");

                entity.HasOne(d => d.Tcrsactvt)
                    .WithMany(p => p.ActivityElements)
                    .HasForeignKey(d => new { d.CrsId, d.TchrUid, d.PlnVsnCdttm, d.SmstrId, d.ActvtSqnbr })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TACTELEM_TCRSACTVT");
            });

            modelBuilder.Entity<Code>(entity =>
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

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.CdTyNavigation)
                    .WithMany(p => p.Tcd)
                    .HasForeignKey(d => d.CdTy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCD_TCDTY");
            });

            modelBuilder.Entity<CodeType>(entity =>
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

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NonFinalCertificativeExam>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.TeacherUserId, e.PlnVsnCdttm, e.SemesterId, e.ExamId });

                entity.ToTable("TCERTEXAM");

                entity.HasComment("Examen certificatif");

                entity.Property(e => e.CourseId)
                    .HasColumnName("CRS_ID")
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.TeacherUserId)
                    .HasColumnName("TCHR_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.PlnVsnCdttm)
                    .HasColumnName("PLN_VSN_CDTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.SemesterId)
                    .HasColumnName("SMSTR_ID")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExamId).HasColumnName("EXAM_ID");

                //entity.Property(e => e.RcdCdttm)
                //    .HasColumnName("RCD_CDTTM")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.NonFinalCertificativeExams)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCERTEXAM_TEXAM");

                entity.HasOne(d => d.CoursePlan)
                    .WithMany(p => p.NonFinalCertificativeExams)
                    .HasForeignKey(d => new { d.CourseId, d.TeacherUserId, d.PlnVsnCdttm, d.SemesterId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCERTEXAM_TCRSPLN");
            });

            modelBuilder.Entity<CourseActivity>(entity =>
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

                entity.HasOne(d => d.CoursePlan)
                    .WithMany(p => p.CourseActivities)
                    .HasForeignKey(d => new { d.CrsId, d.TchrUid, d.PlnVsnCdttm, d.SmstrId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCRSACTVT_TCRSPLN");
            });

            modelBuilder.Entity<CourseMaterial>(entity =>
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
                    .WithMany(p => p.CourseMaterials)
                    .HasForeignKey(d => new { d.CrsId, d.TchrUid, d.PlnVsnCdttm, d.SmstrId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCRSMTRL_TCRSPLN");
            });

            modelBuilder.Entity<CoursePlan>(entity =>
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

                //entity.Property(e => e.RcdCdttm)
                //    .HasColumnName("RCD_CDTTM")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Smstr)
                    .WithMany(p => p.CoursePlans)
                    .HasForeignKey(d => d.SmstrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCRSPLN_TSMSTR");
            });

            modelBuilder.Entity<CourseRequirement>(entity =>
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

            modelBuilder.Entity<Course_SkillElement>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.VsnCdttm, e.SkillId, e.SkillElementSequenceNumber })
                    .HasName("PK_TTMPLTSKLELEM");

                entity.ToTable("TCRSSKLELEM");

                entity.HasComment("Association plan-cadre -- élément de compétence");

                entity.Property(e => e.CourseId)
                    .HasColumnName("CRS_ID")
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.VsnCdttm)
                    .HasColumnName("VSN_CDTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.SkillId)
                    .HasColumnName("SKL_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SkillElementSequenceNumber).HasColumnName("SKLELEM_SQNBR");

                entity.Property(e => e.ContentDetails)
                    .HasColumnName("ADDTNL_DESC")
                    .HasColumnType("ntext");

                entity.Property(e => e.IsPartial)
                    .HasColumnName("PRTL_SKL_IND")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                //entity.Property(e => e.RcdCdttm)
                //    .HasColumnName("RCD_CDTTM")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.TaxonomicLevel)
                    .HasColumnName("TXNMY_CD")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.CourseTemplate)
                    .WithMany(p => p.Tcrssklelem)
                    .HasForeignKey(d => new { d.CourseId, d.VsnCdttm })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTMPLTSKLELEM_TCRSTMPLT");

                entity.HasOne(d => d.SkillElement)
                    .WithMany(p => p.Tcrssklelem)
                    .HasForeignKey(d => new { d.SkillId, d.SkillElementSequenceNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTMPLTSKLELEM_TSKLELEM");
            });

            modelBuilder.Entity<CourseTemplate>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.VsnCdttm });

                entity.ToTable("TCRSTMPLT");

                entity.HasComment("Plan-cadre");

                entity.Property(e => e.Id)
                    .HasColumnName("CRS_ID")
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.VsnCdttm)
                    .HasColumnName("VSN_CDTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.BoardApprovalDate)
                    .HasColumnName("BOARD_APPRV_DT")
                    .HasColumnType("date");

                entity.Property(e => e.CommitteeApprovalDate)
                    .HasColumnName("CMTE_APPRV_DT")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("CRS_DESC")
                    .HasColumnType("ntext");

                entity.Property(e => e.EducationalIntent)
                    .HasColumnName("CRS_EDU_INTENT")
                    .HasColumnType("ntext");

                entity.Property(e => e.PedagogicalIntent)
                    .HasColumnName("CRS_PDG_INTENT")
                    .HasColumnType("ntext");

                entity.Property(e => e.Title)
                    .HasColumnName("CRS_TITLE")
                    .HasMaxLength(50);

                entity.Property(e => e.DepartmentApprovalDate)
                    .HasColumnName("DPTMNT_APPRV_DT")
                    .HasColumnType("date");

                entity.Property(e => e.HomeHours).HasColumnName("HOME_HRS");

                entity.Property(e => e.PgmId)
                    .HasColumnName("PGM_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PracticeHours).HasColumnName("PRCT_HRS");

                //entity.Property(e => e.RcdCdttm)
                //    .HasColumnName("RCD_CDTTM")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TheoryHours).HasColumnName("THEORY_HRS");

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Units)
                    .HasColumnName("UNITS")
                    .HasColumnType("decimal(3, 2)");

                entity.HasOne(d => d.Pgm)
                    .WithMany(p => p.CourseTemplates)
                    .HasForeignKey(d => d.PgmId)
                    .HasConstraintName("FK_TCRSTMPLT_TPGM");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("TDPTMNT");

                entity.HasComment("Département");

                entity.Property(e => e.Id).HasColumnName("DPTMNT_ID");

                entity.Property(e => e.Policy)
                    .HasColumnName("DPTMNT_PLCY")
                    .HasColumnType("ntext");

                entity.Property(e => e.Title)
                    .HasColumnName("DPTMNT_TITLE")
                    .HasMaxLength(250);

                //entity.Property(e => e.RcdCdttm)
                //    .HasColumnName("RCD_CDTTM")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExamInfo>(entity =>
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

                entity.Property(e => e.Weight)
                    .HasColumnName("EXAM_WGHT")
                    .HasColumnType("decimal(5, 2)");

                //entity.Property(e => e.RcdCdttm)
                //    .HasColumnName("RCD_CDTTM")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Exam_SkillElement>(entity =>
            {
                entity.HasKey(e => new { e.ExamId, e.SkillId, e.SkillElelementSequenceNumber });

                entity.ToTable("TEXAMSKLELEM");

                entity.HasComment("Association examen -- élément de compétence");

                entity.Property(e => e.ExamId).HasColumnName("EXAM_ID");

                entity.Property(e => e.SkillId)
                    .HasColumnName("SKL_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SkillElelementSequenceNumber).HasColumnName("SKLELEM_SQNBR");

                //entity.Property(e => e.RcdCdttm)
                //    .HasColumnName("RCD_CDTTM")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SkillElementWeight)
                    .HasColumnName("SKLELEM_WGHT")
                    .HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Exam_SkillElements)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TEXAMSKLELEM_TEXAM");

                entity.HasOne(d => d.SkillElement)
                    .WithMany(p => p.Texamsklelem)
                    .HasForeignKey(d => new { d.SkillId, d.SkillElelementSequenceNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TEXAMSKLELEM_TSKLELEM");
            });

            modelBuilder.Entity<FinalCertificativeExam>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.VsnCdttm, e.ExamId });

                entity.ToTable("TFNLEXAM");

                entity.HasComment("Examen certificatif final");

                entity.Property(e => e.CourseId)
                    .HasColumnName("CRS_ID")
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.VsnCdttm)
                    .HasColumnName("VSN_CDTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExamId).HasColumnName("EXAM_ID");

                //entity.Property(e => e.RcdCdttm)
                //    .HasColumnName("RCD_CDTTM")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.FinalCertificativeExam)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TFNLEXAM_TEXAM");

                entity.HasOne(d => d.Tcrstmplt)
                    .WithMany(p => p.Tfnlexam)
                    .HasForeignKey(d => new { d.CourseId, d.VsnCdttm })
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

                entity.Property(e => e.DepartmentId).HasColumnName("DPTMNT_ID");

                entity.Property(e => e.PgmDesc)
                    .HasColumnName("PGM_DESC")
                    .HasColumnType("ntext");

                entity.Property(e => e.PgmTitle)
                    .HasColumnName("PGM_TITLE")
                    .HasMaxLength(50);

                entity.Property(e => e.Category)
                    .HasColumnName("PGM_TY_CD")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                //entity.Property(e => e.RcdCdttm)
                //    .HasColumnName("RCD_CDTTM")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Tpgm)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TPGM_TDPTMNT");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("TROLE");

                entity.Property(e => e.RoleId)
                    .HasColumnName("ROLE_ID")
                    .ValueGeneratedNever();

                //entity.Property(e => e.RcdCdttm)
                //    .HasColumnName("RCD_CDTTM")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RoleNm)
                    .HasColumnName("ROLE_NM")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("TSKL");

                entity.HasComment("Compétence");

                entity.Property(e => e.Id)
                    .HasColumnName("SKL_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AsscAttd)
                    .HasColumnName("ASSC_ATTD")
                    .HasColumnType("ntext");

                entity.Property(e => e.StudyProgramId)
                    .IsRequired()
                    .HasColumnName("PGM_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                //entity.Property(e => e.RcdCdttm)
                //    .HasColumnName("RCD_CDTTM")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Title)
                    .HasColumnName("SKL_TITLE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.StudyProgram)
                    .WithMany(p => p.Skills)
                    .HasForeignKey(d => d.StudyProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TSKL_TPGM");
            });

            modelBuilder.Entity<SkillAchievementContext>(entity =>
            {
                entity.HasKey(e => new { e.SkillId, e.SequenceNumber });

                entity.ToTable("TSKLCNTXT");

                entity.HasComment("Contextes de réalisation associés à une compétence");

                entity.Property(e => e.SkillId)
                    .HasColumnName("SKL_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SequenceNumber).HasColumnName("SKL_CNTXT_SQNBR");

                //entity.Property(e => e.RcdCdttm)
                //    .HasColumnName("RCD_CDTTM")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Title)
                    .HasColumnName("SKL_CNTXT_TITLE")
                    .HasMaxLength(512);

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Skl)
                    .WithMany(p => p.Tsklcntxt)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TSKLCNTXT_TSKL");
            });

            modelBuilder.Entity<SkillElement>(entity =>
            {
                entity.HasKey(e => new { e.SkillId, e.SequenceNumber });

                entity.ToTable("TSKLELEM");

                entity.HasComment("Élément de compétence");

                entity.Property(e => e.SkillId)
                    .HasColumnName("SKL_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SequenceNumber).HasColumnName("SKLELEM_SQNBR");

                //entity.Property(e => e.RcdCdttm)
                //    .HasColumnName("RCD_CDTTM")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasColumnName("SKLELEM_DESC")
                    .HasColumnType("ntext");

                entity.Property(e => e.Title)
                    .HasColumnName("SKLELEM_TITLE")
                    .HasMaxLength(255);

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Skl)
                    .WithMany(p => p.Tsklelem)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TSKLELEM_TSKL");
            });

            modelBuilder.Entity<SkillElementPerformanceCriteria>(entity =>
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

                //entity.Property(e => e.RcdCdttm)
                //    .HasColumnName("RCD_CDTTM")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SklElemCrtTitle)
                    .HasColumnName("SKL_ELEM_CRT_TITLE")
                    .HasMaxLength(255);

                entity.Property(e => e.TrkUid)
                    .IsRequired()
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.SkillElement)
                    .WithMany(p => p.Tsklelemcrt)
                    .HasForeignKey(d => new { d.SklId, d.SklElemSqnbr })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TSKLELEMCRT_TSKLELEM");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("TSMSTR");

                entity.HasComment("Session");

                entity.Property(e => e.Id)
                    .HasColumnName("SMSTR_ID")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                //entity.Property(e => e.RcdCdttm)
                //    .HasColumnName("RCD_CDTTM")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasColumnName("SMSTR_DESC")
                    .HasMaxLength(50);

                entity.Property(e => e.EndDate)
                    .HasColumnName("SMSTR_NDT")
                    .HasColumnType("date");

                entity.Property(e => e.StartDate)
                    .HasColumnName("SMSTR_SDT")
                    .HasColumnType("date");

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
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

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DptmntId)
                    .HasConstraintName("FK_TUSER_TDPTMNT");
            });

            modelBuilder.Entity<UserAvailability>(entity =>
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

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tuseravl)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TUSERAVL_TUSER");
            });

            modelBuilder.Entity<User_Role>(entity =>
            {
                entity.HasKey(e => new { e.Uid, e.RoleId });

                entity.ToTable("TUSERROLE");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");

                //entity.Property(e => e.RcdCdttm)
                //    .HasColumnName("RCD_CDTTM")
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Tuserrole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TUSERROLE_TROLE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.User_Roles)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TUSERROLE_TUSER");
            });
        }
    }
}

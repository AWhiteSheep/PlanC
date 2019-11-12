using Microsoft.EntityFrameworkCore;
using PlanC.WebApi.Models;

namespace PlanC.WebApi.Models
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
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PCU001;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Code>(entity =>
            {
                entity.HasKey(e => new { e.CdTy, e.Cd });

                entity.ToTable("TCD");

                entity.Property(e => e.CdTy)
                    .HasColumnName("CD_TY")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Cd)
                    .HasColumnName("CD")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CdDesc)
                    .HasColumnName("CD_DESC")
                    .HasMaxLength(10);

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
                    .ValueGeneratedNever();

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

                entity.Property(e => e.CourseId)
                    .HasColumnName("CRS_ID")
                    .HasMaxLength(10);

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
                    .IsUnicode(false);

                entity.Property(e => e.ExamId).HasColumnName("EXAM_ID");

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.NonFinalCertificativeExams)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCERTEXAM_TEXAM");
            });

            modelBuilder.Entity<CoursePlan>(entity =>
            {
                entity.HasKey(e => new { e.CrsId, e.TchrUid, e.PlnVsnCdttm, e.SmstrId });

                entity.ToTable("TCRSPLN");

                entity.Property(e => e.CrsId)
                    .HasColumnName("CRS_ID")
                    .HasMaxLength(10);

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
                    .IsUnicode(false);

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

                entity.Property(e => e.CrsId)
                    .HasColumnName("CRS_ID")
                    .HasMaxLength(10);

                entity.Property(e => e.VsnCdttm)
                    .HasColumnName("VSN_CDTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReqCrsId)
                    .HasColumnName("REQ_CRS_ID")
                    .HasMaxLength(10);

                entity.Property(e => e.CrsReqTyCd)
                    .HasColumnName("CRS_REQ_TY_CD")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.RcdCdttm)
                    .HasColumnName("RCD_CDTTM")
                    .HasColumnType("datetime");

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
                entity.HasKey(e => new { e.CourseId, e.VsnCdttm, e.SkillId, e.SkillElementSequenceNumber });

                entity.ToTable("TCRSSKLELEM");

                entity.Property(e => e.CourseId)
                    .HasColumnName("CRS_ID")
                    .HasMaxLength(10);

                entity.Property(e => e.VsnCdttm)
                    .HasColumnName("VSN_CDTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.SkillId)
                    .HasColumnName("SKL_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.SkillElementSequenceNumber).HasColumnName("SKLELEM_SQNBR");

                entity.Property(e => e.IsPartial)
                    .HasColumnName("PRTL_SKL_IND")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TaxonomicLevel)
                    .HasColumnName("TXNMY_CD")
                    .HasMaxLength(2)
                    .IsUnicode(false);

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

                entity.Property(e => e.Id)
                    .HasColumnName("CRS_ID")
                    .HasMaxLength(10);

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
                    .HasColumnName("CRS_INTENT")
                    .HasColumnType("ntext");

                entity.Property(e => e.Title)
                    .HasColumnName("CRS_TITLE")
                    .HasMaxLength(50);

                entity.Property(e => e.DepartmentApprovalDate)
                    .HasColumnName("DPTMNT_APPRV_DT")
                    .HasColumnType("date");

                entity.Property(e => e.PgmId)
                    .HasColumnName("PGM_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                //entity.Property(e => e.RcdCdttm)
                //    .HasColumnName("RCD_CDTTM")
                //    .HasColumnType("datetime");

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRK_UID")
                    .IsRequired()
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

                entity.Property(e => e.Id)
                    .HasColumnName("DPTMNT_ID")
                    .UseIdentityColumn();

                entity.Property(e => e.Title)
                    .HasColumnName("DPTMNT_TITLE")
                    .HasMaxLength(250);

                entity.Property(e => e.Policy)
                    .HasColumnName("DPTMNT_PLCY")
                    .HasColumnType("ntext");

                //entity.Property(e => e.RcdCdttm)
                //    .HasColumnName("RCD_CDTTM")
                //    .HasColumnType("datetime");

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRK_UID")
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExamInfo>(entity =>
            {
                entity.HasKey(e => e.ExamId);

                entity.ToTable("TEXAM");

                entity.Property(e => e.ExamId)
                    .HasColumnName("EXAM_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ExamTyCd)
                    .HasColumnName("EXAM_TY_CD")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Weight)
                    .HasColumnName("EXAM_WGHT")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Exam_SkillElement>(entity =>
            {
                entity.HasKey(e => new { e.ExamId, e.SkillId, e.SkillElelementSequenceNumber });

                entity.ToTable("TEXAMSKLELEM");

                entity.Property(e => e.ExamId).HasColumnName("EXAM_ID");

                entity.Property(e => e.SkillId)
                    .HasColumnName("SKL_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.SkillElelementSequenceNumber).HasColumnName("SKLELEM_SQNBR");

                entity.Property(e => e.SkillElementWeight)
                    .HasColumnName("SKLELEM_WGHT")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRK_UID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

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

                entity.Property(e => e.CourseId)
                    .HasColumnName("CRS_ID")
                    .HasMaxLength(10);

                entity.Property(e => e.VsnCdttm)
                    .HasColumnName("VSN_CDTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExamId).HasColumnName("EXAM_ID");

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

                entity.Property(e => e.PgmId)
                    .HasColumnName("PGM_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DepartmentId).HasColumnName("DPTMNT_ID");

                entity.Property(e => e.PgmDesc)
                    .HasColumnName("PGM_DESC")
                    .HasColumnType("ntext");

                entity.Property(e => e.PgmTitle)
                    .HasColumnName("PGM_TITLE")
                    .HasMaxLength(10);

                entity.Property(e => e.Category)
                    .HasColumnName("PGM_TY_CD")
                    .HasMaxLength(10);

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

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("TSKL");

                entity.Property(e => e.Id)
                    .HasColumnName("SKL_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AsscAttd)
                    .HasColumnName("ASSC_ATTD")
                    .HasColumnType("ntext");

                entity.Property(e => e.StudyProgramId)
                    .IsRequired()
                    .HasColumnName("PGM_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                //entity.Property(e => e.RcdCdttm)
                //    .HasColumnName("RCD_CDTTM")
                //    .HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasColumnName("SKL_TITLE")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRK_UID")
                    .IsRequired()
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

                entity.Property(e => e.SkillId)
                    .HasColumnName("SKL_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.SequenceNumber).HasColumnName("SKL_CNTXT_SQNBR");

                //entity.Property(e => e.RcdCdttm)
                //    .HasColumnName("RCD_CDTTM")
                //    .HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasColumnName("SKL_CNTXT_DESC")
                    .HasMaxLength(512);

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRK_UID")
                    .IsRequired()
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

                entity.Property(e => e.SkillId)
                    .HasColumnName("SKL_ID")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.SequenceNumber).HasColumnName("SKLELEM_SQNBR");

                //entity.Property(e => e.RcdCdttm)
                //    .HasColumnName("RCD_CDTTM")
                //    .HasColumnType("datetime");

                entity.Property(e => e.Description) //TODO : Ne semble plus exister dans la BD
                    .HasColumnName("SKLELEM_DESC")
                    .HasColumnType("ntext");

                entity.Property(e => e.Title)
                    .HasColumnName("SKLELEM_TITLE")
                    .HasMaxLength(250);

                entity.Property(e => e.TrackingUserId)
                    .HasColumnName("TRK_UID")
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.Skl)
                    .WithMany(p => p.Tsklelem)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TSKLELEM_TSKL");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("TSMSTR");

                entity.Property(e => e.Id)
                    .HasColumnName("SMSTR_ID")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

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
        }
    }
}

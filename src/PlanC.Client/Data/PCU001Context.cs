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

        public virtual DbSet<SkillProgrammeRelation> RSklPgm { get; set; }
        public virtual DbSet<CourseActivityElement> Tactelem { get; set; }
        public virtual DbSet<CodeType> Tcdty { get; set; }
        public virtual DbSet<NonFinalCertificativeExam> Tcertexam { get; set; }
        public virtual DbSet<CourseActivity> Tcrsactvt { get; set; }
        public virtual DbSet<CourseMaterial> Tcrsmtrl { get; set; }
        public virtual DbSet<CoursePlan> Tcrspln { get; set; }
        public virtual DbSet<CourseRequirement> Tcrsreq { get; set; }
        public virtual DbSet<Course_SkillElement> Tcrssklelem { get; set; }
        public virtual DbSet<CourseTemplate> Tcrstmplt { get; set; }
        public virtual DbSet<Department> Tdptmnt { get; set; }
        public virtual DbSet<ExamInfo> Texam { get; set; }
        public virtual DbSet<Exam_SkillElement> Texamsklelem { get; set; }
        public virtual DbSet<FinalCertificativeExam> Tfnlexam { get; set; }
        public virtual DbSet<Tpgm> Tpgm { get; set; }
        public virtual DbSet<Role> Trole { get; set; }
        public virtual DbSet<Skill> Tskl { get; set; }
        public virtual DbSet<SkillAchievementContext> Tsklcntxt { get; set; }
        public virtual DbSet<SkillElement> Tsklelem { get; set; }
        public virtual DbSet<SkillElementPerformanceCriteria> Tsklelemcrt { get; set; }
        public virtual DbSet<Semester> Tsmstr { get; set; }
        public virtual DbSet<User> Tuser { get; set; }
        public virtual DbSet<UserAvailability> Tuseravl { get; set; }
        public virtual DbSet<User_Role> Tuserrole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=database-1.cai5lbxs9ofy.us-east-1.rds.amazonaws.com,1433; initial catalog=PCU001;User ID=dbo802668235;Password=Nemesis2123%*;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkillProgrammeRelation>(entity =>
            {
                entity.HasKey(e => new { e.PgmId, e.DptmntId, e.SklId })
                    .HasName("PK__R_SKL_PG__D129735B0D074A76");

                entity.Property(e => e.PgmId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SklId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Skl)
                    .WithMany(p => p.RSklPgm)
                    .HasForeignKey(d => d.SklId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_R_SKL_PGM__SKL");

                entity.HasOne(d => d.Tpgm)
                    .WithMany(p => p.RSklPgm)
                    .HasForeignKey(d => new { d.PgmId, d.DptmntId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_R_SKL_PGM__PGM");
            });

            modelBuilder.Entity<CourseActivityElement>(entity =>
            {
                entity.HasKey(e => new { e.SklelemSqnbr, e.SklId, e.CrsId, e.TchrUid, e.PlnVsnCdttm, e.SmstrId, e.ActvtSqnbr });

                entity.HasComment("Association activité -- élément de compétence");

                entity.Property(e => e.SklId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CrsId)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.TchrUid).IsUnicode(false);

                entity.Property(e => e.SmstrId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);

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

            modelBuilder.Entity<CodeType>(entity =>
            {
                entity.Property(e => e.CdTy)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TrkUid).IsUnicode(false);
            });

            modelBuilder.Entity<NonFinalCertificativeExam>(entity =>
            {
                entity.HasKey(e => new { e.CrsId, e.TchrUid, e.PlnVsnCdttm, e.SmstrId, e.ExamId });

                entity.HasComment("Examen certificatif");

                entity.Property(e => e.CrsId)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.TchrUid).IsUnicode(false);

                entity.Property(e => e.SmstrId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);

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

            modelBuilder.Entity<CourseActivity>(entity =>
            {
                entity.HasKey(e => new { e.CrsId, e.TchrUid, e.PlnVsnCdttm, e.SmstrId, e.ActvtSqnbr });

                entity.HasComment("Calendrier des activités");

                entity.Property(e => e.CrsId)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.TchrUid).IsUnicode(false);

                entity.Property(e => e.SmstrId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ActvtLgnth).HasComment("Nombre de semaines consacrées à cette activité");

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);

                entity.HasOne(d => d.Tcrspln)
                    .WithMany(p => p.Tcrsactvt)
                    .HasForeignKey(d => new { d.CrsId, d.TchrUid, d.PlnVsnCdttm, d.SmstrId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCRSACTVT_TCRSPLN");
            });

            modelBuilder.Entity<CourseMaterial>(entity =>
            {
                entity.HasKey(e => new { e.CrsId, e.TchrUid, e.PlnVsnCdttm, e.SmstrId, e.CrsMtrlSqnbr });

                entity.HasComment("Matériel requis");

                entity.Property(e => e.CrsId)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.TchrUid).IsUnicode(false);

                entity.Property(e => e.SmstrId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);

                entity.HasOne(d => d.Tcrspln)
                    .WithMany(p => p.Tcrsmtrl)
                    .HasForeignKey(d => new { d.CrsId, d.TchrUid, d.PlnVsnCdttm, d.SmstrId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCRSMTRL_TCRSPLN");
            });

            modelBuilder.Entity<CoursePlan>(entity =>
            {
                entity.HasKey(e => new { e.CrsId, e.TchrUid, e.PlnVsnCdttm, e.SmstrId });

                entity.HasComment("Plan de cours");

                entity.Property(e => e.CrsId)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.TchrUid).IsUnicode(false);

                entity.Property(e => e.SmstrId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);

                entity.HasOne(d => d.Smstr)
                    .WithMany(p => p.Tcrspln)
                    .HasForeignKey(d => d.SmstrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCRSPLN_TSMSTR");
            });

            modelBuilder.Entity<CourseRequirement>(entity =>
            {
                entity.HasKey(e => new { e.CrsId, e.VsnCdttm, e.ReqCrsId });

                entity.HasComment("Prérequis; corequis");

                entity.Property(e => e.CrsId)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.ReqCrsId).IsFixedLength();

                entity.Property(e => e.CrsReqTyCd)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);

                entity.HasOne(d => d.Tcrstmplt)
                    .WithMany(p => p.Tcrsreq)
                    .HasForeignKey(d => new { d.CrsId, d.VsnCdttm })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCRSREQ_TCRSTMPLT");
            });

            modelBuilder.Entity<Course_SkillElement>(entity =>
            {
                entity.HasKey(e => new { e.CrsId, e.VsnCdttm, e.SklId, e.SklelemSqnbr })
                    .HasName("PK_TTMPLTSKLELEM");

                entity.HasComment("Association plan-cadre -- élément de compétence");

                entity.Property(e => e.CrsId)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.SklId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PrtlSklInd)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);

                entity.Property(e => e.TxnmyCd)
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

            modelBuilder.Entity<CourseTemplate>(entity =>
            {
                entity.HasKey(e => new { e.CrsId, e.VsnCdttm });

                entity.HasComment("Plan-cadre");

                entity.Property(e => e.CrsId)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.PgmId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasComment("Département");

                entity.Property(e => e.DptmntId).ValueGeneratedNever();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);
            });

            modelBuilder.Entity<ExamInfo>(entity =>
            {
                entity.HasComment("Entité de base pour un examen");

                entity.Property(e => e.ExamId).ValueGeneratedNever();

                entity.Property(e => e.ExamTyCd)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);
            });

            modelBuilder.Entity<Exam_SkillElement>(entity =>
            {
                entity.HasKey(e => new { e.ExamId, e.SklId, e.SklelemSqnbr });

                entity.HasComment("Association examen -- élément de compétence");

                entity.Property(e => e.SklId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

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

            modelBuilder.Entity<FinalCertificativeExam>(entity =>
            {
                entity.HasKey(e => new { e.CrsId, e.VsnCdttm, e.ExamId });

                entity.HasComment("Examen certificatif final");

                entity.Property(e => e.CrsId)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);

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
                entity.HasKey(e => new { e.PgmId, e.DptmntId })
                    .HasName("PK__tmp_ms_x__CEB445A6AC5B9561");

                entity.HasComment("Programme d'études");

                entity.Property(e => e.PgmId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PgmTyCd)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);

                entity.HasOne(d => d.Dptmnt)
                    .WithMany(p => p.Tpgm)
                    .HasForeignKey(d => d.DptmntId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TPGM_TDPTMNT");

                entity.HasOne(d => d.PgmTyCdNavigation)
                    .WithMany(p => p.Tpgm)
                    .HasForeignKey(d => d.PgmTyCd)
                    .HasConstraintName("FK_TPGM_TCDTY");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RoleNm).IsUnicode(false);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasComment("Compétence");

                entity.Property(e => e.SklId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SklTitle).IsUnicode(false);

                entity.Property(e => e.TrkUid).IsUnicode(false);
            });

            modelBuilder.Entity<SkillAchievementContext>(entity =>
            {
                entity.HasKey(e => new { e.SklId, e.SklCntxtSqnbr });

                entity.HasComment("Contextes de réalisation associés à une compétence");

                entity.Property(e => e.SklId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);

                entity.HasOne(d => d.Skl)
                    .WithMany(p => p.Tsklcntxt)
                    .HasForeignKey(d => d.SklId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TSKLCNTXT_TSKL");
            });

            modelBuilder.Entity<SkillElement>(entity =>
            {
                entity.HasKey(e => new { e.SklId, e.SklelemSqnbr });

                entity.HasComment("Élément de compétence");

                entity.Property(e => e.SklId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);

                entity.HasOne(d => d.Skl)
                    .WithMany(p => p.Tsklelem)
                    .HasForeignKey(d => d.SklId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TSKLELEM_TSKL");
            });

            modelBuilder.Entity<SkillElementPerformanceCriteria>(entity =>
            {
                entity.HasKey(e => new { e.SklId, e.SklElemSqnbr, e.SklElemCrtSqnbr });

                entity.Property(e => e.SklId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);

                entity.HasOne(d => d.Skl)
                    .WithMany(p => p.Tsklelemcrt)
                    .HasForeignKey(d => new { d.SklId, d.SklElemSqnbr })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TSKLELEMCRT_TSKLELEM");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.HasComment("Session");

                entity.Property(e => e.SmstrId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Uid).IsUnicode(false);

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Dptmnt)
                    .WithMany(p => p.Tuser)
                    .HasForeignKey(d => d.DptmntId)
                    .HasConstraintName("FK_TUSER_TDPTMNT");
            });

            modelBuilder.Entity<UserAvailability>(entity =>
            {
                entity.HasKey(e => new { e.Uid, e.UserAvlSqnbr });

                entity.Property(e => e.Uid).IsUnicode(false);

                entity.Property(e => e.UserAvlSqnbr).ValueGeneratedOnAdd();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Tuseravl)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TUSERAVL_TUSER");
            });

            modelBuilder.Entity<User_Role>(entity =>
            {
                entity.HasKey(e => new { e.Uid, e.RoleId });

                entity.Property(e => e.Uid).IsUnicode(false);

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

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

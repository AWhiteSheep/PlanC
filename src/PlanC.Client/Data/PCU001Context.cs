using System;
using Microsoft.EntityFrameworkCore;
using PlanC.EntityDataModel;

namespace PlanC.Client.Data
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

        public virtual DbSet<CategoriesProgrammes> CategoriesProgrammes { get; set; }
        public virtual DbSet<CompetenceContextes> CompetenceContextes { get; set; }
        public virtual DbSet<Competences> Competences { get; set; }
        public virtual DbSet<CoursActivite> CoursActivite { get; set; }
        public virtual DbSet<CoursCompetenceElements> CoursCompetenceElements { get; set; }
        public virtual DbSet<CoursRequis> CoursRequis { get; set; }
        public virtual DbSet<CriteresElementCompetence> CriteresElementCompetence { get; set; }
        public virtual DbSet<Departements> Departements { get; set; }
        public virtual DbSet<DisponibilitesUtilisateur> DisponibilitesUtilisateur { get; set; }
        public virtual DbSet<ElementsCompetence> ElementsCompetence { get; set; }
        public virtual DbSet<Examens> Examens { get; set; }
        public virtual DbSet<ExamensCertificatifsNonsFinals> ExamensCertificatifsNonsFinals { get; set; }
        public virtual DbSet<ExamensElementsCompetences> ExamensElementsCompetences { get; set; }
        public virtual DbSet<ExamensFinalsCertificatifs> ExamensFinalsCertificatifs { get; set; }
        public virtual DbSet<MaterielsCours> MaterielsCours { get; set; }
        public virtual DbSet<PlanCadreCompetenceElements> PlanCadreCompetenceElements { get; set; }
        public virtual DbSet<PlansCadres> PlansCadres { get; set; }
        public virtual DbSet<PlansCours> PlansCours { get; set; }
        public virtual DbSet<ProgrammeCompetences> ProgrammeCompetences { get; set; }
        public virtual DbSet<ProgrammeDepartementView> ProgrammeDepartementView { get; set; }
        public virtual DbSet<Programmes> Programmes { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RolesUtilisateur> RolesUtilisateur { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<TypesFormationsProgrammes> TypesFormationsProgrammes { get; set; }
        public virtual DbSet<Utilisateurs> Utilisateurs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=database-1.cai5lbxs9ofy.us-east-1.rds.amazonaws.com,1433;User ID=dbo802668235;Password=Nemesis2123%*;Initial Catalog=PCU001;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriesProgrammes>(entity =>
            {
                entity.HasKey(e => e.CategorieId)
                    .HasName("PK_TCDTY");

                entity.Property(e => e.CategorieId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TrkUid).IsUnicode(false);
            });

            modelBuilder.Entity<CompetenceContextes>(entity =>
            {
                entity.HasKey(e => new { e.IdentityKeyCompetence, e.ContexteId })
                    .HasName("PK__Context_Competence");

                entity.Property(e => e.ContexteId).ValueGeneratedOnAdd();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdentityKeyCompetenceNavigation)
                    .WithMany(p => p.CompetenceContextes)
                    .HasForeignKey(d => d.IdentityKeyCompetence)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Competenc__Ident__68687968");
            });

            modelBuilder.Entity<Competences>(entity =>
            {
                entity.HasKey(e => e.IdentityKey)
                    .HasName("PK__tmp_ms_x__796424B81FB8FA6E");

                entity.HasComment("Compétence");

                entity.Property(e => e.AttitudeAttendu).HasDefaultValueSql("('(la description d''une ou plusieurs attitudes est attendue.)')");

                entity.Property(e => e.CompetenceId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NombreParties).HasDefaultValueSql("((1))");

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);

                entity.HasOne(d => d.Discipline)
                    .WithMany(p => p.Competences)
                    .HasForeignKey(d => d.DisciplineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TSKL_TDPMNT");
            });

            modelBuilder.Entity<CoursActivite>(entity =>
            {
                entity.HasKey(e => e.Identity)
                    .HasName("PK__tmp_ms_x__6E2BA98B3D6EAA7F")
                    .IsClustered(false);

                entity.HasComment("Calendrier des activités");

                entity.HasIndex(e => new { e.CoursId, e.TchrUid, e.PlnVsnCdttm, e.SessionId, e.ActvtSqnbr })
                    .HasName("PK_TCRSACTVT")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.ActvtLgnth).HasComment("Nombre de semaines consacrées à cette activité");

                entity.Property(e => e.CoursId)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SessionId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TchrUid).IsUnicode(false);

                entity.Property(e => e.TrkUid).IsUnicode(false);

                entity.HasOne(d => d.PlansCours)
                    .WithMany(p => p.CoursActivite)
                    .HasForeignKey(d => new { d.CoursId, d.TchrUid, d.PlnVsnCdttm, d.SessionId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCRSACTVT_TCRSPLN");
            });

            modelBuilder.Entity<CoursCompetenceElements>(entity =>
            {
                entity.HasKey(e => new { e.IdentityCritereElementCompetence, e.IdendityCoursActivity, e.AcitiviteSqnbr })
                    .HasName("PK_TACTELEM");

                entity.HasComment("Association activité -- élément de compétence");

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);

                entity.HasOne(d => d.IdendityCoursActivityNavigation)
                    .WithMany(p => p.CoursCompetenceElements)
                    .HasForeignKey(d => d.IdendityCoursActivity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CoursComp__Idend__3F6663D5");

                entity.HasOne(d => d.IdentityCritereElementCompetenceNavigation)
                    .WithMany(p => p.CoursCompetenceElements)
                    .HasForeignKey(d => d.IdentityCritereElementCompetence)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CoursComp__Ident__3E723F9C");
            });

            modelBuilder.Entity<CoursRequis>(entity =>
            {
                entity.HasKey(e => new { e.CoursId, e.VsnCdttm, e.CoursRequisId })
                    .HasName("PK_TCRSREQ");

                entity.HasComment("Prérequis; corequis");

                entity.Property(e => e.CoursId)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.CoursRequisId).IsFixedLength();

                entity.Property(e => e.CrsReqTyCd)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);

                entity.HasOne(d => d.PlansCadres)
                    .WithMany(p => p.CoursRequis)
                    .HasForeignKey(d => new { d.CoursId, d.VsnCdttm })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCRSREQ_TCRSTMPLT");
            });

            modelBuilder.Entity<CriteresElementCompetence>(entity =>
            {
                entity.HasKey(e => e.IdentityKey)
                    .HasName("PK__tmp_ms_x__796424B8AC031FFF");

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ANO')");

                entity.HasOne(d => d.ElementCompetence)
                    .WithMany(p => p.CriteresElementCompetence)
                    .HasForeignKey(d => d.ElementCompetenceId)
                    .HasConstraintName("FK__CriteresE__Eleme__70FDBF69");
            });

            modelBuilder.Entity<Departements>(entity =>
            {
                entity.HasComment("Département");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);
            });

            modelBuilder.Entity<DisponibilitesUtilisateur>(entity =>
            {
                entity.HasKey(e => new { e.Uid, e.UserAvlSqnbr })
                    .HasName("PK_TUSERAVL");

                entity.Property(e => e.Uid).IsUnicode(false);

                entity.Property(e => e.UserAvlSqnbr).ValueGeneratedOnAdd();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.DisponibilitesUtilisateur)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TUSERAVL_TUSER");
            });

            modelBuilder.Entity<ElementsCompetence>(entity =>
            {
                entity.HasComment("Élément de compétence");

                entity.HasIndex(e => new { e.IdentityKeyCompetences, e.ElementCompetenceSqnbr })
                    .HasName("unique_TSKLELEM")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ElementCompetenceSqnbr).ValueGeneratedOnAdd();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);

                entity.HasOne(d => d.IdentityKeyCompetencesNavigation)
                    .WithMany(p => p.ElementsCompetence)
                    .HasForeignKey(d => d.IdentityKeyCompetences)
                    .HasConstraintName("FK__ElementsC__Ident__6A50C1DA");
            });

            modelBuilder.Entity<Examens>(entity =>
            {
                entity.HasComment("Entité de base pour un examen");

                entity.Property(e => e.Id).UseIdentityColumn();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);

                entity.Property(e => e.TypeExamenCode)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ExamensCertificatifsNonsFinals>(entity =>
            {
                entity.HasKey(e => new { e.CoursId, e.TchrUid, e.PlnVsnCdttm, e.SessionId, e.ExamenId })
                    .HasName("PK_TCERTEXAM");

                entity.HasComment("Examen certificatif");

                entity.Property(e => e.CoursId)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.TchrUid).IsUnicode(false);

                entity.Property(e => e.SessionId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);

                entity.HasOne(d => d.Examen)
                    .WithMany(p => p.ExamensCertificatifsNonsFinals)
                    .HasForeignKey(d => d.ExamenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCERTEXAM_TEXAM");

                entity.HasOne(d => d.PlansCours)
                    .WithMany(p => p.ExamensCertificatifsNonsFinals)
                    .HasForeignKey(d => new { d.CoursId, d.TchrUid, d.PlnVsnCdttm, d.SessionId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCERTEXAM_TCRSPLN");
            });

            modelBuilder.Entity<ExamensElementsCompetences>(entity =>
            {
                entity.HasKey(e => e.IdentityKey)
                    .HasName("PK__tmp_ms_x__796424B81103DB33");

                entity.HasComment("Association examen -- élément de compétence");

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ElementCompetence)
                    .WithMany(p => p.ExamensElementsCompetences)
                    .HasForeignKey(d => d.ElementCompetenceId)
                    .HasConstraintName("FK__ExamensEl__Eleme__60C757A0");

                entity.HasOne(d => d.Examen)
                    .WithMany(p => p.ExamensElementsCompetences)
                    .HasForeignKey(d => d.ExamenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TEXAMSKLELEM_TEXAM");
            });

            modelBuilder.Entity<ExamensFinalsCertificatifs>(entity =>
            {
                entity.HasKey(e => new { e.CoursId, e.VsnCdttm, e.ExamenId })
                    .HasName("PK_TFNLEXAM");

                entity.HasComment("Examen certificatif final");

                entity.Property(e => e.CoursId)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);

                entity.HasOne(d => d.Examen)
                    .WithMany(p => p.ExamensFinalsCertificatifs)
                    .HasForeignKey(d => d.ExamenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TFNLEXAM_TEXAM");

                entity.HasOne(d => d.PlansCadres)
                    .WithMany(p => p.ExamensFinalsCertificatifs)
                    .HasForeignKey(d => new { d.CoursId, d.VsnCdttm })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TFNLEXAM_TCRSTMPLT");
            });

            modelBuilder.Entity<MaterielsCours>(entity =>
            {
                entity.HasKey(e => new { e.CoursId, e.TchrUid, e.PlnVsnCdttm, e.SessionId, e.MaterielSqnbr })
                    .HasName("PK_TCRSMTRL");

                entity.HasComment("Matériel requis");

                entity.Property(e => e.CoursId)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.TchrUid).IsUnicode(false);

                entity.Property(e => e.SessionId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);

                entity.HasOne(d => d.PlansCours)
                    .WithMany(p => p.MaterielsCours)
                    .HasForeignKey(d => new { d.CoursId, d.TchrUid, d.PlnVsnCdttm, d.SessionId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCRSMTRL_TCRSPLN");
            });

            modelBuilder.Entity<PlanCadreCompetenceElements>(entity =>
            {
                entity.HasKey(e => e.IdentityKey)
                    .HasName("PK__tmp_ms_x__796424B8098CBD08");

                entity.HasComment("Association plan-cadre -- élément de compétence");

                entity.Property(e => e.CoursId)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.ElementCompetenceId).HasDefaultValueSql("('1F19D42E-3929-487B-9551-FA4C67EC6951')");

                entity.Property(e => e.PrtlSklInd)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);

                entity.Property(e => e.TxnmyCd)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.ElementCompetence)
                    .WithMany(p => p.PlanCadreCompetenceElements)
                    .HasForeignKey(d => d.ElementCompetenceId)
                    .HasConstraintName("FK__PlanCadre__Eleme__5EDF0F2E");

                entity.HasOne(d => d.PlansCadres)
                    .WithMany(p => p.PlanCadreCompetenceElements)
                    .HasForeignKey(d => new { d.CoursId, d.VsnCdttm })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TTMPLTSKLELEM_TCRSTMPLT");
            });

            modelBuilder.Entity<PlansCadres>(entity =>
            {
                entity.HasKey(e => new { e.CoursId, e.VsnCdttm })
                    .HasName("PK_TCRSTMPLT");

                entity.HasComment("Plan-cadre");

                entity.Property(e => e.CoursId)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.ProgrammeId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);
            });

            modelBuilder.Entity<PlansCours>(entity =>
            {
                entity.HasKey(e => new { e.CoursId, e.TchrUid, e.PlnVsnCdttm, e.SessionId })
                    .HasName("PK_TCRSPLN");

                entity.HasComment("Plan de cours");

                entity.Property(e => e.CoursId)
                    .IsFixedLength()
                    .HasComment("Code d'identification d'un cours");

                entity.Property(e => e.TchrUid).IsUnicode(false);

                entity.Property(e => e.SessionId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.PlansCours)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCRSPLN_TSMSTR");
            });

            modelBuilder.Entity<ProgrammeCompetences>(entity =>
            {
                entity.HasKey(e => new { e.ProgrammeId, e.DepartementId, e.CompetenceId })
                    .HasName("PK__R_SKL_PG__D129735B0D074A76");

                entity.Property(e => e.ProgrammeId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompetenceId)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Programmes)
                    .WithMany(p => p.ProgrammeCompetences)
                    .HasForeignKey(d => new { d.ProgrammeId, d.DepartementId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_R_SKL_PGM__PGM");
            });

            modelBuilder.Entity<ProgrammeDepartementView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ProgrammeDepartementView");
            });

            modelBuilder.Entity<Programmes>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.DepartementId })
                    .HasName("PK__tmp_ms_x__CEB445A66DF6DB7C");

                entity.HasComment("Programme d'études");

                entity.Property(e => e.Id)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CodeType)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);

                entity.Property(e => e.TypeDegreFormation)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.CodeTypeNavigation)
                    .WithMany(p => p.Programmes)
                    .HasForeignKey(d => d.CodeType)
                    .HasConstraintName("FK_TPGM_TCDTY");

                entity.HasOne(d => d.Departement)
                    .WithMany(p => p.Programmes)
                    .HasForeignKey(d => d.DepartementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TPGM_TDPTMNT");

                entity.HasOne(d => d.TypeDegreFormationNavigation)
                    .WithMany(p => p.Programmes)
                    .HasForeignKey(d => d.TypeDegreFormation)
                    .HasConstraintName("FK_TPGM_TPMGFORMTYPE");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Titre).IsUnicode(false);
            });

            modelBuilder.Entity<RolesUtilisateur>(entity =>
            {
                entity.HasKey(e => new { e.UtilisateurId, e.RoleId })
                    .HasName("PK_TUSERROLE");

                entity.Property(e => e.UtilisateurId).IsUnicode(false);

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolesUtilisateur)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TUSERROLE_TROLE");

                entity.HasOne(d => d.Utilisateur)
                    .WithMany(p => p.RolesUtilisateur)
                    .HasForeignKey(d => d.UtilisateurId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TUSERROLE_TUSER");
            });

            modelBuilder.Entity<Sessions>(entity =>
            {
                entity.HasComment("Session");

                entity.Property(e => e.Id)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrkUid).IsUnicode(false);
            });

            modelBuilder.Entity<TypesFormationsProgrammes>(entity =>
            {
                entity.Property(e => e.Id)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Utilisateurs>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.RcdCdttm).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Departement)
                    .WithMany(p => p.Utilisateurs)
                    .HasForeignKey(d => d.DepartementId)
                    .HasConstraintName("FK_TUSER_TDPTMNT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

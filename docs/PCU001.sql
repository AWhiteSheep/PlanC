USE [PCU001]
GO
/****** Object:  Table [dbo].[Programmes]    Script Date: 2019-12-08 00:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Programmes](
	[ID] [char](6) NOT NULL,
	[DepartementID] [int] NOT NULL,
	[Designation] [nvarchar](50) NULL,
	[Description] [ntext] NULL,
	[ProgrammePDF] [ntext] NULL,
	[ProgrammeIMG] [nvarchar](max) NULL,
	[CodeType] [char](2) NULL,
	[NombreCompetencesObligatoires] [int] NULL,
	[NombreCompetencesOptionnelles] [int] NULL,
	[NombreCompetencesComplementaires] [int] NULL,
	[TypeDegreFormation] [char](3) NULL,
	[RCD_CDTTM] [datetime] NULL,
	[TRK_UID] [varchar](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[DepartementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departements]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departements](
	[ID] [int] NOT NULL,
	[Titre] [nvarchar](250) NULL,
	[Politique] [ntext] NULL,
	[RCD_CDTTM] [datetime] NULL,
	[TRK_UID] [varchar](7) NULL,
 CONSTRAINT [PK_TDPTMNT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[ProgrammeDepartementView]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ProgrammeDepartementView]
	AS SELECT Programmes.Designation, Departements.Titre FROM Programmes left join Departements
	on DepartementID = Departements.ID
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](7) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [varchar](7) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [varchar](7) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[UserName] [nvarchar](7) NOT NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[DepartementID] [int] NULL,
	[GVN_NM] [nvarchar](50) NULL,
	[SNM] [nvarchar](50) NULL,
	[RCD_CDTTM] [datetime] NULL,
	[Id] [nvarchar](100) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [varchar](7) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoriesProgrammes]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriesProgrammes](
	[CategorieID] [char](2) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[TRK_UID] [varchar](7) NULL,
	[RCD_CDTTM] [datetime] NULL,
 CONSTRAINT [PK_TCDTY] PRIMARY KEY CLUSTERED 
(
	[CategorieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompetenceContextes]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompetenceContextes](
	[IdentityKeyCompetence] [int] NOT NULL,
	[ContexteID] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[RCD_CDTTM] [datetime] NULL,
 CONSTRAINT [PK__Context_Competence] PRIMARY KEY CLUSTERED 
(
	[IdentityKeyCompetence] ASC,
	[ContexteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Competences]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Competences](
	[IdentityKey] [int] IDENTITY(0,1) NOT NULL,
	[CompetenceID] [char](4) NOT NULL,
	[DisciplineID] [int] NOT NULL,
	[Enonce] [nvarchar](200) NOT NULL,
	[AttitudeAttendu] [ntext] NOT NULL,
	[NombreParties] [int] NOT NULL,
	[CompetenceComplementaire] [bit] NULL,
	[RCD_CDTTM] [datetime] NULL,
	[TRK_UID] [varchar](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdentityKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CoursActivite]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoursActivite](
	[Identity] [int] IDENTITY(0,1) NOT NULL,
	[CoursID] [nchar](10) NOT NULL,
	[TCHR_UID] [varchar](7) NOT NULL,
	[PLN_VSN_CDTTM] [datetime] NOT NULL,
	[SessionID] [char](3) NOT NULL,
	[ACTVT_SQNBR] [smallint] NOT NULL,
	[ACTVT_LGNTH] [smallint] NULL,
	[ACTVT_DESC] [ntext] NULL,
	[RCD_CDTTM] [datetime] NULL,
	[TRK_UID] [varchar](7) NULL,
PRIMARY KEY NONCLUSTERED 
(
	[Identity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [PK_TCRSACTVT] UNIQUE CLUSTERED 
(
	[CoursID] ASC,
	[TCHR_UID] ASC,
	[PLN_VSN_CDTTM] ASC,
	[SessionID] ASC,
	[ACTVT_SQNBR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CoursCompetenceElements]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoursCompetenceElements](
	[IdentityCritereElementCompetence] [int] NOT NULL,
	[IdendityCoursActivity] [int] NOT NULL,
	[AcitiviteSQNBR] [int] NOT NULL,
	[RCD_CDTTM] [datetime] NULL,
	[TRK_UID] [varchar](7) NULL,
 CONSTRAINT [PK_TACTELEM] PRIMARY KEY CLUSTERED 
(
	[IdentityCritereElementCompetence] ASC,
	[IdendityCoursActivity] ASC,
	[AcitiviteSQNBR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CoursRequis]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoursRequis](
	[CoursID] [nchar](10) NOT NULL,
	[VSN_CDTTM] [datetime] NOT NULL,
	[CoursRequisID] [nchar](10) NOT NULL,
	[RCD_CDTTM] [datetime] NULL,
	[CRS_REQ_TY_CD] [char](2) NULL,
	[TRK_UID] [varchar](7) NULL,
 CONSTRAINT [PK_TCRSREQ] PRIMARY KEY CLUSTERED 
(
	[CoursID] ASC,
	[VSN_CDTTM] ASC,
	[CoursRequisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CriteresElementCompetence]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CriteresElementCompetence](
	[IdentityKey] [int] IDENTITY(0,1) NOT NULL,
	[ElementCompetenceId] [nvarchar](100) NOT NULL,
	[CritereElementCompetenceSQNBR] [int] NOT NULL,
	[DescriptionCritere] [nvarchar](max) NULL,
	[RCD_CDTTM] [datetime] NOT NULL,
	[TRK_UID] [varchar](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdentityKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DisponibilitesUtilisateur]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DisponibilitesUtilisateur](
	[UID] [varchar](7) NOT NULL,
	[USER_AVL_SQNBR] [int] IDENTITY(1,1) NOT NULL,
	[WEEKDAY_NBR] [int] NOT NULL,
	[AVL_STM] [time](7) NOT NULL,
	[AVL_NTM] [time](7) NOT NULL,
	[RCD_CDTTM] [datetime] NULL,
 CONSTRAINT [PK_TUSERAVL] PRIMARY KEY CLUSTERED 
(
	[UID] ASC,
	[USER_AVL_SQNBR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ElementsCompetence]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ElementsCompetence](
	[ID] [nvarchar](100) NOT NULL,
	[IdentityKeyCompetences] [int] NOT NULL,
	[ElementCompetenceSQNBR] [int] IDENTITY(1,1) NOT NULL,
	[Libele] [nvarchar](255) NULL,
	[Description] [ntext] NULL,
	[RCD_CDTTM] [datetime] NULL,
	[TRK_UID] [varchar](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unique_TSKLELEM] UNIQUE NONCLUSTERED 
(
	[IdentityKeyCompetences] ASC,
	[ElementCompetenceSQNBR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Examens]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Examens](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TypeExamenCode] [char](2) NULL,
	[Qualification] [nvarchar](150) NULL,
	[PoidExamen] [decimal](5, 2) NULL,
	[RCD_CDTTM] [datetime] NULL,
	[TRK_UID] [varchar](7) NULL,
 CONSTRAINT [PK_TEXAM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamensCertificatifsNonsFinals]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamensCertificatifsNonsFinals](
	[CoursID] [nchar](10) NOT NULL,
	[TCHR_UID] [varchar](7) NOT NULL,
	[PLN_VSN_CDTTM] [datetime] NOT NULL,
	[SessionID] [char](3) NOT NULL,
	[ExamenID] [int] NOT NULL,
	[RCD_CDTTM] [datetime] NULL,
	[TRK_UID] [varchar](7) NULL,
 CONSTRAINT [PK_TCERTEXAM] PRIMARY KEY CLUSTERED 
(
	[CoursID] ASC,
	[TCHR_UID] ASC,
	[PLN_VSN_CDTTM] ASC,
	[SessionID] ASC,
	[ExamenID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamensElementsCompetences]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamensElementsCompetences](
	[IdentityKey] [int] IDENTITY(0,1) NOT NULL,
	[ExamenID] [int] NOT NULL,
	[ElementCompetenceId] [nvarchar](100) NULL,
	[RCD_CDTTM] [datetime] NULL,
	[PoidElement] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdentityKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamensFinalsCertificatifs]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamensFinalsCertificatifs](
	[CoursID] [nchar](10) NOT NULL,
	[VSN_CDTTM] [datetime] NOT NULL,
	[ExamenID] [int] NOT NULL,
	[RCD_CDTTM] [datetime] NULL,
	[TRK_UID] [varchar](7) NULL,
 CONSTRAINT [PK_TFNLEXAM] PRIMARY KEY CLUSTERED 
(
	[CoursID] ASC,
	[VSN_CDTTM] ASC,
	[ExamenID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterielsCours]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterielsCours](
	[CoursID] [nchar](10) NOT NULL,
	[TCHR_UID] [varchar](7) NOT NULL,
	[PLN_VSN_CDTTM] [datetime] NOT NULL,
	[SessionID] [char](3) NOT NULL,
	[MaterielSQNBR] [smallint] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[RCD_CDTTM] [datetime] NULL,
	[TRK_UID] [varchar](7) NULL,
 CONSTRAINT [PK_TCRSMTRL] PRIMARY KEY CLUSTERED 
(
	[CoursID] ASC,
	[TCHR_UID] ASC,
	[PLN_VSN_CDTTM] ASC,
	[SessionID] ASC,
	[MaterielSQNBR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlanCadreCompetenceElements]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanCadreCompetenceElements](
	[IdentityKey] [int] IDENTITY(0,1) NOT NULL,
	[CoursID] [nchar](10) NOT NULL,
	[ElementCompetenceId] [nvarchar](100) NULL,
	[PRTL_SKL_IND] [char](1) NULL,
	[TXNMY_CD] [char](2) NULL,
	[LongDescription] [ntext] NULL,
	[VSN_CDTTM] [datetime] NOT NULL,
	[RCD_CDTTM] [datetime] NULL,
	[TRK_UID] [varchar](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdentityKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlansCadres]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlansCadres](
	[CoursID] [nchar](10) NOT NULL,
	[VSN_CDTTM] [datetime] NOT NULL,
	[ProgrammeID] [char](6) NULL,
	[DenominationCours] [nvarchar](50) NULL,
	[Unites] [decimal](3, 2) NULL,
	[Description] [ntext] NULL,
	[IntentionEducative] [ntext] NULL,
	[IntentionPedagogique] [ntext] NULL,
	[HeuresTotalesTheorie] [int] NULL,
	[HeuresTotalesPratique] [int] NULL,
	[HeuresTotalesMaison] [int] NULL,
	[DateApprobationDepartement] [date] NULL,
	[DateApprobationCommite] [date] NULL,
	[DateApprobationCadre] [date] NULL,
	[TRK_UID] [varchar](7) NULL,
	[RCD_CDTTM] [datetime] NULL,
 CONSTRAINT [PK_TCRSTMPLT] PRIMARY KEY CLUSTERED 
(
	[CoursID] ASC,
	[VSN_CDTTM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlansCours]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlansCours](
	[CoursID] [nchar](10) NOT NULL,
	[TCHR_UID] [varchar](7) NOT NULL,
	[PLN_VSN_CDTTM] [datetime] NOT NULL,
	[SessionID] [char](3) NOT NULL,
	[RCD_CDTTM] [datetime] NULL,
	[TRK_UID] [varchar](7) NULL,
 CONSTRAINT [PK_TCRSPLN] PRIMARY KEY CLUSTERED 
(
	[CoursID] ASC,
	[TCHR_UID] ASC,
	[PLN_VSN_CDTTM] ASC,
	[SessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgrammeCompetences]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgrammeCompetences](
	[ProgrammeID] [char](6) NOT NULL,
	[DepartementID] [int] NOT NULL,
	[CompetenceID] [char](4) NOT NULL,
	[CompetenceEstRequise] [bit] NOT NULL,
	[CompetenceEstComplentaire] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProgrammeID] ASC,
	[DepartementID] ASC,
	[CompetenceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sessions]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sessions](
	[ID] [char](3) NOT NULL,
	[Titre] [nvarchar](50) NULL,
	[Debut] [date] NULL,
	[Fin] [date] NULL,
	[RCD_CDTTM] [datetime] NULL,
	[TRK_UID] [varchar](7) NULL,
 CONSTRAINT [PK_TSMSTR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypesFormationsProgrammes]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypesFormationsProgrammes](
	[ID] [char](3) NOT NULL,
	[Designation] [nvarchar](60) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utilisateurs]    Script Date: 2019-12-08 00:01:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilisateurs](
	[ID] [varchar](7) NOT NULL,
	[DepartementID] [int] NULL,
	[GVN_NM] [nvarchar](50) NULL,
	[SNM] [nvarchar](50) NULL,
	[RCD_CDTTM] [datetime] NULL,
 CONSTRAINT [PK_TUSER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  CONSTRAINT [DF__AspNetUse__RCD_C__1DD065E0]  DEFAULT (getdate()) FOR [RCD_CDTTM]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  CONSTRAINT [DF_AspNetUsers_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[CompetenceContextes] ADD  CONSTRAINT [DF_TSKLCNT_RCD_CDTTM]  DEFAULT (getdate()) FOR [RCD_CDTTM]
GO
ALTER TABLE [dbo].[Competences] ADD  DEFAULT ('(la description d''une ou plusieurs attitudes est attendue.)') FOR [AttitudeAttendu]
GO
ALTER TABLE [dbo].[Competences] ADD  DEFAULT ((1)) FOR [NombreParties]
GO
ALTER TABLE [dbo].[Competences] ADD  CONSTRAINT [DF_TSKL_RCD_CDTTM]  DEFAULT (getdate()) FOR [RCD_CDTTM]
GO
ALTER TABLE [dbo].[CoursActivite] ADD  CONSTRAINT [DF_TCRSACTVT_RCD_CDTTM]  DEFAULT (getdate()) FOR [RCD_CDTTM]
GO
ALTER TABLE [dbo].[CoursCompetenceElements] ADD  CONSTRAINT [DF_TACTELEM_RCD_CDTTM]  DEFAULT (getdate()) FOR [RCD_CDTTM]
GO
ALTER TABLE [dbo].[CoursRequis] ADD  CONSTRAINT [DF_TCRSREQ_RCD_CDTTM]  DEFAULT (getdate()) FOR [RCD_CDTTM]
GO
ALTER TABLE [dbo].[CriteresElementCompetence] ADD  CONSTRAINT [DF_TSKLELEMCRT_RCD_CDTTM]  DEFAULT (getdate()) FOR [RCD_CDTTM]
GO
ALTER TABLE [dbo].[CriteresElementCompetence] ADD  DEFAULT ('ANO') FOR [TRK_UID]
GO
ALTER TABLE [dbo].[Departements] ADD  CONSTRAINT [DF_TDPTMNT_RCD_CDTTM]  DEFAULT (getdate()) FOR [RCD_CDTTM]
GO
ALTER TABLE [dbo].[DisponibilitesUtilisateur] ADD  CONSTRAINT [DF_TUSERAVL_RCD_CDTTM]  DEFAULT (getdate()) FOR [RCD_CDTTM]
GO
ALTER TABLE [dbo].[ElementsCompetence] ADD  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[ElementsCompetence] ADD  CONSTRAINT [DF_TSKLELEM_RCD_CDTTM]  DEFAULT (getdate()) FOR [RCD_CDTTM]
GO
ALTER TABLE [dbo].[Examens] ADD  CONSTRAINT [DF_TEXAM_RCD_CDTTM]  DEFAULT (getdate()) FOR [RCD_CDTTM]
GO
ALTER TABLE [dbo].[ExamensCertificatifsNonsFinals] ADD  CONSTRAINT [DF_TCERTEXAM_RCD_CDTTM]  DEFAULT (getdate()) FOR [RCD_CDTTM]
GO
ALTER TABLE [dbo].[ExamensElementsCompetences] ADD  CONSTRAINT [DF_TEXAMSKLELEM_RCD_CDTTM]  DEFAULT (getdate()) FOR [RCD_CDTTM]
GO
ALTER TABLE [dbo].[ExamensFinalsCertificatifs] ADD  CONSTRAINT [DF_TFNLEXAM_RCD_CDTTM]  DEFAULT (getdate()) FOR [RCD_CDTTM]
GO
ALTER TABLE [dbo].[MaterielsCours] ADD  CONSTRAINT [DF_TCRSMTRL_RCD_CDTTM]  DEFAULT (getdate()) FOR [RCD_CDTTM]
GO
ALTER TABLE [dbo].[PlanCadreCompetenceElements] ADD  DEFAULT ('1F19D42E-3929-487B-9551-FA4C67EC6951') FOR [ElementCompetenceId]
GO
ALTER TABLE [dbo].[PlanCadreCompetenceElements] ADD  CONSTRAINT [DF_TCRSSKLELEM_RCD_CDTTM]  DEFAULT (getdate()) FOR [RCD_CDTTM]
GO
ALTER TABLE [dbo].[PlansCadres] ADD  CONSTRAINT [DF_TCRSTMPLT_RCD_CDTTM]  DEFAULT (getdate()) FOR [RCD_CDTTM]
GO
ALTER TABLE [dbo].[PlansCours] ADD  CONSTRAINT [DF_TCRSPLN_RCD_CDTTM]  DEFAULT (getdate()) FOR [RCD_CDTTM]
GO
ALTER TABLE [dbo].[ProgrammeCompetences] ADD  DEFAULT ((0)) FOR [CompetenceEstRequise]
GO
ALTER TABLE [dbo].[ProgrammeCompetences] ADD  DEFAULT ((0)) FOR [CompetenceEstComplentaire]
GO
ALTER TABLE [dbo].[Programmes] ADD  CONSTRAINT [DF_TPGM_RCD_CDTTM]  DEFAULT (getdate()) FOR [RCD_CDTTM]
GO
ALTER TABLE [dbo].[Sessions] ADD  CONSTRAINT [DF_TSMSTR_RCD_CDTTM]  DEFAULT (getdate()) FOR [RCD_CDTTM]
GO
ALTER TABLE [dbo].[Utilisateurs] ADD  CONSTRAINT [DF_TUSER_RCD_CDTTM]  DEFAULT (getdate()) FOR [RCD_CDTTM]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_TASPUSER_TDPTMNT] FOREIGN KEY([DepartementID])
REFERENCES [dbo].[Departements] ([ID])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_TASPUSER_TDPTMNT]
GO
ALTER TABLE [dbo].[CompetenceContextes]  WITH CHECK ADD FOREIGN KEY([IdentityKeyCompetence])
REFERENCES [dbo].[Competences] ([IdentityKey])
GO
ALTER TABLE [dbo].[Competences]  WITH CHECK ADD  CONSTRAINT [FK_TSKL_TDPMNT] FOREIGN KEY([DisciplineID])
REFERENCES [dbo].[Departements] ([ID])
GO
ALTER TABLE [dbo].[Competences] CHECK CONSTRAINT [FK_TSKL_TDPMNT]
GO
ALTER TABLE [dbo].[CoursActivite]  WITH CHECK ADD  CONSTRAINT [FK_TCRSACTVT_TCRSPLN] FOREIGN KEY([CoursID], [TCHR_UID], [PLN_VSN_CDTTM], [SessionID])
REFERENCES [dbo].[PlansCours] ([CoursID], [TCHR_UID], [PLN_VSN_CDTTM], [SessionID])
GO
ALTER TABLE [dbo].[CoursActivite] CHECK CONSTRAINT [FK_TCRSACTVT_TCRSPLN]
GO
ALTER TABLE [dbo].[CoursCompetenceElements]  WITH CHECK ADD FOREIGN KEY([IdendityCoursActivity])
REFERENCES [dbo].[CoursActivite] ([Identity])
GO
ALTER TABLE [dbo].[CoursCompetenceElements]  WITH CHECK ADD FOREIGN KEY([IdentityCritereElementCompetence])
REFERENCES [dbo].[CriteresElementCompetence] ([IdentityKey])
GO
ALTER TABLE [dbo].[CoursRequis]  WITH CHECK ADD  CONSTRAINT [FK_TCRSREQ_TCRSTMPLT] FOREIGN KEY([CoursID], [VSN_CDTTM])
REFERENCES [dbo].[PlansCadres] ([CoursID], [VSN_CDTTM])
GO
ALTER TABLE [dbo].[CoursRequis] CHECK CONSTRAINT [FK_TCRSREQ_TCRSTMPLT]
GO
ALTER TABLE [dbo].[CriteresElementCompetence]  WITH CHECK ADD FOREIGN KEY([ElementCompetenceId])
REFERENCES [dbo].[ElementsCompetence] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DisponibilitesUtilisateur]  WITH CHECK ADD  CONSTRAINT [FK_TUSERAVL_TUSER] FOREIGN KEY([UID])
REFERENCES [dbo].[Utilisateurs] ([ID])
GO
ALTER TABLE [dbo].[DisponibilitesUtilisateur] CHECK CONSTRAINT [FK_TUSERAVL_TUSER]
GO
ALTER TABLE [dbo].[ElementsCompetence]  WITH CHECK ADD FOREIGN KEY([IdentityKeyCompetences])
REFERENCES [dbo].[Competences] ([IdentityKey])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExamensCertificatifsNonsFinals]  WITH CHECK ADD  CONSTRAINT [FK_TCERTEXAM_TCRSPLN] FOREIGN KEY([CoursID], [TCHR_UID], [PLN_VSN_CDTTM], [SessionID])
REFERENCES [dbo].[PlansCours] ([CoursID], [TCHR_UID], [PLN_VSN_CDTTM], [SessionID])
GO
ALTER TABLE [dbo].[ExamensCertificatifsNonsFinals] CHECK CONSTRAINT [FK_TCERTEXAM_TCRSPLN]
GO
ALTER TABLE [dbo].[ExamensCertificatifsNonsFinals]  WITH CHECK ADD  CONSTRAINT [FK_TCERTEXAM_TEXAM] FOREIGN KEY([ExamenID])
REFERENCES [dbo].[Examens] ([ID])
GO
ALTER TABLE [dbo].[ExamensCertificatifsNonsFinals] CHECK CONSTRAINT [FK_TCERTEXAM_TEXAM]
GO
ALTER TABLE [dbo].[ExamensElementsCompetences]  WITH CHECK ADD FOREIGN KEY([ElementCompetenceId])
REFERENCES [dbo].[ElementsCompetence] ([ID])
GO
ALTER TABLE [dbo].[ExamensElementsCompetences]  WITH CHECK ADD  CONSTRAINT [FK_TEXAMSKLELEM_TEXAM] FOREIGN KEY([ExamenID])
REFERENCES [dbo].[Examens] ([ID])
GO
ALTER TABLE [dbo].[ExamensElementsCompetences] CHECK CONSTRAINT [FK_TEXAMSKLELEM_TEXAM]
GO
ALTER TABLE [dbo].[ExamensFinalsCertificatifs]  WITH CHECK ADD  CONSTRAINT [FK_TFNLEXAM_TCRSTMPLT] FOREIGN KEY([CoursID], [VSN_CDTTM])
REFERENCES [dbo].[PlansCadres] ([CoursID], [VSN_CDTTM])
GO
ALTER TABLE [dbo].[ExamensFinalsCertificatifs] CHECK CONSTRAINT [FK_TFNLEXAM_TCRSTMPLT]
GO
ALTER TABLE [dbo].[ExamensFinalsCertificatifs]  WITH CHECK ADD  CONSTRAINT [FK_TFNLEXAM_TEXAM] FOREIGN KEY([ExamenID])
REFERENCES [dbo].[Examens] ([ID])
GO
ALTER TABLE [dbo].[ExamensFinalsCertificatifs] CHECK CONSTRAINT [FK_TFNLEXAM_TEXAM]
GO
ALTER TABLE [dbo].[MaterielsCours]  WITH CHECK ADD  CONSTRAINT [FK_TCRSMTRL_TCRSPLN] FOREIGN KEY([CoursID], [TCHR_UID], [PLN_VSN_CDTTM], [SessionID])
REFERENCES [dbo].[PlansCours] ([CoursID], [TCHR_UID], [PLN_VSN_CDTTM], [SessionID])
GO
ALTER TABLE [dbo].[MaterielsCours] CHECK CONSTRAINT [FK_TCRSMTRL_TCRSPLN]
GO
ALTER TABLE [dbo].[PlanCadreCompetenceElements]  WITH CHECK ADD FOREIGN KEY([ElementCompetenceId])
REFERENCES [dbo].[ElementsCompetence] ([ID])
GO
ALTER TABLE [dbo].[PlanCadreCompetenceElements]  WITH CHECK ADD  CONSTRAINT [FK_TTMPLTSKLELEM_TCRSTMPLT] FOREIGN KEY([CoursID], [VSN_CDTTM])
REFERENCES [dbo].[PlansCadres] ([CoursID], [VSN_CDTTM])
GO
ALTER TABLE [dbo].[PlanCadreCompetenceElements] CHECK CONSTRAINT [FK_TTMPLTSKLELEM_TCRSTMPLT]
GO
ALTER TABLE [dbo].[PlansCours]  WITH CHECK ADD  CONSTRAINT [FK_TCRSPLN_TSMSTR] FOREIGN KEY([SessionID])
REFERENCES [dbo].[Sessions] ([ID])
GO
ALTER TABLE [dbo].[PlansCours] CHECK CONSTRAINT [FK_TCRSPLN_TSMSTR]
GO
ALTER TABLE [dbo].[ProgrammeCompetences]  WITH CHECK ADD  CONSTRAINT [FK_R_SKL_PGM__PGM] FOREIGN KEY([ProgrammeID], [DepartementID])
REFERENCES [dbo].[Programmes] ([ID], [DepartementID])
GO
ALTER TABLE [dbo].[ProgrammeCompetences] CHECK CONSTRAINT [FK_R_SKL_PGM__PGM]
GO
ALTER TABLE [dbo].[Programmes]  WITH CHECK ADD  CONSTRAINT [FK_TPGM_TCDTY] FOREIGN KEY([CodeType])
REFERENCES [dbo].[CategoriesProgrammes] ([CategorieID])
GO
ALTER TABLE [dbo].[Programmes] CHECK CONSTRAINT [FK_TPGM_TCDTY]
GO
ALTER TABLE [dbo].[Programmes]  WITH CHECK ADD  CONSTRAINT [FK_TPGM_TDPTMNT] FOREIGN KEY([DepartementID])
REFERENCES [dbo].[Departements] ([ID])
GO
ALTER TABLE [dbo].[Programmes] CHECK CONSTRAINT [FK_TPGM_TDPTMNT]
GO
ALTER TABLE [dbo].[Programmes]  WITH CHECK ADD  CONSTRAINT [FK_TPGM_TPMGFORMTYPE] FOREIGN KEY([TypeDegreFormation])
REFERENCES [dbo].[TypesFormationsProgrammes] ([ID])
GO
ALTER TABLE [dbo].[Programmes] CHECK CONSTRAINT [FK_TPGM_TPMGFORMTYPE]
GO
ALTER TABLE [dbo].[Utilisateurs]  WITH CHECK ADD  CONSTRAINT [FK_TUSER_TDPTMNT] FOREIGN KEY([DepartementID])
REFERENCES [dbo].[Departements] ([ID])
GO
ALTER TABLE [dbo].[Utilisateurs] CHECK CONSTRAINT [FK_TUSER_TDPTMNT]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Compétence' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Competences'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code d''identification d''un cours' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CoursActivite', @level2type=N'COLUMN',@level2name=N'CoursID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de semaines consacrées à cette activité' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CoursActivite', @level2type=N'COLUMN',@level2name=N'ACTVT_LGNTH'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Calendrier des activités' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CoursActivite'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Association activité -- élément de compétence' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CoursCompetenceElements'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code d''identification d''un cours' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CoursRequis', @level2type=N'COLUMN',@level2name=N'CoursID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Prérequis; corequis' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CoursRequis'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Département' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Departements'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Élément de compétence' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ElementsCompetence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Entité de base pour un examen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Examens'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code d''identification d''un cours' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExamensCertificatifsNonsFinals', @level2type=N'COLUMN',@level2name=N'CoursID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Examen certificatif' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExamensCertificatifsNonsFinals'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Association examen -- élément de compétence' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExamensElementsCompetences'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code d''identification d''un cours' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExamensFinalsCertificatifs', @level2type=N'COLUMN',@level2name=N'CoursID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Examen certificatif final' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExamensFinalsCertificatifs'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code d''identification d''un cours' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaterielsCours', @level2type=N'COLUMN',@level2name=N'CoursID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Matériel requis' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MaterielsCours'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code d''identification d''un cours' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlanCadreCompetenceElements', @level2type=N'COLUMN',@level2name=N'CoursID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Association plan-cadre -- élément de compétence' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlanCadreCompetenceElements'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code d''identification d''un cours' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlansCadres', @level2type=N'COLUMN',@level2name=N'CoursID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Plan-cadre' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlansCadres'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code d''identification d''un cours' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlansCours', @level2type=N'COLUMN',@level2name=N'CoursID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Plan de cours' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlansCours'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Programme d''études' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Programmes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Session' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sessions'
GO

USE [master]
GO
/****** Object:  Database [PCU001]    Script Date: 2019-12-20 16:46:27 ******/
CREATE DATABASE [PCU001]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PCU001', FILENAME = N'D:\rdsdbdata\DATA\PCU001.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PCU001_log', FILENAME = N'D:\rdsdbdata\DATA\PCU001_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PCU001] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PCU001].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PCU001] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PCU001] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PCU001] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PCU001] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PCU001] SET ARITHABORT OFF 
GO
ALTER DATABASE [PCU001] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PCU001] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PCU001] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PCU001] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PCU001] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PCU001] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PCU001] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PCU001] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PCU001] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PCU001] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PCU001] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PCU001] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PCU001] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PCU001] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PCU001] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PCU001] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PCU001] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PCU001] SET RECOVERY FULL 
GO
ALTER DATABASE [PCU001] SET  MULTI_USER 
GO
ALTER DATABASE [PCU001] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PCU001] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PCU001] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PCU001] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PCU001] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PCU001] SET QUERY_STORE = OFF
GO
USE [PCU001]
GO
/****** Object:  User [dbo802668235]    Script Date: 2019-12-20 16:46:32 ******/
CREATE USER [dbo802668235] FOR LOGIN [dbo802668235] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [dbo802668235]
GO
/****** Object:  Table [dbo].[Programmes]    Script Date: 2019-12-20 16:46:34 ******/
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
/****** Object:  Table [dbo].[Departements]    Script Date: 2019-12-20 16:46:34 ******/
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
/****** Object:  View [dbo].[ProgrammeDepartementView]    Script Date: 2019-12-20 16:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ProgrammeDepartementView]
	AS SELECT Programmes.Designation, Departements.Titre FROM Programmes left join Departements
	on DepartementID = Departements.ID
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2019-12-20 16:46:34 ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 2019-12-20 16:46:35 ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2019-12-20 16:46:35 ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2019-12-20 16:46:35 ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2019-12-20 16:46:35 ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2019-12-20 16:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](256) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2019-12-20 16:46:35 ******/
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
	[Campus] [ntext] NULL,
	[Office] [ntext] NULL,
	[ImageProfilChoice] [int] NULL,
	[IsFormation] [bit] NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 2019-12-20 16:46:36 ******/
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
/****** Object:  Table [dbo].[CategoriesProgrammes]    Script Date: 2019-12-20 16:46:36 ******/
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
/****** Object:  Table [dbo].[CompetenceContextes]    Script Date: 2019-12-20 16:46:36 ******/
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
/****** Object:  Table [dbo].[Competences]    Script Date: 2019-12-20 16:46:36 ******/
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
/****** Object:  Table [dbo].[CoursActivite]    Script Date: 2019-12-20 16:46:36 ******/
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
 CONSTRAINT [PK__tmp_ms_x__6E2BA98B3D6EAA7F] PRIMARY KEY NONCLUSTERED 
(
	[Identity] ASC,
	[CoursID] ASC,
	[TCHR_UID] ASC,
	[PLN_VSN_CDTTM] ASC,
	[SessionID] ASC
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
/****** Object:  Table [dbo].[CoursCompetenceElements]    Script Date: 2019-12-20 16:46:37 ******/
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
/****** Object:  Table [dbo].[CoursRequis]    Script Date: 2019-12-20 16:46:37 ******/
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
/****** Object:  Table [dbo].[CriteresElementCompetence]    Script Date: 2019-12-20 16:46:37 ******/
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
/****** Object:  Table [dbo].[DisponibilitesUtilisateur]    Script Date: 2019-12-20 16:46:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DisponibilitesUtilisateur](
	[UID] [nvarchar](7) NOT NULL,
	[USER_AVL_SQNBR] [int] IDENTITY(1,1) NOT NULL,
	[WEEKDAY_NBR] [int] NOT NULL,
	[AVL_STM] [time](7) NOT NULL,
	[AVL_NTM] [time](7) NOT NULL,
	[RCD_CDTTM] [datetime] NULL,
	[RecurrenceRule] [nvarchar](50) NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[DayOfWeekString] [nvarchar](450) NULL,
	[DayOfWeekHumanLangageFR] [nvarchar](450) NULL,
	[Subject] [nvarchar](450) NULL,
	[Location] [nvarchar](450) NULL,
	[Description] [nvarchar](450) NULL,
 CONSTRAINT [PK_TUSERAVL] PRIMARY KEY CLUSTERED 
(
	[UID] ASC,
	[USER_AVL_SQNBR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ElementsCompetence]    Script Date: 2019-12-20 16:46:37 ******/
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
/****** Object:  Table [dbo].[Examens]    Script Date: 2019-12-20 16:46:37 ******/
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
/****** Object:  Table [dbo].[ExamensCertificatifsNonsFinals]    Script Date: 2019-12-20 16:46:37 ******/
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
/****** Object:  Table [dbo].[ExamensElementsCompetences]    Script Date: 2019-12-20 16:46:38 ******/
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
/****** Object:  Table [dbo].[ExamensFinalsCertificatifs]    Script Date: 2019-12-20 16:46:38 ******/
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
/****** Object:  Table [dbo].[MaterielsCours]    Script Date: 2019-12-20 16:46:38 ******/
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
/****** Object:  Table [dbo].[PlanCadreCompetenceElements]    Script Date: 2019-12-20 16:46:38 ******/
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
/****** Object:  Table [dbo].[PlansCadres]    Script Date: 2019-12-20 16:46:39 ******/
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
/****** Object:  Table [dbo].[PlansCours]    Script Date: 2019-12-20 16:46:39 ******/
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
	[CoursePolicy] [ntext] NULL,
	[Group] [varchar](16) NULL,
	[PonderationComment] [nvarchar](450) NULL,
 CONSTRAINT [PK_PlansCours] PRIMARY KEY CLUSTERED 
(
	[CoursID] ASC,
	[TCHR_UID] ASC,
	[PLN_VSN_CDTTM] ASC,
	[SessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgrammeCompetences]    Script Date: 2019-12-20 16:46:39 ******/
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
/****** Object:  Table [dbo].[RelTablPcrsPcadres]    Script Date: 2019-12-20 16:46:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelTablPcrsPcadres](
	[PlCoursCrsID] [nchar](10) NOT NULL,
	[PlCrsTCHR_UID] [varchar](7) NOT NULL,
	[PlCrsPLN_VSN_CDTTM] [datetime] NOT NULL,
	[PlCrsSessionID] [char](3) NOT NULL,
	[PlCadreId] [nchar](10) NOT NULL,
	[PlVsnCdttm] [datetime] NOT NULL,
 CONSTRAINT [PK_RelTablPcrsPcadres] PRIMARY KEY CLUSTERED 
(
	[PlCoursCrsID] ASC,
	[PlCrsTCHR_UID] ASC,
	[PlCrsPLN_VSN_CDTTM] ASC,
	[PlCrsSessionID] ASC,
	[PlCadreId] ASC,
	[PlVsnCdttm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolesSecretKeys]    Script Date: 2019-12-20 16:46:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolesSecretKeys](
	[Key] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[LifeSpan] [int] NOT NULL,
	[DateGenerated] [datetime] NOT NULL,
 CONSTRAINT [PK_RolesSecretKeys] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sessions]    Script Date: 2019-12-20 16:46:40 ******/
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
/****** Object:  Table [dbo].[TypesFormationsProgrammes]    Script Date: 2019-12-20 16:46:40 ******/
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
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 2019-12-20 16:46:40 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 2019-12-20 16:46:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 2019-12-20 16:46:40 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 2019-12-20 16:46:40 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 2019-12-20 16:46:40 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 2019-12-20 16:46:40 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUsers_DepartementID]    Script Date: 2019-12-20 16:46:40 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_DepartementID] ON [dbo].[AspNetUsers]
(
	[DepartementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 2019-12-20 16:46:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  CONSTRAINT [DF__AspNetUse__RCD_C__1DD065E0]  DEFAULT (getdate()) FOR [RCD_CDTTM]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  CONSTRAINT [DF_AspNetUsers_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  CONSTRAINT [DF_AspNetUsers_ImageProfilChoice]  DEFAULT ((0)) FOR [ImageProfilChoice]
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
ALTER TABLE [dbo].[RolesSecretKeys] ADD  CONSTRAINT [DF_RolesSecretKeys_Key]  DEFAULT (newid()) FOR [Key]
GO
ALTER TABLE [dbo].[RolesSecretKeys] ADD  CONSTRAINT [DF_RolesSecretKeys_DateGenerated]  DEFAULT (getdate()) FOR [DateGenerated]
GO
ALTER TABLE [dbo].[Sessions] ADD  CONSTRAINT [DF_TSMSTR_RCD_CDTTM]  DEFAULT (getdate()) FOR [RCD_CDTTM]
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
ALTER TABLE [dbo].[CompetenceContextes]  WITH CHECK ADD  CONSTRAINT [FK__Competenc__Ident__68687968] FOREIGN KEY([IdentityKeyCompetence])
REFERENCES [dbo].[Competences] ([IdentityKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CompetenceContextes] CHECK CONSTRAINT [FK__Competenc__Ident__68687968]
GO
ALTER TABLE [dbo].[Competences]  WITH CHECK ADD  CONSTRAINT [FK_TSKL_TDPMNT] FOREIGN KEY([DisciplineID])
REFERENCES [dbo].[Departements] ([ID])
GO
ALTER TABLE [dbo].[Competences] CHECK CONSTRAINT [FK_TSKL_TDPMNT]
GO
ALTER TABLE [dbo].[CoursActivite]  WITH CHECK ADD  CONSTRAINT [FK_CoursActivite_PlansCours1] FOREIGN KEY([CoursID], [TCHR_UID], [PLN_VSN_CDTTM], [SessionID])
REFERENCES [dbo].[PlansCours] ([CoursID], [TCHR_UID], [PLN_VSN_CDTTM], [SessionID])
GO
ALTER TABLE [dbo].[CoursActivite] CHECK CONSTRAINT [FK_CoursActivite_PlansCours1]
GO
ALTER TABLE [dbo].[CoursCompetenceElements]  WITH CHECK ADD  CONSTRAINT [FK__CoursComp__Ident__3E723F9C] FOREIGN KEY([IdentityCritereElementCompetence])
REFERENCES [dbo].[CriteresElementCompetence] ([IdentityKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CoursCompetenceElements] CHECK CONSTRAINT [FK__CoursComp__Ident__3E723F9C]
GO
ALTER TABLE [dbo].[CoursRequis]  WITH CHECK ADD  CONSTRAINT [FK_TCRSREQ_TCRSTMPLT] FOREIGN KEY([CoursID], [VSN_CDTTM])
REFERENCES [dbo].[PlansCadres] ([CoursID], [VSN_CDTTM])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CoursRequis] CHECK CONSTRAINT [FK_TCRSREQ_TCRSTMPLT]
GO
ALTER TABLE [dbo].[CriteresElementCompetence]  WITH CHECK ADD  CONSTRAINT [FK__CriteresE__Eleme__70FDBF69] FOREIGN KEY([ElementCompetenceId])
REFERENCES [dbo].[ElementsCompetence] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CriteresElementCompetence] CHECK CONSTRAINT [FK__CriteresE__Eleme__70FDBF69]
GO
ALTER TABLE [dbo].[DisponibilitesUtilisateur]  WITH CHECK ADD  CONSTRAINT [FK_TUSERAVL_TUSER_TASPNET] FOREIGN KEY([UID])
REFERENCES [dbo].[AspNetUsers] ([UserName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DisponibilitesUtilisateur] CHECK CONSTRAINT [FK_TUSERAVL_TUSER_TASPNET]
GO
ALTER TABLE [dbo].[ElementsCompetence]  WITH CHECK ADD  CONSTRAINT [FK__ElementsC__Ident__6A50C1DA] FOREIGN KEY([IdentityKeyCompetences])
REFERENCES [dbo].[Competences] ([IdentityKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ElementsCompetence] CHECK CONSTRAINT [FK__ElementsC__Ident__6A50C1DA]
GO
ALTER TABLE [dbo].[ExamensCertificatifsNonsFinals]  WITH CHECK ADD  CONSTRAINT [FK_ExamensCertificatifsNonsFinals_PlansCours1] FOREIGN KEY([CoursID], [TCHR_UID], [PLN_VSN_CDTTM], [SessionID])
REFERENCES [dbo].[PlansCours] ([CoursID], [TCHR_UID], [PLN_VSN_CDTTM], [SessionID])
GO
ALTER TABLE [dbo].[ExamensCertificatifsNonsFinals] CHECK CONSTRAINT [FK_ExamensCertificatifsNonsFinals_PlansCours1]
GO
ALTER TABLE [dbo].[ExamensCertificatifsNonsFinals]  WITH CHECK ADD  CONSTRAINT [FK_TCERTEXAM_TEXAM] FOREIGN KEY([ExamenID])
REFERENCES [dbo].[Examens] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExamensCertificatifsNonsFinals] CHECK CONSTRAINT [FK_TCERTEXAM_TEXAM]
GO
ALTER TABLE [dbo].[ExamensElementsCompetences]  WITH CHECK ADD  CONSTRAINT [FK__ExamensEl__Eleme__60C757A0] FOREIGN KEY([ElementCompetenceId])
REFERENCES [dbo].[ElementsCompetence] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExamensElementsCompetences] CHECK CONSTRAINT [FK__ExamensEl__Eleme__60C757A0]
GO
ALTER TABLE [dbo].[ExamensElementsCompetences]  WITH CHECK ADD  CONSTRAINT [FK_TEXAMSKLELEM_TEXAM] FOREIGN KEY([ExamenID])
REFERENCES [dbo].[Examens] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExamensElementsCompetences] CHECK CONSTRAINT [FK_TEXAMSKLELEM_TEXAM]
GO
ALTER TABLE [dbo].[ExamensFinalsCertificatifs]  WITH CHECK ADD  CONSTRAINT [FK_TFNLEXAM_TCRSTMPLT] FOREIGN KEY([CoursID], [VSN_CDTTM])
REFERENCES [dbo].[PlansCadres] ([CoursID], [VSN_CDTTM])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExamensFinalsCertificatifs] CHECK CONSTRAINT [FK_TFNLEXAM_TCRSTMPLT]
GO
ALTER TABLE [dbo].[ExamensFinalsCertificatifs]  WITH CHECK ADD  CONSTRAINT [FK_TFNLEXAM_TEXAM] FOREIGN KEY([ExamenID])
REFERENCES [dbo].[Examens] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExamensFinalsCertificatifs] CHECK CONSTRAINT [FK_TFNLEXAM_TEXAM]
GO
ALTER TABLE [dbo].[MaterielsCours]  WITH CHECK ADD  CONSTRAINT [FK_MaterielsCours_PlansCours1] FOREIGN KEY([CoursID], [TCHR_UID], [PLN_VSN_CDTTM], [SessionID])
REFERENCES [dbo].[PlansCours] ([CoursID], [TCHR_UID], [PLN_VSN_CDTTM], [SessionID])
GO
ALTER TABLE [dbo].[MaterielsCours] CHECK CONSTRAINT [FK_MaterielsCours_PlansCours1]
GO
ALTER TABLE [dbo].[PlanCadreCompetenceElements]  WITH CHECK ADD  CONSTRAINT [FK__PlanCadre__Eleme__5EDF0F2E] FOREIGN KEY([ElementCompetenceId])
REFERENCES [dbo].[ElementsCompetence] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlanCadreCompetenceElements] CHECK CONSTRAINT [FK__PlanCadre__Eleme__5EDF0F2E]
GO
ALTER TABLE [dbo].[PlanCadreCompetenceElements]  WITH CHECK ADD  CONSTRAINT [FK_TTMPLTSKLELEM_TCRSTMPLT] FOREIGN KEY([CoursID], [VSN_CDTTM])
REFERENCES [dbo].[PlansCadres] ([CoursID], [VSN_CDTTM])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlanCadreCompetenceElements] CHECK CONSTRAINT [FK_TTMPLTSKLELEM_TCRSTMPLT]
GO
ALTER TABLE [dbo].[PlansCours]  WITH CHECK ADD  CONSTRAINT [FK_PlansCours_Sessions] FOREIGN KEY([SessionID])
REFERENCES [dbo].[Sessions] ([ID])
GO
ALTER TABLE [dbo].[PlansCours] CHECK CONSTRAINT [FK_PlansCours_Sessions]
GO
ALTER TABLE [dbo].[ProgrammeCompetences]  WITH CHECK ADD  CONSTRAINT [FK_R_SKL_PGM__PGM] FOREIGN KEY([ProgrammeID], [DepartementID])
REFERENCES [dbo].[Programmes] ([ID], [DepartementID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProgrammeCompetences] CHECK CONSTRAINT [FK_R_SKL_PGM__PGM]
GO
ALTER TABLE [dbo].[Programmes]  WITH CHECK ADD  CONSTRAINT [FK_TPGM_TCDTY] FOREIGN KEY([CodeType])
REFERENCES [dbo].[CategoriesProgrammes] ([CategorieID])
ON UPDATE CASCADE
ON DELETE SET NULL
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
ALTER TABLE [dbo].[RelTablPcrsPcadres]  WITH CHECK ADD  CONSTRAINT [FK_RelTablPcrsPcadres_PlansCadres] FOREIGN KEY([PlCadreId], [PlVsnCdttm])
REFERENCES [dbo].[PlansCadres] ([CoursID], [VSN_CDTTM])
GO
ALTER TABLE [dbo].[RelTablPcrsPcadres] CHECK CONSTRAINT [FK_RelTablPcrsPcadres_PlansCadres]
GO
ALTER TABLE [dbo].[RelTablPcrsPcadres]  WITH CHECK ADD  CONSTRAINT [FK_RelTablPcrsPcadres_PlansCours] FOREIGN KEY([PlCoursCrsID], [PlCrsTCHR_UID], [PlCrsPLN_VSN_CDTTM], [PlCrsSessionID])
REFERENCES [dbo].[PlansCours] ([CoursID], [TCHR_UID], [PLN_VSN_CDTTM], [SessionID])
GO
ALTER TABLE [dbo].[RelTablPcrsPcadres] CHECK CONSTRAINT [FK_RelTablPcrsPcadres_PlansCours]
GO
ALTER TABLE [dbo].[RolesSecretKeys]  WITH CHECK ADD  CONSTRAINT [FK_RolesSecretKeys_AspNetRoles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RolesSecretKeys] CHECK CONSTRAINT [FK_RolesSecretKeys_AspNetRoles]
GO
EXEC [PCU001].sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code d''identification d''un cours' 
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
USE [master]
GO
ALTER DATABASE [PCU001] SET  READ_WRITE 
GO

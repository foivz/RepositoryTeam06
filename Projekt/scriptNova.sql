USE [master]
GO
/****** Object:  Database [ServisCiscenjeDB]    Script Date: 19.6.2014. 18:13:14 ******/
CREATE DATABASE [ServisCiscenjeDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ServisCiscenjeDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ServisCiscenjeDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ServisCiscenjeDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ServisCiscenjeDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ServisCiscenjeDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ServisCiscenjeDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ServisCiscenjeDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ServisCiscenjeDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ServisCiscenjeDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ServisCiscenjeDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ServisCiscenjeDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ServisCiscenjeDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ServisCiscenjeDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ServisCiscenjeDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ServisCiscenjeDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ServisCiscenjeDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ServisCiscenjeDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ServisCiscenjeDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ServisCiscenjeDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ServisCiscenjeDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ServisCiscenjeDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ServisCiscenjeDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ServisCiscenjeDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ServisCiscenjeDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ServisCiscenjeDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ServisCiscenjeDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ServisCiscenjeDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ServisCiscenjeDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ServisCiscenjeDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ServisCiscenjeDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ServisCiscenjeDB] SET  MULTI_USER 
GO
ALTER DATABASE [ServisCiscenjeDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ServisCiscenjeDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ServisCiscenjeDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ServisCiscenjeDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ServisCiscenjeDB', N'ON'
GO
USE [ServisCiscenjeDB]
GO
/****** Object:  StoredProcedure [dbo].[SelectQueryRadnik]    Script Date: 19.6.2014. 18:13:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectQueryRadnik]
(
	@PosaoID int
)
AS
	SET NOCOUNT ON;
SELECT posao.datum, posao.vrijeme, posao.adresa_ciscenja, posao.velicina_prostora, posao.tip_posla,
posao.cijena, posao.vrijeme_izdavanja_racuna, posao.klijent_id, posao.klijentid_klijent
FROM posao, tim
WHERE tim.radniciidradnik = @PosaoID
AND tim.posaoid_posao = posao.id_posao
GO
/****** Object:  StoredProcedure [dbo].[SelectQueryUsluga]    Script Date: 19.6.2014. 18:13:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectQueryUsluga]
(
	@UslugaID int
)
AS
	SET NOCOUNT ON;
SELECT usluga.id_usluga, usluga.naziv, usluga.cijenaKvadrat
FROM usluga, usluga_posao
WHERE usluga_posao.posaoid_posao = @UslugaID 
AND usluga_posao.uslugaid_usluga = usluga.id_usluga
GO
/****** Object:  Table [dbo].[klijent]    Script Date: 19.6.2014. 18:13:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[klijent](
	[id_klijent] [int] IDENTITY(1,1) NOT NULL,
	[adresa] [varchar](35) NULL,
	[kontakt] [varchar](20) NULL,
	[naziv] [varchar](35) NULL,
	[email] [varchar](35) NULL,
	[posaoid_posao] [int] NOT NULL,
	[posaoid_posao2] [int] NOT NULL,
	[primanjeObavijesti] [varchar](5) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_klijent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[korisnici]    Script Date: 19.6.2014. 18:13:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[korisnici](
	[id_korisnik] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL,
 CONSTRAINT [PK__korisnic__C570D8FBCA58D237] PRIMARY KEY CLUSTERED 
(
	[id_korisnik] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[posao]    Script Date: 19.6.2014. 18:13:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[posao](
	[id_posao] [int] IDENTITY(1,1) NOT NULL,
	[datum] [datetime] NULL,
	[vrijeme] [varchar](50) NULL,
	[adresa_ciscenja] [varchar](35) NULL,
	[velicina_prostora] [int] NULL,
	[tip_posla] [varchar](10) NULL,
	[cijena] [varchar](10) NULL,
	[vrijeme_izdavanja_racuna] [varchar](10) NULL,
	[klijent_id] [int] NOT NULL,
	[klijentid_klijent] [int] NOT NULL,
 CONSTRAINT [PK__posao__2425ACF9CC7D5F9A] PRIMARY KEY CLUSTERED 
(
	[id_posao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[radna_skupina]    Script Date: 19.6.2014. 18:13:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[radna_skupina](
	[id_radnaSkupina] [int] IDENTITY(1,1) NOT NULL,
	[vozilaid_vozilo] [int] NOT NULL,
	[posaoid_posao] [int] NOT NULL,
 CONSTRAINT [PK_radna_skupina] PRIMARY KEY CLUSTERED 
(
	[id_radnaSkupina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[radnici]    Script Date: 19.6.2014. 18:13:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[radnici](
	[idradnik] [int] IDENTITY(1,1) NOT NULL,
	[ime] [varchar](35) NULL,
	[prezime] [varchar](35) NULL,
	[telefon] [varchar](12) NULL,
PRIMARY KEY CLUSTERED 
(
	[idradnik] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tim]    Script Date: 19.6.2014. 18:13:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tim](
	[id_radnaSkupina] [int] IDENTITY(1,1) NOT NULL,
	[posaoid_posao] [int] NOT NULL,
	[radniciidradnik] [int] NOT NULL,
 CONSTRAINT [PK_tim] PRIMARY KEY CLUSTERED 
(
	[id_radnaSkupina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[usluga]    Script Date: 19.6.2014. 18:13:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[usluga](
	[id_usluga] [int] IDENTITY(1,1) NOT NULL,
	[naziv] [varchar](35) NULL,
	[cijenaKvadrat] [float] NULL,
 CONSTRAINT [PK__usluga__9FD22D63E6BD75E1] PRIMARY KEY CLUSTERED 
(
	[id_usluga] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[usluga_posao]    Script Date: 19.6.2014. 18:13:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usluga_posao](
	[id_uslugaPosao] [int] IDENTITY(1,1) NOT NULL,
	[uslugaid_usluga] [int] NOT NULL,
	[posaoid_posao] [int] NOT NULL,
 CONSTRAINT [PK_usluga_posao] PRIMARY KEY CLUSTERED 
(
	[id_uslugaPosao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[vozila]    Script Date: 19.6.2014. 18:13:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[vozila](
	[id_vozilo] [int] IDENTITY(1,1) NOT NULL,
	[registracijska_oznaka] [varchar](15) NULL,
	[model] [varchar](35) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_vozilo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[posao]  WITH CHECK ADD  CONSTRAINT [FKposao982464] FOREIGN KEY([klijentid_klijent])
REFERENCES [dbo].[klijent] ([id_klijent])
GO
ALTER TABLE [dbo].[posao] CHECK CONSTRAINT [FKposao982464]
GO
ALTER TABLE [dbo].[radna_skupina]  WITH CHECK ADD  CONSTRAINT [FKradna_skup677620] FOREIGN KEY([posaoid_posao])
REFERENCES [dbo].[posao] ([id_posao])
GO
ALTER TABLE [dbo].[radna_skupina] CHECK CONSTRAINT [FKradna_skup677620]
GO
ALTER TABLE [dbo].[radna_skupina]  WITH CHECK ADD  CONSTRAINT [FKradna_skup729366] FOREIGN KEY([vozilaid_vozilo])
REFERENCES [dbo].[vozila] ([id_vozilo])
GO
ALTER TABLE [dbo].[radna_skupina] CHECK CONSTRAINT [FKradna_skup729366]
GO
ALTER TABLE [dbo].[tim]  WITH CHECK ADD  CONSTRAINT [FKtim293996] FOREIGN KEY([posaoid_posao])
REFERENCES [dbo].[posao] ([id_posao])
GO
ALTER TABLE [dbo].[tim] CHECK CONSTRAINT [FKtim293996]
GO
ALTER TABLE [dbo].[tim]  WITH CHECK ADD  CONSTRAINT [FKtim361845] FOREIGN KEY([radniciidradnik])
REFERENCES [dbo].[radnici] ([idradnik])
GO
ALTER TABLE [dbo].[tim] CHECK CONSTRAINT [FKtim361845]
GO
ALTER TABLE [dbo].[usluga_posao]  WITH CHECK ADD  CONSTRAINT [FKusluga_pos186432] FOREIGN KEY([uslugaid_usluga])
REFERENCES [dbo].[usluga] ([id_usluga])
GO
ALTER TABLE [dbo].[usluga_posao] CHECK CONSTRAINT [FKusluga_pos186432]
GO
ALTER TABLE [dbo].[usluga_posao]  WITH CHECK ADD  CONSTRAINT [FKusluga_pos587432] FOREIGN KEY([posaoid_posao])
REFERENCES [dbo].[posao] ([id_posao])
GO
ALTER TABLE [dbo].[usluga_posao] CHECK CONSTRAINT [FKusluga_pos587432]
GO
USE [master]
GO
ALTER DATABASE [ServisCiscenjeDB] SET  READ_WRITE 
GO

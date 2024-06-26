USE [master]
GO
/****** Object:  Database [Sirket]    Script Date: 29.03.2024 22:02:30 ******/
CREATE DATABASE [Sirket]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Sirket', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Sirket.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Sirket_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Sirket_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Sirket] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Sirket].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Sirket] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Sirket] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Sirket] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Sirket] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Sirket] SET ARITHABORT OFF 
GO
ALTER DATABASE [Sirket] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Sirket] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Sirket] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Sirket] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Sirket] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Sirket] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Sirket] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Sirket] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Sirket] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Sirket] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Sirket] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Sirket] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Sirket] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Sirket] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Sirket] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Sirket] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Sirket] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Sirket] SET RECOVERY FULL 
GO
ALTER DATABASE [Sirket] SET  MULTI_USER 
GO
ALTER DATABASE [Sirket] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Sirket] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Sirket] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Sirket] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Sirket] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Sirket] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Sirket', N'ON'
GO
ALTER DATABASE [Sirket] SET QUERY_STORE = ON
GO
ALTER DATABASE [Sirket] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Sirket]
GO
/****** Object:  Table [dbo].[Birimler]    Script Date: 29.03.2024 22:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Birimler](
	[Birim_id] [int] IDENTITY(1,1) NOT NULL,
	[Birim_Ad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Birimler] PRIMARY KEY CLUSTERED 
(
	[Birim_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personell]    Script Date: 29.03.2024 22:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personell](
	[Personel_TC] [int] IDENTITY(1,1) NOT NULL,
	[Personel_username] [varchar](50) NOT NULL,
	[Personel_Adı] [varchar](50) NOT NULL,
	[Birim_ID] [varchar](50) NOT NULL,
	[Cinsiyet] [varchar](50) NOT NULL,
	[İşe Başlama Tarihi] [date] NOT NULL,
	[Ünvan] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Personell] PRIMARY KEY CLUSTERED 
(
	[Personel_TC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yönetim]    Script Date: 29.03.2024 22:02:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yönetim](
	[Yönetici_id] [int] IDENTITY(1,101) NOT NULL,
	[Yönetici_kAdı] [varchar](50) NOT NULL,
	[Yönetici_Ad] [varchar](50) NOT NULL,
	[Yönetici_Password] [int] NOT NULL,
 CONSTRAINT [PK_Yönetim] PRIMARY KEY CLUSTERED 
(
	[Yönetici_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Birimler] ON 

INSERT [dbo].[Birimler] ([Birim_id], [Birim_Ad]) VALUES (1, N'Bilgisayar')
INSERT [dbo].[Birimler] ([Birim_id], [Birim_Ad]) VALUES (2, N'Muhasabe')
INSERT [dbo].[Birimler] ([Birim_id], [Birim_Ad]) VALUES (3, N'Yazılım Müh.')
INSERT [dbo].[Birimler] ([Birim_id], [Birim_Ad]) VALUES (4, N'Elektronik Müh.')
SET IDENTITY_INSERT [dbo].[Birimler] OFF
GO
SET IDENTITY_INSERT [dbo].[Personell] ON 

INSERT [dbo].[Personell] ([Personel_TC], [Personel_username], [Personel_Adı], [Birim_ID], [Cinsiyet], [İşe Başlama Tarihi], [Ünvan]) VALUES (24, N'zbastrk', N'ZİYA BAŞTÜRK', N'1', N'E', CAST(N'2024-03-29' AS Date), N'İT')
INSERT [dbo].[Personell] ([Personel_TC], [Personel_username], [Personel_Adı], [Birim_ID], [Cinsiyet], [İşe Başlama Tarihi], [Ünvan]) VALUES (25, N'sezenNecdet', N'NECDET SEZEN', N'2', N'E', CAST(N'2024-03-29' AS Date), N'TT')
INSERT [dbo].[Personell] ([Personel_TC], [Personel_username], [Personel_Adı], [Birim_ID], [Cinsiyet], [İşe Başlama Tarihi], [Ünvan]) VALUES (26, N'selviMerve', N'MERVE SELVİ', N'3', N'K', CAST(N'2024-03-29' AS Date), N'XX')
INSERT [dbo].[Personell] ([Personel_TC], [Personel_username], [Personel_Adı], [Birim_ID], [Cinsiyet], [İşe Başlama Tarihi], [Ünvan]) VALUES (27, N'ebruKck', N'EBRU KCK', N'4', N'K', CAST(N'2024-03-29' AS Date), N'EE')
SET IDENTITY_INSERT [dbo].[Personell] OFF
GO
SET IDENTITY_INSERT [dbo].[Yönetim] ON 

INSERT [dbo].[Yönetim] ([Yönetici_id], [Yönetici_kAdı], [Yönetici_Ad], [Yönetici_Password]) VALUES (1, N'zbastrk', N'Ziya Baştürk', 222222)
INSERT [dbo].[Yönetim] ([Yönetici_id], [Yönetici_kAdı], [Yönetici_Ad], [Yönetici_Password]) VALUES (102, N'selviMerve', N'Merve Selvi', 111111)
INSERT [dbo].[Yönetim] ([Yönetici_id], [Yönetici_kAdı], [Yönetici_Ad], [Yönetici_Password]) VALUES (203, N'sezenNecdet', N'Necdet Sezen', 123456)
SET IDENTITY_INSERT [dbo].[Yönetim] OFF
GO
USE [master]
GO
ALTER DATABASE [Sirket] SET  READ_WRITE 
GO

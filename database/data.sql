USE [master]
GO
/****** Object:  Database [mb]    Script Date: 6/6/2021 10:10:25 PM ******/
CREATE DATABASE [mb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'mb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\mb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'mb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\mb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [mb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [mb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [mb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [mb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [mb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [mb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [mb] SET ARITHABORT OFF 
GO
ALTER DATABASE [mb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [mb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [mb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [mb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [mb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [mb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [mb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [mb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [mb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [mb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [mb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [mb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [mb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [mb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [mb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [mb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [mb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [mb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [mb] SET  MULTI_USER 
GO
ALTER DATABASE [mb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [mb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [mb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [mb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [mb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [mb] SET QUERY_STORE = OFF
GO
USE [mb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [mb]
GO
USE [mb]
GO
/****** Object:  Sequence [dbo].[sequence_1]    Script Date: 6/6/2021 10:10:25 PM ******/
CREATE SEQUENCE [dbo].[sequence_1] 
 AS [bigint]
 START WITH 1
 INCREMENT BY 1
 MINVALUE 0
 MAXVALUE 100
 CYCLE 
 CACHE 
GO
/****** Object:  UserDefinedFunction [dbo].[fn_tinhtienhoadon]    Script Date: 6/6/2021 10:10:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[fn_tinhtienhoadon] (@maHoaDon int)
returns int
as
begin
declare @tongtien int
SELECT @tongtien = SUM( c.so_luong*s.gia_ban) 
from tbchitiethd c , tbsach s , tbhoadon h
WHERE c.ma_sach=s.ma_sach and c.ma_hoadon= h.ma_hoadon and h.ma_hoadon = @maHoaDon
return @tongtien
end
GO
/****** Object:  Table [dbo].[tbsach]    Script Date: 6/6/2021 10:10:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbsach](
	[ma_sach] [int] IDENTITY(350001,2) NOT NULL,
	[ten_sach] [nvarchar](max) NULL,
	[ma_theloai] [int] NULL,
	[tac_gia] [nvarchar](max) NULL,
	[nha_xb] [nvarchar](max) NULL,
	[so_luong] [int] NULL,
	[gia_ban] [int] NULL,
	[hinh] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbsach] PRIMARY KEY CLUSTERED 
(
	[ma_sach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbchitiethd]    Script Date: 6/6/2021 10:10:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbchitiethd](
	[ma_hoadon] [int] NULL,
	[ma_sach] [int] NULL,
	[so_luong] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbhoadon]    Script Date: 6/6/2021 10:10:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbhoadon](
	[ma_hoadon] [int] IDENTITY(470000,1) NOT NULL,
	[ngay] [datetime] NULL,
	[ten_kh] [nvarchar](max) NULL,
	[ma_nv] [int] NULL,
	[trang_thai] [int] NULL,
	[tong_tien] [int] NULL,
 CONSTRAINT [PK_tbhoadon] PRIMARY KEY CLUSTERED 
(
	[ma_hoadon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[CTHD]    Script Date: 6/6/2021 10:10:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CTHD] AS
SELECT tbsach.ten_sach as [Tên sách] ,tbsach.gia_ban as[Giá bán], tbchitiethd.so_luong as [Số lượng], tbchitiethd.thanhtien as [Thành tiền]
FROM tbchitiethd , tbhoadon, tbsach
WHERE  tbsach.ma_sach = tbchitiethd.ma_sach and tbhoadon.ma_hoadon = tbchitiethd.ma_hoadon and thanhtien = ( tbchitiethd.so_luong * tbsach.gia_ban)
GO
/****** Object:  View [dbo].[CTHD1]    Script Date: 6/6/2021 10:10:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CTHD1]  AS
SELECT tbsach.ten_sach as [Tên sách] ,tbsach.gia_ban as[Giá bán], tbchitiethd.so_luong as [Số lượng], tbchitiethd.thanhtien as [Thành tiền]
FROM ((tbchitiethd
inner join tbhoadon ON tbchitiethd.ma_hoadon = tbhoadon.ma_hoadon)
inner join tbsach on tbchitiethd.ma_sach = tbsach.ma_sach and tbchitiethd.thanhtien = tbchitiethd.so_luong*tbsach.gia_ban)
GO
/****** Object:  View [dbo].[CTHD2]    Script Date: 6/6/2021 10:10:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CTHD2]  AS
SELECT tbsach.ten_sach as [Tên sách] ,tbsach.gia_ban as[Giá bán], tbchitiethd.so_luong as [Số lượng], tbchitiethd.thanhtien as [Thành tiền]
FROM tbchitiethd
inner join tbhoadon ON tbchitiethd.ma_hoadon = tbhoadon.ma_hoadon
inner join tbsach on tbchitiethd.ma_sach = tbsach.ma_sach and tbchitiethd.thanhtien = tbchitiethd.so_luong*tbsach.gia_ban
GO
/****** Object:  View [dbo].[CTHD3]    Script Date: 6/6/2021 10:10:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CTHD3]  AS
select tbchitiethd.ma_hoadon
from tbchitiethd
GO
/****** Object:  View [dbo].[CTHD5]    Script Date: 6/6/2021 10:10:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CTHD5]  AS
SELECT tbchitiethd.ma_hoadon, tbsach.ten_sach as [Tên sách] ,tbsach.gia_ban as[Giá bán], tbchitiethd.so_luong as [Số lượng], tbchitiethd.thanhtien as [Thành tiền]
FROM tbchitiethd
inner join tbhoadon ON tbchitiethd.ma_hoadon = tbhoadon.ma_hoadon
inner join tbsach on tbchitiethd.ma_sach = tbsach.ma_sach and tbchitiethd.thanhtien = tbchitiethd.so_luong*tbsach.gia_ban
GO
/****** Object:  View [dbo].[CTHD7]    Script Date: 6/6/2021 10:10:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CTHD7] AS
SELECT tbsach.ten_sach as [Tên sách] ,tbsach.gia_ban as[Giá bán], tbchitiethd.so_luong as [Số lượng], tbchitiethd.thanhtien as [Thành tiền]
FROM tbchitiethd
-- join tbhoadon ON tbchitiethd.ma_hoadon = tbhoadon.ma_hoadon
inner join tbsach on tbchitiethd.ma_sach = tbsach.ma_sach and tbchitiethd.thanhtien = tbchitiethd.so_luong*tbsach.gia_ban
GO
/****** Object:  View [dbo].[CTHD8]    Script Date: 6/6/2021 10:10:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CTHD8] AS
SELECT tbsach.ten_sach as [Tên sách] ,tbsach.gia_ban as[Giá bán], tbchitiethd.so_luong as [Số lượng], tbchitiethd.thanhtien as [Thành tiền]
FROM tbchitiethd
-- join tbhoadon ON tbchitiethd.ma_hoadon = tbhoadon.ma_hoadon
inner join tbsach on tbchitiethd.ma_sach = tbsach.ma_sach
GO
/****** Object:  View [dbo].[CTHD9]    Script Date: 6/6/2021 10:10:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CTHD9] AS
SELECT tbsach.ten_sach as [Tên sách] ,tbsach.gia_ban as[Giá bán], tbchitiethd.so_luong as [Số lượng], tbchitiethd.thanhtien as [Thành tiền]
FROM tbchitiethd
-- join tbhoadon ON tbchitiethd.ma_hoadon = tbhoadon.ma_hoadon
inner join tbsach on tbchitiethd.ma_sach = tbsach.ma_sach where tbchitiethd.thanhtien = tbchitiethd.so_luong*tbsach.gia_ban
GO
/****** Object:  View [dbo].[CTHD13]    Script Date: 6/6/2021 10:10:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CTHD13] AS
SELECT tbsach.ten_sach as [Tên sách] ,tbsach.gia_ban as[Giá bán], tbchitiethd.so_luong as [Số lượng]
FROM tbchitiethd
-- join tbhoadon ON tbchitiethd.ma_hoadon = tbhoadon.ma_hoadon
inner join tbsach on tbchitiethd.ma_sach = tbsach.ma_sach
GO
/****** Object:  View [dbo].[CTHD14]    Script Date: 6/6/2021 10:10:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CTHD14] AS
SELECT tbchitiethd.ma_hoadon, tbsach.ten_sach as [Tên sách] ,tbsach.gia_ban as[Giá bán], tbchitiethd.so_luong as [Số lượng]
FROM tbchitiethd
-- join tbhoadon ON tbchitiethd.ma_hoadon = tbhoadon.ma_hoadon
inner join tbsach on tbchitiethd.ma_sach = tbsach.ma_sach
GO
/****** Object:  View [dbo].[CTHD15]    Script Date: 6/6/2021 10:10:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CTHD15] AS
SELECT tbchitiethd.ma_hoadon,tbsach.ma_sach, tbsach.ten_sach as [Tên sách] ,tbsach.gia_ban as[Giá bán], tbchitiethd.so_luong as [Số lượng]
FROM tbchitiethd
-- join tbhoadon ON tbchitiethd.ma_hoadon = tbhoadon.ma_hoadon
inner join tbsach on tbchitiethd.ma_sach = tbsach.ma_sach
GO
/****** Object:  Table [dbo].[tbnv]    Script Date: 6/6/2021 10:10:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbnv](
	[tk] [int] IDENTITY(1850000,1) NOT NULL,
	[mk] [nvarchar](50) NULL,
	[quyen] [int] NULL,
	[ten_nv] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbnv] PRIMARY KEY CLUSTERED 
(
	[tk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbtheloai]    Script Date: 6/6/2021 10:10:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbtheloai](
	[ma_theloai] [int] IDENTITY(310000,2) NOT NULL,
	[ten_theloai] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbtheloai] PRIMARY KEY CLUSTERED 
(
	[ma_theloai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470000, 350021, 2)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470000, 350021, 1)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470000, 350023, 1)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470004, 350021, 1)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470005, 350023, 1)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470006, 350021, 1)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470007, 350021, 1)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470008, 350021, 1)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470008, 350023, 3)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470009, 350021, 3)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470010, 350021, 1)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470016, 350025, 1)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470017, 350021, 1)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470019, 350029, 3)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470019, 350021, 1)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470021, 350023, 6)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470023, 350023, 2)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470024, 350023, 1)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470026, 350023, 1)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470028, 350043, 3)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470029, 350043, 7)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470030, 350023, 4)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470030, 350029, 12)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470031, 350029, 4)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470032, 350035, 4)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470033, 350021, 4)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470033, 350023, 5)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470034, 350021, 3)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470035, 350021, 4)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470036, 350023, 5)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470036, 350025, 2)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470036, 350035, 1)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470036, 350029, 1)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470036, 350031, 1)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470036, 350043, 1)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470036, 350045, 1)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470036, 350039, 1)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470015, 350021, 1)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470015, 350023, 1)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470018, 350023, 5)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470022, 350023, 4)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470025, 350023, 2)
INSERT [dbo].[tbchitiethd] ([ma_hoadon], [ma_sach], [so_luong]) VALUES (470020, 350029, 2)
SET IDENTITY_INSERT [dbo].[tbhoadon] ON 

INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470000, CAST(N'2020-05-01T20:57:25.000' AS DateTime), N'Long      ', 1850000, 1, 395000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470001, CAST(N'2020-05-02T20:57:25.000' AS DateTime), N'Long      ', 1850000, 1, 395000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470002, CAST(N'2021-05-03T20:57:25.000' AS DateTime), N'Long      ', 1850000, 1, 395000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470003, CAST(N'2021-05-04T20:57:25.000' AS DateTime), N'          ', 1850000, 1, 395000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470004, CAST(N'2021-05-04T20:57:25.000' AS DateTime), N'Long      ', 1850000, 1, 395000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470005, CAST(N'2021-05-05T20:57:25.000' AS DateTime), N'          ', 1850000, 1, 395000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470006, CAST(N'2021-05-06T20:57:25.000' AS DateTime), N'Long      ', NULL, 1, 395000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470007, CAST(N'2021-05-07T20:57:25.000' AS DateTime), N'Long      ', 1850000, 1, 395000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470008, CAST(N'2021-05-08T20:57:25.000' AS DateTime), N'Long      ', 1850000, 1, 395000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470009, CAST(N'2021-05-09T20:57:25.000' AS DateTime), N'Long      ', 1850000, 1, 395000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470010, CAST(N'2021-05-10T20:57:25.000' AS DateTime), N'Long      ', 1850000, 1, 395000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470011, CAST(N'2021-05-11T20:57:25.000' AS DateTime), N'Kiên      ', 1850000, 1, 395000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470013, CAST(N'2021-05-12T20:57:25.000' AS DateTime), N'kiên      ', 1850000, 1, 395000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470015, CAST(N'2021-05-13T20:57:25.000' AS DateTime), N'Linh      ', 1850000, 1, 395000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470016, CAST(N'2021-05-14T20:57:25.000' AS DateTime), N'D  SSSD   ', 1850000, 1, 395000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470017, CAST(N'2021-05-15T20:57:25.000' AS DateTime), N'Long      ', 1850000, 1, 395000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470018, CAST(N'2021-05-16T20:57:25.000' AS DateTime), N'Long      ', 1850000, 1, 395000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470019, CAST(N'2021-05-05T20:57:25.000' AS DateTime), N'Tùng Kem  ', 1850000, 1, 1210000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470020, CAST(N'2021-05-05T20:57:25.000' AS DateTime), N'Kiên      ', 1850000, 1, 740000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470021, CAST(N'2021-05-05T20:57:25.000' AS DateTime), N'KH lẻ     ', 1850000, 1, 474000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470022, CAST(N'2021-05-05T20:57:25.000' AS DateTime), N'Tâm       ', 1850000, 1, 316000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470023, CAST(N'2021-05-05T20:57:25.000' AS DateTime), N'G         ', 1850000, 1, 158000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470024, CAST(N'2021-05-05T20:57:25.000' AS DateTime), N'Mạnh      ', 1850000, 1, 79000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470025, CAST(N'2021-05-05T20:57:25.000' AS DateTime), N'Long An   ', 1850000, 1, 158000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470026, CAST(N'2021-05-05T20:57:25.000' AS DateTime), N'A         ', 1850000, 1, 79000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470028, CAST(N'2021-06-05T20:57:25.000' AS DateTime), N'Long      ', 1850000, 1, 420000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470029, CAST(N'2021-06-05T20:57:25.000' AS DateTime), N'Đặng Văn Long 2021', 1850000, 1, 980000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470030, CAST(N'2021-06-05T20:57:25.000' AS DateTime), N'Khánh', 1850000, 1, 4756000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470031, CAST(N'2021-06-05T21:07:00.000' AS DateTime), N'Hằng', 1850000, 1, 1480000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470032, CAST(N'2021-06-05T23:23:00.000' AS DateTime), N'Hằng', 1850000, 1, 688000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470033, CAST(N'2021-06-06T11:06:28.000' AS DateTime), N'kl', 1850000, 1, 795000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470034, CAST(N'2021-06-06T11:08:28.000' AS DateTime), N'KL', 1850000, 1, 300000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470035, CAST(N'2021-06-06T16:08:49.000' AS DateTime), N'Hằng', 1850000, 1, 400000)
INSERT [dbo].[tbhoadon] ([ma_hoadon], [ngay], [ten_kh], [ma_nv], [trang_thai], [tong_tien]) VALUES (470036, CAST(N'2021-06-06T17:00:16.000' AS DateTime), N'Hoàng Văn Thái', 1850003, 1, 1794000)
SET IDENTITY_INSERT [dbo].[tbhoadon] OFF
SET IDENTITY_INSERT [dbo].[tbnv] ON 

INSERT [dbo].[tbnv] ([tk], [mk], [quyen], [ten_nv]) VALUES (1850000, N'123Ab', 1, N'Nguyễn Hoàng Long')
INSERT [dbo].[tbnv] ([tk], [mk], [quyen], [ten_nv]) VALUES (1850001, N'123', 1, N'Phương Trung Kiên')
INSERT [dbo].[tbnv] ([tk], [mk], [quyen], [ten_nv]) VALUES (1850002, N'123', 1, N'Nguyễn Thế Việt')
INSERT [dbo].[tbnv] ([tk], [mk], [quyen], [ten_nv]) VALUES (1850003, N'123', 0, N'Nguyễn Danh Tùng')
INSERT [dbo].[tbnv] ([tk], [mk], [quyen], [ten_nv]) VALUES (1850004, N'123', 0, N'Danh Tuấn Anh')
INSERT [dbo].[tbnv] ([tk], [mk], [quyen], [ten_nv]) VALUES (1850005, N'123A', 0, N'Đào Hoàng Dương')
SET IDENTITY_INSERT [dbo].[tbnv] OFF
SET IDENTITY_INSERT [dbo].[tbsach] ON 

INSERT [dbo].[tbsach] ([ma_sach], [ten_sach], [ma_theloai], [tac_gia], [nha_xb], [so_luong], [gia_ban], [hinh]) VALUES (350021, N'Truyện Kiều', 310002, N'Nguyễn Du', N'NXB Văn Học', 89, 100000, N'C:\Users\Viet\Downloads\fb\truyen-kieu.jpg')
INSERT [dbo].[tbsach] ([ma_sach], [ten_sach], [ma_theloai], [tac_gia], [nha_xb], [so_luong], [gia_ban], [hinh]) VALUES (350023, N'Đắc nhân tâm ', 310006, N'Chưa cập nhật', N'NXB Trẻ', 1, 79000, N'C:\Users\Viet\Downloads\fb\c-nhn-tm-1-638.jpg')
INSERT [dbo].[tbsach] ([ma_sach], [ten_sach], [ma_theloai], [tac_gia], [nha_xb], [so_luong], [gia_ban], [hinh]) VALUES (350025, N'Born Of Dragons And Fairies', 310010, N'Nhiều tác giả', N'NXB Trẻ', 98, 210000, N'C:\Users\Viet\Downloads\fb\365275_p93369mnxbtrefull23022021050229.jpg')
INSERT [dbo].[tbsach] ([ma_sach], [ten_sach], [ma_theloai], [tac_gia], [nha_xb], [so_luong], [gia_ban], [hinh]) VALUES (350029, N'Đằng Sau Một Quyết Định Lớn', 310010, N'Joseph L. Badaracco', N'Nxb Tổng hợp TP.HCM', 182, 370000, N'C:\Users\Viet\Downloads\fb\366816_p94026mdangsaumotquyetdinhlonbia01.jpg')
INSERT [dbo].[tbsach] ([ma_sach], [ten_sach], [ma_theloai], [tac_gia], [nha_xb], [so_luong], [gia_ban], [hinh]) VALUES (350031, N'Khói Bếp Không Tan', 310002, N'Lê Giang', N'NXB Trẻ', 99, 72000, N'C:\Users\Viet\Downloads\m.Books\image\366675_p93961mnxbtrethumb14432021044359.jpg')
INSERT [dbo].[tbsach] ([ma_sach], [ten_sach], [ma_theloai], [tac_gia], [nha_xb], [so_luong], [gia_ban], [hinh]) VALUES (350033, N'Oxf Advanced AM Dict Pk', 310010, N'', N'Oxford University Press', 100, 442000, N'C:\Users\Viet\Downloads\m.Books\image\188808_p64930m41fymtq4xfl.jpg')
INSERT [dbo].[tbsach] ([ma_sach], [ten_sach], [ma_theloai], [tac_gia], [nha_xb], [so_luong], [gia_ban], [hinh]) VALUES (350035, N'Laser B2', 310010, N'R. Nicholas A. Nebel', N'Macmillan', 95, 172000, N'C:\Users\Viet\Downloads\m.Books\image\173591_p62500m81metwy48l.jpg')
INSERT [dbo].[tbsach] ([ma_sach], [ten_sach], [ma_theloai], [tac_gia], [nha_xb], [so_luong], [gia_ban], [hinh]) VALUES (350037, N'Yêu Trong Tỉnh Thức Với Osho', 310016, N'Osho', N'NXB Văn hóa - Văn nghệ', 100, 79000, N'C:\Users\Viet\Downloads\m.Books\image\364199_p92951myeu168kbia01.jpg')
INSERT [dbo].[tbsach] ([ma_sach], [ten_sach], [ma_theloai], [tac_gia], [nha_xb], [so_luong], [gia_ban], [hinh]) VALUES (350039, N'Tỏa Sáng', 310018, N'Jessica Jung', N'NXB Thanh Niên', 99, 80000, N'C:\Users\Viet\Downloads\m.Books\image\361592_p92108mshine.jpg')
INSERT [dbo].[tbsach] ([ma_sach], [ten_sach], [ma_theloai], [tac_gia], [nha_xb], [so_luong], [gia_ban], [hinh]) VALUES (350041, N'Hà Nội Trong Mắt Một Người - Tay Chơi', 310002, N'Mai Lâm', N'NXB Trẻ', 200, 135000, N'C:\Users\Viet\Downloads\m.Books\image\P93351Enxbtre_full_26372021_113733.jpg')
INSERT [dbo].[tbsach] ([ma_sach], [ten_sach], [ma_theloai], [tac_gia], [nha_xb], [so_luong], [gia_ban], [hinh]) VALUES (350043, N'Vòng Tay Học Trò', 310002, N'Nguyễn Thị Hoàng', N'Nxb Hội Nhà Văn', 89, 140000, N'C:\Users\Viet\Downloads\m.Books\image\P93400Evong_tay_hoc_tro_b__a_jacket.jpg')
INSERT [dbo].[tbsach] ([ma_sach], [ten_sach], [ma_theloai], [tac_gia], [nha_xb], [so_luong], [gia_ban], [hinh]) VALUES (350045, N'Cơ Hội Của Chúa: Tiểu Thuyết', 310018, N'Nguyễn Việt Hà', N'NXB Trẻ', 99, 145000, N'C:\Users\Viet\Downloads\m.Books\image\P93109Enxbtre_full_28172021_021747.jpg')
INSERT [dbo].[tbsach] ([ma_sach], [ten_sach], [ma_theloai], [tac_gia], [nha_xb], [so_luong], [gia_ban], [hinh]) VALUES (350047, N'Đảo: Tập Truyện Ngắn', 310020, N'Nguyễn Ngọc Tư', N'NXB Trẻ', 100, 68000, N'C:\Users\Viet\Downloads\m.Books\image\P93114Enxbtre_full_15222021_092212.jpg')
INSERT [dbo].[tbsach] ([ma_sach], [ten_sach], [ma_theloai], [tac_gia], [nha_xb], [so_luong], [gia_ban], [hinh]) VALUES (350049, N'Tím Ngát Tuổi Hai Mươi', 310020, N'Phan Quang', N' NXB Văn Học', 100, 69000, N'C:\Users\Viet\Downloads\m.Books\image\364549_p93080mtimngattuoihaimuoi.jpg')
INSERT [dbo].[tbsach] ([ma_sach], [ten_sach], [ma_theloai], [tac_gia], [nha_xb], [so_luong], [gia_ban], [hinh]) VALUES (350051, N'Một Ngày Rồi Thôi ', 310022, N'Nguyễn Thị Hoàng', N'Nxb Hội Nhà Văn', 29, 119000, N'C:\Users\Viet\Downloads\m.Books\image\364504_p93059mtefsamcd.jpg')
SET IDENTITY_INSERT [dbo].[tbsach] OFF
SET IDENTITY_INSERT [dbo].[tbtheloai] ON 

INSERT [dbo].[tbtheloai] ([ma_theloai], [ten_theloai]) VALUES (310000, N'')
INSERT [dbo].[tbtheloai] ([ma_theloai], [ten_theloai]) VALUES (310002, N'Văn học')
INSERT [dbo].[tbtheloai] ([ma_theloai], [ten_theloai]) VALUES (310006, N'Tham khảo')
INSERT [dbo].[tbtheloai] ([ma_theloai], [ten_theloai]) VALUES (310010, N'Ngoại Văn')
INSERT [dbo].[tbtheloai] ([ma_theloai], [ten_theloai]) VALUES (310012, N'Kinh tế')
INSERT [dbo].[tbtheloai] ([ma_theloai], [ten_theloai]) VALUES (310016, N'Ngôn tình')
INSERT [dbo].[tbtheloai] ([ma_theloai], [ten_theloai]) VALUES (310018, N'Tiểu Thuyết')
INSERT [dbo].[tbtheloai] ([ma_theloai], [ten_theloai]) VALUES (310020, N'Truyện ngắn')
INSERT [dbo].[tbtheloai] ([ma_theloai], [ten_theloai]) VALUES (310022, N'Truyện Dài')
INSERT [dbo].[tbtheloai] ([ma_theloai], [ten_theloai]) VALUES (310024, N'Toán học')
INSERT [dbo].[tbtheloai] ([ma_theloai], [ten_theloai]) VALUES (310026, N'Sử học')
INSERT [dbo].[tbtheloai] ([ma_theloai], [ten_theloai]) VALUES (310028, N'Ngoai Truyện')
SET IDENTITY_INSERT [dbo].[tbtheloai] OFF
ALTER TABLE [dbo].[tbhoadon] ADD  CONSTRAINT [tt]  DEFAULT ((0)) FOR [trang_thai]
GO
ALTER TABLE [dbo].[tbnv] ADD  CONSTRAINT [setquyen]  DEFAULT ((0)) FOR [quyen]
GO
ALTER TABLE [dbo].[tbsach] ADD  CONSTRAINT [ts]  DEFAULT (N'Chưa cập nhật') FOR [ten_sach]
GO
ALTER TABLE [dbo].[tbsach] ADD  CONSTRAINT [ml]  DEFAULT ((310000)) FOR [ma_theloai]
GO
ALTER TABLE [dbo].[tbsach] ADD  CONSTRAINT [tg]  DEFAULT (N'Chưa cập nhật') FOR [tac_gia]
GO
ALTER TABLE [dbo].[tbsach] ADD  CONSTRAINT [nxb]  DEFAULT (N'Chưa cập nhật') FOR [nha_xb]
GO
ALTER TABLE [dbo].[tbchitiethd]  WITH CHECK ADD  CONSTRAINT [FK_tbchitiethd_tbhoadon] FOREIGN KEY([ma_hoadon])
REFERENCES [dbo].[tbhoadon] ([ma_hoadon])
GO
ALTER TABLE [dbo].[tbchitiethd] CHECK CONSTRAINT [FK_tbchitiethd_tbhoadon]
GO
ALTER TABLE [dbo].[tbchitiethd]  WITH CHECK ADD  CONSTRAINT [FK_tbchitiethd_tbsach] FOREIGN KEY([ma_sach])
REFERENCES [dbo].[tbsach] ([ma_sach])
GO
ALTER TABLE [dbo].[tbchitiethd] CHECK CONSTRAINT [FK_tbchitiethd_tbsach]
GO
ALTER TABLE [dbo].[tbhoadon]  WITH CHECK ADD  CONSTRAINT [FK_tbhoadon_tbnv] FOREIGN KEY([ma_nv])
REFERENCES [dbo].[tbnv] ([tk])
GO
ALTER TABLE [dbo].[tbhoadon] CHECK CONSTRAINT [FK_tbhoadon_tbnv]
GO
ALTER TABLE [dbo].[tbsach]  WITH CHECK ADD  CONSTRAINT [FK_tbsach_tbtheloai1] FOREIGN KEY([ma_theloai])
REFERENCES [dbo].[tbtheloai] ([ma_theloai])
GO
ALTER TABLE [dbo].[tbsach] CHECK CONSTRAINT [FK_tbsach_tbtheloai1]
GO
/****** Object:  StoredProcedure [dbo].[proc_capnhatsoluongsach]    Script Date: 6/6/2021 10:10:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[proc_capnhatsoluongsach] @maHoaDon int
as
begin
update tbsach
set tbsach.so_luong = s.so_luong-c.so_luong
from tbl_sach s
INNER JOIN tbchitiethd c on  c.ma_sach = s.ma_sach 
where c.ma_hoadon = @maHoaDon
end
GO
/****** Object:  StoredProcedure [dbo].[proc_capnhatsoluongsach1]    Script Date: 6/6/2021 10:10:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[proc_capnhatsoluongsach1] @maHoadon int
as
begin
update tbsach
set tbsach.so_luong = s.so_luong-c.so_luong
from tbsach s
INNER JOIN tbchitiethd c on  c.ma_sach = s.ma_sach 
where c.ma_hoadon = @maHoaDon
end
GO
/****** Object:  StoredProcedure [dbo].[proc_themchitiethoadon]    Script Date: 6/6/2021 10:10:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[proc_themchitiethoadon]
@maHoaDon int, @maSach int, @soLuong int 
as
begin
declare @sodong int
select @sodong =( select count (*) from tbchitiethd where ma_hoadon = @maHoadon and ma_sach = @maSach)
if (@sodong > 1)
insert into tbchitiethd (ma_hoadon, ma_sach , so_luong )values (@maHoaDon ,@maSach ,@soLuong);
else 
update tbchitiethd set so_luong = @soLuong
where ma_hoadon = @maHoadon and ma_sach = @maSach
end
GO
/****** Object:  StoredProcedure [dbo].[proc_themchitiethoadon1]    Script Date: 6/6/2021 10:10:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[proc_themchitiethoadon1]
@maHoadon int, @maSach int, @soLuong int 
as
begin
declare @sodong int
select @sodong =( select count (*) from tbchitiethd where ma_hoadon = @maHoadon and ma_sach = @maSach)
if (@sodong > 1)
insert into tbchitiethd (ma_hoadon, ma_sach , so_luong )values (@maHoadon ,@maSach ,@soLuong);
else 
update tbchitiethd set so_luong = @soLuong
where ma_hoadon = @maHoadon and ma_sach = @maSach
end
GO
/****** Object:  StoredProcedure [dbo].[proc_themchitiethoadon2]    Script Date: 6/6/2021 10:10:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[proc_themchitiethoadon2]
@maHoadon int, @maSach int, @soLuong int 
as
begin
declare @sodong int
select @sodong =( select count (*) from tbchitiethd where ma_hoadon = @maHoadon and ma_sach = @maSach)
if (@sodong >= 1)
insert into tbchitiethd (ma_hoadon, ma_sach , so_luong )values (@maHoadon ,@maSach ,@soLuong);
else 
update tbchitiethd set so_luong = @soLuong
where ma_hoadon = @maHoadon and ma_sach = @maSach
end
GO
/****** Object:  StoredProcedure [dbo].[proc_themchitiethoadon3]    Script Date: 6/6/2021 10:10:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[proc_themchitiethoadon3]
@maHoadon int, @maSach int, @soLuong int 
as
begin
declare @sodong int
select @sodong =( select count (*) from tbchitiethd where ma_hoadon = @maHoadon and ma_sach = @maSach)
if (@sodong = 0)
insert into tbchitiethd (ma_hoadon, ma_sach , so_luong )values (@maHoadon ,@maSach ,@soLuong);
else 
update tbchitiethd set so_luong = @soLuong
where ma_hoadon = @maHoadon and ma_sach = @maSach
end
GO
/****** Object:  StoredProcedure [dbo].[proc_themchitiethoadon4]    Script Date: 6/6/2021 10:10:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[proc_themchitiethoadon4]
@maHoadon int, @maSach int, @soLuong int 
as
begin
--declare @sodong int
--select @sodong =( select count (*) from tbchitiethd where ma_hoadon = @maHoadon and ma_sach = @maSach)
--if (@sodong = 0)
insert into tbchitiethd (ma_hoadon, ma_sach , so_luong )values (@maHoadon ,@maSach ,@soLuong);
--else 
--update tbchitiethd set so_luong = @soLuong
--where ma_hoadon = @maHoadon and ma_sach = @maSach
end
GO
/****** Object:  StoredProcedure [dbo].[proc_themchitiethoadon6]    Script Date: 6/6/2021 10:10:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[proc_themchitiethoadon6]
@maHoadon int, @maSach int, @soLuong int 
as
begin
declare @sodong int
select @sodong =( select count (*) from tbchitiethd where ma_hoadon = @maHoadon and ma_sach = @maSach)
if (@sodong = 0)
insert into tbchitiethd (ma_hoadon, ma_sach , so_luong )values (@maHoadon ,@maSach ,@soLuong);
else 
update tbchitiethd set so_luong = @soLuong
where ma_hoadon = @maHoadon and ma_sach = @maSach
end
GO
/****** Object:  StoredProcedure [dbo].[proc_xoasachkhoicthd]    Script Date: 6/6/2021 10:10:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[proc_xoasachkhoicthd]
@maHoadon int ,@maSach int
as
begin
delete tbchitiethd where ma_hoadon = @maHoadon and ma_sach = @maSach
end
GO
USE [master]
GO
ALTER DATABASE [mb] SET  READ_WRITE 
GO

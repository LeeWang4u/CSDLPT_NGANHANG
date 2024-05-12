USE [master]
GO
/****** Object:  Database [NGANHANG]    Script Date: 5/13/2024 2:38:47 AM ******/
CREATE DATABASE [NGANHANG]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NGANHANG', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.LEQUANGHIEN\MSSQL\DATA\NGANHANG.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NGANHANG_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.LEQUANGHIEN\MSSQL\DATA\NGANHANG_log.ldf' , SIZE = 204800KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [NGANHANG] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NGANHANG].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NGANHANG] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NGANHANG] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NGANHANG] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NGANHANG] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NGANHANG] SET ARITHABORT OFF 
GO
ALTER DATABASE [NGANHANG] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NGANHANG] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NGANHANG] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NGANHANG] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NGANHANG] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NGANHANG] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NGANHANG] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NGANHANG] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NGANHANG] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NGANHANG] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NGANHANG] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NGANHANG] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NGANHANG] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NGANHANG] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NGANHANG] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NGANHANG] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NGANHANG] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NGANHANG] SET RECOVERY FULL 
GO
ALTER DATABASE [NGANHANG] SET  MULTI_USER 
GO
ALTER DATABASE [NGANHANG] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NGANHANG] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NGANHANG] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NGANHANG] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NGANHANG] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NGANHANG] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'NGANHANG', N'ON'
GO
ALTER DATABASE [NGANHANG] SET QUERY_STORE = ON
GO
ALTER DATABASE [NGANHANG] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [NGANHANG]
GO
/****** Object:  User [HTKN]    Script Date: 5/13/2024 2:38:47 AM ******/
CREATE USER [HTKN] FOR LOGIN [HTKN] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [MSmerge_PAL_role]    Script Date: 5/13/2024 2:38:47 AM ******/
CREATE ROLE [MSmerge_PAL_role]
GO
/****** Object:  DatabaseRole [MSmerge_D7FE72EDD488440086C6EF2B44677FB1]    Script Date: 5/13/2024 2:38:47 AM ******/
CREATE ROLE [MSmerge_D7FE72EDD488440086C6EF2B44677FB1]
GO
/****** Object:  DatabaseRole [MSmerge_34C88524A4C2402F88E869F3B018B5DD]    Script Date: 5/13/2024 2:38:47 AM ******/
CREATE ROLE [MSmerge_34C88524A4C2402F88E869F3B018B5DD]
GO
/****** Object:  DatabaseRole [MSmerge_10652A9B9C444069B782BEF0795B36F9]    Script Date: 5/13/2024 2:38:47 AM ******/
CREATE ROLE [MSmerge_10652A9B9C444069B782BEF0795B36F9]
GO
ALTER ROLE [db_owner] ADD MEMBER [HTKN]
GO
ALTER ROLE [MSmerge_PAL_role] ADD MEMBER [MSmerge_D7FE72EDD488440086C6EF2B44677FB1]
GO
ALTER ROLE [MSmerge_PAL_role] ADD MEMBER [MSmerge_34C88524A4C2402F88E869F3B018B5DD]
GO
ALTER ROLE [MSmerge_PAL_role] ADD MEMBER [MSmerge_10652A9B9C444069B782BEF0795B36F9]
GO
/****** Object:  Schema [MSmerge_PAL_role]    Script Date: 5/13/2024 2:38:47 AM ******/
CREATE SCHEMA [MSmerge_PAL_role]
GO
/****** Object:  View [dbo].[Get_Subscribes]    Script Date: 5/13/2024 2:38:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Get_Subscribes]
AS
SELECT TENCN=PUBS.description, TENSERVER=subscriber_server
 FROM sysmergepublications  PUBS, sysmergesubscriptions SUBS
 WHERE PUBS.pubid = SUBS.pubid AND  publisher <> subscriber_server
 and PUBS.description like '%chi nhánh%'
GO
/****** Object:  Table [dbo].[ChiNhanh]    Script Date: 5/13/2024 2:38:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiNhanh](
	[MACN] [nchar](10) NOT NULL,
	[TENCN] [nvarchar](100) NOT NULL,
	[DIACHI] [nvarchar](100) NOT NULL,
	[SoDT] [nvarchar](15) NOT NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_ChiNhanh] PRIMARY KEY CLUSTERED 
(
	[MACN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GD_CHUYENTIEN]    Script Date: 5/13/2024 2:38:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GD_CHUYENTIEN](
	[MAGD] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[SOTK_CHUYEN] [nchar](9) NOT NULL,
	[NGAYGD] [datetime] NOT NULL,
	[SOTIEN] [money] NOT NULL,
	[SOTK_NHAN] [nchar](9) NOT NULL,
	[MANV] [nchar](10) NOT NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_GD_CHUYENTIEN] PRIMARY KEY CLUSTERED 
(
	[MAGD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GD_GOIRUT]    Script Date: 5/13/2024 2:38:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GD_GOIRUT](
	[MAGD] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[SOTK] [nchar](9) NOT NULL,
	[LOAIGD] [nchar](2) NOT NULL,
	[NGAYGD] [datetime] NOT NULL,
	[SOTIEN] [money] NOT NULL,
	[MANV] [nchar](10) NOT NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_GD_GOIRUT] PRIMARY KEY CLUSTERED 
(
	[MAGD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 5/13/2024 2:38:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[CMND] [nchar](10) NOT NULL,
	[HO] [nvarchar](50) NOT NULL,
	[TEN] [nvarchar](10) NOT NULL,
	[DIACHI] [nvarchar](100) NULL,
	[PHAI] [nvarchar](3) NULL,
	[NGAYCAP] [date] NOT NULL,
	[SODT] [nvarchar](15) NOT NULL,
	[MACN] [nchar](10) NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[CMND] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 5/13/2024 2:38:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MANV] [nchar](10) NOT NULL,
	[HO] [nvarchar](40) NOT NULL,
	[TEN] [nvarchar](10) NOT NULL,
	[CMND] [nchar](10) NOT NULL,
	[DIACHI] [nvarchar](100) NULL,
	[PHAI] [nvarchar](3) NOT NULL,
	[SODT] [nvarchar](15) NOT NULL,
	[MACN] [nchar](10) NULL,
	[TrangThaiXoa] [int] NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MANV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 5/13/2024 2:38:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[SOTK] [nchar](9) NOT NULL,
	[CMND] [nchar](10) NOT NULL,
	[SODU] [money] NULL,
	[MACN] [nchar](10) NULL,
	[rowguid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[SOTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiNhanh] ([MACN], [TENCN], [DIACHI], [SoDT], [rowguid]) VALUES (N'BENTHANH  ', N'Chi nhánh Bến Thành', N'211 Lê Lợi, Quận 1, TPHCM', N'..', N'4d3e8d6b-89d8-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[ChiNhanh] ([MACN], [TENCN], [DIACHI], [SoDT], [rowguid]) VALUES (N'TANDINH   ', N'Chi nhánh Tân Định', N'234 Hai Bà Trưng, phường Đakao, Quận 1, TPHCM', N'...', N'4e3e8d6b-89d8-ee11-9ecc-507b9dbf3058')
GO
SET IDENTITY_INSERT [dbo].[GD_GOIRUT] ON 

INSERT [dbo].[GD_GOIRUT] ([MAGD], [SOTK], [LOAIGD], [NGAYGD], [SOTIEN], [MANV], [rowguid]) VALUES (46003, N'123456789', N'GT', CAST(N'2024-04-14T20:30:37.900' AS DateTime), 1000000.0000, N'NV03      ', N'7ed59b2d-63fa-ee11-9ed7-507b9dbf3058')
INSERT [dbo].[GD_GOIRUT] ([MAGD], [SOTK], [LOAIGD], [NGAYGD], [SOTIEN], [MANV], [rowguid]) VALUES (46004, N'123456789', N'RT', CAST(N'2024-04-14T21:20:15.633' AS DateTime), 1000000.0000, N'NV03      ', N'26727a1c-6afa-ee11-9ed7-507b9dbf3058')
SET IDENTITY_INSERT [dbo].[GD_GOIRUT] OFF
GO
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'0123456789', N'Lê', N'Thị Khuyên', N'Hà Nội', N'Nữ', CAST(N'2024-03-05' AS Date), N'0898765432', N'TANDINH   ', N'91315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'0123456790', N'Lê', N'Thị Quỳnh', N'Hà Nội', N'Nữ', CAST(N'2024-03-05' AS Date), N'0898765434', N'TANDINH   ', N'9b315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'1234567890', N'Nguyễn', N'Văn Anh', N'Hồ Chí Minh', N'Nam', CAST(N'2024-03-05' AS Date), N'0987654321', N'BENTHANH  ', N'88315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'1234567900', N'Trần', N'Thị Vân', N'Hồ Chí Minh', N'Nữ', CAST(N'2024-03-05' AS Date), N'0987654323', N'BENTHANH  ', N'92315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'2345678901', N'Trần', N'Thị Bình', N'Hà Nội', N'Nữ', CAST(N'2024-03-05' AS Date), N'0976543210', N'TANDINH   ', N'89315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'2345678910', N'Lê', N'Thị Xuyên', N'Hà Nội', N'Nữ', CAST(N'2024-03-05' AS Date), N'0976543212', N'TANDINH   ', N'93315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'3456789012', N'Lê', N'Văn Cường', N'Hồ Chí Minh', N'Nam', CAST(N'2024-03-05' AS Date), N'0965432109', N'BENTHANH  ', N'8a315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'3456789020', N'Phạm', N'Thị Yến', N'Hồ Chí Minh', N'Nữ', CAST(N'2024-03-05' AS Date), N'0965432111', N'BENTHANH  ', N'94315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'4567890123', N'Phạm', N'Thị Duyên', N'Hà Nội', N'Nữ', CAST(N'2024-03-05' AS Date), N'0954321098', N'BENTHANH  ', N'8b315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'4567890130', N'Nguyễn', N'Thị Zén', N'Hà Nội', N'Nữ', CAST(N'2024-03-05' AS Date), N'0954321100', N'BENTHANH  ', N'95315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'5678901234', N'Hoàng', N'Văn Em', N'Hồ Chí Minh', N'Nam', CAST(N'2024-03-05' AS Date), N'0943210987', N'TANDINH   ', N'8c315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'5678901240', N'Tran', N'Thị Khân', N'Hồ Chí Minh', N'Nữ', CAST(N'2024-03-05' AS Date), N'0943210989', N'TANDINH   ', N'96315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'6789012345', N'Nguyễn', N'Thị Fail', N'Hà Nội', N'Nữ', CAST(N'2024-03-05' AS Date), N'0932109876', N'TANDINH   ', N'8d315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'6789012350', N'Hoàng', N'Thị Linh', N'Hà Nội', N'Nữ', CAST(N'2024-03-05' AS Date), N'0932109878', N'TANDINH   ', N'97315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'7890123456', N'Võ', N'Văn Giang', N'Hồ Chí Minh', N'Nam', CAST(N'2024-03-05' AS Date), N'0921098765', N'BENTHANH  ', N'8e315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'7890123460', N'Võ', N'Thị Minh', N'Hồ Chí Minh', N'Nữ', CAST(N'2024-03-05' AS Date), N'0921098767', N'BENTHANH  ', N'98315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'8901234567', N'Trần', N'Thị Huyền', N'Hà Nội', N'Nữ', CAST(N'2024-03-05' AS Date), N'0910987654', N'BENTHANH  ', N'8f315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'8901234570', N'Tran', N'Thị Ngân', N'Hà Nội', N'Nữ', CAST(N'2024-03-05' AS Date), N'0910987656', N'BENTHANH  ', N'99315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'9012345678', N'Nguyễn', N'Văn Into', N'Hồ Chí Minh', N'Nam', CAST(N'2024-03-05' AS Date), N'0909876543', N'TANDINH   ', N'90315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[KhachHang] ([CMND], [HO], [TEN], [DIACHI], [PHAI], [NGAYCAP], [SODT], [MACN], [rowguid]) VALUES (N'9012345680', N'Nguyễn', N'Thị Phương', N'Hồ Chí Minh', N'Nữ', CAST(N'2024-03-05' AS Date), N'0909876545', N'TANDINH   ', N'9a315fdd-f4da-ee11-9ecc-507b9dbf3058')
GO
INSERT [dbo].[NhanVien] ([MANV], [HO], [TEN], [CMND], [DIACHI], [PHAI], [SODT], [MACN], [TrangThaiXoa], [rowguid]) VALUES (N'NV01      ', N'Trần Minh', N'Nguyên', N'012345678 ', N'Bình Dương', N'Nam', N'1111111111', N'BENTHANH  ', 0, N'4f3e8d6b-89d8-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[NhanVien] ([MANV], [HO], [TEN], [CMND], [DIACHI], [PHAI], [SODT], [MACN], [TrangThaiXoa], [rowguid]) VALUES (N'NV02      ', N'Lê Văn', N'Tài', N'1234567890', NULL, N'Nam', N'2222222222', N'TANDINH   ', 0, N'503e8d6b-89d8-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[NhanVien] ([MANV], [HO], [TEN], [CMND], [DIACHI], [PHAI], [SODT], [MACN], [TrangThaiXoa], [rowguid]) VALUES (N'NV03      ', N'Trần Quang', N'Đại', N'123454321 ', N'Hà Nội', N'Nam', N'0987654321', N'BENTHANH  ', 0, N'50ecbb9f-96d8-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[NhanVien] ([MANV], [HO], [TEN], [CMND], [DIACHI], [PHAI], [SODT], [MACN], [TrangThaiXoa], [rowguid]) VALUES (N'NV04      ', N'Nguyễn Thị', N'Linh', N'4567890123', N'Vũng Tàu', N'Nữ', N'4444444444', N'TANDINH   ', 0, N'7f315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[NhanVien] ([MANV], [HO], [TEN], [CMND], [DIACHI], [PHAI], [SODT], [MACN], [TrangThaiXoa], [rowguid]) VALUES (N'NV05      ', N'Trần Văn', N'Hoàng', N'234144629 ', N'Nghệ An', N'Nam', N'3333333333', N'BENTHANH  ', 0, N'39d40d78-1a10-ef11-9ede-507b9dbf3058')
INSERT [dbo].[NhanVien] ([MANV], [HO], [TEN], [CMND], [DIACHI], [PHAI], [SODT], [MACN], [TrangThaiXoa], [rowguid]) VALUES (N'NV06      ', N'Đoàn Văn', N'Hậu', N'6789012345', N'Hà Nội', N'Nam', N'6666666666', N'TANDINH   ', 0, N'81315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[NhanVien] ([MANV], [HO], [TEN], [CMND], [DIACHI], [PHAI], [SODT], [MACN], [TrangThaiXoa], [rowguid]) VALUES (N'NV07      ', N'Trần Thị', N'Ngân', N'5678901234', N'Đồng Nai', N'Nữ', N'5555555555', N'BENTHANH  ', 0, N'80315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[NhanVien] ([MANV], [HO], [TEN], [CMND], [DIACHI], [PHAI], [SODT], [MACN], [TrangThaiXoa], [rowguid]) VALUES (N'NV08      ', N'Quế Ngọc', N'Hải', N'7890123456', N'Nghệ An', N'Nam', N'7777777777', N'TANDINH   ', 0, N'82315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[NhanVien] ([MANV], [HO], [TEN], [CMND], [DIACHI], [PHAI], [SODT], [MACN], [TrangThaiXoa], [rowguid]) VALUES (N'NV09      ', N'Nguyễn Thị', N'Thúy', N'8901234567', N'Lâm Đồng', N'Nữ', N'1212121212', N'BENTHANH  ', 0, N'83315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[NhanVien] ([MANV], [HO], [TEN], [CMND], [DIACHI], [PHAI], [SODT], [MACN], [TrangThaiXoa], [rowguid]) VALUES (N'NV10      ', N'Lionel', N'Messi', N'9012345678', N'TP.HCM', N'Nam', N'1313131313', N'TANDINH   ', 0, N'84315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[NhanVien] ([MANV], [HO], [TEN], [CMND], [DIACHI], [PHAI], [SODT], [MACN], [TrangThaiXoa], [rowguid]) VALUES (N'NV11      ', N'Critiano', N'Ronaldoê', N'1212121212', N'H?i Phòng', N'Nam', N'1414141414', N'BENTHANH  ', 0, N'85315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[NhanVien] ([MANV], [HO], [TEN], [CMND], [DIACHI], [PHAI], [SODT], [MACN], [TrangThaiXoa], [rowguid]) VALUES (N'NV12      ', N'Taylor', N'Swift', N'1313131313', N'Long An', N'Nữ', N'1515151515', N'TANDINH   ', 0, N'86315fdd-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[NhanVien] ([MANV], [HO], [TEN], [CMND], [DIACHI], [PHAI], [SODT], [MACN], [TrangThaiXoa], [rowguid]) VALUES (N'NV13      ', N'Nguyen', N'Van A', N'141414141 ', N'123 Duong ABC', N'Nam', N'0123456789', N'TANDINH   ', 0, N'556039bc-a80f-ef11-9ede-507b9dbf3058')
INSERT [dbo].[NhanVien] ([MANV], [HO], [TEN], [CMND], [DIACHI], [PHAI], [SODT], [MACN], [TrangThaiXoa], [rowguid]) VALUES (N'NV15      ', N'dfgdg', N'sdgg', N'234144634 ', N'sgsgg', N'Nam', N'313', N'BENTHANH  ', 0, N'95864cdc-8b10-ef11-9ede-507b9dbf3058')
GO
INSERT [dbo].[TaiKhoan] ([SOTK], [CMND], [SODU], [MACN], [rowguid]) VALUES (N'123456789', N'1234567890', 5000000000.0000, N'BENTHANH  ', N'd9615ef2-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[TaiKhoan] ([SOTK], [CMND], [SODU], [MACN], [rowguid]) VALUES (N'234567890', N'2345678901', 10000000.0000, N'BENTHANH  ', N'da615ef2-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[TaiKhoan] ([SOTK], [CMND], [SODU], [MACN], [rowguid]) VALUES (N'345678901', N'3456789012', 20000000.0000, N'TANDINH   ', N'db615ef2-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[TaiKhoan] ([SOTK], [CMND], [SODU], [MACN], [rowguid]) VALUES (N'456789012', N'4567890123', 100000000.0000, N'TANDINH   ', N'dc615ef2-f4da-ee11-9ecc-507b9dbf3058')
INSERT [dbo].[TaiKhoan] ([SOTK], [CMND], [SODU], [MACN], [rowguid]) VALUES (N'567890123', N'5678901234', 300000000.0000, N'BENTHANH  ', N'dd615ef2-f4da-ee11-9ecc-507b9dbf3058')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_ChiNhanh]    Script Date: 5/13/2024 2:38:48 AM ******/
ALTER TABLE [dbo].[ChiNhanh] ADD  CONSTRAINT [UK_ChiNhanh] UNIQUE NONCLUSTERED 
(
	[TENCN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [MSmerge_index_901578250]    Script Date: 5/13/2024 2:38:48 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [MSmerge_index_901578250] ON [dbo].[ChiNhanh]
(
	[rowguid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [MSmerge_index_933578364]    Script Date: 5/13/2024 2:38:48 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [MSmerge_index_933578364] ON [dbo].[GD_CHUYENTIEN]
(
	[rowguid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [MSmerge_index_965578478]    Script Date: 5/13/2024 2:38:48 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [MSmerge_index_965578478] ON [dbo].[GD_GOIRUT]
(
	[rowguid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [MSmerge_index_997578592]    Script Date: 5/13/2024 2:38:48 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [MSmerge_index_997578592] ON [dbo].[KhachHang]
(
	[rowguid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [idx_unique_cmnd]    Script Date: 5/13/2024 2:38:48 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [idx_unique_cmnd] ON [dbo].[NhanVien]
(
	[CMND] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [MSmerge_index_1029578706]    Script Date: 5/13/2024 2:38:48 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [MSmerge_index_1029578706] ON [dbo].[NhanVien]
(
	[rowguid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [MSmerge_index_1077578877]    Script Date: 5/13/2024 2:38:48 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [MSmerge_index_1077578877] ON [dbo].[TaiKhoan]
(
	[rowguid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChiNhanh] ADD  CONSTRAINT [MSmerge_df_rowguid_B089E517381840A18AE8316EF855FE0F]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[GD_CHUYENTIEN] ADD  CONSTRAINT [DF_GD_CHUYENTIEN_NGAYGD]  DEFAULT (getdate()) FOR [NGAYGD]
GO
ALTER TABLE [dbo].[GD_CHUYENTIEN] ADD  CONSTRAINT [MSmerge_df_rowguid_84709EC74EF3473897592A658EEADD13]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[GD_GOIRUT] ADD  CONSTRAINT [DF_GD_GOIRUT_NGAYGD]  DEFAULT (getdate()) FOR [NGAYGD]
GO
ALTER TABLE [dbo].[GD_GOIRUT] ADD  CONSTRAINT [DF_GD_GOIRUT_SOTIEN]  DEFAULT ((100000)) FOR [SOTIEN]
GO
ALTER TABLE [dbo].[GD_GOIRUT] ADD  CONSTRAINT [MSmerge_df_rowguid_FC83AF53CA1846E5951B9F51C3596D04]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[KhachHang] ADD  CONSTRAINT [MSmerge_df_rowguid_8FD8DE76840E471CA72953C4EAD805A6]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[NhanVien] ADD  CONSTRAINT [DF_NhanVien_PHAI]  DEFAULT (N'Nam') FOR [PHAI]
GO
ALTER TABLE [dbo].[NhanVien] ADD  CONSTRAINT [DF_NhanVien_TrangThaiXoa]  DEFAULT ((0)) FOR [TrangThaiXoa]
GO
ALTER TABLE [dbo].[NhanVien] ADD  CONSTRAINT [MSmerge_df_rowguid_6C00369A6DCC43DDA7BE3B1F1B75F66F]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[TaiKhoan] ADD  DEFAULT ((0)) FOR [SODU]
GO
ALTER TABLE [dbo].[TaiKhoan] ADD  CONSTRAINT [MSmerge_df_rowguid_A20B6104C4424C638410B77EA0C2DCA8]  DEFAULT (newsequentialid()) FOR [rowguid]
GO
ALTER TABLE [dbo].[GD_CHUYENTIEN]  WITH CHECK ADD  CONSTRAINT [FK_GD_CHUYENTIEN_NhanVien] FOREIGN KEY([MANV])
REFERENCES [dbo].[NhanVien] ([MANV])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[GD_CHUYENTIEN] CHECK CONSTRAINT [FK_GD_CHUYENTIEN_NhanVien]
GO
ALTER TABLE [dbo].[GD_CHUYENTIEN]  WITH CHECK ADD  CONSTRAINT [FK_GD_CHUYENTIEN_TaiKhoan] FOREIGN KEY([SOTK_CHUYEN])
REFERENCES [dbo].[TaiKhoan] ([SOTK])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[GD_CHUYENTIEN] CHECK CONSTRAINT [FK_GD_CHUYENTIEN_TaiKhoan]
GO
ALTER TABLE [dbo].[GD_CHUYENTIEN]  WITH CHECK ADD  CONSTRAINT [FK_GD_CHUYENTIEN_TaiKhoan1] FOREIGN KEY([SOTK_NHAN])
REFERENCES [dbo].[TaiKhoan] ([SOTK])
GO
ALTER TABLE [dbo].[GD_CHUYENTIEN] CHECK CONSTRAINT [FK_GD_CHUYENTIEN_TaiKhoan1]
GO
ALTER TABLE [dbo].[GD_GOIRUT]  WITH CHECK ADD  CONSTRAINT [FK_GD_GOIRUT_NhanVien] FOREIGN KEY([MANV])
REFERENCES [dbo].[NhanVien] ([MANV])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[GD_GOIRUT] CHECK CONSTRAINT [FK_GD_GOIRUT_NhanVien]
GO
ALTER TABLE [dbo].[GD_GOIRUT]  WITH CHECK ADD  CONSTRAINT [FK_GD_GOIRUT_TaiKhoan] FOREIGN KEY([SOTK])
REFERENCES [dbo].[TaiKhoan] ([SOTK])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[GD_GOIRUT] CHECK CONSTRAINT [FK_GD_GOIRUT_TaiKhoan]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [FK_KhachHang_ChiNhanh] FOREIGN KEY([MACN])
REFERENCES [dbo].[ChiNhanh] ([MACN])
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [FK_KhachHang_ChiNhanh]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_ChiNhanh] FOREIGN KEY([MACN])
REFERENCES [dbo].[ChiNhanh] ([MACN])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_ChiNhanh]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_KhachHang] FOREIGN KEY([CMND])
REFERENCES [dbo].[KhachHang] ([CMND])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_KhachHang]
GO
ALTER TABLE [dbo].[GD_CHUYENTIEN]  WITH CHECK ADD  CONSTRAINT [CK_GD_CHUYENTIEN] CHECK  (([SOTIEN]>(0)))
GO
ALTER TABLE [dbo].[GD_CHUYENTIEN] CHECK CONSTRAINT [CK_GD_CHUYENTIEN]
GO
ALTER TABLE [dbo].[GD_CHUYENTIEN]  WITH NOCHECK ADD  CONSTRAINT [repl_identity_range_79E11956_CBD6_40F1_A3A6_0C24311EBDFF] CHECK NOT FOR REPLICATION (([MAGD]>=(1) AND [MAGD]<=(1001) OR [MAGD]>(1001) AND [MAGD]<=(2001)))
GO
ALTER TABLE [dbo].[GD_CHUYENTIEN] CHECK CONSTRAINT [repl_identity_range_79E11956_CBD6_40F1_A3A6_0C24311EBDFF]
GO
ALTER TABLE [dbo].[GD_GOIRUT]  WITH CHECK ADD  CONSTRAINT [CK_LOAIGD] CHECK  (([LOAIGD]='RT' OR [LOAIGD]='GT'))
GO
ALTER TABLE [dbo].[GD_GOIRUT] CHECK CONSTRAINT [CK_LOAIGD]
GO
ALTER TABLE [dbo].[GD_GOIRUT]  WITH CHECK ADD  CONSTRAINT [CK_SOTIEN] CHECK  (([SOTIEN]>=(100000)))
GO
ALTER TABLE [dbo].[GD_GOIRUT] CHECK CONSTRAINT [CK_SOTIEN]
GO
ALTER TABLE [dbo].[GD_GOIRUT]  WITH NOCHECK ADD  CONSTRAINT [repl_identity_range_A3FF216C_135C_4598_B18E_379BA1D4C118] CHECK NOT FOR REPLICATION (([MAGD]>=(1) AND [MAGD]<=(1001) OR [MAGD]>(1001) AND [MAGD]<=(2001)))
GO
ALTER TABLE [dbo].[GD_GOIRUT] CHECK CONSTRAINT [repl_identity_range_A3FF216C_135C_4598_B18E_379BA1D4C118]
GO
/****** Object:  StoredProcedure [dbo].[DSSV]    Script Date: 5/13/2024 2:38:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DSSV] @ten VARCHAR(100), @tenserver NVARCHAR(100) OUTPUT

AS
SELECT  @tenserver= SUBS.subscriber_server 
                                FROM sysmergepublications pubs
                                INNER JOIN sysmergesubscriptions SUBS ON PUBS.pubid = SUBS.pubid
                                WHERE publisher <> subscriber_server AND pubs.name = @ten
GO
/****** Object:  StoredProcedure [dbo].[Num2Text_SP]    Script Date: 5/13/2024 2:38:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Num2Text_SP]
    @Number int,
    @TextResult nvarchar(4000) OUTPUT
AS 
BEGIN 
    DECLARE @sNumber nvarchar(4000)
    DECLARE @Return nvarchar(4000)
    DECLARE @mLen int
    DECLARE @i int

    DECLARE @mDigit int
    DECLARE @mGroup int
    DECLARE @mTemp nvarchar(4000)
    DECLARE @mNumText nvarchar(4000)

    SELECT @sNumber = LTRIM(STR(@Number))
    SELECT @mLen = Len(@sNumber)

    SELECT @i = 1
    SELECT @mTemp = ''

    WHILE @i <= @mLen
    BEGIN
        SELECT @mDigit = SUBSTRING(@sNumber, @i, 1)

        IF @mDigit = 0 
            SELECT @mNumText = N'không'
        ELSE
        BEGIN
            IF @mDigit = 1 
                SELECT @mNumText = N'một'
            ELSE IF @mDigit = 2 
                SELECT @mNumText = N'hai'
            ELSE IF @mDigit = 3 
                SELECT @mNumText = N'ba'
            ELSE IF @mDigit = 4 
                SELECT @mNumText = N'bốn'
            ELSE IF @mDigit = 5 
                SELECT @mNumText = N'năm'
            ELSE IF @mDigit = 6 
                SELECT @mNumText = N'sáu'
            ELSE IF @mDigit = 7 
                SELECT @mNumText = N'bảy'
            ELSE IF @mDigit = 8 
                SELECT @mNumText = N'tám'
            ELSE IF @mDigit = 9 
                SELECT @mNumText = N'chín'
        END

        SELECT @mTemp = @mTemp + ' ' + @mNumText

        IF (@mLen = @i) BREAK

        SELECT @mGroup = (@mLen - @i) % 9

        IF @mGroup = 0
        BEGIN
            SELECT @mTemp = @mTemp + N' tỷ'

            IF SUBSTRING(@sNumber, @i + 1, 3) = N'000' 
                SELECT @i = @i + 3

            IF SUBSTRING(@sNumber, @i + 1, 3) = N'000' 
                SELECT @i = @i + 3

            IF SUBSTRING(@sNumber, @i + 1, 3) = N'000' 
                SELECT @i = @i + 3
        END 
        ELSE IF @mGroup = 6
        BEGIN
            SELECT @mTemp = @mTemp + N' triệu'

            IF SUBSTRING(@sNumber, @i + 1, 3) = N'000' 
                SELECT @i = @i + 3

            IF SUBSTRING(@sNumber, @i + 1, 3) = N'000' 
                SELECT @i = @i + 3
        END
        ELSE IF @mGroup = 3
        BEGIN
            SELECT @mTemp = @mTemp + N' nghìn'

            IF SUBSTRING(@sNumber, @i + 1, 3) = N'000' 
                SELECT @i = @i + 3
        END
        ELSE
        BEGIN
            SELECT @mGroup = (@mLen - @i) % 3

            IF @mGroup = 2	
                SELECT @mTemp = @mTemp + N' trăm'
            ELSE IF @mGroup = 1
                SELECT @mTemp = @mTemp + N' mươi'	
        END

        SELECT @i = @i + 1
    END

    --'Loại bỏ trường hợp x00
    SELECT @mTemp = Replace(@mTemp, N'không mươi không', '')

    --'Loại bỏ trường hợp 00x
    SELECT @mTemp = Replace(@mTemp, N'không mươi ', N'linh ')

    --'Loại bỏ trường hợp x0, x>=2
    SELECT @mTemp = Replace(@mTemp, N'mươi không', N'mươi')

    --'Fix trường hợp 10
    SELECT @mTemp = Replace(@mTemp, N'một mươi', N'mười')

    --'Fix trường hợp x4, x>=2
    SELECT @mTemp = Replace(@mTemp, N'mươi bốn', N'mươi tư')

    --'Fix trường hợp x04 
    SELECT @mTemp = Replace(@mTemp, N'linh bốn', N'linh tư')

    --'Fix trường hợp x5, x>=2
    SELECT @mTemp = Replace(@mTemp, N'mươi năm', N'mươi nhăm')

    --'Fix trường hợp x1, x>=2
    SELECT @mTemp = Replace(@mTemp, N'mươi một', N'mươi mốt')

    --'Fix trường hợp x15
    SELECT @mTemp = Replace(@mTemp, N'mười năm', N'mười lăm')

    --'Bỏ ký tự space
    SELECT @mTemp = LTrim(@mTemp)

    --'Ucase ký tự đầu tiên
    SELECT @Return = UPPER(Left(@mTemp, 1)) + SUBSTRING(@mTemp, 2, 4000)

    SET @TextResult = @Return
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CHUYENCHINHANH_NV]    Script Date: 5/13/2024 2:38:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CHUYENCHINHANH_NV] 
    @MANV nchar(10), 
    @MANVC nchar(10),
    @MACN nchar(10),
    @CMND nchar(10),
    @CMND0 nchar(10),
	@TENSERVER VARCHAR(100)--,
   -- @LinkServer nchar (20)
AS
DECLARE @LGNAME VARCHAR(50)
DECLARE @USERNAME VARCHAR(50)
declare  @LinkServer nchar (20)
DECLARE @Result NVARCHAR(100)
DECLARE @sql NVARCHAR(MAX);
SET XACT_ABORT ON;
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN TRY
    BEGIN TRAN
		
		--DECLARE @ten VARCHAR(100) = 'NGANHANG_TANDINH';
		-- TIM LINK SERVER

-- Thực hiện stored procedure trên linked server và lấy kết quả vào @Result
EXEC LINK0.NGANHANG.dbo.DSSV @TENSERVER, @Result OUTPUT;

-- Kiểm tra xem @Result có giá trị không
IF @Result IS NOT NULL
BEGIN
    -- Nếu @Result có giá trị, thực hiện câu truy vấn SELECT
    BEGIN TRY
        SELECT @LinkServer = s.name  
        FROM sys.servers AS s 
        WHERE s.product LIKE '%' + @Result + '%';

        -- Kiểm tra xem có kết quả từ câu truy vấn SELECT không
        IF @LinkServer IS NULL
        BEGIN
            -- Nếu không có kết quả, in ra thông báo "raieror" và kết thúc
            RAISERROR('KHONG TIM THAY SERVER CHI NHANH !!!', 16, 1) -- Thông báo khi không tìm thấy kết quả
            RETURN; -- Kết thúc stored procedure
        END
    END TRY
    BEGIN CATCH
        -- Xử lý ngoại lệ khi không thể thực hiện câu lệnh SELECT trên linked server
        RAISERROR('LOI TIM SERVER !!!', 16, 1)
        RETURN; -- Thoát khỏi stored procedure
    END CATCH
END
ELSE
BEGIN
    -- Nếu @Result là NULL, thông báo "raieror" và kết thúc
    RAISERROR('KHONG TIM THAY CHI NHANH !!!', 16, 1) -- Thông báo khi không tìm thấy kết quả
    RETURN; -- Kết thúc stored procedure
END



    SET @sql = '
        IF EXISTS(SELECT * FROM ' + QUOTENAME(@LinkServer) + '.NganHang.dbo.NhanVien WHERE CMND  = @CMND0)
        BEGIN
            UPDATE ' + QUOTENAME(@LinkServer) + '.NganHang.dbo.NhanVien
            SET TrangThaiXoa = 0, CMND = @CMND
            WHERE CMND  = @CMND0;
        END
        ELSE
        BEGIN
            INSERT INTO ' + QUOTENAME(@LinkServer) + '.NganHang.dbo.NhanVien (MANV, HO, TEN, CMND,  DIACHI, PHAI, SODT, MACN, TRANGTHAIXOA)
            SELECT MANV = @MANVC, HO, TEN, CMND = @CMND,  DIACHI, PHAI, SODT, MACN = @MACN, TRANGTHAIXOA
            FROM dbo.NhanVien
            WHERE MANV = @MANV;
        END';

    EXEC sp_executesql @sql, 
                       N'@MANVC NCHAR(10), @MACN NCHAR(10), @CMND NCHAR(10), @MANV NCHAR(10), @CMND0 NCHAR(10)', 
                       @MANVC, @MACN, @CMND, @MANV, @CMND0;
					   

    IF EXISTS(SELECT 1 FROM NhanVien
              WHERE NhanVien.MANV = @MANV AND				
              (EXISTS(SELECT 1 FROM GD_GOIRUT WHERE GD_GOIRUT.MANV = NhanVien.MANV) 
               OR EXISTS(SELECT MAGD FROM GD_CHUYENTIEN WHERE GD_CHUYENTIEN.MANV = NhanVien.MANV)))
    BEGIN 
        UPDATE dbo.NhanVien
        SET TrangThaiXoa = 1, CMND = @CMND0
        WHERE MANV = @MANV;
    END
    ELSE
    BEGIN
        DELETE FROM dbo.NhanVien WHERE MANV = @MANV;
    END

    COMMIT TRAN;

    IF EXISTS(SELECT SUSER_SNAME(sid) FROM sys.sysusers WHERE name = CAST(@MANV AS NVARCHAR))
    BEGIN
        SET @LGNAME = CAST((SELECT SUSER_SNAME(sid) FROM sys.sysusers WHERE name = CAST(@MANV AS NVARCHAR)) AS VARCHAR(50))
        SET @USERNAME = CAST(@MANV AS VARCHAR(50))
        EXEC SP_DROPUSER @USERNAME;
        EXEC SP_DROPLOGIN  @LGNAME;
    END
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0)
    BEGIN
        ROLLBACK TRAN;
    END;
    THROW;
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[SP_CHUYENTIEN]    Script Date: 5/13/2024 2:38:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_CHUYENTIEN] (@STKGUI nChar(9), @STKNHAN nChar(9), @TIEN MONEY,@MANV NCHAR(10))
AS
SET XACT_ABORT ON	--NEU OFF THI SQL SE BO QUA LENH GAY LOI VA CHAY TIEP
BEGIN
	--KIEM TRA STK_GUI VA STK_NHAN CO TON TAI TRONG DB HAY KHONG, SAU DO THI KIEM TRA SO DU NGUOI GUI.
	IF ( EXISTS( SELECT SOTK FROM TaiKhoan WHERE SOTK=@STKNHAN ) AND 
			EXISTS( SELECT SOTK FROM TaiKhoan WHERE SOTK=@STKGUI) )
		BEGIN
			DECLARE @SODU_NGUOICHUYEN MONEY
			SELECT @SODU_NGUOICHUYEN = SODU FROM TaiKhoan WHERE @STKGUI = SOTK

			IF @SODU_NGUOICHUYEN < @TIEN
				RAISERROR('SO DU KHONG DU !!!', 16, 1)
			ELSE
				BEGIN
					BEGIN TRANSACTION
					BEGIN TRY
						UPDATE TaiKhoan
						SET SODU -= @TIEN
						WHERE @STKGUI = SOTK

						UPDATE TaiKhoan
						SET SODU += @TIEN
						WHERE @STKNHAN = SOTK

						INSERT INTO GD_CHUYENTIEN(SOTK_CHUYEN,NGAYGD,SOTIEN,SOTK_NHAN,MANV) 
							VALUES (@STKGUI,GETDATE(),@TIEN,@STKNHAN,@MANV)

						COMMIT
					END TRY
					
					BEGIN CATCH		-- một số trường hợp bất ngờ có thể xảy ra gây ra lỗi
						ROLLBACK	-- ví dụ như mất điện khi đang cộng trừ tiền trong tài khoản.
						DECLARE @ERRORMESSAGE VARCHAR(2000)
						SELECT @ERRORMESSAGE = 'Lỗi: ' + ERROR_MESSAGE()
						RAISERROR(@ERRORMESSAGE, 16, 1)
					END CATCH
				END
		END
	ELSE
		RAISERROR('SO TAI KHOAN KHONG TON TAI !!!', 16, 1)
END

GO
/****** Object:  StoredProcedure [dbo].[SP_GUIRUT]    Script Date: 5/13/2024 2:38:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[SP_GUIRUT] (@STK	NCHAR(9), @TIEN MONEY, @LOAIGD NCHAR(2),@MANV NCHAR(10))
AS
SET XACT_ABORT ON		-- NEU OFF THI SQL SE BO QUA LENH GAY LOI.
BEGIN TRANSACTION		-- Nếu chỉ SP chỉ có một lệnh UPDATE thì ta không cần sử dụng giao tác vì nó là giao tác tự động.
	BEGIN TRY			-- Nhưng SP này ta có 2 lệnh là UPDATE và INSERT.
		IF EXISTS(SELECT SOTK FROM TaiKhoan WHERE SOTK=@STK)	-- Kiểm tra stk có tồn tại hay không, sau đó xét xem nó là 'RT' hay 'GT'
			BEGIN
				DECLARE @SODU MONEY
				SELECT @SODU=SODU FROM TaiKhoan WHERE @STK=SOTK

				IF @LOAIGD = 'GT'
					BEGIN
						UPDATE TaiKhoan
						SET SODU += @TIEN
						WHERE @STK = SOTK

						INSERT INTO GD_GOIRUT(SOTK,LOAIGD,NGAYGD,SOTIEN,MANV) 
							VALUES(@STK,@LOAIGD,GETDATE(),@TIEN,@MANV)
					END

	
				ELSE IF @LOAIGD = 'RT'
					BEGIN
						IF @SODU < @TIEN
							RAISERROR('SO DU KHONG DU !!!', 16, 1)
						ELSE
							BEGIN
								UPDATE TaiKhoan
								SET SODU -= @TIEN
								WHERE @STK = SOTK

								INSERT INTO GD_GOIRUT(SOTK,LOAIGD,NGAYGD,SOTIEN,MANV) 
									VALUES(@STK,@LOAIGD,GETDATE(),@TIEN,@MANV)
							END
					END
			END
		ELSE
			RAISERROR('SO TAI KHOAN KHONG TON TAI !!!', 16, 1)
		
		COMMIT
	END TRY
	
BEGIN CATCH
	ROLLBACK
	DECLARE @ERRORMESSAGE VARCHAR(2000)
	SELECT @ERRORMESSAGE = 'Lỗi: ' + ERROR_MESSAGE()
	RAISERROR(@ERRORMESSAGE, 16, 1)
END CATCH


GO
/****** Object:  StoredProcedure [dbo].[SP_KiemTraCMNDNhanVien]    Script Date: 5/13/2024 2:38:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_KiemTraCMNDNhanVien]
	@X NCHAR(10)
AS
BEGIN
	DECLARE @ktnv INT
	SELECT @ktnv = COUNT(*) FROM NhanVien WHERE CMND=@X

	IF @ktnv != 0
	BEGIN
		SELECT CAST(1 AS BIT)
		RETURN 
	END
		

	SELECT @ktnv = COUNT(*) FROM LINK1.NGANHANG.dbo.NhanVien WHERE CMND=@X

	IF @ktnv = 0
	BEGIN
		SELECT CAST(0 AS BIT)
		RETURN 
	END

	SELECT CAST(1 AS BIT)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_kiemtraNV]    Script Date: 5/13/2024 2:38:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[SP_kiemtraNV]
	@X NCHAR(10)
AS
BEGIN
	DECLARE @ktnv INT
	SELECT @ktnv = COUNT(*) FROM NhanVien WHERE MANV=@X

	IF @ktnv != 0
	BEGIN
		SELECT CAST(1 AS BIT)
		RETURN 
	END
		

	SELECT @ktnv = COUNT(*) FROM LINK1.NGANHANG.dbo.NhanVien WHERE MANV=@X

	IF @ktnv = 0
	BEGIN
		SELECT CAST(0 AS BIT)
		RETURN 
	END

	SELECT CAST(1 AS BIT)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_KiemTraSTK]    Script Date: 5/13/2024 2:38:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_KiemTraSTK]
	@STK NCHAR(9)
AS
BEGIN
IF  EXISTS( SELECT SOTK FROM TaiKhoan WHERE SOTK=@STK )
BEGIN
SELECT (kh.HO + ' ' + kh.TEN) AS [HOTEN], SODU FROM TaiKhoan
JOIN LINK2.NGANHANG.dbo.KhachHang KH ON TaiKhoan.CMND = KH.CMND
WHERE SOTK = @STK
END
ELSE
RAISERROR('SO TAI KHOAN KHONG TON TAI !!!', 16, 1)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LAY_DS_CHI_NHANH]    Script Date: 5/13/2024 2:38:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_LAY_DS_CHI_NHANH]
	@MACN NVARCHAR(20)
AS
BEGIN
	SELECT CN.MACN, CN.TENCN,CN.DIACHI, CN.SoDT FROM LINK0.NGANHANG.DBO.CHINHANH CN
	WHERE CN.MACN <>  @MACN
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Lay_Thong_Tin_NV_Tu_Login]    Script Date: 5/13/2024 2:38:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_Lay_Thong_Tin_NV_Tu_Login] @TENLOGIN NVARCHAR(20)
AS
BEGIN
	DECLARE @UID INT
	DECLARE @MANV NCHAR(10)

	SELECT @UID = UID, @MANV = NAME  FROM SYS.sysusers
		WHERE SID = SUSER_SID(@TENLOGIN)

	DECLARE @HOVATEN NVARCHAR(50)
	SELECT @HOVATEN = (HO + ' ' + TEN) FROM NHANVIEN WHERE @MANV = MANV

	IF @HOVATEN IS NULL
		RAISERROR (N'Nhân viên không tồn tại', 16, 1)

	SELECT MANV = @MANV,
		   HOVATEN = @HOVATEN,
		   NHOM = NAME
	FROM SYS.SYSUSERS 
	WHERE UID = (SELECT GROUPUID FROM SYS.SYSMEMBERS WHERE MEMBERUID = @UID) AND (NAME = 'NGANHANG' OR NAME = 'CHINHANH')
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MaxMANV]    Script Date: 5/13/2024 2:38:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_MaxMANV]
@test INT
AS
BEGIN
	SELECT MAX(manv) AS MANV
FROM LINK0.NGANHANG.dbo.NhanVien;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Num2Text]    Script Date: 5/13/2024 2:38:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Num2Text]
    @Number int
AS 
BEGIN 
    DECLARE @sNumber nvarchar(4000)
    DECLARE @Return nvarchar(4000)
    DECLARE @mLen int
    DECLARE @i int

    DECLARE @mDigit int
    DECLARE @mGroup int
    DECLARE @mTemp nvarchar(4000)
    DECLARE @mNumText nvarchar(4000)

    SELECT @sNumber = LTRIM(STR(@Number))
    SELECT @mLen = Len(@sNumber)

    SELECT @i = 1
    SELECT @mTemp = ''

    WHILE @i <= @mLen
    BEGIN
        SELECT @mDigit = SUBSTRING(@sNumber, @i, 1)

        IF @mDigit = 0 
            SELECT @mNumText = N'không'
        ELSE
        BEGIN
            IF @mDigit = 1 
                SELECT @mNumText = N'một'
            ELSE IF @mDigit = 2 
                SELECT @mNumText = N'hai'
            ELSE IF @mDigit = 3 
                SELECT @mNumText = N'ba'
            ELSE IF @mDigit = 4 
                SELECT @mNumText = N'bốn'
            ELSE IF @mDigit = 5 
                SELECT @mNumText = N'năm'
            ELSE IF @mDigit = 6 
                SELECT @mNumText = N'sáu'
            ELSE IF @mDigit = 7 
                SELECT @mNumText = N'bảy'
            ELSE IF @mDigit = 8 
                SELECT @mNumText = N'tám'
            ELSE IF @mDigit = 9 
                SELECT @mNumText = N'chín'
        END

        SELECT @mTemp = @mTemp + ' ' + @mNumText

        IF (@mLen = @i) BREAK

        SELECT @mGroup = (@mLen - @i) % 9

        IF @mGroup = 0
        BEGIN
            SELECT @mTemp = @mTemp + N' tỷ'

            IF SUBSTRING(@sNumber, @i + 1, 3) = N'000' 
                SELECT @i = @i + 3

            IF SUBSTRING(@sNumber, @i + 1, 3) = N'000' 
                SELECT @i = @i + 3

            IF SUBSTRING(@sNumber, @i + 1, 3) = N'000' 
                SELECT @i = @i + 3
        END 
        ELSE IF @mGroup = 6
        BEGIN
            SELECT @mTemp = @mTemp + N' triệu'

            IF SUBSTRING(@sNumber, @i + 1, 3) = N'000' 
                SELECT @i = @i + 3

            IF SUBSTRING(@sNumber, @i + 1, 3) = N'000' 
                SELECT @i = @i + 3
        END
        ELSE IF @mGroup = 3
        BEGIN
            SELECT @mTemp = @mTemp + N' nghìn'

            IF SUBSTRING(@sNumber, @i + 1, 3) = N'000' 
                SELECT @i = @i + 3
        END
        ELSE
        BEGIN
            SELECT @mGroup = (@mLen - @i) % 3

            IF @mGroup = 2	
                SELECT @mTemp = @mTemp + N' trăm'
            ELSE IF @mGroup = 1
                SELECT @mTemp = @mTemp + N' mươi'	
        END

        SELECT @i = @i + 1
    END

    --'Loại bỏ trường hợp x00
    SELECT @mTemp = Replace(@mTemp, N'không mươi không', '')

    --'Loại bỏ trường hợp 00x
    SELECT @mTemp = Replace(@mTemp, N'không mươi ', N'linh ')

    --'Loại bỏ trường hợp x0, x>=2
    SELECT @mTemp = Replace(@mTemp, N'mươi không', N'mươi')

    --'Fix trường hợp 10
    SELECT @mTemp = Replace(@mTemp, N'một mươi', N'mười')

    --'Fix trường hợp x4, x>=2
    SELECT @mTemp = Replace(@mTemp, N'mươi bốn', N'mươi tư')

    --'Fix trường hợp x04 
    SELECT @mTemp = Replace(@mTemp, N'linh bốn', N'linh tư')

    --'Fix trường hợp x5, x>=2
    SELECT @mTemp = Replace(@mTemp, N'mươi năm', N'mươi nhăm')

    --'Fix trường hợp x1, x>=2
    SELECT @mTemp = Replace(@mTemp, N'mươi một', N'mươi mốt')

    --'Fix trường hợp x15
    SELECT @mTemp = Replace(@mTemp, N'mười năm', N'mười lăm')

    --'Bỏ ký tự space
    SELECT @mTemp = LTrim(@mTemp)

    --'Ucase ký tự đầu tiên
    SELECT @Return = UPPER(Left(@mTemp, 1)) + SUBSTRING(@mTemp, 2, 4000)

    SELECT @Return AS SOTIEN
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tao_tai_khoan_nhan_vien]    Script Date: 5/13/2024 2:38:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_tao_tai_khoan_nhan_vien]
     
    @USERNAME VARCHAR(50), @LGNAME VARCHAR(50), @PASS VARCHAR(50), @ROLE VARCHAR(50)     
AS
  DECLARE @RET INT
  EXEC @RET= SP_ADDLOGIN @LGNAME, @PASS, 'NGANHANG'
  IF (@RET =1)  -- LOGIN NAME BI TRUNG
  BEGIN
     RAISERROR ('Login name bị trùng', 16,1)
	 RETURN
  END 
  EXEC @RET= SP_GRANTDBACCESS @LGNAME, @USERNAME
  IF (@RET =1)  -- USER  NAME BI TRUNG
  BEGIN
       EXEC SP_DROPLOGIN @LGNAME
       RAISERROR ('Nhân viên dã có login name', 16,2)
       RETURN
  END
  EXEC sp_addrolemember @ROLE, @USERNAME
  IF @ROLE = 'ADMIN'
  BEGIN
      EXEC sp_addsrvrolemember @LGNAME, 'SecurityAdmin'
      EXEC sp_addsrvrolemember @LGNAME, 'DBCREATOR'
	  EXEC sp_addsrvrolemember @LGNAME, 'ProcessAdmin'
  END
GO
/****** Object:  StoredProcedure [dbo].[sp_TimNV]    Script Date: 5/13/2024 2:38:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_TimNV]
	@X NCHAR(10)
AS
BEGIN
	IF EXISTS(SELECT MANV FROM dbo.NhanVien WHERE dbo.NhanVien.MANV = @X)
		RETURN 1; 
	ELSE IF EXISTS(SELECT MANV FROM LINK1.NGANHANG.dbo.NhanVien AS NV WHERE NV.MANV = @X)
		RETURN 1; 
	ELSE 
		RETURN 0;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_xoa_tai_khoan_nhan_vien]    Script Date: 5/13/2024 2:38:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_xoa_tai_khoan_nhan_vien]
	@manv NCHAR(10)
AS
BEGIN
	DECLARE @loginname NVARCHAR(30)

	-- Find login name  by @manv
	SELECT @loginname = L.name FROM sys.sysusers U
	INNER JOIN sys.syslogins L ON U.sid = L.sid
	WHERE U.name = @manv

	EXEC sp_revokedbaccess @manv
	EXEC sp_droplogin @loginname
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'‘GT’ : gởi tiền vào TK , ‘RT’ : rút tiền khỏi TK' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GD_GOIRUT', @level2type=N'COLUMN',@level2name=N'LOAIGD'
GO
USE [master]
GO
ALTER DATABASE [NGANHANG] SET  READ_WRITE 
GO

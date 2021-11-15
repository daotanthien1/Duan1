USE [master]
GO
/****** Object:  Database [DuAn1]    Script Date: 11/15/2021 10:54:22 PM ******/
CREATE DATABASE [DuAn1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DuAn1', FILENAME = N'D:\database\DuAn1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DuAn1_log', FILENAME = N'D:\database\DuAn1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DuAn1] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DuAn1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DuAn1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DuAn1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DuAn1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DuAn1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DuAn1] SET ARITHABORT OFF 
GO
ALTER DATABASE [DuAn1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DuAn1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DuAn1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DuAn1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DuAn1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DuAn1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DuAn1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DuAn1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DuAn1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DuAn1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DuAn1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DuAn1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DuAn1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DuAn1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DuAn1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DuAn1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DuAn1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DuAn1] SET RECOVERY FULL 
GO
ALTER DATABASE [DuAn1] SET  MULTI_USER 
GO
ALTER DATABASE [DuAn1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DuAn1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DuAn1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DuAn1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DuAn1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DuAn1] SET QUERY_STORE = OFF
GO
USE [DuAn1]
GO
/****** Object:  Table [dbo].[Beverages]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beverages](
	[Name] [nvarchar](55) NOT NULL,
	[Price] [float] NOT NULL,
	[Id_type] [int] NOT NULL,
	[Id_beverage] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_beverage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bills]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bills](
	[Id_employee] [int] NOT NULL,
	[Id_bill] [int] IDENTITY(1,1) NOT NULL,
	[Id_customer] [int] NULL,
	[Id_table] [int] NOT NULL,
	[DateCheckIn] [datetime] NOT NULL,
	[DateCheckOut] [datetime] NULL,
	[status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_bill] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bills_detail]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bills_detail](
	[Id_bill_detaill] [int] IDENTITY(1,1) NOT NULL,
	[Id_bill] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Id_beverage] [int] NOT NULL,
	[totalPrice] [float] NULL,
	[sale] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_bill_detaill] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Email] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](10) NOT NULL,
	[Id_customer] [int] IDENTITY(1,1) NOT NULL,
	[Reward] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_customer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id_role] [int] NOT NULL,
	[Gender] [int] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Password] [varchar](100) NULL,
	[DayOfBirth] [date] NOT NULL,
	[Id_employee] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Salary] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_employee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredients]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredients](
	[Id_ingredient] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Id_supplier] [int] NOT NULL,
	[Id_type] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[mass] [real] NULL,
	[Id_unit] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_ingredient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InputBills]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InputBills](
	[ID_Bill] [int] IDENTITY(1,1) NOT NULL,
	[DateCheckIn] [datetime] NOT NULL,
	[ID_employee] [int] NOT NULL,
	[SumPrice] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Bill] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InputBillsDetaill]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InputBillsDetaill](
	[Id_BillDetaill] [int] IDENTITY(1,1) NOT NULL,
	[quantity] [float] NOT NULL,
	[Id_Ingredient] [int] NOT NULL,
	[ID_Bill] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_BillDetaill] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id_role] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedules]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedules](
	[Id_schedule] [int] IDENTITY(1,1) NOT NULL,
	[Id_employee] [int] NOT NULL,
	[Id_shift] [int] NOT NULL,
	[Days] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_schedule] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shifts]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shifts](
	[TimeBegin] [varchar](10) NOT NULL,
	[TimeEnd] [varchar](10) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[Id_shift] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_shift] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[Name] [nvarchar](50) NOT NULL,
	[Id_supplier] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_supplier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tables]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tables](
	[ID_Table] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Table] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypesOfBeverage]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypesOfBeverage](
	[Id_type] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypesOfIngredient]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypesOfIngredient](
	[Id_type] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypesVoucher]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypesVoucher](
	[ID_Type] [int] IDENTITY(1,1) NOT NULL,
	[Sale] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[units]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[units](
	[ID_unit] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_unit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vouchers]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vouchers](
	[Id_voucher] [varchar](6) NOT NULL,
	[DateBegin] [date] NOT NULL,
	[DateEnd] [date] NULL,
	[Id_employee] [int] NOT NULL,
	[ID_Type] [int] NOT NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_voucher] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Beverages] ON 
GO
INSERT [dbo].[Beverages] ([Name], [Price], [Id_type], [Id_beverage], [Image]) VALUES (N'đồ uống 1', 10000, 1, 1, N'Images\Images\183890896_1590654974613258_3415619598044667773_n.jpg')
GO
INSERT [dbo].[Beverages] ([Name], [Price], [Id_type], [Id_beverage], [Image]) VALUES (N'đồ uống 2', 100000, 2, 2, N'Images\Images\202741576_322461289348291_9177331863886024386_n.jpg')
GO
INSERT [dbo].[Beverages] ([Name], [Price], [Id_type], [Id_beverage], [Image]) VALUES (N'đồ uống 3', 1000, 1, 3, N'Images\Images\183890896_1590654974613258_3415619598044667773_n.jpg')
GO
SET IDENTITY_INSERT [dbo].[Beverages] OFF
GO
SET IDENTITY_INSERT [dbo].[Bills] ON 
GO
INSERT [dbo].[Bills] ([Id_employee], [Id_bill], [Id_customer], [Id_table], [DateCheckIn], [DateCheckOut], [status]) VALUES (1, 21, NULL, 2, CAST(N'2021-11-15T16:08:23.040' AS DateTime), CAST(N'2021-11-15T16:08:25.863' AS DateTime), 1)
GO
INSERT [dbo].[Bills] ([Id_employee], [Id_bill], [Id_customer], [Id_table], [DateCheckIn], [DateCheckOut], [status]) VALUES (1, 22, NULL, 3, CAST(N'2021-11-15T16:08:27.843' AS DateTime), CAST(N'2021-11-15T16:08:28.870' AS DateTime), 1)
GO
INSERT [dbo].[Bills] ([Id_employee], [Id_bill], [Id_customer], [Id_table], [DateCheckIn], [DateCheckOut], [status]) VALUES (1, 23, NULL, 2, CAST(N'2021-11-15T17:14:28.287' AS DateTime), CAST(N'2021-11-15T17:14:30.743' AS DateTime), 1)
GO
INSERT [dbo].[Bills] ([Id_employee], [Id_bill], [Id_customer], [Id_table], [DateCheckIn], [DateCheckOut], [status]) VALUES (1, 24, NULL, 3, CAST(N'2021-11-15T17:14:32.443' AS DateTime), CAST(N'2021-11-15T18:06:21.277' AS DateTime), 1)
GO
INSERT [dbo].[Bills] ([Id_employee], [Id_bill], [Id_customer], [Id_table], [DateCheckIn], [DateCheckOut], [status]) VALUES (1, 25, NULL, 2, CAST(N'2021-11-15T18:06:12.180' AS DateTime), CAST(N'2021-11-15T18:06:17.573' AS DateTime), 1)
GO
INSERT [dbo].[Bills] ([Id_employee], [Id_bill], [Id_customer], [Id_table], [DateCheckIn], [DateCheckOut], [status]) VALUES (1, 26, NULL, 7, CAST(N'2021-11-15T21:33:52.477' AS DateTime), NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Bills] OFF
GO
SET IDENTITY_INSERT [dbo].[Bills_detail] ON 
GO
INSERT [dbo].[Bills_detail] ([Id_bill_detaill], [Id_bill], [Quantity], [Id_beverage], [totalPrice], [sale]) VALUES (29, 21, 1, 1, 10000, 0)
GO
INSERT [dbo].[Bills_detail] ([Id_bill_detaill], [Id_bill], [Quantity], [Id_beverage], [totalPrice], [sale]) VALUES (30, 22, 1, 1, 10000, 0)
GO
INSERT [dbo].[Bills_detail] ([Id_bill_detaill], [Id_bill], [Quantity], [Id_beverage], [totalPrice], [sale]) VALUES (31, 23, 1, 1, 10000, 0)
GO
INSERT [dbo].[Bills_detail] ([Id_bill_detaill], [Id_bill], [Quantity], [Id_beverage], [totalPrice], [sale]) VALUES (32, 24, 1, 1, 10000, 0)
GO
INSERT [dbo].[Bills_detail] ([Id_bill_detaill], [Id_bill], [Quantity], [Id_beverage], [totalPrice], [sale]) VALUES (33, 25, 4, 1, 40000, 0)
GO
INSERT [dbo].[Bills_detail] ([Id_bill_detaill], [Id_bill], [Quantity], [Id_beverage], [totalPrice], [sale]) VALUES (34, 26, 2, 2, 200000, 0)
GO
SET IDENTITY_INSERT [dbo].[Bills_detail] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 
GO
INSERT [dbo].[Customers] ([Email], [name], [Gender], [Id_customer], [Reward]) VALUES (N'tungnh230802@gmail.com', N'tung', N'nam', 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 
GO
INSERT [dbo].[Employees] ([Id_role], [Gender], [Email], [Address], [Password], [DayOfBirth], [Id_employee], [Name], [Salary]) VALUES (1, 1, N'tungnh230802@gmail.com', N'binh thuan', N'1292201552198220877194054219216496220885', CAST(N'2021-11-07' AS Date), 1, N'tùng', 100000000)
GO
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[Ingredients] ON 
GO
INSERT [dbo].[Ingredients] ([Id_ingredient], [Name], [Id_supplier], [Id_type], [Price], [mass], [Id_unit]) VALUES (1, N'nl 1', 2, 2, 1000, NULL, NULL)
GO
INSERT [dbo].[Ingredients] ([Id_ingredient], [Name], [Id_supplier], [Id_type], [Price], [mass], [Id_unit]) VALUES (2, N'nl 1', 1, 1, 1000, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Ingredients] OFF
GO
SET IDENTITY_INSERT [dbo].[InputBills] ON 
GO
INSERT [dbo].[InputBills] ([ID_Bill], [DateCheckIn], [ID_employee], [SumPrice]) VALUES (3, CAST(N'2021-11-15T06:18:24.020' AS DateTime), 1, 50000)
GO
INSERT [dbo].[InputBills] ([ID_Bill], [DateCheckIn], [ID_employee], [SumPrice]) VALUES (5, CAST(N'2021-11-15T09:41:57.300' AS DateTime), 1, 5000)
GO
INSERT [dbo].[InputBills] ([ID_Bill], [DateCheckIn], [ID_employee], [SumPrice]) VALUES (6, CAST(N'2021-11-15T09:47:05.027' AS DateTime), 1, 1000000)
GO
INSERT [dbo].[InputBills] ([ID_Bill], [DateCheckIn], [ID_employee], [SumPrice]) VALUES (7, CAST(N'2021-11-15T10:50:10.527' AS DateTime), 1, 10000)
GO
SET IDENTITY_INSERT [dbo].[InputBills] OFF
GO
SET IDENTITY_INSERT [dbo].[InputBillsDetaill] ON 
GO
INSERT [dbo].[InputBillsDetaill] ([Id_BillDetaill], [quantity], [Id_Ingredient], [ID_Bill]) VALUES (2, 1000, 2, 6)
GO
INSERT [dbo].[InputBillsDetaill] ([Id_BillDetaill], [quantity], [Id_Ingredient], [ID_Bill]) VALUES (3, 10, 2, 7)
GO
SET IDENTITY_INSERT [dbo].[InputBillsDetaill] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([Id_role], [Name]) VALUES (1, N'Quản lý')
GO
INSERT [dbo].[Roles] ([Id_role], [Name]) VALUES (2, N'Nhân viên')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Suppliers] ON 
GO
INSERT [dbo].[Suppliers] ([Name], [Id_supplier], [Email], [Address]) VALUES (N'ncc 1', 1, N'1', N'1')
GO
INSERT [dbo].[Suppliers] ([Name], [Id_supplier], [Email], [Address]) VALUES (N'ncc 2', 2, N'1', N'1')
GO
SET IDENTITY_INSERT [dbo].[Suppliers] OFF
GO
SET IDENTITY_INSERT [dbo].[tables] ON 
GO
INSERT [dbo].[tables] ([ID_Table], [name], [Status]) VALUES (1, N'bàn 1', N'Trống')
GO
INSERT [dbo].[tables] ([ID_Table], [name], [Status]) VALUES (2, N'bàn 2', N'Trống')
GO
INSERT [dbo].[tables] ([ID_Table], [name], [Status]) VALUES (3, N'bàn 3', N'Trống')
GO
INSERT [dbo].[tables] ([ID_Table], [name], [Status]) VALUES (4, N'bàn 4', N'Trống')
GO
INSERT [dbo].[tables] ([ID_Table], [name], [Status]) VALUES (5, N'bàn 5', N'Trống')
GO
INSERT [dbo].[tables] ([ID_Table], [name], [Status]) VALUES (6, N'bàn 6', N'Trống')
GO
INSERT [dbo].[tables] ([ID_Table], [name], [Status]) VALUES (7, N'bàn 7', N'Trống')
GO
SET IDENTITY_INSERT [dbo].[tables] OFF
GO
SET IDENTITY_INSERT [dbo].[TypesOfBeverage] ON 
GO
INSERT [dbo].[TypesOfBeverage] ([Id_type], [Name]) VALUES (1, N'loại 1')
GO
INSERT [dbo].[TypesOfBeverage] ([Id_type], [Name]) VALUES (2, N'loại 2')
GO
INSERT [dbo].[TypesOfBeverage] ([Id_type], [Name]) VALUES (3, N'loại 3')
GO
INSERT [dbo].[TypesOfBeverage] ([Id_type], [Name]) VALUES (4, N'loại 4')
GO
SET IDENTITY_INSERT [dbo].[TypesOfBeverage] OFF
GO
SET IDENTITY_INSERT [dbo].[TypesOfIngredient] ON 
GO
INSERT [dbo].[TypesOfIngredient] ([Id_type], [Name]) VALUES (1, N'nl 1')
GO
INSERT [dbo].[TypesOfIngredient] ([Id_type], [Name]) VALUES (2, N'nl 2')
GO
SET IDENTITY_INSERT [dbo].[TypesOfIngredient] OFF
GO
SET IDENTITY_INSERT [dbo].[TypesVoucher] ON 
GO
INSERT [dbo].[TypesVoucher] ([ID_Type], [Sale]) VALUES (1, 20)
GO
INSERT [dbo].[TypesVoucher] ([ID_Type], [Sale]) VALUES (2, 15)
GO
INSERT [dbo].[TypesVoucher] ([ID_Type], [Sale]) VALUES (3, 0)
GO
SET IDENTITY_INSERT [dbo].[TypesVoucher] OFF
GO
ALTER TABLE [dbo].[Bills] ADD  DEFAULT (getdate()) FOR [DateCheckIn]
GO
ALTER TABLE [dbo].[Bills] ADD  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[Bills_detail] ADD  DEFAULT ((0)) FOR [sale]
GO
ALTER TABLE [dbo].[Customers] ADD  DEFAULT ((0)) FOR [Reward]
GO
ALTER TABLE [dbo].[Employees] ADD  DEFAULT ('1292201552198220877194054219216496220885') FOR [Password]
GO
ALTER TABLE [dbo].[InputBills] ADD  DEFAULT (getdate()) FOR [DateCheckIn]
GO
ALTER TABLE [dbo].[tables] ADD  DEFAULT (N'trống') FOR [Status]
GO
ALTER TABLE [dbo].[Vouchers] ADD  DEFAULT (getdate()) FOR [DateBegin]
GO
ALTER TABLE [dbo].[Vouchers] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Beverages]  WITH CHECK ADD  CONSTRAINT [FK_Id_type_Beverages] FOREIGN KEY([Id_type])
REFERENCES [dbo].[TypesOfBeverage] ([Id_type])
GO
ALTER TABLE [dbo].[Beverages] CHECK CONSTRAINT [FK_Id_type_Beverages]
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD  CONSTRAINT [FK_Id_customer] FOREIGN KEY([Id_customer])
REFERENCES [dbo].[Customers] ([Id_customer])
GO
ALTER TABLE [dbo].[Bills] CHECK CONSTRAINT [FK_Id_customer]
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD  CONSTRAINT [FK_Id_employee_Employee] FOREIGN KEY([Id_employee])
REFERENCES [dbo].[Employees] ([Id_employee])
GO
ALTER TABLE [dbo].[Bills] CHECK CONSTRAINT [FK_Id_employee_Employee]
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD  CONSTRAINT [FK_Id_table] FOREIGN KEY([Id_table])
REFERENCES [dbo].[tables] ([ID_Table])
GO
ALTER TABLE [dbo].[Bills] CHECK CONSTRAINT [FK_Id_table]
GO
ALTER TABLE [dbo].[Bills_detail]  WITH CHECK ADD  CONSTRAINT [FK_Id_beverage_Bill_detail] FOREIGN KEY([Id_beverage])
REFERENCES [dbo].[Beverages] ([Id_beverage])
GO
ALTER TABLE [dbo].[Bills_detail] CHECK CONSTRAINT [FK_Id_beverage_Bill_detail]
GO
ALTER TABLE [dbo].[Bills_detail]  WITH CHECK ADD  CONSTRAINT [FK_Id_bill_BillDetail] FOREIGN KEY([Id_bill])
REFERENCES [dbo].[Bills] ([Id_bill])
GO
ALTER TABLE [dbo].[Bills_detail] CHECK CONSTRAINT [FK_Id_bill_BillDetail]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [fk_idRole] FOREIGN KEY([Id_role])
REFERENCES [dbo].[Roles] ([Id_role])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [fk_idRole]
GO
ALTER TABLE [dbo].[Ingredients]  WITH CHECK ADD  CONSTRAINT [fk] FOREIGN KEY([Id_unit])
REFERENCES [dbo].[units] ([ID_unit])
GO
ALTER TABLE [dbo].[Ingredients] CHECK CONSTRAINT [fk]
GO
ALTER TABLE [dbo].[Ingredients]  WITH CHECK ADD  CONSTRAINT [FK_ID_supplier] FOREIGN KEY([Id_supplier])
REFERENCES [dbo].[Suppliers] ([Id_supplier])
GO
ALTER TABLE [dbo].[Ingredients] CHECK CONSTRAINT [FK_ID_supplier]
GO
ALTER TABLE [dbo].[Ingredients]  WITH CHECK ADD  CONSTRAINT [FK_ID_Type] FOREIGN KEY([Id_type])
REFERENCES [dbo].[TypesOfIngredient] ([Id_type])
GO
ALTER TABLE [dbo].[Ingredients] CHECK CONSTRAINT [FK_ID_Type]
GO
ALTER TABLE [dbo].[InputBills]  WITH CHECK ADD  CONSTRAINT [FK_ID_employee] FOREIGN KEY([ID_employee])
REFERENCES [dbo].[Employees] ([Id_employee])
GO
ALTER TABLE [dbo].[InputBills] CHECK CONSTRAINT [FK_ID_employee]
GO
ALTER TABLE [dbo].[InputBillsDetaill]  WITH CHECK ADD  CONSTRAINT [FK_ID_ingredient] FOREIGN KEY([Id_Ingredient])
REFERENCES [dbo].[Ingredients] ([Id_ingredient])
GO
ALTER TABLE [dbo].[InputBillsDetaill] CHECK CONSTRAINT [FK_ID_ingredient]
GO
ALTER TABLE [dbo].[InputBillsDetaill]  WITH CHECK ADD  CONSTRAINT [FK_ID_InputBills] FOREIGN KEY([ID_Bill])
REFERENCES [dbo].[InputBills] ([ID_Bill])
GO
ALTER TABLE [dbo].[InputBillsDetaill] CHECK CONSTRAINT [FK_ID_InputBills]
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD  CONSTRAINT [FK_Id_employee_schedule] FOREIGN KEY([Id_employee])
REFERENCES [dbo].[Employees] ([Id_employee])
GO
ALTER TABLE [dbo].[Schedules] CHECK CONSTRAINT [FK_Id_employee_schedule]
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD  CONSTRAINT [FK_Id_Shift] FOREIGN KEY([Id_shift])
REFERENCES [dbo].[Shifts] ([Id_shift])
GO
ALTER TABLE [dbo].[Schedules] CHECK CONSTRAINT [FK_Id_Shift]
GO
ALTER TABLE [dbo].[Vouchers]  WITH CHECK ADD  CONSTRAINT [FK_Id_employe_voucher] FOREIGN KEY([Id_employee])
REFERENCES [dbo].[Employees] ([Id_employee])
GO
ALTER TABLE [dbo].[Vouchers] CHECK CONSTRAINT [FK_Id_employe_voucher]
GO
ALTER TABLE [dbo].[Vouchers]  WITH CHECK ADD  CONSTRAINT [FK_Id_TypeVoucher_voucher] FOREIGN KEY([ID_Type])
REFERENCES [dbo].[TypesVoucher] ([ID_Type])
GO
ALTER TABLE [dbo].[Vouchers] CHECK CONSTRAINT [FK_Id_TypeVoucher_voucher]
GO
/****** Object:  StoredProcedure [dbo].[CHANGE_PASSWORD]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CHANGE_PASSWORD] 
@EMAIL varchar(50),
@OLDPASS varchar(100),
@NEWPASS varchar(100)
AS
BEGIN
		DECLARE @OP varchar(100)
		SELECT @OP = Password from Employees where Email = @EMAIL
		IF @OP = @OLDPASS
		BEGIN 
		UPDATE Employees SET Password = @NEWPASS where Email = @EMAIL
		return 1
		END
		ELSE
		return -1
END
GO
/****** Object:  StoredProcedure [dbo].[checkOut]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[checkOut]
@idBill int
as
begin
	update bills set status = 1, DateCheckOut = GETDATE()
	where Id_bill = @idBill
end
GO
/****** Object:  StoredProcedure [dbo].[CREATE_NEW_PASS]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CREATE_NEW_PASS] 
@Email nvarchar(50),
@Password nvarchar(100)
AS
BEGIN
Update Employees SET Password = @Password
where Email = @Email
END


select * from Employees
GO
/****** Object:  StoredProcedure [dbo].[DELETE_DATA_FROM_EMPLOYEE]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DELETE_DATA_FROM_EMPLOYEE] @Email varchar(50),@mail varchar(50)
AS
BEGIN
		if(not exists (select * from Employees where Email = @mail))
			begin
					DELETE from Employees 
					where Email = @Email
			end
END
GO
/****** Object:  StoredProcedure [dbo].[DELETE_DATA_FROM_ROLES]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DELETE_DATA_FROM_ROLES]
@id_role int
AS
BEGIN
		DELETE FROM Roles
		where Id_role = @id_role
		DBCC CHECKIDENT ('Roles', RESEED, 2) -- Reset identity to 2
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteDataSchedule]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- proc delete data schedules
create proc [dbo].[DeleteDataSchedule]
@Id_shift int, @Id_employee int, @day int
as
	begin
		delete from Schedules where Id_shift = @Id_shift and Id_employee = @Id_employee and Days = @day
	end
GO
/****** Object:  StoredProcedure [dbo].[DeleteDataShifts]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- proc delete data table shifts
create proc [dbo].[DeleteDataShifts]
@Id_shift int
as
	begin
		delete from Shifts where Id_shift = @Id_shift
	end
GO
/****** Object:  StoredProcedure [dbo].[DeleteDataTypeVoucher]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- proc delete data TypeVoucher
create proc [dbo].[DeleteDataTypeVoucher]
@Id int
as
	begin 
		delete from TypesVoucher where ID_Type = @Id
	end
GO
/****** Object:  StoredProcedure [dbo].[DeleteDataVoucher]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[DeleteDataVoucher]
@Id_type int, @DayBegin varchar(50), @DayEnd varchar(50)
as
	begin
		delete Vouchers where ID_Type = @Id_type and DateBegin = @DayBegin and DateEnd = @DayEnd
	end
GO
/****** Object:  StoredProcedure [dbo].[DeleteTable]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Delete data table
create proc [dbo].[DeleteTable]
@id int
as
	begin
		delete tables where ID_Table = @id
	end
GO
/****** Object:  StoredProcedure [dbo].[EmployeeLOGIN]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EmployeeLOGIN] @EMAIL VARCHAR(50), @PASSWORD VARCHAR(100)
AS 
BEGIN
	DECLARE @STATUS INT
	IF EXISTS(SELECT * FROM Employees 
	WHERE Email = @EMAIL AND Password = @PASSWORD)
		SET @STATUS = 1
	ELSE 
		SET @STATUS = 0
	SELECT @STATUS
END
GO
/****** Object:  StoredProcedure [dbo].[FORGOT_PASSWORD]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FORGOT_PASSWORD] @EMAIL varchar(50)
AS
BEGIN
	Declare @STATUS int

if exists(select Id_employee from Employees where Email = @EMAIL)
	set @STATUS = 1
else
	set @STATUS = 0
select @STATUS
END
GO
/****** Object:  StoredProcedure [dbo].[GET_ROLES]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GET_ROLES]
AS
BEGIN
		Select Id_role,Name from Roles
END
GO
/****** Object:  StoredProcedure [dbo].[getConfigurationSale]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- proc get sale for configuration
create proc [dbo].[getConfigurationSale]
@id int
as
	begin
		if(@id = 0)
			begin
				select ID_Type, Sale from TypesVoucher 
			end
		else
			begin
				select ID_Type, Sale from TypesVoucher where ID_Type = @id
			end
	end
GO
/****** Object:  StoredProcedure [dbo].[getCountSaleVoucher]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- get count Sale in vouchers
create proc [dbo].[getCountSaleVoucher]
@Id_type int
as
	begin
		select count(ID_Type) from Vouchers where ID_Type = @Id_type
	end
GO
/****** Object:  StoredProcedure [dbo].[getDataSchedule]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- get data schedule
CREATE proc [dbo].[getDataSchedule]
as
	begin
		select b.Id_schedule, a.Name, b.Days, c.Id_shift from Employees a
		inner join Schedules b on a.Id_employee = b.Id_employee
		inner join Shifts c on b.Id_shift = c.Id_shift
	end
GO
/****** Object:  StoredProcedure [dbo].[GetDataShifts]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- proc get data table shifts
create proc [dbo].[GetDataShifts]
as
	begin
		select * from Shifts
	end
GO
/****** Object:  StoredProcedure [dbo].[getDataTable]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getDataTable]
as
	begin
		select * from tables
	end
GO
/****** Object:  StoredProcedure [dbo].[getDataTypeVouchers]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- proc for table TypeOfVoucher
-- proc get data
create proc [dbo].[getDataTypeVouchers]
as
	begin 
		select ID_Type,CONCAT(CAST(Sale AS varchar(10)),'%') from TypesVoucher
	end
GO
/****** Object:  StoredProcedure [dbo].[getDataUnits]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- get data units
create proc [dbo].[getDataUnits]
as
	begin
		select * from units
	end
GO
/****** Object:  StoredProcedure [dbo].[getDataVoucher]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- get data of voucher
create proc [dbo].[getDataVoucher]
as
	begin
		select a.Id_voucher, a.DateBegin, a.DateEnd, CONCAT(CAST(b.Sale AS varchar(10)),'%'), a.Status from Vouchers a 
		inner join TypesVoucher b on a.ID_Type = b.ID_Type
	end
GO
/****** Object:  StoredProcedure [dbo].[getEmailSendVoucher]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	-- proc get email for send voucher
create proc [dbo].[getEmailSendVoucher]
@reward int
as
	begin
		select Email from Customers where Reward <= @reward
	end
GO
/****** Object:  StoredProcedure [dbo].[getListBillDetail]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getListBillDetail] 
@idBill int
as
begin 
	select * from Bills_detail
	where Id_bill = @idBill
end
GO
/****** Object:  StoredProcedure [dbo].[getListMenu]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getListMenu]
@Id_table int
as
begin
	select bv.Name,bd.Quantity, bv.Price, bd.totalPrice, bd.sale from Bills_detail as bd, Bills as b, Beverages as bv
	where bd.Id_bill = b.Id_bill and bd.Id_beverage = bv.Id_beverage
	and b.Id_table = @Id_table and B.status = 0
end
GO
/****** Object:  StoredProcedure [dbo].[getMaxID]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getMaxID]
as
begin
	select max(id_bill) from Bills
end
GO
/****** Object:  StoredProcedure [dbo].[getNameForInputBillDetail]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getNameForInputBillDetail]
as
	begin
		select ID_unit, Name from units
	end
GO
/****** Object:  StoredProcedure [dbo].[getNameIngredientForInputBillDetail]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- get name ingredient for inputBillDetail
CREATE proc [dbo].[getNameIngredientForInputBillDetail]
@id_type int
as
	begin
		select Name, Id_ingredient from Ingredients where Id_type = @id_type
	end
GO
/****** Object:  StoredProcedure [dbo].[GETNHANVIEN]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GETNHANVIEN]
AS
BEGIN
		Select Id_role,Name,Gender,Email,Address,DayOfBirth,Salary from Employees
END
GO
/****** Object:  StoredProcedure [dbo].[getSaleForVoucher]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- get Sale for Voucher
create proc [dbo].[getSaleForVoucher]
as
	begin
		select ID_Type, Sale from TypesVoucher
	end
GO
/****** Object:  StoredProcedure [dbo].[getSumprice]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getSumprice]
@id_table int 
as 
begin 
	select sum(bd.totalPrice) from Bills_detail as bd, Bills as b
	where bd.Id_bill = b.Id_bill and b.Id_table = @id_table and B.status = 0
end
GO
/****** Object:  StoredProcedure [dbo].[getTypeIngredientForInputBillDetail]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getTypeIngredientForInputBillDetail]
as
	begin
		select Name, Id_type from TypesOfIngredient
	end
GO
/****** Object:  StoredProcedure [dbo].[getUncheckBill]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getUncheckBill]
@Id_table int
as
begin
	select * from bills 
	where Id_table = @Id_table and status = 0
end
GO
/****** Object:  StoredProcedure [dbo].[getVoucherSendMail]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- proc get voucher for send mail to customer
create proc [dbo].[getVoucherSendMail]
@id_type int
as
	begin
		declare @status int = 0
		if(exists(select Id_voucher from Vouchers where Status = @status))
		begin
			select a.Id_voucher from Vouchers a,TypesVoucher b where a.Status = 0 and b.ID_Type = @id_type
		end
	end
GO
/****** Object:  StoredProcedure [dbo].[INSERT_DATA_TO_EMPLOYEE]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERT_DATA_TO_EMPLOYEE] 
@Id_role int,
@Gender nvarchar(10),
@Email varchar(50),
@Address nvarchar(50),
@DayOfBirth date,
@Name nvarchar(50),
@Salary float
AS
BEGIN
		INSERT INTO Employees(Id_role,Name,Gender,Email,Address,DayOfBirth,Salary)
		VALUES(@Id_role,@Name,@Gender,@Email,@Address,@DayOfBirth,@Salary)
END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_DATA_TO_ROLES]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERT_DATA_TO_ROLES]
@Name nvarchar(20)
AS
BEGIN
		INSERT INTO ROLES(Name)
		VALUES(@Name)
END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_VAITRO]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[INSERT_VAITRO]
AS
BEGIN
		SELECT * from Roles
END
GO
/****** Object:  StoredProcedure [dbo].[insertBillDetailIngredient]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- proc insert inputBillDetail
CREATE proc [dbo].[insertBillDetailIngredient]
@quantity nvarchar(45),
@nameType nvarchar(45), @datetime datetime
as
	begin
		declare @id_ingredient int, @id_bill int
		select @id_ingredient = Id_ingredient from Ingredients where Name = @nameType
		select @id_bill = ID_Bill from InputBills where DateCheckIn = @datetime
		insert into InputBillsDetaill(quantity,Id_Ingredient,ID_Bill)
		values(@quantity,@id_ingredient,@id_bill)
	end
GO
/****** Object:  StoredProcedure [dbo].[insertBillIngredient]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertBillIngredient]
@dayCheck datetime, @sumprice float, @mail nvarchar(50)
as
	begin
		declare @id_employee int
		select @id_employee = Id_employee from Employees where Email = @mail
		insert into InputBills(DateCheckIn,ID_employee, SumPrice) values(@dayCheck,@id_employee,@sumprice)
	end
GO
/****** Object:  StoredProcedure [dbo].[InsertDataSchedule]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- proc Insert data Schedules
create proc [dbo].[InsertDataSchedule]
@day int, @Id_employee int, @Id_shift int
as
	begin
		if(not exists(select * from Schedules where Id_employee = @Id_employee and Id_shift = @Id_shift and Days = @day))
			begin
					insert into Schedules(Id_employee, Id_shift, Days)
					values(@Id_employee, @Id_shift, @day)
			end
	end
GO
/****** Object:  StoredProcedure [dbo].[InsertDataShifts]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertDataShifts]
@Id_shift int, @TimeBegin varchar(50), @TimeEnd varchar(50)
as
	begin
		if(not exists(select * from Shifts where Id_shift = @Id_shift))
		begin
			insert into Shifts(TimeBegin,TimeEnd, Id_shift) 
			values(@TimeBegin, @TimeEnd, @Id_shift)
		end
	end
GO
/****** Object:  StoredProcedure [dbo].[InsertDataTable]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- insert data table
create proc [dbo].[InsertDataTable]
@name nvarchar(50), @Status nvarchar(20)
as
	begin
		insert into tables (name, Status) values(@name, @Status)
	end
GO
/****** Object:  StoredProcedure [dbo].[InsertDataTypeVoucher]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- proc insert data TypeVoucher
create proc [dbo].[InsertDataTypeVoucher]
@Sale float
as
	begin
			if(not exists(select * from TypesVoucher where Sale = @Sale))
			begin
				insert into TypesVoucher(Sale) values (@Sale)
			end
	end
GO
/****** Object:  StoredProcedure [dbo].[InsertDataUnit]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertDataUnit]
@name nvarchar(10)
as
	begin
		if(not exists(select * from units where Name = @name))
			begin
				insert into units(Name) values(@name)
			end
	end
GO
/****** Object:  StoredProcedure [dbo].[insertDataVoucher]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- proc insert data Voucher
create proc [dbo].[insertDataVoucher]
@Id_voucher varchar(6), @DayBegin date, @DayEnd date,  @mail varchar(50), @Id_type int, @Status int
as
	begin
		declare @Id_employee int
		if(not exists (select Id_voucher from Vouchers where Id_voucher = @Id_voucher))
		begin
			select @Id_employee = Id_employee from Employees where Email = @mail
			insert into Vouchers(Id_voucher, DateBegin, DateEnd,Id_employee ,ID_Type, Status) values (@Id_voucher, @DayBegin, @DayEnd,@Id_employee ,@Id_type, @Status)
		end
	end
GO
/****** Object:  StoredProcedure [dbo].[loadIdShift]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- load shift
create proc [dbo].[loadIdShift]
as
	begin
		select Id_shift from Shifts
	end
GO
/****** Object:  StoredProcedure [dbo].[loadName]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- load Name
create proc [dbo].[loadName]
as
	begin
		select Name, Id_employee from Employees
	end
GO
/****** Object:  StoredProcedure [dbo].[loadTypeVoucher]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[loadTypeVoucher]
as
	begin
		select ID_Type, Sale from TypesVoucher
	end
GO
/****** Object:  StoredProcedure [dbo].[LOGIN]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LOGIN] @EMAIL VARCHAR(50), @PASSWORD VARCHAR(100)
AS 
BEGIN
	DECLARE @STATUS INT
	IF EXISTS(SELECT * FROM Employees 
	WHERE Email = @EMAIL AND Password = @PASSWORD)
		SET @STATUS = 1
	ELSE 
		SET @STATUS = 0
	SELECT @STATUS
END
GO
/****** Object:  StoredProcedure [dbo].[PriceInputBill]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- proc sum price input bill
create proc [dbo].[PriceInputBill]
@id_type int, @number int
as 
	begin
		select Price*@number from Ingredients where Id_ingredient = @id_type
	end
GO
/****** Object:  StoredProcedure [dbo].[SEARCH_EMPLOYEE]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SEARCH_EMPLOYEE]
@Name nvarchar(50)
AS
BEGIN
		SET NOCOUNT ON;
		SELECT  Id_role,Name,Gender,Email,Address,DayOfBirth,Salary from Employees
		where LOWER(Name) like N'%' + lower(@Name) + '%'
END
GO
/****** Object:  StoredProcedure [dbo].[SEARCH_ROLES]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SEARCH_ROLES]
@Name nvarchar(50)
AS
BEGIN
		SET NOCOUNT ON;
		SELECT  Id_role,Name from Roles
		where LOWER(Name) like N'%' + lower(@Name) + '%'
END
GO
/****** Object:  StoredProcedure [dbo].[SearchDataShifts]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- proc search data table shifts
create proc [dbo].[SearchDataShifts]
@Id_shift int
as
	begin
		set nocount on;
		select Id_shift, TimeBegin, TimeEnd from Shifts where Id_shift = @Id_shift
	end
GO
/****** Object:  StoredProcedure [dbo].[SearchDataTypeVoucher]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- proc search data TypeVoucher
create proc [dbo].[SearchDataTypeVoucher]
@Sale float
as
	begin
		set nocount on;
		select * from TypesVoucher where Sale = @Sale
	end
GO
/****** Object:  StoredProcedure [dbo].[SearchDataVoucher]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- search Sale in Voucher
create proc [dbo].[SearchDataVoucher]
@Id_type int
as
	begin
		set nocount on;
		select Id_voucher, DateBegin, DateEnd, ID_Type, Status from Vouchers where ID_Type = @Id_type
	end
GO
/****** Object:  StoredProcedure [dbo].[searchSchedules]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- proc search schedules
create proc [dbo].[searchSchedules]
@Id_employee int
as
	begin
		set nocount on;
		select b.Id_schedule, a.Name, b.Days, c.Id_shift from Employees a
		inner join Schedules b on a.Id_employee = b.Id_employee and a.Id_employee = @Id_employee
		inner join Shifts c on b.Id_shift = c.Id_shift
	end

GO
/****** Object:  StoredProcedure [dbo].[SearchTable]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- search data table
create proc [dbo].[SearchTable]
@name nvarchar(50)
as
	begin
		select * from tables where name like + '%' + @name + '%'
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_BeverageDelete]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_BeverageDelete](@id_beverage   NVARCHAR(55))
AS
  BEGIN

        BEGIN
			delete Beverages
			where Id_beverage = @id_beverage
        END
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_BeverageInsert]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_BeverageInsert](
                                          @Name   NVARCHAR(55),
                                          @Price       int,
                                          @id_type        int,
                                          @image nvarchar(500))
AS
  BEGIN

        BEGIN
			insert into Beverages(Name,Price,Id_type,Image)
			values(@Name,@Price,@id_type,@image)
        END
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_BeverageSearch]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_BeverageSearch](@Name   NVARCHAR(55))
AS
  BEGIN

        BEGIN
			set nocount on;
			select Name,Price,Id_type,Id_beverage,Image
			from	Beverages where Name like '%'+@Name+'%'

        END
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_BeverageUpdate]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_BeverageUpdate](
                                          @Name   NVARCHAR(55),
                                          @Price       int,
                                          @id_type        int,
                                          @image nvarchar(500),
										  @id_beverage int)
AS
  BEGIN

        BEGIN
			update Beverages
			set Name = @Name,
				Price = @Price,
				Id_type = @id_type,
				Image = @image
			where Id_beverage = @id_beverage

        END
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_CustomerSearch]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_CustomerSearch](@Email NVARCHAR(50))
AS
  BEGIN

        BEGIN
			set nocount on;
			select Name, Email, Gender,Id_customer,Reward
			from Customers where Email like '%' + @Email + '%'
        END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CustomerUpdate]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_CustomerUpdate](
                                          @Email   NVARCHAR(55),
                                          @Gender       NVARCHAR(10),
                                          @idCustomers       int,
                                          @reward int,
										  @name nvarchar(50))
AS
  BEGIN
        BEGIN
			if(not exists (select * from Customers where Email = @Email))
			begin
				update Customers
				set
				Email = @Email,
				Gender = @Gender,
				Reward = @reward,
				Name = @name
				where Id_customer = @idCustomers
			end
        END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetBeverage]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_GetBeverage]
as
begin
            SELECT name,price,id_type,id_beverage,image
            FROM   beverages

end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetBeverageById]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_GetBeverageById]
@id_type int
as
begin
            SELECT name,price,id_type,id_beverage,image
            FROM   beverages where Id_type = @id_type

end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCustomers]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_GetCustomers]
as
begin
      select  Name, Email, Gender,Id_customer,Reward  from Customers
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetIngredient]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_GetIngredient]
as
begin
    SELECT Id_ingredient, Name, Id_supplier, Id_type, Price
    FROM Ingredients
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSupplier]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_GetSupplier]
as
begin
    SELECT Name, Id_supplier, Email, Address
    FROM Suppliers
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTypeOfIngredient]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_GetTypeOfIngredient]
as
begin
    SELECT Id_type, Name
    FROM TypesOfIngredient
end
GO
/****** Object:  StoredProcedure [dbo].[sp_IngredientDelete]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_IngredientDelete](@Id_ingredient int)
AS
  BEGIN
		delete Ingredients
		where Id_ingredient = @Id_ingredient
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_IngredientInsert]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_IngredientInsert] (@Name nvarchar(100),
									  @Id_supplier int,
									  @Id_type int,
								 	  @Price float)
										
AS
  BEGIN
		insert into Ingredients(Name,Id_supplier,Id_type,Price)
		values(@Name,@Id_supplier,@Id_type,@Price)
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_IngredientSearch]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_IngredientSearch](@Name NVARCHAR(100))
AS
  BEGIN

        BEGIN
			set nocount on;
			select Name, Id_type, Price, Id_supplier
			from Ingredients where Name like '%' + @Name + '%'
        END
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_IngredientUpdate]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_IngredientUpdate](@Name nvarchar(100),
									  @Id_supplier int,
									  @Id_type int,
								 	  @Price float,
									  @Id_ingredient int)
AS
  BEGIN
		update Ingredients
		set Name = @Name,
			Id_supplier = @Id_supplier,
			Id_type = @Id_type,
			Price = @Price
		where Id_ingredient = @Id_ingredient
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_insertBill]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_insertBill]
@idTable int, @idEmployee INT
as
begin 
	insert into bills (id_table, Id_employee)
	values (@idtable, @idemployee)
end
GO
/****** Object:  StoredProcedure [dbo].[sp_insertBillDetail]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_insertBillDetail]
@idBill int, @idBeverage int, @quantity int, @sale int
as
begin
	declare @price float;
	select @price = Price from Beverages
	where Id_beverage = @idBeverage
	if(@sale = 0)
	begin
		declare @isExistBillInfo int = 0;
		declare @quantityBeverage int;
		select @isExistBillInfo = Id_bill_detaill, @quantityBeverage = Quantity from Bills_detail
		where Id_bill = @idBill and Id_beverage = @idBeverage
		
		if(@isExistBillInfo > 0)
		begin
			declare @newQuantity int = @quantityBeverage + @quantity
			if(@newQuantity > 0)
				update Bills_detail set Quantity = @newQuantity, totalPrice = @newQuantity * @price
				where Id_beverage = @idBeverage and Id_bill = @idBill
			else
				delete Bills_detail where Id_bill = @idBill and Id_beverage = @idBeverage
		end
		else
		begin
			insert into Bills_detail(Id_beverage,Id_bill,Quantity, sale,totalPrice)
			values (@idBeverage, @idBill, @quantity, @sale, @price * @quantity)	
		end
	end
	else
	begin
		insert into Bills_detail(Id_beverage,Id_bill,Quantity, sale,totalPrice)
		values (@idBeverage, @idBill, @quantity, @sale, (@price * @quantity) * (100 - @sale)/100)	
	end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_SupplierDelete]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_SupplierDelete](@Id_supplier int)
AS
  BEGIN
		delete Suppliers
		where Id_supplier = @Id_supplier
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_SupplierInsert]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_SupplierInsert] (@Name nvarchar(50),
									@Email nvarchar(50),
									@Address nvarchar(100))
									
AS
  BEGIN
		insert into Suppliers(Name, Email, Address)
		values(@Name, @Email, @Address)
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_SupplierSearch]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_SupplierSearch](@Name NVARCHAR(50))
AS
  BEGIN

        BEGIN
			set nocount on;
			select Name, Id_supplier
			from Suppliers where Name like '%' + @Name + '%'
        END
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_SupplierUpdate]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_SupplierUpdate](@Name nvarchar(50),
								   @Email nvarchar(50),
								   @Address nvarchar(100),
								   @Id_supplier int)
AS
  BEGIN
		update Suppliers
		set Name = @Name,
			Email = @Email,
			Address = @Address
		where Id_supplier = @Id_supplier
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_TypeOfBeverageDelete]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_TypeOfBeverageDelete](   @ID   int)
AS
  BEGIN
	
        BEGIN
			delete TypesOfBeverage
			where Id_type = @ID
        END
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_TypeOfBeverageGet]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_TypeOfBeverageGet] 
										
AS
  BEGIN
		select id_type, name from typesofbeverage
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_TypeOfBeverageInsertSearch]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_TypeOfBeverageInsertSearch](   @Name   NVARCHAR(55),
										@StatementType nvarchar(20) = '')
AS
  BEGIN
	IF @StatementType = 'Insert'
        BEGIN
			insert into TypesOfBeverage(Name)
			values(@Name)
        END
	IF @StatementType = 'Search'
        BEGIN
			select Id_type, Name 
			from TypesOfBeverage where Name like '%'+@Name+'%'
        END
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_TypeOfBeverageUpdate]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_TypeOfBeverageUpdate] (  @Name   NVARCHAR(55),
											@id_type int)
										
AS
  BEGIN
		update TypesOfBeverage
		set Name = @Name
		where Id_type = @id_type
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_TypeOfIngredientDelete]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_TypeOfIngredientDelete](@Id_type int)
AS
  BEGIN
		delete TypesOfIngredient
		where Id_type = @Id_type
	END
-- exec sp_Type
GO
/****** Object:  StoredProcedure [dbo].[sp_TypeOfIngredientInsert]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_TypeOfIngredientInsert] (@Name nvarchar(50))
										
AS
  BEGIN
		insert into TypesOfIngredient(Name)
		values(@Name)
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_TypeOfIngredientSearch]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_TypeOfIngredientSearch](@Name NVARCHAR(50))
AS
  BEGIN

        BEGIN
			set nocount on;
			select Name, Id_type
			from TypesOfIngredient where Name like '%' + @Name + '%'
        END
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_TypeOfIngredientUpdate]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_TypeOfIngredientUpdate](@Name nvarchar(50),
										   @Id_type int)
AS
  BEGIN
		update TypesOfIngredient
		set Name = @Name
		where Id_type = @Id_type
	END
-- exec sp_TypeOfIngredientUpdate 'Dau', 1
GO
/****** Object:  StoredProcedure [dbo].[UPDATE_DATA_TO_EMPLOYEE]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPDATE_DATA_TO_EMPLOYEE] 
@Id_role int,
@Name nvarchar(50),
@Gender int,
@Email varchar(50),
@Address nvarchar(50),
@DayOfBirth date,
@Salary float
AS
BEGIN
		UPDATE Employees SET Id_role = Id_role,Address =  @Address, Gender = @Gender,
												Email = @Email, DayOfBirth = @DayOfBirth,Salary = @Salary,Name = @Name
												where Email = @Email
END
GO
/****** Object:  StoredProcedure [dbo].[UPDATE_DATA_TO_ROLES]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPDATE_DATA_TO_ROLES]
@id_role int,
@name nvarchar(50)
AS
BEGIN
		UPDATE Roles
		SET Name = @name 
		where Id_role = @id_role 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCustomerAfterSendVoucher]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- update reward after send voucher mail to customer
create proc [dbo].[UpdateCustomerAfterSendVoucher]
@email nvarchar(50)
as
	begin
		Update Customers set Reward = 0 where Email = @email
	end
GO
/****** Object:  StoredProcedure [dbo].[UpdateDataSchedule]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- proc update data schedules
create proc [dbo].[UpdateDataSchedule]
@Id_shift int, @Id_employee int, @day int, @Id_schedule int
as
	begin
		update Schedules set Id_employee = @Id_employee, Id_shift = @Id_shift, Days = @day where Id_schedule = @Id_schedule
	end
GO
/****** Object:  StoredProcedure [dbo].[UpdateDataShifts]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- proc update data table shifts
create proc [dbo].[UpdateDataShifts]
@Id_shift int, @TimeBegin varchar(50), @TimeEnd varchar(50)
as
	begin
		Update Shifts set TimeBegin = @TimeBegin, TimeEnd = @TimeEnd where Id_shift = @Id_shift
	end
GO
/****** Object:  StoredProcedure [dbo].[UpdateDatatypeVoucher]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- proc Update data TypeVoucher
create proc [dbo].[UpdateDatatypeVoucher]
@Id int, @Sale float
as
	begin
		if(not exists(select * from TypesVoucher where Sale = @Sale))
			begin
				Update TypesVoucher set Sale = @Sale where ID_Type = @Id
			end
	end
GO
/****** Object:  StoredProcedure [dbo].[UpdateDataUnits]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- update data units
create proc [dbo].[UpdateDataUnits]
@name nvarchar(10), @id int
as
	begin
		if(not exists(select * from units where Name = @name))
			begin
				update units set Name = @name where ID_unit = @id
			end
	end
GO
/****** Object:  StoredProcedure [dbo].[UpdateTable]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateTable]
@name nvarchar(50), @Status nvarchar(20), @id int
as
	begin
			update tables set name = @name, Status = @Status where ID_Table = @id
	end
GO
/****** Object:  StoredProcedure [dbo].[UpdateVoucherForSend]    Script Date: 11/15/2021 10:54:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- proc update voucher after send mail to customer
create proc [dbo].[UpdateVoucherForSend]
@Id_voucher nvarchar(6)
as
	begin
		Update Vouchers set Status = 1 where Id_voucher = @Id_voucher
	end
GO
USE [master]
GO
ALTER DATABASE [DuAn1] SET  READ_WRITE 
GO

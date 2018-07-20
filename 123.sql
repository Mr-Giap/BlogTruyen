USE [master]
GO
/****** Object:  Database [BlogTruyen]    Script Date: 7/20/2018 5:16:15 PM ******/
CREATE DATABASE [BlogTruyen]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BlogTruyen', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BlogTruyen.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BlogTruyen_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BlogTruyen_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BlogTruyen] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BlogTruyen].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BlogTruyen] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BlogTruyen] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BlogTruyen] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BlogTruyen] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BlogTruyen] SET ARITHABORT OFF 
GO
ALTER DATABASE [BlogTruyen] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BlogTruyen] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BlogTruyen] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BlogTruyen] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BlogTruyen] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BlogTruyen] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BlogTruyen] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BlogTruyen] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BlogTruyen] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BlogTruyen] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BlogTruyen] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BlogTruyen] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BlogTruyen] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BlogTruyen] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BlogTruyen] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BlogTruyen] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BlogTruyen] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BlogTruyen] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BlogTruyen] SET  MULTI_USER 
GO
ALTER DATABASE [BlogTruyen] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BlogTruyen] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BlogTruyen] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BlogTruyen] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BlogTruyen] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BlogTruyen]
GO
/****** Object:  User [shj]    Script Date: 7/20/2018 5:16:15 PM ******/
CREATE USER [shj] FOR LOGIN [shj] WITH DEFAULT_SCHEMA=[shj]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 7/20/2018 5:16:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[IdCategory] [int] NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[IdCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Chapters]    Script Date: 7/20/2018 5:16:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chapters](
	[IdChapter] [int] IDENTITY(1,1) NOT NULL,
	[IdPost] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](1000) NOT NULL,
	[ChapContent] [nvarchar](max) NOT NULL,
	[Note] [nvarchar](500) NULL,
 CONSTRAINT [PK_Chapters] PRIMARY KEY CLUSTERED 
(
	[IdChapter] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comments]    Script Date: 7/20/2018 5:16:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[IdComment] [uniqueidentifier] NOT NULL,
	[IdPost] [uniqueidentifier] NOT NULL,
	[IdUser] [uniqueidentifier] NOT NULL,
	[ReplyToUser] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[IdComment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Posts]    Script Date: 7/20/2018 5:16:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[IdPost] [uniqueidentifier] NOT NULL,
	[PostName] [nvarchar](250) NOT NULL,
	[NameAscii] [nvarchar](500) NULL,
	[Introduction] [nvarchar](max) NULL,
	[Length] [int] NULL,
	[DateCreate] [date] NULL,
	[Note] [nvarchar](500) NULL,
	[IdUser] [uniqueidentifier] NOT NULL,
	[Source] [nvarchar](500) NULL,
	[Author] [nvarchar](100) NULL,
	[IsDelete] [bit] NOT NULL,
	[IsFull] [bit] NOT NULL,
	[IdCategory] [int] NOT NULL,
	[Type] [nvarchar](500) NOT NULL,
	[Child] [nvarchar](500) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 7/20/2018 5:16:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Types]    Script Date: 7/20/2018 5:16:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Types](
	[IdType] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Types] PRIMARY KEY CLUSTERED 
(
	[IdType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 7/20/2018 5:16:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[IdUser] [uniqueidentifier] NOT NULL CONSTRAINT [DF_User_Id]  DEFAULT (newid()),
	[FullName] [nvarchar](50) NOT NULL,
	[Avatar] [varchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NOT NULL,
	[PhoneNumber] [varchar](50) NULL,
	[Sex] [bit] NULL,
	[BirthDay] [date] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[PassWord] [varchar](50) NOT NULL,
	[AboutMe] [nvarchar](max) NULL,
	[Permission] [tinyint] NULL,
	[IsActived] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (2, N'Poster')
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (3, N'Watcher')
SET IDENTITY_INSERT [dbo].[Roles] OFF
INSERT [dbo].[Users] ([IdUser], [FullName], [Avatar], [Address], [Email], [PhoneNumber], [Sex], [BirthDay], [UserName], [PassWord], [AboutMe], [Permission], [IsActived], [IsDelete], [RoleId]) VALUES (N'5ff9af2b-faa9-4a39-8429-1266388e7f26', N'Nguyễn TháiGiáp', NULL, NULL, N'shjkaze95@gmail.com', N'01698811102', 0, CAST(N'1995-05-28' AS Date), N'admin', N'123456', NULL, NULL, 0, 0, 1)
ALTER TABLE [dbo].[Comments] ADD  CONSTRAINT [DF_Comments_IdComment]  DEFAULT (newid()) FOR [IdComment]
GO
ALTER TABLE [dbo].[Posts] ADD  CONSTRAINT [DF_Posts_IdPost]  DEFAULT (newid()) FOR [IdPost]
GO
USE [master]
GO
ALTER DATABASE [BlogTruyen] SET  READ_WRITE 
GO

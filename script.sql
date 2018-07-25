USE [master]
GO
/****** Object:  Database [BlogTruyen]    Script Date: 7/25/2018 5:45:48 PM ******/
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
/****** Object:  User [shj]    Script Date: 7/25/2018 5:45:48 PM ******/
CREATE USER [shj] FOR LOGIN [shj] WITH DEFAULT_SCHEMA=[shj]
GO
ALTER ROLE [db_datareader] ADD MEMBER [shj]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [shj]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 7/25/2018 5:45:48 PM ******/
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
/****** Object:  Table [dbo].[Chapters]    Script Date: 7/25/2018 5:45:48 PM ******/
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
	[DateCreate] [datetime] NULL,
 CONSTRAINT [PK_Chapters] PRIMARY KEY CLUSTERED 
(
	[IdChapter] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comments]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[IdComment] [uniqueidentifier] NOT NULL,
	[IdPost] [uniqueidentifier] NOT NULL,
	[IdUser] [uniqueidentifier] NOT NULL,
	[ReplyToUser] [uniqueidentifier] NULL,
	[Content] [nvarchar](max) NOT NULL,
	[DateCreate] [datetime] NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[IdComment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Interested]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interested](
	[Idinterested] [uniqueidentifier] NOT NULL,
	[Like] [bit] NULL,
	[Love] [bit] NULL,
	[Hate] [bit] NULL,
	[IdPost] [uniqueidentifier] NOT NULL,
	[IdUser] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Interested] PRIMARY KEY CLUSTERED 
(
	[Idinterested] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Posts]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Posts](
	[IdPost] [uniqueidentifier] NOT NULL,
	[PostName] [nvarchar](250) NOT NULL,
	[NameAscii] [nvarchar](500) NULL,
	[Introduction] [nvarchar](max) NULL,
	[Avatar] [varchar](250) NULL,
	[Length] [int] NULL,
	[DateCreate] [datetime] NULL,
	[Note] [nvarchar](500) NULL,
	[IdUser] [uniqueidentifier] NOT NULL,
	[Source] [nvarchar](500) NULL,
	[Author] [nvarchar](100) NULL,
	[IsDelete] [bit] NOT NULL,
	[IsFull] [bit] NOT NULL,
	[IdCategory] [int] NOT NULL,
	[Type] [nvarchar](500) NOT NULL,
	[Child] [nvarchar](500) NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[IdPost] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 7/25/2018 5:45:48 PM ******/
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
/****** Object:  Table [dbo].[Types]    Script Date: 7/25/2018 5:45:48 PM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 7/25/2018 5:45:48 PM ******/
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
	[DateCreate] [datetime] NULL,
	[AboutMe] [nvarchar](max) NULL,
	[Permission] [tinyint] NULL,
	[PassActive] [nvarchar](250) NULL,
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
INSERT [dbo].[Users] ([IdUser], [FullName], [Avatar], [Address], [Email], [PhoneNumber], [Sex], [BirthDay], [UserName], [PassWord], [DateCreate], [AboutMe], [Permission], [PassActive], [IsActived], [IsDelete], [RoleId]) VALUES (N'5ff9af2b-faa9-4a39-8429-1266388e7f26', N'Nguyễn TháiGiáp', NULL, NULL, N'shjkaze95@gmail.com', N'01698811102', 0, CAST(N'1995-05-28' AS Date), N'admin', N'123456', NULL, NULL, NULL, NULL, 1, 0, 1)
INSERT [dbo].[Users] ([IdUser], [FullName], [Avatar], [Address], [Email], [PhoneNumber], [Sex], [BirthDay], [UserName], [PassWord], [DateCreate], [AboutMe], [Permission], [PassActive], [IsActived], [IsDelete], [RoleId]) VALUES (N'ff800905-622d-44e5-8c7c-ee3e389c128b', N'cba', NULL, NULL, N'bbb@gmail.com', N'46544412', 0, CAST(N'1995-10-28' AS Date), N'user2', N'123456', NULL, NULL, NULL, NULL, 1, 0, 1)
INSERT [dbo].[Users] ([IdUser], [FullName], [Avatar], [Address], [Email], [PhoneNumber], [Sex], [BirthDay], [UserName], [PassWord], [DateCreate], [AboutMe], [Permission], [PassActive], [IsActived], [IsDelete], [RoleId]) VALUES (N'5f7c84b9-17af-448b-ad74-fb147c46101f', N'abc', NULL, NULL, N'aaa@gmail.com', N'012345679', 1, CAST(N'1995-05-10' AS Date), N'user', N'123456', NULL, NULL, NULL, NULL, 0, 0, 2)
ALTER TABLE [dbo].[Comments] ADD  CONSTRAINT [DF_Comments_IdComment]  DEFAULT (newid()) FOR [IdComment]
GO
ALTER TABLE [dbo].[Interested] ADD  CONSTRAINT [DF_Interested_Idinterested]  DEFAULT (newid()) FOR [Idinterested]
GO
ALTER TABLE [dbo].[Posts] ADD  CONSTRAINT [DF_Posts_IdPost]  DEFAULT (newid()) FOR [IdPost]
GO
ALTER TABLE [dbo].[Chapters]  WITH CHECK ADD  CONSTRAINT [FK_Chapters_Posts] FOREIGN KEY([IdPost])
REFERENCES [dbo].[Posts] ([IdPost])
GO
ALTER TABLE [dbo].[Chapters] CHECK CONSTRAINT [FK_Chapters_Posts]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Posts] FOREIGN KEY([IdPost])
REFERENCES [dbo].[Posts] ([IdPost])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Posts]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Users] ([IdUser])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users]
GO
ALTER TABLE [dbo].[Interested]  WITH CHECK ADD  CONSTRAINT [FK_Interested_Posts] FOREIGN KEY([IdPost])
REFERENCES [dbo].[Posts] ([IdPost])
GO
ALTER TABLE [dbo].[Interested] CHECK CONSTRAINT [FK_Interested_Posts]
GO
ALTER TABLE [dbo].[Interested]  WITH CHECK ADD  CONSTRAINT [FK_Interested_Users] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Users] ([IdUser])
GO
ALTER TABLE [dbo].[Interested] CHECK CONSTRAINT [FK_Interested_Users]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_Posts_Categories] FOREIGN KEY([IdCategory])
REFERENCES [dbo].[Categories] ([IdCategory])
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_Posts_Categories]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_Posts_Users] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Users] ([IdUser])
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_Posts_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
/****** Object:  StoredProcedure [dbo].[Categories_Delete]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Categories_Delete]	
@id INT
AS
BEGIN
	DELETE FROM dbo.Categories
	WHERE IdCategory = @id
END

GO
/****** Object:  StoredProcedure [dbo].[Categories_Getall]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Categories_Getall]
@start INT,
@length INT,
@total INT OUTPUT
AS
BEGIN
	IF OBJECT_ID('tempdb..#pagingCategories') IS NOT NULL DROP TABLE #pagingCategories
	SELECT * INTO #pagingCategories FROM (
		SELECT DISTINCT c.IdCategory, c.CategoryName, (ROW_NUMBER() OVER (ORDER BY c.CategoryName ASC)) AS rownumber
		FROM dbo.Categories c
	) AS db
	SET @total = (SELECT COUNT(*) FROM dbo.Roles)
	SELECT * FROM #pagingCategories r
	WHERE r.rownumber > @start AND r.rownumber <= @start + @length
	DROP TABLE #pagingCategories
END

GO
/****** Object:  StoredProcedure [dbo].[Categories_Getallpaging]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Categories_Getallpaging]
@start INT,
@length INT
AS
BEGIN
	SELECT * INTO #pagingCategories FROM (
		SELECT DISTINCT c.IdCategory, c.CategoryName, (ROW_NUMBER() OVER (ORDER BY c.CategoryName ASC)) AS rownumber
		FROM dbo.Categories c
	) AS db
	WHERE db.rownumber > @start AND db.rownumber <= @start + @length
END

GO
/****** Object:  StoredProcedure [dbo].[Categories_Insert]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Categories_Insert]
@name NVARCHAR(100)
AS
BEGIN
	INSERT INTO dbo.Categories
	        (CategoryName )
	VALUES  (@name  -- CategoryName - nvarchar(100)
	          )
END

GO
/****** Object:  StoredProcedure [dbo].[Categories_Update]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Categories_Update]
@id INT,
@name NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.Categories
	SET CategoryName = @name
	WHERE IdCategory = @id
END

GO
/****** Object:  StoredProcedure [dbo].[Chapter_Delete]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Chapter_Delete]
@id INT
AS
BEGIN
	DELETE FROM dbo.Chapters
	WHERE IdChapter = @id
END

GO
/****** Object:  StoredProcedure [dbo].[Chapter_Getall]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Chapter_Getall]
@start INT,
@length INT,
@total INT OUTPUT
AS
BEGIN
	IF OBJECT_ID('tempdb..#pagingChapter') IS NOT NULL DROP TABLE #pagingChapter
	SELECT * INTO #pagingChapter FROM (
		SELECT DISTINCT c.IdChapter,c.IdPost,c.Title,c.ChapContent,c.Note,c.DateCreate, (ROW_NUMBER() OVER (ORDER BY c.DateCreate DESC)) AS rownumber
		FROM dbo.Chapters c
	) AS db
	SET @total = (SELECT COUNT(*) FROM dbo.Roles)
	SELECT * FROM #pagingChapter r
	WHERE r.rownumber > @start AND r.rownumber <= @start + @length
	DROP TABLE #pagingChapter
END

GO
/****** Object:  StoredProcedure [dbo].[Chapter_Getallpaging]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Chapter_Getallpaging]
@start INT,
@length INT
AS
BEGIN
	SELECT *  FROM (
		SELECT DISTINCT c.IdChapter,c.IdPost,c.Title,c.ChapContent,c.Note,c.DateCreate, (ROW_NUMBER() OVER (ORDER BY c.DateCreate DESC)) AS rownumber
		FROM dbo.Chapters c
	) AS db
	WHERE db.rownumber > @start AND db.rownumber <= @start + @length
END
GO
/****** Object:  StoredProcedure [dbo].[Chapter_Insert]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Chapter_Insert]	
@idpost UNIQUEIDENTIFIER,
@title NVARCHAR(1000),
@content NVARCHAR(max),
@note NVARCHAR(500),
@datecreate DATETIME
AS
BEGIN
	INSERT INTO dbo.Chapters
	        ( IdPost ,
	          Title ,
	          ChapContent ,
	          Note ,
	          DateCreate
	        )
	VALUES  ( @idpost , -- IdPost - uniqueidentifier
	          @title , -- Title - nvarchar(1000)
	          @content, -- ChapContent - nvarchar(max)
	          @note, -- Note - nvarchar(500)
	          @datecreate  -- DateCreate - datetime
	        )
END

GO
/****** Object:  StoredProcedure [dbo].[Chapter_Update]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Chapter_Update]
@id INT,
@idpost UNIQUEIDENTIFIER,
@title NVARCHAR(1000),
@content NVARCHAR(max),
@note NVARCHAR(500)
AS
BEGIN
	UPDATE dbo.Chapters
	SET IdPost = @idpost,Title = @title, ChapContent = @content, Note = @note
	WHERE IdChapter = @id
END

GO
/****** Object:  StoredProcedure [dbo].[Comment_Delete]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Comment_Delete]
@id UNIQUEIDENTIFIER
AS
BEGIN
	DELETE FROM dbo.Comments
	WHERE IdComment = @id
END

GO
/****** Object:  StoredProcedure [dbo].[Comment_Getall]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Comment_Getall]
@start INT,
@length INT,
@total INT OUTPUT
AS
BEGIN
	IF OBJECT_ID('tempdb..#pagingComment') IS NOT NULL DROP TABLE #pagingComment
	SELECT * INTO #pagingComment FROM (
		SELECT DISTINCT c.IdComment,c.IdPost,c.IdUser,c.ReplyToUser,c.Content,c.DateCreate, (ROW_NUMBER() OVER (ORDER BY c.DateCreate DESC)) AS rownumber
		FROM dbo.Comments c
	) AS db
	SET @total = (SELECT COUNT(*) FROM dbo.Roles)
	SELECT * FROM #pagingComment r
	WHERE r.rownumber > @start AND r.rownumber <= @start + @length
	DROP TABLE #pagingComment
END

GO
/****** Object:  StoredProcedure [dbo].[Comment_Getallpaging]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Comment_Getallpaging]
@start INT,
@length INT
AS
BEGIN
	SELECT * INTO #pagingComment FROM (
		SELECT DISTINCT c.IdComment,c.IdPost,c.IdUser,c.ReplyToUser,c.Content,c.DateCreate, (ROW_NUMBER() OVER (ORDER BY c.DateCreate DESC)) AS rownumber
		FROM dbo.Comments c
	) AS db
	WHERE db.rownumber > @start AND db.rownumber <= @start + @length
END

GO
/****** Object:  StoredProcedure [dbo].[Comment_Insert]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Comment_Insert]
@id UNIQUEIDENTIFIER,
@idpost UNIQUEIDENTIFIER,
@iduser UNIQUEIDENTIFIER,
@replyto UNIQUEIDENTIFIER,
@content NVARCHAR(max),
@datecreate DATETIME
AS
BEGIN
	INSERT INTO dbo.Comments
	        ( IdComment ,
	          IdPost ,
	          IdUser ,
	          ReplyToUser ,
	          Content ,
	          DateCreate
	        )
	VALUES  ( @id , -- IdComment - uniqueidentifier
	          @idpost , -- IdPost - uniqueidentifier
	          @iduser, -- IdUser - uniqueidentifier
	          @replyto , -- ReplyToUser - uniqueidentifier
	          @content , -- Content - nvarchar(max)
	          @datecreate  -- DateCreate - datetime
	        )
END

GO
/****** Object:  StoredProcedure [dbo].[Comment_Update]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Comment_Update]
@id UNIQUEIDENTIFIER,
@idpost UNIQUEIDENTIFIER,
@iduser UNIQUEIDENTIFIER,
@replyto UNIQUEIDENTIFIER,
@content NVARCHAR(max)
AS
BEGIN
	UPDATE dbo.Comments
	SET IdPost = @idpost, IdUser = @iduser, ReplyToUser = @replyto, Content = @content
	WHERE IdComment = @id
END

GO
/****** Object:  StoredProcedure [dbo].[Interested_Delete]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Interested_Delete]
@id UNIQUEIDENTIFIER
AS
BEGIN
	DELETE FROM dbo.Interested
	WHERE Idinterested = @id
END

GO
/****** Object:  StoredProcedure [dbo].[Interested_Getall]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Interested_Getall]
@start INT,
@length INT,
@total INT OUTPUT
AS
BEGIN
	IF OBJECT_ID('tempdb..#pagingInterested') IS NOT NULL DROP TABLE #pagingInterested
	SELECT * INTO #pagingInterested FROM (
		SELECT DISTINCT i.Idinterested,i.[Like],i.Love,i.Hate,i.IdPost,i.IdUser, (ROW_NUMBER() OVER (ORDER BY i.IdPost DESC)) AS rownumber
		FROM dbo.Interested i
	) AS db
	SET @total = (SELECT COUNT(*) FROM dbo.Roles)
	SELECT * FROM #pagingInterested r
	WHERE r.rownumber > @start AND r.rownumber <= @start + @length
	DROP TABLE #pagingInterested
END

GO
/****** Object:  StoredProcedure [dbo].[Interested_Getallpaging]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Interested_Getallpaging]
@start INT,
@length INT
AS
BEGIN
	SELECT *  FROM (
		SELECT DISTINCT i.Idinterested,i.[Like],i.Love,i.Hate,i.IdPost,i.IdUser, (ROW_NUMBER() OVER (ORDER BY i.IdPost DESC)) AS rownumber
		FROM dbo.Interested i
	) AS db
	WHERE db.rownumber > @start AND db.rownumber <= @start + @length
END
GO
/****** Object:  StoredProcedure [dbo].[Interested_Insert]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Interested_Insert]
@id UNIQUEIDENTIFIER,
@like bit,
@love BIT,
@hate BIT,
@idpost UNIQUEIDENTIFIER,
@iduser UNIQUEIDENTIFIER
AS
BEGIN
	INSERT INTO dbo.Interested
	        ( Idinterested ,
	          [Like] ,
	          Love ,
	          Hate ,
	          IdPost ,
	          IdUser
	        )
	VALUES  ( @id , -- Idinterested - uniqueidentifier
	          @like , -- Like - int
	          @love , -- Love - int
	          @hate, -- Hate - int
	          @idpost , -- IdPost - uniqueidentifier
	          @iduser  -- IdUser - uniqueidentifier
	        )
END

GO
/****** Object:  StoredProcedure [dbo].[Interested_Update]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Interested_Update]
@id UNIQUEIDENTIFIER,
@like bit,
@love BIT,
@hate BIT,
@idpost UNIQUEIDENTIFIER,
@iduser UNIQUEIDENTIFIER
AS
BEGIN
	UPDATE dbo.Interested
	SET [Like] = @like, Love = @love, Hate = @hate, IdPost = @idpost, IdUser = @iduser
	WHERE Idinterested = @id
END

GO
/****** Object:  StoredProcedure [dbo].[Post_Delete]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Post_Delete]
@id UNIQUEIDENTIFIER
AS
BEGIN
	UPDATE dbo.Posts
	SET IsDelete = 1
	WHERE IdPost = @id
END

GO
/****** Object:  StoredProcedure [dbo].[Post_Getall]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Post_Getall]
@start INT,
@length INT,
@total INT OUTPUT
AS
BEGIN
	IF OBJECT_ID('tempdb..#pagingpost') IS NOT NULL DROP TABLE #pagingpost
	SELECT * INTO #pagingpost FROM (
		SELECT DISTINCT p.IdPost,p.PostName,p.NameAscii,p.Introduction,p.Avatar,p.Length,p.DateCreate,p.Note,p.IdUser,
		p.Source,p.Author,p.IsDelete,p.IsFull,p.IdCategory,p.Type,p.Child, (ROW_NUMBER() OVER (ORDER BY p.DateCreate DESC)) AS rownumber
		FROM dbo.Posts p
	) AS db
	SET @total = (SELECT COUNT(*) FROM dbo.Roles)
	SELECT * FROM #pagingpost r
	WHERE r.rownumber > @start AND r.rownumber <= @start + @length
	DROP TABLE #pagingpost
END

GO
/****** Object:  StoredProcedure [dbo].[Post_Getallpaging]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Post_Getallpaging]
@start INT,
@length INT
AS
BEGIN
	SELECT * FROM (
		SELECT DISTINCT p.IdPost,p.PostName,p.NameAscii,p.Introduction,p.Avatar,p.Length,p.DateCreate,p.Note,p.IdUser,
		p.Source,p.Author,p.IsDelete,p.IsFull,p.IdCategory,p.Type,p.Child, (ROW_NUMBER() OVER (ORDER BY p.DateCreate DESC)) AS rownumber
		FROM dbo.Posts p
	) AS db
	WHERE db.rownumber > @start AND db.rownumber <= @start + @length
END

GO
/****** Object:  StoredProcedure [dbo].[Post_Insert]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Post_Insert]
@id UNIQUEIDENTIFIER,
@postname NVARCHAR(250),
@nameascii NVARCHAR(500),
@introduction NVARCHAR(max),
@avatar VARCHAR(250),
@length INT,
@datecreate DATETIME,
@note NVARCHAR(500),
@iduser UNIQUEIDENTIFIER,
@source NVARCHAR(500),
@author NVARCHAR(100),
@isdelete BIT,
@isfull BIT,
@idcategory INT,
@type NVARCHAR(500),
@child NVARCHAR(500)
AS
BEGIN
	INSERT INTO dbo.Posts
	        ( IdPost ,
	          PostName ,
	          NameAscii ,
	          Introduction ,
	          Avatar ,
	          Length ,
	          DateCreate ,
	          Note ,
	          IdUser ,
	          Source ,
	          Author ,
	          IsDelete ,
	          IsFull ,
	          IdCategory ,
	          Type ,
	          Child
	        )
	VALUES  ( @id, -- IdPost - uniqueidentifier
	          @postname , -- PostName - nvarchar(250)
	          @nameascii, -- NameAscii - nvarchar(500)
	          @introduction, -- Introduction - nvarchar(max)
	          @avatar, -- Avatar - varchar(250)
	          @length, -- Length - int
	          @datecreate , -- DateCreate - date
	          @note, -- Note - nvarchar(500)
	          @iduser, -- IdUser - uniqueidentifier
	          @source, -- Source - nvarchar(500)
	          @author, -- Author - nvarchar(100)
	          @isdelete, -- IsDelete - bit
	          @isfull, -- IsFull - bit
	          @idcategory, -- IdCategory - int
	          @type, -- Type - nvarchar(500)
	          @child  -- Child - nvarchar(500)
	        )
END

GO
/****** Object:  StoredProcedure [dbo].[Post_Update]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Post_Update]
@id UNIQUEIDENTIFIER,
@postname NVARCHAR(250),
@nameascii NVARCHAR(500),
@introduction NVARCHAR(max),
@avatar VARCHAR(250),
@length INT,
@note NVARCHAR(500),
@iduser UNIQUEIDENTIFIER,
@source NVARCHAR(500),
@author NVARCHAR(100),
@isdelete BIT,
@isfull BIT,
@idcategory INT,
@type NVARCHAR(500),
@child NVARCHAR(500)
AS
BEGIN
	UPDATE dbo.Posts
	SET PostName = @postname, NameAscii = @nameascii, Introduction = @introduction, Avatar = @avatar,
	Length = @length,Note = @note,IdUser = @iduser,Source = @source,Author = @author,
	IsDelete = @isdelete, IsFull = @isfull, IdCategory = @idcategory, Type = @type,Child = Child
	WHERE IdPost = @id
END

GO
/****** Object:  StoredProcedure [dbo].[Roles_Delete]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Roles_Delete]
@id INT
AS
BEGIN
	DELETE FROM dbo.Roles
	WHERE RoleId = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Roles_Getall]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Roles_Getall]
@start INT,
@length INT,
@total INT OUTPUT
AS
BEGIN
	IF OBJECT_ID('tempdb..#pagingrole') IS NOT NULL DROP TABLE #pagingrole
	SELECT * INTO #pagingrole FROM (
		SELECT DISTINCT r.RoleId,r.RoleName, (ROW_NUMBER() OVER (ORDER BY r.RoleName ASC)) AS rownumber
		FROM dbo.Roles r
	) AS db
	SET @total = (SELECT COUNT(*) FROM dbo.Roles)
	SELECT * FROM #pagingrole r
	WHERE r.rownumber > @start AND r.rownumber <= @start + @length
	DROP TABLE #pagingrole
END

GO
/****** Object:  StoredProcedure [dbo].[Roles_Getallpaging]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Roles_Getallpaging]
@start INT,
@length INT
AS
BEGIN
	SELECT *  FROM (
		SELECT DISTINCT r.RoleId,r.RoleName, (ROW_NUMBER() OVER (ORDER BY r.RoleName ASC)) AS rownumber
		FROM dbo.Roles r
	) AS db
	WHERE db.rownumber > @start AND db.rownumber <= @start + @length
END
GO
/****** Object:  StoredProcedure [dbo].[Roles_GetbyId]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Roles_GetbyId]
@id INT
AS
BEGIN
	SELECT * FROM dbo.Roles
	WHERE RoleId = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Roles_Insert]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Roles_Insert]
@name NVARCHAR(50)
AS
BEGIN
	INSERT INTO dbo.Roles
	        ( RoleName )
	VALUES  ( @name  -- RoleName - nvarchar(50)
	          )
END
GO
/****** Object:  StoredProcedure [dbo].[Roles_Update]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Roles_Update]
@id INT,
@name NVARCHAR(50)
AS
BEGIN
	UPDATE dbo.Roles
	SET RoleName = @name
	WHERE RoleId = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Type_Getall]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Type_Getall]
@start INT,
@length INT,
@total INT OUTPUT
AS
BEGIN
	IF OBJECT_ID('tempdb..#pagingtype') IS NOT NULL DROP TABLE #pagingtype
	SELECT * INTO #pagingtype FROM 
			(SELECT DISTINCT t.IdType, t.TypeName,(ROW_NUMBER() OVER (ORDER BY t.TypeName ASC)) AS rownumber
			 FROM dbo.Types t
			) AS db

	SET @total = (SELECT COUNT(*) FROM #pagingtype)
	SELECT * FROM #pagingtype as p
	WHERE p.rownumber > @start AND p.rownumber <= @start + @length
	DROP TABLE #pagingtype
END

GO
/****** Object:  StoredProcedure [dbo].[Type_Getallpaging]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Type_Getallpaging]
@start INT,
@length INT
AS
BEGIN
	SELECT * FROM 
			(SELECT DISTINCT t.IdType, t.TypeName,(ROW_NUMBER() OVER (ORDER BY t.TypeName ASC)) AS rownumber
			 FROM dbo.Types t
			) AS db
	WHERE db.rownumber > @start AND db.rownumber <= @start + @length
END
GO
/****** Object:  StoredProcedure [dbo].[Types_Delete]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Types_Delete]
@id INT
AS
BEGIN
	DELETE FROM dbo.Types
	WHERE IdType = @id
END

GO
/****** Object:  StoredProcedure [dbo].[Types_Insert]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Types_Insert]
@name NVARCHAR(100)
AS
BEGIN
	INSERT INTO dbo.Types
	        ( TypeName )
	VALUES  ( @name  -- TypeName - nvarchar(100)
	          )
END

GO
/****** Object:  StoredProcedure [dbo].[Types_Update]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Types_Update]
@id INT,
@name NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.Types
	SET TypeName = @name
	WHERE IdType = @id
END

GO
/****** Object:  StoredProcedure [dbo].[User_CheckActive]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[User_CheckActive]
@id UNIQUEIDENTIFIER
AS
BEGIN
	SELECT * FROM dbo.Users
	WHERE IdUser = @id AND IsActived = 'true'
	IF(@@ROWCOUNT = 0) RETURN 0
	ELSE RETURN 1
END

GO
/****** Object:  StoredProcedure [dbo].[User_CheckLogin]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[User_CheckLogin]
@username VARCHAR(50),
@password VARCHAR(50)
AS
BEGIN
	SELECT * FROM dbo.Users
	WHERE UserName = @username AND PassWord = @password AND IsActived = 'true' AND IsDelete = 'false'
	IF(@@ROWCOUNT = 0) RETURN 0
	ELSE RETURN 1
END

GO
/****** Object:  StoredProcedure [dbo].[User_CheckUsername]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[User_CheckUsername]
@userName VARCHAR(50)
AS
BEGIN
	SELECT * FROM dbo.Users
	WHERE UserName = @userName
	IF(@@ROWCOUNT = 0)
	RETURN 0
	ELSE
	RETURN 1
END

GO
/****** Object:  StoredProcedure [dbo].[User_Delete]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Delete]
@id  UNIQUEIDENTIFIER
AS
BEGIN
	UPDATE dbo.Users
	SET IsDelete = 1
	WHERE IdUser = @id
END
GO
/****** Object:  StoredProcedure [dbo].[User_Getall]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Getall]
@start INT,
@length INT,
@total INT OUTPUT
AS
BEGIN
	--CREATE TABLE #paging(
	--		  IdUser UNIQUEIDENTIFIER,
	--          FullName nvarchar(50),
	--          Avatar varchar(250),
	--          Address nvarchar(250),
	--          Email nvarchar(250),
	--          PhoneNumber varchar(50),
	--          Sex BIT,
	--          BirthDay DATE,
	--          UserName varchar(50),
	--          PassWord varchar(50),
	--          DateCreate DATETIME,
	--          AboutMe nvarchar(max),
	--          Permission TINYINT,
	--          PassActive nvarchar(250),
	--          IsActived BIT,
	--          IsDelete BIT,
	--          RoleId INT,
	--		  RoleName NVARCHAR(50),
	--		  RowNumber int
	--)
	IF OBJECT_ID('tempdb..#temp') IS NOT NULL DROP TABLE #temp
	SELECT * INTO #temp FROM (
		SELECT DISTINCT u.IdUser,
	          u.FullName ,
	          u.Avatar ,
	          u.Address ,
	          u.Email ,
	          u.PhoneNumber ,
	          u.Sex ,
	          u.BirthDay ,
	          u.UserName ,
	          u.PassWord ,
	          u.DateCreate ,
	          u.AboutMe ,
	          u.Permission ,
	          u.PassActive ,
	          u.IsActived ,
	          u.IsDelete ,
	          u.RoleId,
			  r.RoleName,
			  ROW_NUMBER() OVER (ORDER BY u.DateCreate DESC) AS RC
			  FROM dbo.Users u INNER JOIN dbo.Roles r ON r.RoleId = u.RoleId
	) AS B
	SET @total = (SELECT COUNT(*) FROM #temp)
	SELECT *
	FROM #temp AS t
	WHERE t.RC > @start AND t.RC <= @start + @length
	DROP TABLE #temp
END
GO
/****** Object:  StoredProcedure [dbo].[User_getallpaging]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_getallpaging]
@start INT,
@length INT	
AS
BEGIN
	SELECT * FROM (
		SELECT DISTINCT u.IdUser,
	          u.FullName ,
	          u.Avatar ,
	          u.Address ,
	          u.Email ,
	          u.PhoneNumber ,
	          u.Sex ,
	          u.BirthDay ,
	          u.UserName ,
	          u.PassWord ,
	          u.DateCreate ,
	          u.AboutMe ,
	          u.Permission ,
	          u.PassActive ,
	          u.IsActived ,
	          u.IsDelete ,
	          u.RoleId,
			  r.RoleName,
			  ROW_NUMBER() OVER (ORDER BY u.DateCreate DESC) AS rownumber
			  FROM dbo.Users u INNER JOIN dbo.Roles r ON r.RoleId = u.RoleId
	) AS B
	WHERE B.rownumber > @start AND B.rownumber <= @start + @length
END

GO
/****** Object:  StoredProcedure [dbo].[User_GetbyId]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_GetbyId]
@id UNIQUEIDENTIFIER
AS
BEGIN
	SELECT * FROM dbo.Users
	WHERE IdUser = @id
END

GO
/****** Object:  StoredProcedure [dbo].[User_Insert]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Insert]
@id  UNIQUEIDENTIFIER,
@fullname NVARCHAR(50),
@avatar VARCHAR(250),
@address NVARCHAR(250),
@email NVARCHAR(250),
@phone VARCHAR(50),
@sex BIT,
@birthday DATE,
@username VARCHAR(50),
@password VARCHAR(50),
@datecreate DATETIME,
@aboutme NVARCHAR(max),
@permission TINYINT,
@passactive NVARCHAR(250),
@isactive BIT,
@isdelete BIT,
@roleid INT
AS
BEGIN
	INSERT INTO dbo.Users
	        ( IdUser ,
	          FullName ,
	          Avatar ,
	          Address ,
	          Email ,
	          PhoneNumber ,
	          Sex ,
	          BirthDay ,
	          UserName ,
	          PassWord ,
	          DateCreate ,
	          AboutMe ,
	          Permission ,
	          PassActive ,
	          IsActived ,
	          IsDelete ,
	          RoleId
	        )
	VALUES  ( @id , -- IdUser - uniqueidentifier
	          @fullname , -- FullName - nvarchar(50)
	          @avatar , -- Avatar - varchar(250)
	          @address, -- Address - nvarchar(250)
	          @email, -- Email - nvarchar(250)
	          @phone, -- PhoneNumber - varchar(50)
	          @sex, -- Sex - bit
	          @birthday, -- BirthDay - date
	          @username, -- UserName - varchar(50)
	          @password, -- PassWord - varchar(50)
	          @datecreate, -- DateCreate - datetime
	          @aboutme, -- AboutMe - nvarchar(max)
	          @permission, -- Permission - tinyint
	          @passactive, -- PassActive - nvarchar(250)
	          @isactive, -- IsActived - bit
	          @isdelete , -- IsDelete - bit
	          @roleid  -- RoleId - int
	        )
END
GO
/****** Object:  StoredProcedure [dbo].[User_Update]    Script Date: 7/25/2018 5:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Update]
@id  UNIQUEIDENTIFIER,
@fullname NVARCHAR(50),
@avatar VARCHAR(250),
@address NVARCHAR(250),
@email NVARCHAR(250),
@phone VARCHAR(50),
@sex BIT,
@birthday DATE,
@username VARCHAR(50),
@password VARCHAR(50),
@aboutme NVARCHAR(max),
@permission TINYINT,
@passactive NVARCHAR(250),
@isactive BIT,
@isdelete BIT,
@roleid INT
AS
BEGIN
	UPDATE dbo.Users
	SET	 FullName = @username, Avatar = @avatar, Address = @address ,Email = @email ,
	          PhoneNumber = @phone , Sex = @sex , BirthDay = @birthday,UserName = @username ,
	          PassWord = @password , AboutMe = @aboutme , Permission = @permission ,
	          PassActive =@passactive, IsActived = @isactive, IsDelete = @isdelete , RoleId = @roleid
	WHERE IdUser = @id
END

GO
USE [master]
GO
ALTER DATABASE [BlogTruyen] SET  READ_WRITE 
GO

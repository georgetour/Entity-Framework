USE [master]
GO
/****** Object:  Database [SecondDatabase]    Script Date: 15-Jan-18 7:04:04 PM ******/
CREATE DATABASE [SecondDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SecondDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\SecondDatabase.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SecondDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\SecondDatabase_log.ldf' , SIZE = 1536KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SecondDatabase] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SecondDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SecondDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SecondDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SecondDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SecondDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SecondDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [SecondDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SecondDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SecondDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SecondDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SecondDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SecondDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SecondDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SecondDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SecondDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SecondDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SecondDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SecondDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SecondDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SecondDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SecondDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SecondDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SecondDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SecondDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SecondDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [SecondDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SecondDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SecondDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SecondDatabase] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SecondDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
USE [SecondDatabase]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 15-Jan-18 7:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Biography] [nvarchar](max) NULL,
	[DateAdded] [smalldatetime] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 15-Jan-18 7:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [smallmoney] NOT NULL,
	[ImageFile] [nvarchar](100) NULL,
	[AuthorId] [int] NOT NULL,
	[PublisherId] [int] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publishers]    Script Date: 15-Jan-18 7:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publishers](
	[PublisherId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Publishers] PRIMARY KEY CLUSTERED 
(
	[PublisherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([AuthorId], [Name], [Biography], [DateAdded], [Active]) VALUES (3, N'Kurt Vonnegut', NULL, CAST(N'2017-12-18T00:00:00' AS SmallDateTime), 1)
INSERT [dbo].[Authors] ([AuthorId], [Name], [Biography], [DateAdded], [Active]) VALUES (4, N'Ernest Heminway', NULL, CAST(N'2018-01-15T00:00:00' AS SmallDateTime), 1)
INSERT [dbo].[Authors] ([AuthorId], [Name], [Biography], [DateAdded], [Active]) VALUES (5, N'George Orwell', NULL, CAST(N'2017-12-18T00:00:00' AS SmallDateTime), 1)
INSERT [dbo].[Authors] ([AuthorId], [Name], [Biography], [DateAdded], [Active]) VALUES (6, N'Herman Melville', NULL, CAST(N'2017-12-18T00:00:00' AS SmallDateTime), 1)
INSERT [dbo].[Authors] ([AuthorId], [Name], [Biography], [DateAdded], [Active]) VALUES (7, N'John Steinbeck', NULL, CAST(N'2017-12-18T00:00:00' AS SmallDateTime), 1)
SET IDENTITY_INSERT [dbo].[Authors] OFF
INSERT [dbo].[Books] ([BookId], [Title], [Description], [Price], [ImageFile], [AuthorId], [PublisherId]) VALUES (N'25d21ffd-9840-47ce-b3c4-179c3e750cc2', N'The grapes of wrath', NULL, 22.0000, NULL, 7, 2)
INSERT [dbo].[Books] ([BookId], [Title], [Description], [Price], [ImageFile], [AuthorId], [PublisherId]) VALUES (N'3f4caa54-f688-4a7c-8e98-26dbd5f59a85', N'1984', NULL, 40.0000, NULL, 5, 1)
INSERT [dbo].[Books] ([BookId], [Title], [Description], [Price], [ImageFile], [AuthorId], [PublisherId]) VALUES (N'2c69307a-6f8b-4854-b7b0-28b985d7b37d', N'Old man and the sea', NULL, 30.0000, NULL, 4, 2)
INSERT [dbo].[Books] ([BookId], [Title], [Description], [Price], [ImageFile], [AuthorId], [PublisherId]) VALUES (N'6f23ea5f-a8cc-4de1-9d38-392ca6b30fac', N'Slaughterhouse 5', NULL, 20.0000, NULL, 3, 1)
INSERT [dbo].[Books] ([BookId], [Title], [Description], [Price], [ImageFile], [AuthorId], [PublisherId]) VALUES (N'c9acd978-a688-45de-8cb3-7d6cb565ef69', N'ΜΠΑΜΙΑΣ', NULL, 15.0000, NULL, 6, 3)
INSERT [dbo].[Books] ([BookId], [Title], [Description], [Price], [ImageFile], [AuthorId], [PublisherId]) VALUES (N'98d98ffb-c847-4815-96a8-b56ad9ce37c4', N'Moby Dick', NULL, 15.0000, NULL, 6, 3)
INSERT [dbo].[Books] ([BookId], [Title], [Description], [Price], [ImageFile], [AuthorId], [PublisherId]) VALUES (N'493987b4-8963-4abf-931c-fabe80177b09', N'ΜΠΑΜΙΑΣ2', NULL, 15.0000, NULL, 6, 3)
SET IDENTITY_INSERT [dbo].[Publishers] ON 

INSERT [dbo].[Publishers] ([PublisherId], [Name]) VALUES (1, N'Penguin Random House')
INSERT [dbo].[Publishers] ([PublisherId], [Name]) VALUES (2, N'HarperCollins')
INSERT [dbo].[Publishers] ([PublisherId], [Name]) VALUES (3, N'Simon & Cluster')
SET IDENTITY_INSERT [dbo].[Publishers] OFF
ALTER TABLE [dbo].[Authors] ADD  CONSTRAINT [DF_Authors_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Books] ADD  CONSTRAINT [DF_Books_BookId]  DEFAULT (newid()) FOR [BookId]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Authors] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([AuthorId])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Authors]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Publishers] FOREIGN KEY([PublisherId])
REFERENCES [dbo].[Publishers] ([PublisherId])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Publishers]
GO
USE [master]
GO
ALTER DATABASE [SecondDatabase] SET  READ_WRITE 
GO

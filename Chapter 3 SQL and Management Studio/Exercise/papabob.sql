USE [master]
GO
/****** Object:  Database [Papabobs]    Script Date: 16-Jan-18 7:08:55 PM ******/
CREATE DATABASE [Papabobs]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Papabobs', FILENAME = N'C:\C-Sharp-Projects\Entity Framework\Chapter 3 SQL and Management Studio\Exercise\Papabobs.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Papabobs_log', FILENAME = N'C:\C-Sharp-Projects\Entity Framework\Chapter 3 SQL and Management Studio\Exercise\Papabobs_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Papabobs] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Papabobs].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Papabobs] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Papabobs] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Papabobs] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Papabobs] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Papabobs] SET ARITHABORT OFF 
GO
ALTER DATABASE [Papabobs] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Papabobs] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Papabobs] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Papabobs] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Papabobs] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Papabobs] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Papabobs] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Papabobs] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Papabobs] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Papabobs] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Papabobs] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Papabobs] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Papabobs] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Papabobs] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Papabobs] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Papabobs] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Papabobs] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Papabobs] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Papabobs] SET  MULTI_USER 
GO
ALTER DATABASE [Papabobs] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Papabobs] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Papabobs] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Papabobs] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Papabobs] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Papabobs]
GO
/****** Object:  Table [dbo].[Crusts]    Script Date: 16-Jan-18 7:08:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Crusts](
	[CrustId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Crusts] PRIMARY KEY CLUSTERED 
(
	[CrustId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 16-Jan-18 7:08:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[PhoneNumber] [char](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[State] [char](2) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 16-Jan-18 7:08:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[OrderItemId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[SizeId] [int] NOT NULL,
	[CrustId] [int] NOT NULL,
	[Cheese] [bit] NOT NULL,
	[Sausage] [bit] NOT NULL,
	[Peperoni] [bit] NOT NULL,
	[Bacon] [bit] NOT NULL,
	[Onion] [bit] NOT NULL,
	[GreenPepper] [bit] NOT NULL,
	[Mushroom] [bit] NOT NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[OrderItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 16-Jan-18 7:08:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[OrderTotal] [smallmoney] NOT NULL,
	[OrderStatusId] [int] NOT NULL,
	[OrderDate] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 16-Jan-18 7:08:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[OrderStatusId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[OrderStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sizes]    Script Date: 16-Jan-18 7:08:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sizes](
	[SizeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Sizes] PRIMARY KEY CLUSTERED 
(
	[SizeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Crusts] FOREIGN KEY([CrustId])
REFERENCES [dbo].[Crusts] ([CrustId])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Crusts]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_OrderItems] FOREIGN KEY([OrderItemId])
REFERENCES [dbo].[OrderItems] ([OrderItemId])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_OrderItems]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Orders]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Sizes] FOREIGN KEY([SizeId])
REFERENCES [dbo].[Sizes] ([SizeId])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Sizes]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_OrderStatus] FOREIGN KEY([OrderStatusId])
REFERENCES [dbo].[OrderStatus] ([OrderStatusId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_OrderStatus]
GO
USE [master]
GO
ALTER DATABASE [Papabobs] SET  READ_WRITE 
GO

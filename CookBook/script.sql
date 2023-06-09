USE [master]
GO
/****** Object:  Database [KniggaShop]    Script Date: 30.05.2023 14:28:05 ******/
CREATE DATABASE [KniggaShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KniggaShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\KniggaShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'KniggaShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\KniggaShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [KniggaShop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KniggaShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KniggaShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KniggaShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KniggaShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KniggaShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KniggaShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [KniggaShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KniggaShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KniggaShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KniggaShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KniggaShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KniggaShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KniggaShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KniggaShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KniggaShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KniggaShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KniggaShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KniggaShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KniggaShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KniggaShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KniggaShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KniggaShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KniggaShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KniggaShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KniggaShop] SET  MULTI_USER 
GO
ALTER DATABASE [KniggaShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KniggaShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KniggaShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KniggaShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KniggaShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [KniggaShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [KniggaShop] SET QUERY_STORE = OFF
GO
USE [KniggaShop]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 30.05.2023 14:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Price] [decimal](15, 2) NOT NULL,
	[SalePrice] [decimal](15, 2) NOT NULL,
	[Photo] [image] NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Maker] [varchar](50) NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 30.05.2023 14:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[Talon] [int] NOT NULL,
	[Point] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderBook]    Script Date: 30.05.2023 14:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderBook](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Price] [decimal](15, 2) NOT NULL,
	[SalePrice] [decimal](15, 2) NOT NULL,
	[BookID] [int] NOT NULL,
	[OrderID] [int] NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_OrderBook] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 30.05.2023 14:28:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Role] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OrderBook]  WITH CHECK ADD  CONSTRAINT [FK_OrderBook_Book] FOREIGN KEY([BookID])
REFERENCES [dbo].[Book] ([ID])
GO
ALTER TABLE [dbo].[OrderBook] CHECK CONSTRAINT [FK_OrderBook_Book]
GO
ALTER TABLE [dbo].[OrderBook]  WITH CHECK ADD  CONSTRAINT [FK_OrderBook_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([ID])
GO
ALTER TABLE [dbo].[OrderBook] CHECK CONSTRAINT [FK_OrderBook_Order]
GO
USE [master]
GO
ALTER DATABASE [KniggaShop] SET  READ_WRITE 
GO

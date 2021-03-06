USE [master]
GO
/****** Object:  Database [bloggenerator]    Script Date: 2013/12/7 1:03:35 ******/
CREATE DATABASE [bloggenerator]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bloggenerator', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\bloggenerator.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'bloggenerator_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\bloggenerator_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [bloggenerator] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bloggenerator].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bloggenerator] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bloggenerator] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bloggenerator] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bloggenerator] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bloggenerator] SET ARITHABORT OFF 
GO
ALTER DATABASE [bloggenerator] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bloggenerator] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [bloggenerator] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bloggenerator] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bloggenerator] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bloggenerator] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bloggenerator] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bloggenerator] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bloggenerator] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bloggenerator] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bloggenerator] SET  DISABLE_BROKER 
GO
ALTER DATABASE [bloggenerator] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bloggenerator] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bloggenerator] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bloggenerator] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bloggenerator] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bloggenerator] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bloggenerator] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bloggenerator] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [bloggenerator] SET  MULTI_USER 
GO
ALTER DATABASE [bloggenerator] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bloggenerator] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bloggenerator] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bloggenerator] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [bloggenerator]
GO
/****** Object:  Table [dbo].[bloginfo]    Script Date: 2013/12/7 1:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bloginfo](
	[blogid] [int] IDENTITY(1,1) NOT NULL,
	[uid] [int] NOT NULL,
	[blogtitle] [varchar](50) NOT NULL,
	[bloglabel] [varchar](50) NOT NULL,
	[briefintro] [varchar](50) NOT NULL,
	[blogcontent] [text] NOT NULL,
	[createdate] [varchar](20) NOT NULL,
 CONSTRAINT [PK_bloginfo] PRIMARY KEY CLUSTERED 
(
	[blogid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[userinfo]    Script Date: 2013/12/7 1:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[userinfo](
	[uid] [int] IDENTITY(1,1) NOT NULL,
	[uemail] [varchar](50) NOT NULL,
	[upassword] [varchar](20) NOT NULL,
	[username] [varchar](50) NULL,
	[style] [tinyint] NULL,
	[blogname] [varchar](50) NULL,
	[linkname1] [varchar](50) NULL,
	[linkurl1] [varchar](50) NULL,
	[linkname2] [varchar](50) NULL,
	[linkurl2] [varchar](50) NULL,
	[linkname3] [varchar](50) NULL,
	[linkurl3] [varchar](50) NULL,
 CONSTRAINT [PK_userinfo] PRIMARY KEY CLUSTERED 
(
	[uid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [bloggenerator] SET  READ_WRITE 
GO

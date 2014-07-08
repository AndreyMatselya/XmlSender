USE [master]
GO
/****** Object:  Database [XmlSender]    Script Date: 08.07.2014 23:03:49 ******/
CREATE DATABASE [XmlSender]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'XmlSender', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\XmlSender.mdf' , SIZE = 7168KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'XmlSender_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\XmlSender_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [XmlSender] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [XmlSender].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [XmlSender] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [XmlSender] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [XmlSender] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [XmlSender] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [XmlSender] SET ARITHABORT OFF 
GO
ALTER DATABASE [XmlSender] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [XmlSender] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [XmlSender] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [XmlSender] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [XmlSender] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [XmlSender] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [XmlSender] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [XmlSender] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [XmlSender] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [XmlSender] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [XmlSender] SET  DISABLE_BROKER 
GO
ALTER DATABASE [XmlSender] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [XmlSender] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [XmlSender] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [XmlSender] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [XmlSender] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [XmlSender] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [XmlSender] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [XmlSender] SET RECOVERY FULL 
GO
ALTER DATABASE [XmlSender] SET  MULTI_USER 
GO
ALTER DATABASE [XmlSender] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [XmlSender] SET DB_CHAINING OFF 
GO
ALTER DATABASE [XmlSender] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [XmlSender] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'XmlSender', N'ON'
GO
USE [XmlSender]
GO
/****** Object:  Table [dbo].[Response]    Script Date: 08.07.2014 23:03:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Response](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Xml_Id] [uniqueidentifier] NOT NULL,
	[Cover] [xml] NOT NULL,
	[Errors] [xml] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[Identif] [nvarchar](50) NOT NULL,
	[InsuranceAwardingDate] [datetime] NULL,
	[InsuranceSuspensionDate] [nvarchar](200) NULL,
	[ErrorsCount] [int] NOT NULL,
	[ErrorsText] [nvarchar](max) NULL,
 CONSTRAINT [PK_Response] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Xml]    Script Date: 08.07.2014 23:03:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Xml](
	[Id] [uniqueidentifier] NOT NULL,
	[SendDate] [datetime] NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[XmlBody] [xml] NOT NULL,
	[Description] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Xml] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Response]  WITH CHECK ADD  CONSTRAINT [FK_Response_Xml] FOREIGN KEY([Xml_Id])
REFERENCES [dbo].[Xml] ([Id])
GO
ALTER TABLE [dbo].[Response] CHECK CONSTRAINT [FK_Response_Xml]
GO
USE [master]
GO
ALTER DATABASE [XmlSender] SET  READ_WRITE 
GO

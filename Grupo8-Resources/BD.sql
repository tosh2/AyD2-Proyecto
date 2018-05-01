USE [master]
GO

/****** Object:  Database [ad2-proyecto]    Script Date: 01/05/2018 1:42:01 ******/
CREATE DATABASE [ad2-proyecto]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ad2-proyecto', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ad2-proyecto.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ad2-proyecto_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ad2-proyecto_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [ad2-proyecto] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ad2-proyecto].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [ad2-proyecto] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [ad2-proyecto] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [ad2-proyecto] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [ad2-proyecto] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [ad2-proyecto] SET ARITHABORT OFF 
GO

ALTER DATABASE [ad2-proyecto] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [ad2-proyecto] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [ad2-proyecto] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [ad2-proyecto] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [ad2-proyecto] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [ad2-proyecto] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [ad2-proyecto] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [ad2-proyecto] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [ad2-proyecto] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [ad2-proyecto] SET  DISABLE_BROKER 
GO

ALTER DATABASE [ad2-proyecto] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [ad2-proyecto] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [ad2-proyecto] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [ad2-proyecto] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [ad2-proyecto] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [ad2-proyecto] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [ad2-proyecto] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [ad2-proyecto] SET RECOVERY FULL 
GO

ALTER DATABASE [ad2-proyecto] SET  MULTI_USER 
GO

ALTER DATABASE [ad2-proyecto] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [ad2-proyecto] SET DB_CHAINING OFF 
GO

ALTER DATABASE [ad2-proyecto] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [ad2-proyecto] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [ad2-proyecto] SET  READ_WRITE 
GO


-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


USE [ad2-proyecto]
GO

/****** Object:  Table [dbo].[Usuario]    Script Date: 01/05/2018 2:07:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Usuario](
	[Cuenta] [int] NOT NULL,
	[Nombres] [varchar](50) NULL,
	[Apellidos] [varchar](50) NULL,
	[Dpi] [numeric](18, 0) NULL,
	[SaldoInicial] [numeric](9, 2) NULL,
	[Correo] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


-->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


USE [ad2-proyecto]
GO

/****** Object:  Table [dbo].[Transferencia]    Script Date: 01/05/2018 2:07:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transferencia](
	[CuentaOrigen] [int] NOT NULL,
	[CuentaDestino] [int] NOT NULL,
	[MontoTransferencia] [numeric](9, 2) NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Transferencia]  WITH CHECK ADD  CONSTRAINT [FK_Transferencia_Usuario] FOREIGN KEY([CuentaOrigen])
REFERENCES [dbo].[Usuario] ([Cuenta])
GO

ALTER TABLE [dbo].[Transferencia] CHECK CONSTRAINT [FK_Transferencia_Usuario]
GO

ALTER TABLE [dbo].[Transferencia]  WITH CHECK ADD  CONSTRAINT [FK_Transferencia_Usuario1] FOREIGN KEY([CuentaDestino])
REFERENCES [dbo].[Usuario] ([Cuenta])
GO

ALTER TABLE [dbo].[Transferencia] CHECK CONSTRAINT [FK_Transferencia_Usuario1]
GO
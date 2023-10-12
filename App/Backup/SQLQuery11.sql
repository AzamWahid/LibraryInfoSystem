USE [master]
GO
/****** Object:  Database [LIS]    Script Date: 11/10/2023 8:47:56 PM ******/
CREATE DATABASE [LIS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LIS', FILENAME = N'H:\Persnol\UNI\7th\cs619\Final\LibraryInfoSystem\App\Data\LIS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LIS_log', FILENAME = N'H:\Persnol\UNI\7th\cs619\Final\LibraryInfoSystem\App\Data\LIS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [LIS] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LIS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LIS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LIS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LIS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LIS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LIS] SET ARITHABORT OFF 
GO
ALTER DATABASE [LIS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LIS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LIS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LIS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LIS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LIS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LIS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LIS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LIS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LIS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LIS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LIS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LIS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LIS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LIS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LIS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LIS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LIS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LIS] SET  MULTI_USER 
GO
ALTER DATABASE [LIS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LIS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LIS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LIS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LIS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LIS] SET QUERY_STORE = OFF
GO
USE [LIS]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/10/2023 8:47:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UID] [bigint] IDENTITY(1,1) NOT NULL,
	[UName] [varchar](15) NULL,
	[UFName] [varchar](15) NULL,
	[UEmail] [varchar](50) NULL,
	[UMobileNo] [bigint] NULL,
	[UPass] [varchar](50) NULL,
	[UType] [char](1) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddRegUser]    Script Date: 11/10/2023 8:47:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_AddRegUser]
	-- Add the parameters for the stored procedure here
	
	@UName varchar(15),
	@UFName varchar(15),
	@UEmail varchar(50),
	@UMobileNo bigint,
	@UPass varchar(50),
	@UType char(1)


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

			Insert into Users (UName, UFName, UEmail, UMobileNo,UPass,UType)
				 values (@UName, @UFName, @UEmail, @UMobileNo, @UPass,@UType)
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CheckUserCredentials]    Script Date: 11/10/2023 8:47:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[sp_CheckUserCredentials]
	-- Add the parameters for the stored procedure here
	
	@UEmail varchar(50),
	@UPass varchar(50)

-- exec[sp_CheckUserExists]'azamwahid@yahoo.com',03322762032

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select *
	from Users
	where UEmail = @UEmail and UPass = @UPass
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CheckUserExists]    Script Date: 11/10/2023 8:47:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_CheckUserExists]
	-- Add the parameters for the stored procedure here
	
	@UEmail varchar(50),
	@UMobileNo bigint

-- exec[sp_CheckUserExists]'azamwahid@yahoo.com',03322762032

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select *
	from Users
	where UEmail = @UEmail or UMobileNo = @UMobileNo
	
END
GO
USE [master]
GO
ALTER DATABASE [LIS] SET  READ_WRITE 
GO

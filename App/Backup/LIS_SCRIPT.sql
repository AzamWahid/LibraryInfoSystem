USE [master]
GO
/****** Object:  Database [LIS]    Script Date: 29/11/2023 12:50:38 AM ******/
CREATE DATABASE [LIS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LIS', FILENAME = N'F:\Virtual University\7th\CS619\Final\App\Data\LIS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LIS_log', FILENAME = N'F:\Virtual University\7th\CS619\Final\App\Data\LIS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
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
ALTER DATABASE [LIS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [LIS] SET QUERY_STORE = OFF
GO
USE [LIS]
GO
/****** Object:  Table [dbo].[book]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[book](
	[BookID] [bigint] IDENTITY(1,1) NOT NULL,
	[BookCode] [varchar](50) NULL,
	[BookTitle] [varchar](50) NULL,
	[BookAuthor] [varchar](50) NULL,
	[BookISBN] [varchar](50) NULL,
	[BookYear] [bigint] NULL,
	[BookEdition] [bigint] NULL,
	[BookNoofCopies] [bigint] NULL,
 CONSTRAINT [PK_book] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BorrowBook]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BorrowBook](
	[BBID] [bigint] IDENTITY(1,1) NOT NULL,
	[BBRefNo] [bigint] NULL,
	[BBRefDate] [datetime] NULL,
	[BBUID] [bigint] NULL,
	[BBBookID] [bigint] NULL,
	[BBDays] [bigint] NULL,
 CONSTRAINT [PK_BorrowBook] PRIMARY KEY CLUSTERED 
(
	[BBID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BorrowReturn]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BorrowReturn](
	[BRID] [bigint] IDENTITY(1,1) NOT NULL,
	[BRRefNo] [bigint] NULL,
	[BRRefDate] [datetime] NULL,
	[BRBID] [bigint] NULL,
	[BRFineYN] [char](1) NULL,
 CONSTRAINT [PK_BorrowReturn] PRIMARY KEY CLUSTERED 
(
	[BRID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FinePay]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FinePay](
	[FID] [bigint] IDENTITY(1,1) NOT NULL,
	[FRefNo] [bigint] NULL,
	[FRefDate] [datetime] NULL,
	[FIFID] [bigint] NULL,
	[FAmnt] [decimal](16, 2) NULL,
 CONSTRAINT [PK_Fine] PRIMARY KEY CLUSTERED 
(
	[FID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImposeFine]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImposeFine](
	[IFID] [bigint] IDENTITY(1,1) NOT NULL,
	[IFRefNo] [bigint] NULL,
	[IFRefDate] [datetime] NULL,
	[IFBRID] [bigint] NULL,
	[IFAmnt] [decimal](16, 2) NULL,
 CONSTRAINT [PK_ImposeFine] PRIMARY KEY CLUSTERED 
(
	[IFID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UID] [bigint] IDENTITY(1,1) NOT NULL,
	[UName] [varchar](15) NULL,
	[UFName] [varchar](15) NULL,
	[UEmail] [varchar](50) NULL,
	[UMobileNo] [varchar](50) NULL,
	[UPass] [varchar](50) NULL,
	[UType] [char](1) NULL,
	[UAllowBorrow] [char](1) NULL,
	[UBookRights] [char](1) NULL,
	[UBlock] [char](1) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[book] ADD  CONSTRAINT [DF_book_edition]  DEFAULT ((0)) FOR [BookISBN]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_UAllowBorrow]  DEFAULT ('Y') FOR [UAllowBorrow]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_UBookRights]  DEFAULT ('N') FOR [UBookRights]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_UBlock]  DEFAULT ('N') FOR [UBlock]
GO
ALTER TABLE [dbo].[BorrowBook]  WITH CHECK ADD  CONSTRAINT [FK_BorrowBook_book] FOREIGN KEY([BBBookID])
REFERENCES [dbo].[book] ([BookID])
GO
ALTER TABLE [dbo].[BorrowBook] CHECK CONSTRAINT [FK_BorrowBook_book]
GO
ALTER TABLE [dbo].[BorrowBook]  WITH CHECK ADD  CONSTRAINT [FK_BorrowBook_Users] FOREIGN KEY([BBUID])
REFERENCES [dbo].[Users] ([UID])
GO
ALTER TABLE [dbo].[BorrowBook] CHECK CONSTRAINT [FK_BorrowBook_Users]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddRegUser]    Script Date: 29/11/2023 12:50:38 AM ******/
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
	@UMobileNo varchar(50),
	@UPass varchar(50),
	@UType char(1),
	@UAllowBorrow char(1) = 'Y',
	@UBookRights char(1) = 'N',
	@UBlock char(1) = 'N'


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

			Insert into Users (UName, UFName, UEmail, UMobileNo,UPass,UType,UAllowBorrow,UBookRights,UBlock)
				 values (@UName, @UFName, @UEmail, @UMobileNo, @UPass,@UType,@UAllowBorrow,@UBookRights,@UBlock)
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CheckUserCredentials]    Script Date: 29/11/2023 12:50:38 AM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_CheckUserExists]    Script Date: 29/11/2023 12:50:38 AM ******/
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
	@UMobileNo bigint = 0

-- exec[sp_CheckUserExists]'azamwahid@yahoo.com',03322762032

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select [UID],UName,UEmail,UMobileNo,UPass,
	       case when UType = 'S' then 'Student' else case when UType = 'F' then 'Faculty' else 'Admin' end end as UType
	from Users
	where UEmail = @UEmail or UMobileNo = @UMobileNo
	
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_ChectAlreadyBorrow]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_ChectAlreadyBorrow]
	-- Add the parameters for the stored procedure here
	
		@UID bigint,
		@BookID bigint

--	exec [Sp_ChectAlreadyBorrow]2,9
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select BBID,BBBookID,BBUID
		from borrowBook
		where BBBookID = @BookID and BBUID = @UID
		and BBID not in (select BRBID from BorrowReturn)


END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteBook]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_DeleteBook]
	-- Add the parameters for the stored procedure here
	
		@BookCode varchar(50)

--	exec [sp_getBookEdit]'01'
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		delete book
		where BookCode = @BookCode

END
GO
/****** Object:  StoredProcedure [dbo].[Sp_DeleteCheckBook]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_DeleteCheckBook]
	-- Add the parameters for the stored procedure here

		@BookCode varchar(50)

--	exec [Sp_DeleteCheckBook]'002'
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select BBID,BBBookID,BBUID
		from borrowBook
		inner join book on BBBookID = BookID
		where BookCode = @BookCode 
		and BBID not in (select BRBID from BorrowReturn)
		union all
		select BBID,BBBookID,BBUID
		from ImposeFine
		inner join BorrowReturn on IFBRID = BRID
		inner join borrowBook on BRBID = BBID
		inner join book on BBBookID = BookID
		where BookCode = @BookCode 
		and IFID not in (select FIFID from FinePay)

END
GO
/****** Object:  StoredProcedure [dbo].[sp_getAvailableBook]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getAvailableBook]
	-- Add the parameters for the stored procedure here
--	exec[sp_getAvailableBook]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		IF OBJECT_ID('tempdb..#Ava_Book') IS NOT NULL
			BEGIN
			DROP TABLE #Ava_Book
		END

		select BookID,BookCode,BookTitle,BookAuthor,BookISBN,BookYear,BookEdition,BookNoofCopies,0 as borrow, BookNoofCopies as remainingCopies
		into #Ava_Book
		from book
		union all 
		select BookID,BookCode,BookTitle,BookAuthor,BookISBN,BookYear,BookEdition,BookNoofCopies,1,-1
		from BorrowBook
		inner join book on BBBookID = BookID
		union all 
		select BookID,BookCode,BookTitle,BookAuthor,BookISBN,BookYear,BookEdition,BookNoofCopies,-1,1
		from BorrowReturn
		inner join BorrowBook on BRBID = BBID
		inner join book on BBBookID = BookID

		select BookID,BookCode,max(BookTitle) as BookTitle,max(BookAuthor) as BookAuthor,
			   max(BookISBN) as BookISBN,max(BookYear) as BookYear,max(BookEdition) as BookEdition,
			   max(BookNoofCopies) as BookNoofCopies,sum(borrow) as borrow, sum(remainingCopies) as remainingCopies
		from #Ava_Book
		group by BookID,BookCode
		having sum(remainingCopies) > 0
		






END
GO
/****** Object:  StoredProcedure [dbo].[sp_getBookEdit]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getBookEdit]
	-- Add the parameters for the stored procedure here
	
		@BookCode varchar(50)

--	exec [sp_getBookEdit]'01'
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select BookCode,BookTitle,BookAuthor,BookISBN,BookYear,BookEdition,BookNoofCopies
		from book
		where BookCode = @BookCode

END
GO
/****** Object:  StoredProcedure [dbo].[sp_getBookList]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getBookList]
	-- Add the parameters for the stored procedure here
--	exec [sp_getBookList]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select  BookCode,BookTitle,BookAuthor,BookISBN,BookYear,BookEdition,BookNoofCopies
		from book

END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetFinePayNo]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[sp_GetFinePayNo]
	-- Add the parameters for the stored procedure here
	


--	exec [sp_GetFinePayNo]2
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select isnull(max(FRefNo),0) + 1 as FRefNo
		from FinePay

END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetImposeFineNo]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetImposeFineNo]
	-- Add the parameters for the stored procedure here
	


--	exec [sp_GetUserBorrowRetNo]2
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select isnull(max([IFRefNo]),0) + 1 as ImposeRefNo
		from ImposeFine

END
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetLateReturnList]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_GetLateReturnList]
	-- Add the parameters for the stored procedure here
	
		@UEmail varchar(50)

--	exec [Sp_GetLateReturnList]'azamwahid@outlook.com'
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select BBID,BBRefNo,BBRefDate,BBDays,BRID,BRRefNo,BRRefDate,BookTitle,BookAuthor,BookISBN,BookYear,BookEdition,
			   DATEDIFF(DAY, DATEADD(DAY, BBDays, BBRefDate), BRRefDate) as late_Days
		from BorrowReturn
		inner join BorrowBook on BRBID = BBID
		inner join book on BBBookID = BookID
		inner join Users on BBUID = [UID]
		where  UEmail = @UEmail and BRFineYN='Y' and BRID not in (select IFBRID from ImposeFine)
		


END
GO
/****** Object:  StoredProcedure [dbo].[sp_getUserBorrowList]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getUserBorrowList]
	-- Add the parameters for the stored procedure here
	
		@UID bigint

--	exec[sp_getUserBorrowList]2
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select BBID,BBRefNo,BBRefDate,BookTitle,BookAuthor,BookISBN,BookYear,BookEdition,
		BBDays, DATEDIFF(DAY, GETDATE(), DATEADD(DAY, BBDays, BBRefDate)) AS DaysLeft
		from BorrowBook
		inner join book on BBBookID = BookID
		where BBUID = @UID and BBID not in (select BRBID from BorrowReturn)
		order by DaysLeft 

END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserBorrowNo]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetUserBorrowNo]
	-- Add the parameters for the stored procedure here
	
		@UID bigint

--	exec [sp_GetUserBorrowNo]2
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select isnull(max(BBRefNo),0) + 1 as BorrowNo
		from BorrowBook
		where BBUID = @UID

END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserBorrowRetNo]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetUserBorrowRetNo]
	-- Add the parameters for the stored procedure here
	
		@UID bigint

--	exec [sp_GetUserBorrowRetNo]2
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select isnull(max(BRRefNo),0) + 1 as BorrowRetNo
		from BorrowReturn
		inner join BorrowBook on BRBID = BBID
		where BBUID = @UID

END
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetUserImposeFine]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_GetUserImposeFine]
	-- Add the parameters for the stored procedure here
	
		@UID Bigint

--	exec[Sp_GetUserImposeFine]'azamwahid@outlook.com'
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select IFID,IFRefNo,IFRefDate,BBID,BBRefNo,BBRefDate,BBDays,BRID,BRRefNo,BRRefDate,BookTitle,BookAuthor,BookISBN,BookYear,BookEdition,
			   DATEDIFF(DAY, DATEADD(DAY, BBDays, BBRefDate), BRRefDate) as late_Days,IFAmnt
		from ImposeFine
		inner join BorrowReturn on IFBRID = BRID
		inner join BorrowBook on BRBID = BBID
		inner join book on BBBookID = BookID
		inner join Users on BBUID = [UID]
		where  [UID] = @UID and IFID not in (select FIFID from FinePay)
		


END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUsers]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetUsers]
	-- Add the parameters for the stored procedure here
	


-- exec[sp_GetUsers]'azamwahid@yahoo.com',03322762032

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select [UID],UName,UFName,UEmail,UMobileNo,UPass,
	       case when UType = 'S' then 'Student' else case when UType = 'F' then 'Faculty' else 'Admin' end end as UType,
		   UAllowBorrow,UBookRights,UBlock
	from Users
	--where UType<>'A'
	order by UType
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUsersByEmail]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetUsersByEmail]
	-- Add the parameters for the stored procedure here
	
	@UEmail varchar(50)

-- exec[sp_GetUsers]'azamwahid@yahoo.com',03322762032

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select [UID],UName,UFName,UEmail,UMobileNo,UPass,
	       case when UType = 'S' then 'Student' else case when UType = 'F' then 'Faculty' else 'Admin' end end as UType,
		   UAllowBorrow,UBookRights,UBlock
	from Users
	where UEmail = @UEmail
	order by UType
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_NeglectImposeFine]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_NeglectImposeFine]
	-- Add the parameters for the stored procedure here
	
	

	@BorrowRetID bigint


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	 update BorrowReturn set BRFineYN = 'N' where BRID = @BorrowRetID
		

				 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Rpt_BorrowBook]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Rpt_BorrowBook]
	-- Add the parameters for the stored procedure here
	
		@UEmail varchar(50)

--	exec[sp_Rpt_BorrowBook]'All'
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select UEmail,UName,UMobileNo,BBRefNo,BBRefDate,BookTitle,BookAuthor,BookISBN,BookYear,BookEdition,
		       BBDays, DATEDIFF(DAY, GETDATE(), DATEADD(DAY, BBDays, BBRefDate)) AS DaysLeft
		from BorrowBook
		inner join book on BBBookID = BookID
		inner join users on BBUID = [UID]
		where UEmail = case when @UEmail = 'all' then UEmail else  @UEmail end
		      and BBID not in (select BRBID from BorrowReturn)
		order by DaysLeft 

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Rpt_ImposeFineDetail]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Rpt_ImposeFineDetail]
	-- Add the parameters for the stored procedure here

		@UEmail varchar(50)

--	exec[sp_Rpt_ImposeFineDetail]'azamwahid@outlook.com'
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select UEmail,(UName) as UName,(UMobileNo) as UMobileNo,IFRefDate,BBRefDate,BBDays,
			   BRREfDate, DATEDIFF(DAY, DATEADD(DAY, BBDays, BBRefDate), BRRefDate) as late_Days,
			   BookTitle,BookAuthor,BookISBN,BookYear,BookEdition,
			   (IFAmnt) as IFAmnt
		from ImposeFine
		inner join BorrowReturn on IFBRID = BRID
		inner join BorrowBook on BRBID = BBID
		inner join book on BBBookID = BookID
		inner join Users on BBUID = [UID]
		where UEmail = case when @UEmail = 'all' then UEmail else  @UEmail end
		and IFID not in (select FIFID from FinePay)
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Rpt_ImposeFineMember]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Rpt_ImposeFineMember]
	-- Add the parameters for the stored procedure here

--	exec[sp_Rpt_ImposeFineMember]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select UEmail,max(UName) as UName,max(UMobileNo) as UMobileNo,Sum(IFAmnt) as IFAmnt
		from ImposeFine
		inner join BorrowReturn on IFBRID = BRID
		inner join BorrowBook on BRBID = BBID
		inner join Users on BBUID = [UID]
		where IFID not in (select FIFID from FinePay)
		group by UEmail

END
GO
/****** Object:  StoredProcedure [dbo].[Sp_Rpt_LateReturn]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_Rpt_LateReturn]
	-- Add the parameters for the stored procedure here
	
	--	@UEmail varchar(50)

--	exec [Sp_Rpt_LateReturn]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select BBRefDate,BBDays,BRRefDate,BookTitle,BookAuthor,BookISBN,BookEdition,BookYear,
			   DATEDIFF(DAY, DATEADD(DAY, BBDays, BBRefDate), BRRefDate) as late_Days,
			    case when BRID in (select IFBRID from ImposeFine) then 'Imposed' else 'Pending' end as fineImpose,BRFineYN,
			   UEmail,UName,UMobileNo
		from BorrowReturn
		inner join BorrowBook on BRBID = BBID
		inner join book on BBBookID = BookID
		inner join Users on BBUID = [UID]
		left outer join ImposeFine on IFBRID = BRID
		where ISNULL(IFID,0) not in (select FIFID from FinePay)
		and BRFineYN='Y'
END
GO
/****** Object:  StoredProcedure [dbo].[sp_RptBookDetails]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_RptBookDetails]
	-- Add the parameters for the stored procedure here
--	exec[sp_RptBookDetails]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		IF OBJECT_ID('tempdb..#Rpt_Book') IS NOT NULL
			BEGIN
			DROP TABLE #Rpt_Book
		END

		select BookID,BookCode,BookTitle,BookAuthor,BookISBN,BookYear,BookEdition,BookNoofCopies,0 as borrow, BookNoofCopies as remainingCopies
		into #Rpt_Book
		from book
		union all 
		select BookID,BookCode,BookTitle,BookAuthor,BookISBN,BookYear,BookEdition,BookNoofCopies,1,-1
		from BorrowBook
		inner join book on BBBookID = BookID
		union all 
		select BookID,BookCode,BookTitle,BookAuthor,BookISBN,BookYear,BookEdition,BookNoofCopies,-1,1
		from BorrowReturn
		inner join BorrowBook on BRBID = BBID
		inner join book on BBBookID = BookID

		select BookID,BookCode,max(BookTitle) as BookTitle,max(BookAuthor) as BookAuthor,
			   max(BookISBN) as BookISBN,max(BookYear) as BookYear,max(BookEdition) as BookEdition,
			   max(BookNoofCopies) as BookNoofCopies,sum(borrow) as borrow, sum(remainingCopies) as remainingCopies
	--	into #rpt
		from #Rpt_Book
		group by BookID,BookCode
		
		--select * from #rpt
		--union all
		--select 0,'','TOTAL BOOKS','',
		--	   '','','',
		--	   0,0, count(BookCode)
		--from #rpt
		--union all
		--select 0,'','TOTAL COPIES','',
		--	   '','','',
		--	   0,0, sum(remainingCopies)
		--from #rpt
		

	
		






END
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveBook]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_SaveBook]
	-- Add the parameters for the stored procedure here
	
	@EntryMode varchar(255),
	@BookCode varchar(50),
	@BookTitle varchar(50),
	@BookAuthor varchar(50),
	@BookIsbn varchar(50),
	@BookYear bigint,
	@BookEdition bigint,
	@BookNoOfCopies bigint


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    if @EntryMode = 'Add'
	Insert into book (BookCode, BookTitle, BookAuthor, BookIsbn, BookYear,BookEdition,BookNoOfCopies)
				 values (@BookCode, @BookTitle, @BookAuthor, @BookIsbn, @BookYear,@BookEdition,@BookNoOfCopies)
	else
	Update book set BookCode=@BookCode, BookTitle=@BookTitle, BookAuthor=@BookAuthor, BookIsbn=@BookIsbn,
				    BookYear=@BookYear,BookEdition=@BookEdition,BookNoOfCopies=@BookNoOfCopies
	WHERE BookCode=@BookCode
				 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveBorrow]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_SaveBorrow]
	-- Add the parameters for the stored procedure here
	
	
	@BorrowNo bigint,
	@BorrowDate datetime,
	@BorrowUID bigint,
	@BorrowBookID bigint,
	@BorrowDays bigint


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	Insert into BorrowBook (BBRefNo, BBRefDate, BBUID, BBBookID, BBDays)
				 values (@BorrowNo, @BorrowDate, @BorrowUID, @BorrowBookID, @BorrowDays)

				 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveBorrowRet]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_SaveBorrowRet]
	-- Add the parameters for the stored procedure here
	
	
	@BorrowRetNo bigint,
	@BorrowRetDate datetime,
	@BorrowID bigint,
	@BRFineYN char(1)


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	Insert into BorrowReturn (BRRefNo, BRRefDate, BRBID, BRFineYN)
				 values (@BorrowRetNo, @BorrowRetDate, @BorrowID, @BRFineYN)

				 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveFinePay]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[sp_SaveFinePay]
	-- Add the parameters for the stored procedure here
	
	
	@FRefNo bigint,
	@FRefDate datetime,
	@FIFID bigint,
	@FAmnt decimal(16,2)


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	Insert into FinePay(FRefNo, FRefDate, FIFID, FAmnt)
		values (@FRefNo, @FRefDate, @FIFID, @FAmnt)

				 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveImposeFine]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_SaveImposeFine]
	-- Add the parameters for the stored procedure here
	
	
	@IFRefNo bigint,
	@IFRefDate datetime,
	@BorrowRetID bigint,
	@FineAmnt decimal(16,2)


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	Insert into ImposeFine (IFRefNo, IFRefDate, IFBRID, IFAmnt)
		values (@IFRefNo, @IFRefDate, @BorrowRetID, @FineAmnt)

				 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdatePassword]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[sp_UpdatePassword]
	-- Add the parameters for the stored procedure here
	
	@UEmail varchar(50),
	@UCurrPass varchar(50),
	@UNewPass varchar(50)

-- exec[sp_CheckUserExists]'azamwahid@yahoo.com',03322762032

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update users set UPass = @UNewPass
	where UEmail = @UEmail and UPass = @UCurrPass
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateRegUser]    Script Date: 29/11/2023 12:50:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateRegUser]
	-- Add the parameters for the stored procedure here
	
	@UID bigint,
	@UName varchar(15),
	@UFName varchar(15),
	@UEmail varchar(50),
	@UMobileNo varchar(50),
	@UPass varchar(50),
	@UType char(1),
	@UAllowBorrow char(1) = 'Y',
	@UBookRights char(1) = 'N',
	@UBlock char(1) = 'N'


-- exec[sp_CheckUserExists]'azamwahid@yahoo.com',03322762032

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update users set UName=@UName,UFName=@UFName,UMobileNo=@UMobileNo,UPass=@UPass,UType=@UType,
				     UAllowBorrow = @UAllowBorrow, UBookRights = @UBookRights,UBlock=@UBlock
	where [UID] = @UID
	
END
GO
USE [master]
GO
ALTER DATABASE [LIS] SET  READ_WRITE 
GO

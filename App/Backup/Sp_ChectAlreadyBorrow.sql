USE [LIS]
GO
/****** Object:  StoredProcedure [dbo].[Sp_ChectAlreadyBorrow]    Script Date: 22/10/2023 1:30:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Sp_ChectAlreadyBorrow]
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

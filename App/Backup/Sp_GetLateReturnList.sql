USE [LIS]
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetLateReturnList]    Script Date: 22/10/2023 1:30:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Sp_GetLateReturnList]
	-- Add the parameters for the stored procedure here
	
		@UID bigint

--	exec [Sp_GetLateReturnList]2
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		select BRID,BBRefNo,BBRefDate,BBDays,BRRefNo,BRRefDate,BookTitle,
			   DATEDIFF(DAY, DATEADD(DAY, BBDays, BBRefDate), BRRefDate) as late_Days
		from BorrowReturn
		inner join BorrowBook on BRBID = BBID
		inner join book on BBBookID = BookID
		where  BBUID = @UID and BRFineYN='Y'
		


END

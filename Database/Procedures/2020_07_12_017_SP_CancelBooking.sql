USE [Hotels_DB]
GO
/****** Object:  StoredProcedure [dbo].[CancelBooking]    Script Date: 20.12.2020 16:03:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[CancelBooking] 
@Book  int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
DELETE FROM [dbo].[Booking] WHERE book_id = @Book
END

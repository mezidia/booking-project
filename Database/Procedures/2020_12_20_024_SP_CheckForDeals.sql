USE [Hotels_DB]
GO
/****** Object:  StoredProcedure [dbo].[CheckForDeals]    Script Date: 20.12.2020 19:00:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[CheckForDeals]
@SaleBool bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT [hotel_id]
  FROM [dbo].[Rooms] WHERE sale_bool = @SaleBool
END

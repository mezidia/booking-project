USE [Hotels_DB]
GO
/****** Object:  StoredProcedure [dbo].[CancelBooking]    Script Date: 07.12.2020 9:36:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RateAndReview] 
@User  int,
@Hotel int,
@Rating int,
@Review nvarchar(MAX),
@Date int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
INSERT INTO [dbo].[Reviews] ([user_id],[hotel_id],[rating_int],[review_str],[createDate_date])
  SELECT @User, @Hotel, @Rating, @Review, @Date
END

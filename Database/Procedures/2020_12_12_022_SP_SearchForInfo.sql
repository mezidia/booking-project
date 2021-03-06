USE [Hotels_DB]
GO
/****** Object:  StoredProcedure [dbo].[SearchForInfo]    Script Date: 20.12.2020 20:01:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SearchForInfo] 
@CountryId int, @NumberOfStars int, @HotelType int, @Rating int, @Sale bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT [country_id]
  FROM [dbo].[Hotels] WHERE country_id = @CountryId
SELECT [number_of_stars_int]
  FROM [dbo].[Hotels] WHERE [number_of_stars_int] = @NumberOfStars
SELECT [hotelType_int]
  FROM [dbo].[Hotels] WHERE [hotelType_int] = @HotelType
SELECT [rating_int] 
  FROM [dbo].[Hotels] WHERE rating_int = @Rating
SELECT [sale_bool]
  FROM [dbo].[Rooms] WHERE sale_bool = @Sale
END

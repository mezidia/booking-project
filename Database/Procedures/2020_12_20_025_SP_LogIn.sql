USE [Hotels_DB]
GO
/****** Object:  StoredProcedure [dbo].[LogIn]    Script Date: 20.12.2020 21:23:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[LogIn] 
@Login  nvarchar(max),
@Password  nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT [login_str], [password_str], [user_id], [permission_int]

  FROM [dbo].[Users] WHERE login_str = @Login AND password_str = @Password
END

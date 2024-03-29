USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_City_Insert]    Script Date: 2/12/2013 7:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		CONGHAU 
-- Create date:	10/16/2013
-- Description:	
-- Revisions:	
-- =============================================
CREATE Procedure [dbo].[p_DL_City_Insert]
	@CountryCode varchar (3),
	@CityName nvarchar (30),
	@Avatar nvarchar (100),
	@Summary nvarchar (500),
	@AvgRating float,
	@TotalUserRating int,
	@TotalPointRating int,
	@Status int
AS
Begin
	SET NOCOUNT ON
	insert into DL_City
		( CountryCode, CityName, Avatar, Summary, AvgRating, TotalUserRating, TotalPointRating, Status)
	values
		(@CountryCode,@CityName,@Avatar,@Summary,@AvgRating,@TotalUserRating,@TotalPointRating,@Status)

	select SCOPE_IDENTITY()
End

GO

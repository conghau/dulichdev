USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_City_Update]    Script Date: 2/12/2013 7:14:07 PM ******/
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
CREATE Procedure [dbo].[p_DL_City_Update]
	@ID bigint,
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
	update DL_City
	set
		[CountryCode] = @CountryCode,
		[CityName] = @CityName,
		[Avatar] = @Avatar,
		[Summary] = @Summary,
		[AvgRating] = @AvgRating,
		[TotalUserRating] = @TotalUserRating,
		[TotalPointRating] = @TotalPointRating,
		[Status] = @Status
	where
		ID = @ID
	select @@ROWCOUNT
End

GO

USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_Place_Update]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_DL_Place_Update]
	@ID bigint,
	@DL_CityId bigint,
	@DL_PlaceTypeId bigint,
	@Name nvarchar (200),
	@Address nvarchar (500),
	@Avatar nvarchar (500),
	@AvgRating float,
	@TotalUserRating nchar (10),
	@TotalPointRating nchar (10),
	@Status int
AS
Begin
	SET NOCOUNT ON
	update DL_Place
	set
		[DL_CityId] = @DL_CityId,
		[DL_PlaceTypeId] = @DL_PlaceTypeId,
		[Name] = @Name,
		[Address] = @Address,
		[Avatar] = @Avatar,
		[AvgRating] = @AvgRating,
		[TotalUserRating] = @TotalUserRating,
		[TotalPointRating] = @TotalPointRating,
		[Status] = @Status
	where
		ID = @ID
	select @@ROWCOUNT
End

GO

USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_Place_Insert]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_DL_Place_Insert]
	@DL_CityId bigint,
	@DL_PlaceTypeId bigint,
	@Name nvarchar (200),
	@Address nvarchar (500),
	@Avatar nvarchar (500),
	@AvgRating float,
	@TotalUserRating nchar (10),
	@TotalPointRating nchar (10),
	@CreatedBy bigint,
	@Status int
AS
Begin
	SET NOCOUNT ON
	insert into DL_Place
		( DL_CityId, DL_PlaceTypeId, Name, Address, Avatar, AvgRating, TotalUserRating, TotalPointRating, CreatedDate, CreatedBy, Status)
	values
		(@DL_CityId,@DL_PlaceTypeId,@Name,@Address,@Avatar,@AvgRating,@TotalUserRating,@TotalPointRating,GETDATE(),@CreatedBy,@Status)

	select SCOPE_IDENTITY()
End

GO

USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_LikeCity_Update]    Script Date: 2/12/2013 7:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		CONGHAU 
-- Create date:	10/6/2013
-- Description:	
-- Revisions:	
-- =============================================
Create Procedure [dbo].[p_DL_LikeCity_Update]
	@ID bigint,
	@DL_CityId bigint,
	@UserId bigint,
	@Status int
AS
Begin
	SET NOCOUNT ON
	update DL_LikeCity
	set
		[DL_CityId] = @DL_CityId,
		[UserId] = @UserId,
		[Status] = @Status
	where
		ID = @ID
	select @@ROWCOUNT
End

GO

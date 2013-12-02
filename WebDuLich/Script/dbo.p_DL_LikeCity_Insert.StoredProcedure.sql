USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_LikeCity_Insert]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_DL_LikeCity_Insert]
	@DL_CityId bigint,
	@UserId bigint,
	@Status int
AS
Begin
	SET NOCOUNT ON
	insert into DL_LikeCity
		( DL_CityId, UserId, CreatedDate, Status)
	values
		(@DL_CityId,@UserId,GETDATE(),@Status)

	select SCOPE_IDENTITY()
End

GO

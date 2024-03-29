USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_CommentPlace_Update]    Script Date: 2/12/2013 7:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		CONGHAU 
-- Create date:	10/5/2013
-- Description:	
-- Revisions:	
-- =============================================
Create Procedure [dbo].[p_DL_CommentPlace_Update]
	@ID bigint,
	@DL_PlaceID bigint,
	@UserId bigint,
	@Content ntext,
	@Rating int,
	@Status int
AS
Begin
	SET NOCOUNT ON
	update DL_CommentPlace
	set
		[DL_PlaceID] = @DL_PlaceID,
		[UserId] = @UserId,
		[Content] = @Content,
		[Rating] = @Rating,
		[Status] = @Status
	where
		ID = @ID
	select @@ROWCOUNT
End

GO

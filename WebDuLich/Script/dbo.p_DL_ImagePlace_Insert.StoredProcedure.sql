USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_ImagePlace_Insert]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_DL_ImagePlace_Insert]
	@DL_PlaceID bigint,
	@LinkImage nvarchar (500),
	@Status int
AS
Begin
	SET NOCOUNT ON
	insert into DL_ImagePlace
		( DL_PlaceID, LinkImage, CreatedDate, Status)
	values
		(@DL_PlaceID,@LinkImage,GETDATE(),@Status)

	select SCOPE_IDENTITY()
End

GO

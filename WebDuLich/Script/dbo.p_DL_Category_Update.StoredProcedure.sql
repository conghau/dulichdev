USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_Category_Update]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_DL_Category_Update]
	@ID bigint,
	@ParentId bigint,
	@Category nvarchar (50),
	@Status int
AS
Begin
	SET NOCOUNT ON
	update DL_Category
	set
		[ParentId] = @ParentId,
		[Category] = @Category,
		[Status] = @Status
	where
		ID = @ID
	select @@ROWCOUNT
End

GO

USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_Place_Update_Status]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_DL_Place_Update_Status]
	@ID bigint,	
	@Status int
AS
Begin
	SET NOCOUNT ON
	update DL_Place
	set		
		[Status] = @Status
	where
		ID = @ID
	select @@ROWCOUNT
End


GO

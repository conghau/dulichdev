USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_ImagePlace_Delete]    Script Date: 12/9/2013 5:03:45 PM ******/
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
create Procedure [dbo].[p_DL_ImagePlace_Delete]
	@ID bigint
AS
Begin
	SET NOCOUNT ON
	update DL_ImagePlace
	set
		[Status] = 1
	where
		ID = @ID
	select @@ROWCOUNT
End

GO

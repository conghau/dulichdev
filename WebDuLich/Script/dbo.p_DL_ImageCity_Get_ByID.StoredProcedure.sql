USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_ImageCity_Get_ByID]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_DL_ImageCity_Get_ByID]
	@ID bigint
AS
Begin
	SET NOCOUNT ON
	select
			*
	
	from DL_ImageCity
	where
		ID = @ID
	 and isnull(status,0) = 0 
End

GO

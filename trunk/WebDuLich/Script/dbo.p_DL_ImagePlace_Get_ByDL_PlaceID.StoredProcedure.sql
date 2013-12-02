USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_ImagePlace_Get_ByDL_PlaceID]    Script Date: 2/12/2013 7:14:07 PM ******/
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
create Procedure [dbo].[p_DL_ImagePlace_Get_ByDL_PlaceID]
	@DL_PlaceID bigint
AS
Begin
	SET NOCOUNT ON
	select
			*
	
	from DL_ImagePlace
	where
		DL_PlaceID = @DL_PlaceID
	 and isnull(status,0) = 0 
End

GO

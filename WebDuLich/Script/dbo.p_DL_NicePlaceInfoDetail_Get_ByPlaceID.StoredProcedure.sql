USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_NicePlaceInfoDetail_Get_ByPlaceID]    Script Date: 7/12/2013 11:19:19 PM ******/
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
CREATE Procedure [dbo].[p_DL_NicePlaceInfoDetail_Get_ByPlaceID]
	@DL_PlaceID bigint
AS
Begin
	SET NOCOUNT ON
	select
			*
	
	from DL_NicePlaceInfoDetail
	where
		DL_PlaceID = @DL_PlaceID
	 and isnull(staus,0) = 0 
End


GO

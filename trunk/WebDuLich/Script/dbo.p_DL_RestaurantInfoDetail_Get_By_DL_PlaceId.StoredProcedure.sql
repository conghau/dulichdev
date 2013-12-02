USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_RestaurantInfoDetail_Get_By_DL_PlaceId]    Script Date: 2/12/2013 7:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		THIENSU-BS 
-- Create date:	1/11/2013
-- Description:	
-- Revisions:	
-- =============================================
create Procedure [dbo].[p_DL_RestaurantInfoDetail_Get_By_DL_PlaceId]
	@DL_PlaceId bigint
AS
Begin
	SET NOCOUNT ON
	select
			*
	
	from DL_RestaurantInfoDetail
	where
		DL_PlaceId = @DL_PlaceId
	 and isnull(status,0) = 0 
End

GO

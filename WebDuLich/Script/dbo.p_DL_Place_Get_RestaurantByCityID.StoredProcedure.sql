USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_Place_Get_RestaurantByCityID]    Script Date: 2/12/2013 7:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create Procedure [dbo].[p_DL_Place_Get_RestaurantByCityID]
	@CityID bigint
AS
Begin
	SET NOCOUNT ON
	select
			*
	from DL_Place
	where
		DL_CityId = @CityID
	 and isnull(status,0) = 0 
	 and DL_PlaceTypeId =2
End

GO

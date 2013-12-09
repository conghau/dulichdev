USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_CityInfoDetail_Get_ByID]    Script Date: 12/9/2013 5:03:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		CONGHAU 
-- Create date:	10/27/2013
-- Description:	
-- Revisions:	
-- =============================================
Create Procedure [dbo].[p_DL_CityInfoDetail_Get_ByID]
	@Id bigint
AS
Begin
	SET NOCOUNT ON
	select
			*
	
	from DL_CityInfoDetail
	where
		Id = @Id
	 and isnull(status,0) = 0 
End

GO

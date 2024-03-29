USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_CityInfoDetail_Update]    Script Date: 2/12/2013 7:14:07 PM ******/
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
CREATE Procedure [dbo].[p_DL_CityInfoDetail_Update]
	@Id bigint,
	@DL_CityId bigint,
	@History ntext,
	@Nature ntext,
	@Social ntext,
	@Administrative ntext,
	@Economy ntext,
	@Travel ntext,
	@Status int
AS
Begin
	SET NOCOUNT ON
	update DL_CityInfoDetail
	set
		[DL_CityId] = @DL_CityId,
		[History] = @History,
		[Nature] = @Nature,
		[Social] = @Social,
		[Administrative] = @Administrative,
		[Economy] = @Economy,
		[Travel] = @Travel,
		[Status] = @Status
	where
		DL_CityId = @DL_CityId
	select @@ROWCOUNT
End


GO

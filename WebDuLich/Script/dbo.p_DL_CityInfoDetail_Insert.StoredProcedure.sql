USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_CityInfoDetail_Insert]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_DL_CityInfoDetail_Insert]
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
	insert into DL_CityInfoDetail
		( DL_CityId, History, Nature, Social, Administrative, Economy, Travel, CreatedDate, Status)
	values
		(@DL_CityId,@History,@Nature,@Social,@Administrative,@Economy,@Travel,GETDATE(),@Status)

	select SCOPE_IDENTITY()
End


GO

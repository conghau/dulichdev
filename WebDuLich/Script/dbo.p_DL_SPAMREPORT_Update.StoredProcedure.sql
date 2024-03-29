USE [dulich_data_hau]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_SPAMREPORT_Update]    Script Date: 2/26/2014 8:31:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		CongHau
-- Create date:	2/24/2014
-- Description:	
-- Revisions:	
-- =============================================
Create Procedure [dbo].[p_DL_SPAMREPORT_Update]
	@ID bigint,
	@DL_PlaceID bigint,
	@UserID bigint,
	@CreateDate datetime,
	@UpdateDate datetime,
	@Status bit
AS
Begin
	SET NOCOUNT ON
	update DL_SPAMREPORT
	set
		[DL_PlaceID] = @DL_PlaceID,
		[UserID] = @UserID,
		[CreateDate] = @CreateDate,
		[UpdateDate] = @UpdateDate,
		[Status] = @Status
	where
		ID = @ID
	select @@ROWCOUNT
End


GO

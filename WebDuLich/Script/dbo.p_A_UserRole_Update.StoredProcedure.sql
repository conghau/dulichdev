USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_A_UserRole_Update]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_A_UserRole_Update]
	@ID bigint,
	@A_UserProfileID bigint,
	@A_RoleID bigint,
	@UpdatedBy bigint,
	@Status int
AS
Begin
	SET NOCOUNT ON
	update A_UserRole
	set
		[A_UserProfileID] = @A_UserProfileID,
		[A_RoleID] = @A_RoleID,
		[UpdatedBy] = @UpdatedBy,
		[UpdatedDate] = GETDATE(),
		[Status] = @Status
	where
		ID = @ID
	select @@ROWCOUNT
End

GO

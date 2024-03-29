USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_A_RolesTranslation_Update]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_A_RolesTranslation_Update]
	@ID bigint,
	@M_LanguageID bigint,
	@A_RoleID bigint,
	@RoleName nvarchar (50),
	@UpdatedBy bigint,
	@Status int
AS
Begin
	SET NOCOUNT ON
	update A_RolesTranslation
	set
		[M_LanguageID] = @M_LanguageID,
		[A_RoleID] = @A_RoleID,
		[RoleName] = @RoleName,
		[UpdatedBy] = @UpdatedBy,
		[UpdatedDate] = GETDATE(),
		[Status] = @Status
	where
		ID = @ID
	select @@ROWCOUNT
End

GO

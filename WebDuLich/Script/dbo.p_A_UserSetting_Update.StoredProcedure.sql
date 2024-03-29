USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_A_UserSetting_Update]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_A_UserSetting_Update]
	@ID bigint,
	@A_UserProfileID bigint,
	@M_LanguageID bigint,
	@DateFormat nvarchar (20),
	@TimeFormat nvarchar (20),
	@UpdatedBy bigint,
	@Status int
AS
Begin
	SET NOCOUNT ON
	update A_UserSetting
	set
		[A_UserProfileID] = @A_UserProfileID,
		[M_LanguageID] = @M_LanguageID,
		[DateFormat] = @DateFormat,
		[TimeFormat] = @TimeFormat,
		[UpdatedBy] = @UpdatedBy,
		[UpdatedDate] = GETDATE(),
		[Status] = @Status
	where
		ID = @ID
	select @@ROWCOUNT
End

GO

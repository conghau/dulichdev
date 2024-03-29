USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_A_UserSetting_Insert]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_A_UserSetting_Insert]
	@A_UserProfileID bigint,
	@M_LanguageID bigint,
	@DateFormat nvarchar (20),
	@TimeFormat nvarchar (20),
	@CreatedBy bigint,
	@UpdatedBy bigint,
	@Status int
AS
Begin
	SET NOCOUNT ON
	insert into A_UserSetting
		( A_UserProfileID, M_LanguageID, DateFormat, TimeFormat, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate, Status)
	values
		(@A_UserProfileID,@M_LanguageID,@DateFormat,@TimeFormat,@CreatedBy,GETDATE(),@UpdatedBy,GETDATE(),@Status)

	select SCOPE_IDENTITY()
End

GO

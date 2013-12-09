USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_UserProfile_Insert]    Script Date: 12/9/2013 5:03:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		CONGHAU 
-- Create date:	11/16/2013
-- Description:	
-- Revisions:	
-- =============================================
Create Procedure [dbo].[p_UserProfile_Insert]
	@UserName nvarchar (56)
AS
Begin
	SET NOCOUNT ON
	insert into UserProfile
		( UserName)
	values
		(@UserName)

	select SCOPE_IDENTITY()
End

GO

USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_webpages_Roles_Insert]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_webpages_Roles_Insert]
	@RoleName nvarchar (256)
AS
Begin
	SET NOCOUNT ON
	insert into webpages_Roles
		( RoleName)
	values
		(@RoleName)

	select SCOPE_IDENTITY()
End


GO

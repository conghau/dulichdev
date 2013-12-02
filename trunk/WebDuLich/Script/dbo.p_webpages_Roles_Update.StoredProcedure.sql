USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_webpages_Roles_Update]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_webpages_Roles_Update]
	@RoleId int,
	@RoleName nvarchar (256)
AS
Begin
	SET NOCOUNT ON
	update webpages_Roles
	set
		[RoleName] = @RoleName
	where
		RoleId = @RoleId
	select @@ROWCOUNT
End


GO

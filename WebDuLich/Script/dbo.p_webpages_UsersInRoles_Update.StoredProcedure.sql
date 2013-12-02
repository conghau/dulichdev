USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_webpages_UsersInRoles_Update]    Script Date: 2/12/2013 7:14:07 PM ******/
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
CREATE Procedure [dbo].[p_webpages_UsersInRoles_Update]
	@RoleId int,
	@UserId int
AS
Begin
	SET NOCOUNT ON
	update webpages_UsersInRoles
	set
		[RoleId] = @RoleId
	where
		webpages_UsersInRoles.UserId = @UserId
	select @@ROWCOUNT
End


GO

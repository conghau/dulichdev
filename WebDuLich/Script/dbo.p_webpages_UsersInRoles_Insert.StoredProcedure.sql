USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_webpages_UsersInRoles_Insert]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_webpages_UsersInRoles_Insert]
	@UserId int,
	@RoleId int
AS
Begin
	SET NOCOUNT ON
	insert into webpages_UsersInRoles
		( UserId, RoleId)
	values
		(@UserId,@RoleId)
End


GO

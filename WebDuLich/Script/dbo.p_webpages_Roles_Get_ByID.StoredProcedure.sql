USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_webpages_Roles_Get_ByID]    Script Date: 2/12/2013 7:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		CONGHAU 
-- Create date:	10/6/2013
-- Description:	
-- Revisions:	
-- =============================================
CREATE Procedure [dbo].[p_webpages_Roles_Get_ByID]
	@RoleId int
AS
Begin
	SET NOCOUNT ON
	select
			*
	
	from webpages_Roles
	where RoleId = @RoleId
End



GO

USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_webpages_Roles_CountNumberUser]    Script Date: 2/12/2013 7:14:07 PM ******/
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
ALTER procedure [dbo].[p_webpages_UsersInRoles_CountNumberUser]
as
begin
select webpages_Roles.RoleId, webpages_Roles.RoleName,count(UserId) as NumberUser
from webpages_Roles  LEFT JOIN webpages_UsersInRoles ON webpages_UsersInRoles.RoleId= webpages_Roles.RoleId
group by webpages_Roles.RoleId, webpages_Roles.RoleName
end


GO

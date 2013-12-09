USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_webpages_UsersInRoles_CountNumberUser]    Script Date: 12/9/2013 5:03:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[p_webpages_UsersInRoles_CountNumberUser]
as
begin
select webpages_Roles.RoleId, webpages_Roles.RoleName,count(UserId) as NumberUser
from webpages_Roles  LEFT JOIN webpages_UsersInRoles ON webpages_UsersInRoles.RoleId= webpages_Roles.RoleId
group by webpages_Roles.RoleId, webpages_Roles.RoleName
end
GO

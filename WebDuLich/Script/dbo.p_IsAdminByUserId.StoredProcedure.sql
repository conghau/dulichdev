USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_IsAdminByUserId]    Script Date: 2/12/2013 7:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[p_IsAdminByUserId]
@UserId bigint
as
begin
declare @isAdmin int

if exists(
		select RoleName
		from webpages_Roles LEFT JOIN webpages_UsersInRoles ON webpages_Roles.RoleId = webpages_UsersInRoles.RoleId
		where webpages_UsersInRoles.UserId = @UserId and webpages_Roles.RoleName='admin'
	)
set @isAdmin = 1
else
set @isAdmin = -1

select @isAdmin
end

GO

USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_webpages_UsersInRoles_Delete]    Script Date: 2/12/2013 7:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[p_webpages_UsersInRoles_Delete]
@UserId int
as 
begin
delete webpages_UsersInRoles
where UserId= @UserId
end
GO

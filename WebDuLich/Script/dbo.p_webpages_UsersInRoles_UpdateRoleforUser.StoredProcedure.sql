USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_webpages_UsersInRoles_UpdateRoleforUser]    Script Date: 2/12/2013 7:14:07 PM ******/
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


Create procedure [dbo].[p_webpages_UsersInRoles_UpdateRoleforUser]
@UserId int,
@RoleId int
as
begin
Declare @SQL1 NVARCHAR(MAX) SET @SQL1  ='update webpages_UsersInRoles set [RoleId] ='+CONVERT(NVARCHAR(10),@RoleId)+' where webpages_UsersInRoles.UserId ='+CONVERT(NVARCHAR(10),@UserId)+''
Declare @SQL2 NVARCHAR(MAX) SET @SQL2 ='insert into webpages_UsersInRoles ( UserId, RoleId) values ('+CONVERT(NVARCHAR(10),@UserId)+','+CONVERT(NVARCHAR(10),@RoleId)+')'
--print(@SQL1)
--print(@SQL2)

if exists(
	select * from webpages_UsersInRoles where webpages_UsersInRoles.UserId= @UserId)
EXEC(@SQL1)
else
EXEC(@SQL2)
end

GO

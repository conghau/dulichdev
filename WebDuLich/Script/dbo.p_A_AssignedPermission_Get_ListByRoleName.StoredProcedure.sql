USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_A_AssignedPermission_Get_ListByRoleName]    Script Date: 12/9/2013 5:03:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		CONGHAU 
-- Create date:	10/5/2013
-- Description:	
-- Revisions:	
-- =============================================
CREATE Procedure [dbo].[p_A_AssignedPermission_Get_ListByRoleName]
@RoleName varchar(30)
AS
Begin
	SET NOCOUNT ON
	select
			A_AssignedPermission.*, A_ObjectFunction.A_ObjectID, A_ObjectFunction.A_FunctionID
	from A_AssignedPermission LEFT JOIN A_ObjectFunction on A_AssignedPermission.A_ObjectFunctionID = A_ObjectFunction.ID
	where 
	A_AssignedPermission.A_RoleID = (Select webpages_Roles.RoleId from webpages_Roles where webpages_Roles.RoleName = @RoleName) 
	and isnull(A_AssignedPermission.status,0)=0 
End

GO

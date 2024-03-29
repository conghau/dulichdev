USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_A_ObjectFunction_Get_ByRoleID]    Script Date: 12/9/2013 5:03:45 PM ******/
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
create Procedure [dbo].[p_A_ObjectFunction_Get_ByRoleID]
	@RoleId bigint
AS
Begin
	select
			*	
	from A_ObjectFunction
	where A_ObjectFunction.ID IN
	(
		select
				A_AssignedPermission.A_ObjectFunctionID	
		from A_AssignedPermission
		where 
			A_AssignedPermission.A_RoleID =@RoleId and
		isnull(status,0)=0 
	)
	 and isnull(status,0) = 0 
End

GO

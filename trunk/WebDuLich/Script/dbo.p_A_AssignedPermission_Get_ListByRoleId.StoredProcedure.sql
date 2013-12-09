USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_A_AssignedPermission_Get_ListByRoleId]    Script Date: 12/9/2013 5:03:45 PM ******/
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
create Procedure [dbo].[p_A_AssignedPermission_Get_ListByRoleId]
@RoleId bigint
AS
Begin
	SET NOCOUNT ON
	select
			*	
	from A_AssignedPermission
	where 
	A_RoleID =@RoleId and
	isnull(status,0)=0 
End

GO

USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_A_Function_Get_ByObjectIDAndRoleId]    Script Date: 12/9/2013 5:03:45 PM ******/
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
CREATE Procedure [dbo].[p_A_Function_Get_ByObjectIDAndRoleId]
	@ObjectID bigint,
	@RoleId bigint
AS
Begin
	select A_Function.*
	from
	A_Function
	LEFT JOIN A_ObjectFunction ON A_Function.ID = A_ObjectFunction.A_FunctionID
	LEFT JOIN A_AssignedPermission ON A_AssignedPermission.A_ObjectFunctionID = A_ObjectFunction.ID
	Where
			A_ObjectFunction.A_ObjectID = @ObjectID
	and A_AssignedPermission.A_RoleID = @RoleId
End

GO

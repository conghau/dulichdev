USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_A_AssignedPermission_DeleteAdv]    Script Date: 12/9/2013 5:03:45 PM ******/
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
CREATE Procedure [dbo].[p_A_AssignedPermission_DeleteAdv]
	@A_RoleID bigint,
	@FunctionId bigint,
	@ObjectId bigint
AS
Begin
declare @isExists int =0
declare @A_ObjectFunctionID bigint = (select A_ObjectFunction.ID 
		from A_ObjectFunction
		Where A_ObjectFunction.A_FunctionID = @FunctionId and A_ObjectFunction.A_ObjectID= @ObjectId)

declare @DeleteSQL nvarchar(max)='DELETE FROM A_AssignedPermission where A_AssignedPermission.A_ObjectFunctionID = '+CONVERT(NVARCHAR(20),@A_ObjectFunctionID)+' and A_AssignedPermission.A_RoleID = '+CONVERT(NVARCHAR(20),@A_RoleID)+'  select @@ROWCOUNT'

if exists
(
	select * 
	from A_AssignedPermission
	where A_AssignedPermission.A_ObjectFunctionID = @A_ObjectFunctionID
	and A_AssignedPermission.A_RoleID = @A_RoleID
	
) 
 exec(@DeleteSQL)
else
	select @isExists
end
GO

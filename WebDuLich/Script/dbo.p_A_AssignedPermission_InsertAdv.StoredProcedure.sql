USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_A_AssignedPermission_InsertAdv]    Script Date: 12/9/2013 5:03:45 PM ******/
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
CREATE Procedure [dbo].[p_A_AssignedPermission_InsertAdv] 
	@A_RoleID bigint,
	@CreatedBy bigint,
	@UpdatedBy bigint,
	@Status int,
	@FunctionId bigint,
	@ObjectId bigint
AS
Begin
declare @isExists int =0
declare @A_ObjectFunctionID bigint = (select A_ObjectFunction.ID 
		from A_ObjectFunction
		Where A_ObjectFunction.A_FunctionID = @FunctionId and A_ObjectFunction.A_ObjectID= @ObjectId)

declare @InsertSQL nvarchar(max)='insert into A_AssignedPermission
		( A_ObjectFunctionID, A_RoleID, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate, Status)
	values
		('+CONVERT(NVARCHAR(10),@A_ObjectFunctionID)+','+CONVERT(NVARCHAR(10),@A_RoleID)+','+CONVERT(NVARCHAR(10),@CreatedBy)+',GETDATE(),'+CONVERT(NVARCHAR(10),@UpdatedBy)+',GETDATE(),'+CONVERT(NVARCHAR(10),@Status)+') select SCOPE_IDENTITY()'

if not exists
(
	select * 
	from A_AssignedPermission
	where A_AssignedPermission.A_ObjectFunctionID = @A_ObjectFunctionID

	and A_AssignedPermission.A_RoleID = @A_RoleID
	
) 
 exec(@InsertSQL)
else
	select @isExists
end
GO

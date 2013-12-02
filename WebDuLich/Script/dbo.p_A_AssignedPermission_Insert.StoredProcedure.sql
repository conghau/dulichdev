USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_A_AssignedPermission_Insert]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_A_AssignedPermission_Insert]
	@A_ObjectFunctionID bigint,
	@A_RoleID bigint,
	@CreatedBy bigint,
	@UpdatedBy bigint,
	@Status int
AS
Begin
	SET NOCOUNT ON
	insert into A_AssignedPermission
		( A_ObjectFunctionID, A_RoleID, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate, Status)
	values
		(@A_ObjectFunctionID,@A_RoleID,@CreatedBy,GETDATE(),@UpdatedBy,GETDATE(),@Status)

	select SCOPE_IDENTITY()
End

GO

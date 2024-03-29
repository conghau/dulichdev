USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_A_AssignedPermission_HasPermission]    Script Date: 12/9/2013 5:03:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[p_A_AssignedPermission_HasPermission] --'AddNicePlace','Assign','ADMIN'
	@objectName varchar(30),
	@functionName varchar(30),
	@roleName varchar(30)
as
Begin
	declare @objectId int
	declare @functionId int
	declare @objectFunctionId int
	declare @result int

	--get object by name
	select @objectId = ID
	from A_Object
	where
		ObjectName = @objectName
	
	--print @objectID

	--get function by name
	select @functionId = ID
	from A_Function
	where
		FunctionName = @functionName

	--print @functionID

	select @objectFunctionId = ID 
	from A_ObjectFunction
	where
		A_ObjectID = @objectId and
		A_FunctionID = @functionId

	--print @objectFunctionId

	if exists
		(
			select webpages_Roles.RoleName
			from A_AssignedPermission  LEFT JOIN webpages_Roles on A_AssignedPermission.A_RoleID = webpages_Roles.RoleId
			where
				A_ObjectFunctionID = @objectFunctionId and
				webpages_Roles.RoleName = @roleName and
				Status <> 1
		)
		set @result = 0;
	else
		set @result = -1;

	select @result;
End


GO

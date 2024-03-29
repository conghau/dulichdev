USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_A_Object_Update]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_A_Object_Update]
	@ID bigint,
	@ParentID bigint,
	@ObjectName varchar (15),
	@Order int,
	@ObjectType nvarchar (50),
	@Url varchar (15),
	@UpdatedBy bigint,
	@Status int
AS
Begin
	SET NOCOUNT ON
	update A_Object
	set
		[ParentID] = @ParentID,
		[ObjectName] = @ObjectName,
		[Order] = @Order,
		[ObjectType] = @ObjectType,
		[Url] = @Url,
		[UpdatedBy] = @UpdatedBy,
		[UpdatedDate] = GETDATE(),
		[Status] = @Status
	where
		ID = @ID
	select @@ROWCOUNT
End

GO

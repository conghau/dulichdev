USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_A_Object_Get_ByParentID]    Script Date: 12/9/2013 5:03:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		
-- Create date:	7/10/2013
-- Description:	
-- Revisions:	
-- =============================================
create Procedure [dbo].[p_A_Object_Get_ByParentID]
	@ParentID bigint
AS
Begin
	SET NOCOUNT ON
	select
			*
	
	from A_Object
	where
		ParentID = @ParentID
	 and isnull(status,0) = 0 
End

GO

USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_A_Object_Get_ListParent]    Script Date: 12/9/2013 5:03:45 PM ******/
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
CREATE Procedure [dbo].[p_A_Object_Get_ListParent]

AS
Begin
	SET NOCOUNT ON
	select
			*
	
	from A_Object
	where 
	A_Object.ParentID is null OR A_Object.ParentID=0 and
	isnull(status,0)=0 
End

GO

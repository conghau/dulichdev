USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_A_UserProfile_Get_List]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_A_UserProfile_Get_List]

AS
Begin
	SET NOCOUNT ON
	select
			*
	
	from A_UserProfile
	where 
	isnull(status,0)=0 
End

GO

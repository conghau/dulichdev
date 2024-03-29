USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_A_Function_Get_ByObjectID]    Script Date: 12/9/2013 5:03:45 PM ******/
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
Create Procedure [dbo].[p_A_Function_Get_ByObjectID]
	@ObjectID bigint
AS
Begin
	select *
	from
	A_Function
	Where
	 A_Function.ID IN
		(select
				A_ObjectFunction.A_FunctionID	
		from A_ObjectFunction
		where
			A_ObjectFunction.A_ObjectID = @ObjectID
			and isnull(status,0) = 0 
			)
End

GO

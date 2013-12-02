USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_A_ObjectFunction_Delete]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_A_ObjectFunction_Delete]
	@ID bigint,
	@UpdatedBy bigint

AS
Begin
	SET NOCOUNT ON
	update A_ObjectFunction
	set

	Status=1,

	UpdatedBy=@UpdatedBy,

	UpdatedDate=GETDATE()

	where
		ID = @ID
	select @@ROWCOUNT
End

GO

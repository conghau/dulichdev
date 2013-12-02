USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_M_SystemSetting_Update]    Script Date: 2/12/2013 7:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		CONGHAU 
-- Create date:	10/6/2013
-- Description:	
-- Revisions:	
-- =============================================
Create Procedure [dbo].[p_M_SystemSetting_Update]
	@ID bigint,
	@Attribute nvarchar (50),
	@Value text,
	@Status int
AS
Begin
	SET NOCOUNT ON
	update M_SystemSetting
	set
		[Attribute] = @Attribute,
		[Value] = @Value,
		[Status] = @Status
	where
		ID = @ID
	select @@ROWCOUNT
End

GO

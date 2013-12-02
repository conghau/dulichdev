USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_M_SystemSetting_Insert]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_M_SystemSetting_Insert]
	@Attribute nvarchar (50),
	@Value text,
	@Status int
AS
Begin
	SET NOCOUNT ON
	insert into M_SystemSetting
		( Attribute, Value, Status)
	values
		(@Attribute,@Value,@Status)

	select SCOPE_IDENTITY()
End

GO

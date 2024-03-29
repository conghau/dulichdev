USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_Place_Update_SomeValue]    Script Date: 12/6/2013 9:35:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		CONGHAU 
-- Create date:	10/16/2013
-- Description:	
-- Revisions:	
-- =============================================
create Procedure [dbo].[p_DL_Place_Update_SomeValue]
	@ID bigint,
	@DL_CityId bigint,
	@Name nvarchar (200),
	@Address nvarchar (500),
	@Avatar nvarchar (500)
AS
Begin
	SET NOCOUNT ON
	update DL_Place
	set
		[DL_CityId] = @DL_CityId,
		[Name] = @Name,
		[Address] = @Address,
		[Avatar] = @Avatar
	where
		ID = @ID
	select @@ROWCOUNT
End

GO

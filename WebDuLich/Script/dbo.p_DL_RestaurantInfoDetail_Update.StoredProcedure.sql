USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_RestaurantInfoDetail_Update]    Script Date: 2/12/2013 7:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		THIENSU-BS 
-- Create date:	8/11/2013
-- Description:	
-- Revisions:	
-- =============================================
Create Procedure [dbo].[p_DL_RestaurantInfoDetail_Update]
	@ID bigint,
	@DL_PlaceId bigint,
	@Info nvarchar (400),
	@Menu nvarchar (500),
	@Note nvarchar (300),
	@MobiPhone nvarchar (12),
	@HomePhone nvarchar (12),
	@Fax nvarchar (12),
	@Email nvarchar (50),
	@Website nvarchar (50),
	@Status int
AS
Begin
	SET NOCOUNT ON
	update DL_RestaurantInfoDetail
	set
		[DL_PlaceId] = @DL_PlaceId,
		[Info] = @Info,
		[Menu] = @Menu,
		[Note] = @Note,
		[MobiPhone] = @MobiPhone,
		[HomePhone] = @HomePhone,
		[Fax] = @Fax,
		[Email] = @Email,
		[Website] = @Website,
		[Status] = @Status
	where
		ID = @ID
	select @@ROWCOUNT
End

GO

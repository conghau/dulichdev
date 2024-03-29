USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_RestaurantInfoDetail_Insert]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_DL_RestaurantInfoDetail_Insert]
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
	insert into DL_RestaurantInfoDetail
		( DL_PlaceId, Info, Menu, Note, MobiPhone, HomePhone, Fax, Email, Website, CreatedDate, Status)
	values
		(@DL_PlaceId,@Info,@Menu,@Note,@MobiPhone,@HomePhone,@Fax,@Email,@Website,GETDATE(),@Status)

	select SCOPE_IDENTITY()
End

GO

USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_HotelPlaceInfoDetail_Insert]    Script Date: 2/12/2013 7:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		THIENSU-BS 
-- Create date:	1/11/2013
-- Description:	
-- Revisions:	
-- =============================================
Create Procedure [dbo].[p_DL_HotelPlaceInfoDetail_Insert]
	@DL_PlaceId bigint,
	@Info nvarchar (400),
	@Service nvarchar (300),
	@RoomType nvarchar (50),
	@OpenCloseTime nvarchar (50),
	@Price nchar (30),
	@PayType nvarchar (100),
	@Note nvarchar (300),
	@MobiPhone nvarchar (12),
	@HomePhone nvarchar (12),
	@Fax nvarchar (12),
	@Email nvarchar (50),
	@Status int
AS
Begin
	SET NOCOUNT ON
	insert into DL_HotelPlaceInfoDetail
		( DL_PlaceId, Info, Service, RoomType, OpenCloseTime, Price, PayType, Note, MobiPhone, HomePhone, Fax, Email, CreatedDate, Status)
	values
		(@DL_PlaceId,@Info,@Service,@RoomType,@OpenCloseTime,@Price,@PayType,@Note,@MobiPhone,@HomePhone,@Fax,@Email,GETDATE(),@Status)

	select SCOPE_IDENTITY()
End

GO

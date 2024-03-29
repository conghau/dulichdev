USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_NicePlaceInfoDetail_Insert]    Script Date: 2/12/2013 7:14:07 PM ******/
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
create Procedure [dbo].[p_DL_NicePlaceInfoDetail_Insert]
 @DL_PlaceId bigint,
 @Info ntext,
 @History ntext,
 @OpenCloseTime nvarchar (50),
 @Note nvarchar (300),
 @Staus int
AS
Begin
 SET NOCOUNT ON
 insert into DL_NicePlaceInfoDetail
  ( DL_PlaceId, Info, History, OpenCloseTime, Note, CreatedDate, Staus)
 values
  (@DL_PlaceId,@Info,@History,@OpenCloseTime,@Note,GETDATE(),@Staus)

 select SCOPE_IDENTITY()
End


GO

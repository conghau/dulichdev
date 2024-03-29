USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_NicePlaceInfoDetail_Update]    Script Date: 2/12/2013 7:14:07 PM ******/
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
create Procedure [dbo].[p_DL_NicePlaceInfoDetail_Update]
 @ID bigint,
 @DL_PlaceId bigint,
 @Info ntext,
 @History ntext,
 @OpenCloseTime nvarchar (50),
 @Note nvarchar (300),
 @Staus int
AS
Begin
 SET NOCOUNT ON
 update DL_NicePlaceInfoDetail
 set
  [DL_PlaceId] = @DL_PlaceId,
  [Info] = @Info,
  [History] = @History,
  [OpenCloseTime] = @OpenCloseTime,
  [Note] = @Note,
  [Staus] = @Staus
 where
  ID = @ID
 select @@ROWCOUNT
End


GO

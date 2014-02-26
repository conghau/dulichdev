USE [dulich_data_hau]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_SPAMREPORT_Insert]    Script Date: 2/26/2014 8:31:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		CongHau
-- Create date:	2/24/2014
-- Description:	
-- Revisions:	
-- =============================================
CREATE Procedure [dbo].[p_DL_SPAMREPORT_Insert]
	@DL_PlaceID bigint,
	@UserID bigint,
	@Status tinyint
AS
Begin
	SET NOCOUNT ON
	insert into DL_SPAMREPORT
		( DL_PlaceID, UserID, CreateDate, UpdateDate, Status)
	values
		(@DL_PlaceID,@UserID,GETDATE(),GETDATE(),@Status)

	select SCOPE_IDENTITY()
End


GO

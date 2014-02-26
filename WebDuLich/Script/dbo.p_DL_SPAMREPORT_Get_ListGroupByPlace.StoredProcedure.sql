USE [dulich_data_hau]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_SPAMREPORT_Get_ListGroupByPlace]    Script Date: 2/26/2014 8:31:34 PM ******/
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
Create Procedure [dbo].[p_DL_SPAMREPORT_Get_ListGroupByPlace]

AS
Begin
	SET NOCOUNT ON
	select
			DL_SPAMREPORT.DL_PlaceID
	from DL_SPAMREPORT
	where 
	isnull(status,0)=0
	group by DL_SPAMREPORT.DL_PlaceID
End


GO

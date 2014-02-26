USE [dulich_data_hau]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_SPAMREPORT_Get_ByID]    Script Date: 2/26/2014 8:31:34 PM ******/
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
Create Procedure [dbo].[p_DL_SPAMREPORT_Get_ByID]
	@ID bigint
AS
Begin
	SET NOCOUNT ON
	select
			*
	
	from DL_SPAMREPORT
	where
		ID = @ID
	 and isnull(status,0) = 0 
End


GO

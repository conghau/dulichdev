USE [dulich_data_hau]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_SPAMREPORT_Delete]    Script Date: 2/26/2014 8:31:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[p_DL_SPAMREPORT_Delete]
@ID BIGINT
WITH EXECUTE AS CALLER
AS
Begin
 SET NOCOUNT ON
 update DL_SPAMREPORT
 set
  [Status] = 1
 where
  ID = @ID
 select @@ROWCOUNT
End
GO

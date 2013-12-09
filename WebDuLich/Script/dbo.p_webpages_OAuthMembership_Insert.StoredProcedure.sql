USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_webpages_OAuthMembership_Insert]    Script Date: 12/9/2013 5:03:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		CONGHAU 
-- Create date:	11/16/2013
-- Description:	
-- Revisions:	
-- =============================================
Create Procedure [dbo].[p_webpages_OAuthMembership_Insert]
	@Provider nvarchar (30),
	@ProviderUserId nvarchar (100),
	@UserId int
AS
Begin
	SET NOCOUNT ON
	insert into webpages_OAuthMembership
		( Provider, ProviderUserId, UserId)
	values
		(@Provider,@ProviderUserId,@UserId)
End

GO

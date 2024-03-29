USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_webpages_OAuthMembership_Update]    Script Date: 12/9/2013 5:03:45 PM ******/
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
Create Procedure [dbo].[p_webpages_OAuthMembership_Update]
	@Provider nvarchar (30),
	@ProviderUserId nvarchar (100),
	@UserId int
AS
Begin
	SET NOCOUNT ON
	update webpages_OAuthMembership
	set
		[UserId] = @UserId
	where
		Provider = @Provider
		and ProviderUserId = @ProviderUserId
	select @@ROWCOUNT
End

GO

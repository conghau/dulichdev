USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_webpages_Membership_Insert]    Script Date: 12/9/2013 5:03:45 PM ******/
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
Create Procedure [dbo].[p_webpages_Membership_Insert]
	@UserId int,
	@CreateDate datetime,
	@ConfirmationToken nvarchar (128),
	@IsConfirmed bit,
	@LastPasswordFailureDate datetime,
	@PasswordFailuresSinceLastSuccess int,
	@Password nvarchar (128),
	@PasswordChangedDate datetime,
	@PasswordSalt nvarchar (128),
	@PasswordVerificationToken nvarchar (128),
	@PasswordVerificationTokenExpirationDate datetime
AS
Begin
	SET NOCOUNT ON
	insert into webpages_Membership
		( UserId, CreateDate, ConfirmationToken, IsConfirmed, LastPasswordFailureDate, PasswordFailuresSinceLastSuccess, Password, PasswordChangedDate, PasswordSalt, PasswordVerificationToken, PasswordVerificationTokenExpirationDate)
	values
		(@UserId,@CreateDate,@ConfirmationToken,@IsConfirmed,@LastPasswordFailureDate,@PasswordFailuresSinceLastSuccess,@Password,@PasswordChangedDate,@PasswordSalt,@PasswordVerificationToken,@PasswordVerificationTokenExpirationDate)
End

GO

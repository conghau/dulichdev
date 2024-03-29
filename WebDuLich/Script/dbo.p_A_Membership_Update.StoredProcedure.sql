USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_A_Membership_Update]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_A_Membership_Update]
	@ID bigint,
	@A_UserProfileID bigint,
	@Password nvarchar (128),
	@PasswordFailuresSinceLastSuccess int,
	@IsBlocked bit,
	@ComfirmationToken nvarchar (128),
	@IsConfirmed bit,
	@LastPasswordFailureDate datetime,
	@PasswordChangedDate datetime,
	@M_CompanyID bigint,
	@M_TravellerID bigint,
	@M_HotelID bigint,
	@M_ServiceCenterID bigint,
	@B_PosID bigint,
	@LastestLogin datetime,
	@QueryStatus int,
	@UpdatedBy bigint,
	@Status int
AS
Begin
	SET NOCOUNT ON
	update A_Membership
	set
		[A_UserProfileID] = @A_UserProfileID,
		[Password] = @Password,
		[PasswordFailuresSinceLastSuccess] = @PasswordFailuresSinceLastSuccess,
		[IsBlocked] = @IsBlocked,
		[ComfirmationToken] = @ComfirmationToken,
		[IsConfirmed] = @IsConfirmed,
		[LastPasswordFailureDate] = @LastPasswordFailureDate,
		[PasswordChangedDate] = @PasswordChangedDate,
		[M_CompanyID] = @M_CompanyID,
		[M_TravellerID] = @M_TravellerID,
		[M_HotelID] = @M_HotelID,
		[M_ServiceCenterID] = @M_ServiceCenterID,
		[B_PosID] = @B_PosID,
		[LastestLogin] = @LastestLogin,
		[QueryStatus] = @QueryStatus,
		[UpdatedBy] = @UpdatedBy,
		[UpdatedDate] = GETDATE(),
		[Status] = @Status
	where
		ID = @ID
	select @@ROWCOUNT
End

GO

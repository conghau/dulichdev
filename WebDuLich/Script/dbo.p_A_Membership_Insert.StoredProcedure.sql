USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_A_Membership_Insert]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_A_Membership_Insert]
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
	@CreatedBy bigint,
	@UpdatedBy bigint,
	@Status int
AS
Begin
	SET NOCOUNT ON
	insert into A_Membership
		( A_UserProfileID, Password, PasswordFailuresSinceLastSuccess, IsBlocked, ComfirmationToken, IsConfirmed, LastPasswordFailureDate, PasswordChangedDate, M_CompanyID, M_TravellerID, M_HotelID, M_ServiceCenterID, B_PosID, LastestLogin, QueryStatus, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate, Status)
	values
		(@A_UserProfileID,@Password,@PasswordFailuresSinceLastSuccess,@IsBlocked,@ComfirmationToken,@IsConfirmed,@LastPasswordFailureDate,@PasswordChangedDate,@M_CompanyID,@M_TravellerID,@M_HotelID,@M_ServiceCenterID,@B_PosID,@LastestLogin,@QueryStatus,@CreatedBy,GETDATE(),@UpdatedBy,GETDATE(),@Status)

	select SCOPE_IDENTITY()
End

GO

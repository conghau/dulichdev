USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_A_UserProfile_Update]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_A_UserProfile_Update]
	@Id bigint,
	@UserName nvarchar (50),
	@FirstName nvarchar (30),
	@LastName nvarchar (30),
	@PhoneNumber nvarchar (50),
	@Email nvarchar (120),
	@Department nvarchar (100),
	@Description nvarchar (500),
	@CompanyId bigint,
	@UpdatedBy bigint,
	@Status int
AS
Begin
	SET NOCOUNT ON
	update A_UserProfile
	set
		[UserName] = @UserName,
		[FirstName] = @FirstName,
		[LastName] = @LastName,
		[PhoneNumber] = @PhoneNumber,
		[Email] = @Email,
		[Department] = @Department,
		[Description] = @Description,
		[CompanyId] = @CompanyId,
		[UpdatedBy] = @UpdatedBy,
		[UpdatedDate] = GETDATE(),
		[Status] = @Status
	where
		Id = @Id
	select @@ROWCOUNT
End

GO

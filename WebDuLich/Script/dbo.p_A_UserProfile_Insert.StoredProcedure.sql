USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_A_UserProfile_Insert]    Script Date: 2/12/2013 7:14:07 PM ******/
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
Create Procedure [dbo].[p_A_UserProfile_Insert]
	@UserName nvarchar (50),
	@FirstName nvarchar (30),
	@LastName nvarchar (30),
	@PhoneNumber nvarchar (50),
	@Email nvarchar (120),
	@Department nvarchar (100),
	@Description nvarchar (500),
	@CompanyId bigint,
	@CreatedBy bigint,
	@UpdatedBy bigint,
	@Status int
AS
Begin
	SET NOCOUNT ON
	insert into A_UserProfile
		( UserName, FirstName, LastName, PhoneNumber, Email, Department, Description, CompanyId, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate, Status)
	values
		(@UserName,@FirstName,@LastName,@PhoneNumber,@Email,@Department,@Description,@CompanyId,@CreatedBy,GETDATE(),@UpdatedBy,GETDATE(),@Status)

	select SCOPE_IDENTITY()
End

GO

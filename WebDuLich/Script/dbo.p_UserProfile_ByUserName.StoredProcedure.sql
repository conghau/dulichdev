USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_UserProfile_ByUserName]    Script Date: 2/12/2013 7:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[p_UserProfile_ByUserName] 
@UserName nvarchar(50)
as
begin

		select *
		from UserProfile 
		where UserProfile.UserName=@UserName
end

GO

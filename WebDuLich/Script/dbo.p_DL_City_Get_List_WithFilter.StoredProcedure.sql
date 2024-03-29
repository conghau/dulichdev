USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_City_Get_List_WithFilter]    Script Date: 2/12/2013 7:14:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		TienAn 
-- Create date:	10/5/2013
-- Description:	
-- Revisions:	
-- =============================================
CREATE Procedure [dbo].[p_DL_City_Get_List_WithFilter] 
	@CountryCode nvarchar(3),
	@CityName nvarchar(30),
	--@Avatar nvarchar(100), avatar k can search :P
	
	--@avgRating float,
--Paging
	@Page BIGINT,
	@PageSize BIGINT,
	@OrderBy NVARCHAR(50),
	@OrderDirection NVARCHAR(4),
	@TotalRecords BIGINT OUTPUT
AS

Declare @filter Nvarchar(MAX)
set @filter='isnull(status,0)=0'
if @CountryCode <>''
set @filter = @filter +' AND [CountryCode] ='''+@CountryCode+''''
if @CityName <>''
set @filter = @filter +' AND [CityName] LIKE ''%'+@CityName+ '%'''


print(@filter)

DECLARE @SQL NVARCHAR(MAX)
set @SQL ='
Select *
from(
	select
	ROW_NUMBER() OVER(ORDER BY '+@OrderBy+' '+@OrderDirection+' ) AS RowNum,
	*	
	from DL_City
	where '+@filter+'
	)BK 
where
	RowNum BETWEEN (('+CONVERT(NVARCHAR(20),@Page)+' - 1) * '+CONVERT(NVARCHAR(20),@PageSize)+' + 1) AND ('+CONVERT(NVARCHAR(20),@Page)+'  * '+CONVERT(NVARCHAR(20),@PageSize)+') '

EXEC(@SQL)

DECLARE @SQL2 NVarchar(MAX)
Set @SQL2 ='SET @TotalRecords =(
SELECT 
	count(id)
FROM DL_City
	where '+@filter+'
)'
EXEC sp_executesql @SQL2, N'@TotalRecords INT OUTPUT', @TotalRecords OUTPUT

	RETURN


GO

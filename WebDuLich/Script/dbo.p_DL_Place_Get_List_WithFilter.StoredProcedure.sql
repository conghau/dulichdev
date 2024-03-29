USE [dulichdev]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_Place_Get_List_WithFilter]    Script Date: 2/12/2013 7:14:07 PM ******/
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
create Procedure [dbo].[p_DL_Place_Get_List_WithFilter]
 @PlaceName nvarchar(30),
 @PlaceType bigint,
 @Address nvarchar(50),
 @cityid bigint,
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
if @PlaceName <>''
set @filter = @filter +' AND ISNULL(Name,'''') LIKE ''%'+@PlaceName+ '%'''
if @Address <>''
set @filter = @filter +' AND ISNULL(Address,'''') LIKE ''%'+@Address+ '%'''
if @PlaceType <> null or @PlaceType > 0
set @filter = @filter + 'AND DL_PlaceTypeId ='+CONVERT(NVARCHAR(10),@PlaceType)
if @cityid <> null or @cityid > 0
set @filter = @filter + 'AND DL_CityId ='+CONVERT(NVARCHAR(10),@cityid)
if @OrderBy is null set @OrderBy = 'createddate'
if @OrderDirection is null set @OrderDirection='DESC'

DECLARE @SQL NVARCHAR(MAX)
set @SQL ='
Select *
from(
 select
 ROW_NUMBER() OVER(ORDER BY '+@OrderBy+' '+@OrderDirection+' ) AS RowNum,
 * 
 from DL_Place
 where '+@filter+'
 )BK 
where
 RowNum BETWEEN (('+CONVERT(NVARCHAR(20),@Page)+' - 1) * '+CONVERT(NVARCHAR(20),@PageSize)+' + 1) AND ('+CONVERT(NVARCHAR(20),@Page)+'  * '+CONVERT(NVARCHAR(20),@PageSize)+') '

EXEC(@SQL)

DECLARE @SQL2 NVarchar(MAX)
Set @SQL2 ='SET @TotalRecords =(
SELECT 
 count(id)
FROM DL_Place
 where '+@filter+'
)'
EXEC sp_executesql @SQL2, N'@TotalRecords INT OUTPUT', @TotalRecords OUTPUT

 RETURN


GO

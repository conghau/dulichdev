USE [dulich_data_hau]
GO
/****** Object:  StoredProcedure [dbo].[p_DL_SPAMREPORT_Get_ListPlaceID]    Script Date: 2/26/2014 8:31:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		CongHau
-- Create date:	2/24/2014
-- Description:	
-- Revisions:	
-- =============================================
CREATE Procedure [dbo].[p_DL_SPAMREPORT_Get_ListPlaceID] --1,10,'','DESC',10
	@Page BIGINT,
	@PageSize BIGINT,
	@OrderBy NVARCHAR(50),
	@OrderDirection NVARCHAR(4),
	@TotalRecords BIGINT OUTPUT
AS
if @OrderBy = '' or @OrderBy is null 
set @OrderBy='NumberReport'
DECLARE @SQL NVARCHAR(MAX)
set @SQL='
	Select *
	from(
		Select ROW_NUMBER() OVER(ORDER BY '+@OrderBy+' '+@OrderDirection+' ) AS RowNum, TK.*,DL_Place.Name as PlaceName
		FROM (
				select
						DL_SPAMREPORT.DL_PlaceID, count(DL_SPAMREPORT.UserID) As NumberReport
				from DL_SPAMREPORT
				where 
					isnull(DL_SPAMREPORT.status,0)=0
				group by DL_SPAMREPORT.DL_PlaceID
			)TK LEFT JOIN DL_Place on TK.DL_PlaceID =DL_Place.ID
		)BK
	where RowNum BETWEEN (('+CONVERT(NVARCHAR(20),@Page)+' - 1) * '+CONVERT(NVARCHAR(20),@PageSize)+' + 1) AND ('+CONVERT(NVARCHAR(20),@Page)+'  * '+CONVERT(NVARCHAR(20),@PageSize)+') '
	EXEC(@SQL)
Declare @SQL2 Nvarchar(max)
set @SQL2 = 'Set @TotalRecords =(
			select  count( DISTINCT(DL_SPAMREPORT.DL_PlaceID) ) 
			from DL_SPAMREPORT 
			where 
			isnull(DL_SPAMREPORT.status,0)=0 
		 )'
EXEC sp_executesql @SQL2, N'@TotalRecords INT OUTPUT', @TotalRecords OUTPUT


GO

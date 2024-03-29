USE [dulich_data_hau]
GO
/****** Object:  Table [dbo].[DL_SPAMREPORT]    Script Date: 2/26/2014 8:31:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DL_SPAMREPORT](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[DL_PlaceID] [bigint] NOT NULL,
	[UserID] [bigint] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_DL_SPAMREPORT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [MyHumidor]
GO

/****** Object:  Table [dbo].[Whiskey]    Script Date: 5/29/2018 9:05:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Whiskey](
	[WhiskeyID] [nchar](35) NULL,
	[Brand] [nchar](64) NULL,
	[Type] [nchar](64) NULL
) ON [PRIMARY]
GO



USE [MyHumidor]
GO

/****** Object:  Table [dbo].[Cigar]    Script Date: 5/29/2018 9:03:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cigar](
	[CigarID] [int] NULL,
	[Brand] [nchar](100) NULL,
	[Series] [nchar](100) NULL,
	[Description] [nchar](250) NULL,
	[Photo] [image] NULL,
	[DatePurchased] [datetime] NULL,
	[UserID] [nchar](35) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



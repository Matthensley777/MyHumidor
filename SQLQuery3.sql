USE [MyHumidor]
GO

/****** Object:  Table [dbo].[User]    Script Date: 5/29/2018 9:05:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[UserID] [nchar](35) NULL,
	[FirstName] [nchar](100) NULL,
	[LastName] [nchar](100) NULL
) ON [PRIMARY]
GO



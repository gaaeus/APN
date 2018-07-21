USE [APN_Default]
GO

/****** Object:  Table [dbo].[Country]    Script Date: 21/07/2018 22:00:03 ******/
DROP TABLE [dbo].[Country]
GO

/****** Object:  Table [dbo].[Country]    Script Date: 21/07/2018 22:00:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](128) NOT NULL,
	[Alpha2Code] [varchar](2) NOT NULL,
	[Alpha3Code] [varchar](3) NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



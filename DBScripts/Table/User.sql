USE [APN_Default]
GO

/****** Object:  Table [dbo].[User]    Script Date: 21/07/2018 22:02:43 ******/
DROP TABLE [dbo].[User]
GO

/****** Object:  Table [dbo].[User]    Script Date: 21/07/2018 22:02:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ProfileId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[Name] [varchar](64) NOT NULL,
	[Surname] [nvarchar](128) NOT NULL,
	[Email] [varchar](256) NULL,
	[Phone] [varchar](64) NULL,
	[Cellphone] [varchar](64) NULL,
	[Address] [varchar](max) NOT NULL,
	[Address2] [varchar](max) NULL,
	[Address3] [varchar](max) NULL,
	[City] [varchar](256) NOT NULL,
	[County] [varchar](256) NULL,
	[CountryId] [int] NOT NULL,
	[PostalCode] [nvarchar](10) NOT NULL,
	[Observations] [varchar](max) NULL,
	[MapCoordinates] [varchar](max) NULL,
	[Login] [varchar](256) NULL,
	[Password] [varchar](256) NULL,
	[Active] [bit] NULL,
	[Locked] [bit] NULL,
	[Deleted] [bit] NULL,
	[LastLogin] [datetime] NULL,
	[LoginAttempts] [bit] NULL,
	[AddedBy] [int] NOT NULL,
	[AddedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedAt] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



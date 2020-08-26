USE [WebDb]
GO

/****** Object:  Table [dbo].[firms]    Script Date: 8/25/2020 11:38:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[firms](
	[FirmId] [int] IDENTITY(1,1) NOT NULL,
	[FirmName] [nvarchar](max) NULL,
 CONSTRAINT [PK_firms] PRIMARY KEY CLUSTERED 
(
	[FirmId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[questionanswers]    Script Date: 8/25/2020 11:38:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[questionanswers](
	[questionAnswerId] [int] IDENTITY(1,1) NOT NULL,
	[firmId] [int] NOT NULL,
	[userName] [nvarchar](max) NULL,
	[message] [nvarchar](max) NULL,
 CONSTRAINT [PK_questionanswers] PRIMARY KEY CLUSTERED 
(
	[questionAnswerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



USE [LojaDsco]
GO

/****** Object:  Table [dbo].[CashBack]    Script Date: 21/02/2019 11:58:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CashBack](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Genero] [varchar](10) NOT NULL,
	[DiaSemana] [int] NOT NULL,
	[Percentual] [int] NULL,
 CONSTRAINT [PK_CashBack] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO



USE [LojaDsco]
GO

/****** Object:  Table [dbo].[Venda]    Script Date: 21/02/2019 11:59:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Venda](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ValorVenda] [decimal](18, 2) NULL,
	[ValorCashBack] [decimal](18, 2) NULL,
	[KeyDisc] [varchar](200) NULL,
	[Quantidade] [int] NULL,
	[DataVenda] [datetime] NULL,
	[IdVenda] [varchar](100) NULL,
	[ValorVendaTotal] [decimal](18, 2) NULL,
	[ValorCashBackTotal] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Venda] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO



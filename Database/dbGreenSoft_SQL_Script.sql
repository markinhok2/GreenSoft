USE [dbGreenSoft]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 16/03/2017 00:16:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[Cliente_ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Cpf] [varchar](15) NOT NULL,
	[DtNascimento] [date] NOT NULL,
	[Rua] [varchar](100) NOT NULL,
	[Numero] [varchar](30) NOT NULL,
	[Bairro] [varchar](50) NOT NULL,
	[Cep] [varchar](10) NOT NULL,
	[Uf] [nchar](2) NOT NULL,
	[Pais] [nchar](2) NOT NULL,
	[DtCadastro] [datetime] NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Cliente_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cooperativa]    Script Date: 16/03/2017 00:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cooperativa](
	[Cooperativa_ID] [int] IDENTITY(1,1) NOT NULL,
	[Razao] [varchar](100) NOT NULL,
	[Cnpj] [varchar](30) NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Cooperativa] PRIMARY KEY CLUSTERED 
(
	[Cooperativa_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 16/03/2017 00:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[Pedido_ID] [int] NOT NULL,
	[Cliente_ID] [int] NOT NULL,
	[Cooperativa_ID] [int] NOT NULL,
	[Usuario_ID] [int] NOT NULL,
	[ValorTotal] [decimal](18, 2) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[Pedido_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PedidoItem]    Script Date: 16/03/2017 00:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoItem](
	[Seq_ID] [int] NOT NULL,
	[Pedido_ID] [int] NOT NULL,
	[Produto_ID] [int] NULL,
	[Qtde] [int] NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[ValorTotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_PedidoItem] PRIMARY KEY CLUSTERED 
(
	[Seq_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Produto]    Script Date: 16/03/2017 00:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Produto](
	[Produto_ID] [int] NOT NULL,
	[Descricao] [varchar](100) NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
	[Unidade] [varchar](4) NOT NULL,
	[Estoque] [int] NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
(
	[Produto_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProdutoCoperativa]    Script Date: 16/03/2017 00:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProdutoCoperativa](
	[Cooperativa_ID] [int] NOT NULL,
	[Produto_ID] [int] NOT NULL,
	[Ativo] [bit] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 16/03/2017 00:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[Usuario_ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Senha] [varchar](50) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Ativo] [bit] NOT NULL,
	[Cooperativa_ID] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Usuario_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Cliente] FOREIGN KEY([Cliente_ID])
REFERENCES [dbo].[Cliente] ([Cliente_ID])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Cliente]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Cooperativa] FOREIGN KEY([Cooperativa_ID])
REFERENCES [dbo].[Cooperativa] ([Cooperativa_ID])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Cooperativa]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Usuario] FOREIGN KEY([Usuario_ID])
REFERENCES [dbo].[Usuario] ([Usuario_ID])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Usuario]
GO
ALTER TABLE [dbo].[PedidoItem]  WITH CHECK ADD  CONSTRAINT [FK_PedidoItem_Pedido] FOREIGN KEY([Pedido_ID])
REFERENCES [dbo].[Pedido] ([Pedido_ID])
GO
ALTER TABLE [dbo].[PedidoItem] CHECK CONSTRAINT [FK_PedidoItem_Pedido]
GO
ALTER TABLE [dbo].[PedidoItem]  WITH CHECK ADD  CONSTRAINT [FK_PedidoItem_Produto] FOREIGN KEY([Produto_ID])
REFERENCES [dbo].[Produto] ([Produto_ID])
GO
ALTER TABLE [dbo].[PedidoItem] CHECK CONSTRAINT [FK_PedidoItem_Produto]
GO
ALTER TABLE [dbo].[ProdutoCoperativa]  WITH CHECK ADD  CONSTRAINT [FK_ProdutoCoperativa_Cooperativa] FOREIGN KEY([Cooperativa_ID])
REFERENCES [dbo].[Cooperativa] ([Cooperativa_ID])
GO
ALTER TABLE [dbo].[ProdutoCoperativa] CHECK CONSTRAINT [FK_ProdutoCoperativa_Cooperativa]
GO
ALTER TABLE [dbo].[ProdutoCoperativa]  WITH CHECK ADD  CONSTRAINT [FK_ProdutoCoperativa_Produto] FOREIGN KEY([Produto_ID])
REFERENCES [dbo].[Produto] ([Produto_ID])
GO
ALTER TABLE [dbo].[ProdutoCoperativa] CHECK CONSTRAINT [FK_ProdutoCoperativa_Produto]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Cooperativa] FOREIGN KEY([Cooperativa_ID])
REFERENCES [dbo].[Cooperativa] ([Cooperativa_ID])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Cooperativa]
GO

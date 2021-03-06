/****** Object:  Table [dbo].[Cliente]    Script Date: 07/04/2015 21:08:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[CI] [varchar](20) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 07/04/2015 21:08:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] NOT NULL,
	[PadreId] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 07/04/2015 21:08:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proveedor](
	[Id] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[RIF] [varchar](10) NOT NULL,
	[Direccion] [varchar](200) NOT NULL,
	[Correo] [varchar](50) NULL,
	[Responsable] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
	[FechaRegistro] [datetime] NOT NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 07/04/2015 21:08:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] NOT NULL,
	[UPC] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[UMId] [varchar](50) NOT NULL,
	[CategoriaId] [int] NOT NULL,
	[Costo] [decimal](10, 2) NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[Exento] [bit] NOT NULL,
	[Existencia] [decimal](18, 4) NOT NULL,
	[Activo] [bit] NOT NULL,
	[TipoProducto] [bit] NOT NULL,
	[EsServicio] [bit] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProveedorCliente]    Script Date: 07/04/2015 21:08:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProveedorCliente](
	[ProveedorId] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
 CONSTRAINT [PK_ProveedorCliente] PRIMARY KEY CLUSTERED 
(
	[ProveedorId] ASC,
	[ClienteId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProveedorProducto]    Script Date: 07/04/2015 21:08:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProveedorProducto](
	[ProveedorId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
 CONSTRAINT [PK_ProveedorProducto] PRIMARY KEY CLUSTERED 
(
	[ProveedorId] ASC,
	[ProductoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimiento]    Script Date: 07/04/2015 21:08:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimiento](
	[Id] [int] NOT NULL,
	[TipoMovimiento] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
 CONSTRAINT [PK_Movimiento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_Movimiento_TipoMovimiento]    Script Date: 07/04/2015 21:08:37 ******/
ALTER TABLE [dbo].[Movimiento] ADD  CONSTRAINT [DF_Movimiento_TipoMovimiento]  DEFAULT ((1)) FOR [TipoMovimiento]
GO
/****** Object:  Default [DF_Producto_FechaRegistro]    Script Date: 07/04/2015 21:08:37 ******/
ALTER TABLE [dbo].[Producto] ADD  CONSTRAINT [DF_Producto_FechaRegistro]  DEFAULT (getdate()) FOR [FechaRegistro]
GO
/****** Object:  Default [DF_Producto_Exento]    Script Date: 07/04/2015 21:08:37 ******/
ALTER TABLE [dbo].[Producto] ADD  CONSTRAINT [DF_Producto_Exento]  DEFAULT ((0)) FOR [Exento]
GO
/****** Object:  Default [DF_Producto_Existencia]    Script Date: 07/04/2015 21:08:37 ******/
ALTER TABLE [dbo].[Producto] ADD  CONSTRAINT [DF_Producto_Existencia]  DEFAULT ((0)) FOR [Existencia]
GO
/****** Object:  Default [DF_Producto_Activo]    Script Date: 07/04/2015 21:08:37 ******/
ALTER TABLE [dbo].[Producto] ADD  CONSTRAINT [DF_Producto_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  Default [DF_Producto_TipoProducto]    Script Date: 07/04/2015 21:08:37 ******/
ALTER TABLE [dbo].[Producto] ADD  CONSTRAINT [DF_Producto_TipoProducto]  DEFAULT ((1)) FOR [TipoProducto]
GO
/****** Object:  Default [DF_Producto_EsServicio]    Script Date: 07/04/2015 21:08:37 ******/
ALTER TABLE [dbo].[Producto] ADD  CONSTRAINT [DF_Producto_EsServicio]  DEFAULT ((1)) FOR [EsServicio]
GO
/****** Object:  ForeignKey [FK_Categoria_Categoria]    Script Date: 07/04/2015 21:08:37 ******/
ALTER TABLE [dbo].[Categoria]  WITH CHECK ADD  CONSTRAINT [FK_Categoria_Categoria] FOREIGN KEY([PadreId])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Categoria] CHECK CONSTRAINT [FK_Categoria_Categoria]
GO
/****** Object:  ForeignKey [FK_Movimiento_Producto]    Script Date: 07/04/2015 21:08:37 ******/
ALTER TABLE [dbo].[Movimiento]  WITH CHECK ADD  CONSTRAINT [FK_Movimiento_Producto] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([Id])
GO
ALTER TABLE [dbo].[Movimiento] CHECK CONSTRAINT [FK_Movimiento_Producto]
GO
/****** Object:  ForeignKey [FK_Producto_Categoria]    Script Date: 07/04/2015 21:08:37 ******/
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
/****** Object:  ForeignKey [FK_ProveedorCliente_Cliente]    Script Date: 07/04/2015 21:08:37 ******/
ALTER TABLE [dbo].[ProveedorCliente]  WITH CHECK ADD  CONSTRAINT [FK_ProveedorCliente_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[ProveedorCliente] CHECK CONSTRAINT [FK_ProveedorCliente_Cliente]
GO
/****** Object:  ForeignKey [FK_ProveedorCliente_Proveedor]    Script Date: 07/04/2015 21:08:37 ******/
ALTER TABLE [dbo].[ProveedorCliente]  WITH CHECK ADD  CONSTRAINT [FK_ProveedorCliente_Proveedor] FOREIGN KEY([ProveedorId])
REFERENCES [dbo].[Proveedor] ([Id])
GO
ALTER TABLE [dbo].[ProveedorCliente] CHECK CONSTRAINT [FK_ProveedorCliente_Proveedor]
GO
/****** Object:  ForeignKey [FK_ProveedorProducto_Producto]    Script Date: 07/04/2015 21:08:37 ******/
ALTER TABLE [dbo].[ProveedorProducto]  WITH CHECK ADD  CONSTRAINT [FK_ProveedorProducto_Producto] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([Id])
GO
ALTER TABLE [dbo].[ProveedorProducto] CHECK CONSTRAINT [FK_ProveedorProducto_Producto]
GO
/****** Object:  ForeignKey [FK_ProveedorProducto_Proveedor]    Script Date: 07/04/2015 21:08:37 ******/
ALTER TABLE [dbo].[ProveedorProducto]  WITH CHECK ADD  CONSTRAINT [FK_ProveedorProducto_Proveedor] FOREIGN KEY([ProveedorId])
REFERENCES [dbo].[Proveedor] ([Id])
GO
ALTER TABLE [dbo].[ProveedorProducto] CHECK CONSTRAINT [FK_ProveedorProducto_Proveedor]
GO

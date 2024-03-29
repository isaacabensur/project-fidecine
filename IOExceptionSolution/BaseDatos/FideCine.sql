CREATE DATABASE FideCine
GO
USE [FideCine]
GO
/****** Object:  Table [dbo].[GeneroPelicula]    Script Date: 10/15/2012 02:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GeneroPelicula](
	[idgenero] [int] NOT NULL,
	[nombreGenero] [varchar](50) NULL,
 CONSTRAINT [PK_GeneroPelicula] PRIMARY KEY CLUSTERED 
(
	[idgenero] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 10/15/2012 02:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[idcliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellidoPaterno] [varchar](50) NULL,
	[apellidoMaterno] [varchar](50) NULL,
	[dni] [int] NULL,
	[fechaNacimiento] [date] NULL,
	[correo] [varchar](50) NULL,
	[direccion] [varchar](50) NOT NULL,
	[tipocliente] [varchar](10) NOT NULL,
	[puntos] [int] NULL,
	[estado] [char](1) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[idcliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CategoriaPelicula]    Script Date: 10/15/2012 02:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CategoriaPelicula](
	[idcategoria] [int] NOT NULL,
	[nombreCategoria] [varchar](50) NULL,
 CONSTRAINT [PK_CategoriaPelicula] PRIMARY KEY CLUSTERED 
(
	[idcategoria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 10/15/2012 02:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sala]    Script Date: 10/15/2012 02:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sala](
	[IdSala] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](20) NOT NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_Sala] PRIMARY KEY CLUSTERED 
(
	[IdSala] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoPelicula]    Script Date: 10/15/2012 02:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoPelicula](
	[idtipo] [int] NOT NULL,
	[nombreTipo] [varchar](50) NULL,
 CONSTRAINT [PK_TipoPelicula] PRIMARY KEY CLUSTERED 
(
	[idtipo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VisitaCliente]    Script Date: 10/15/2012 02:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisitaCliente](
	[IdVisitaCliente] [int] IDENTITY(1,1) NOT NULL,
	[IdCartelera] [int] NULL,
	[idcliente] [int] NULL,
	[CantidadEntradas] [int] NULL,
 CONSTRAINT [PK_VisitaCliente] PRIMARY KEY CLUSTERED 
(
	[IdVisitaCliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TarjetaCliente]    Script Date: 10/15/2012 02:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TarjetaCliente](
	[idcliente] [int] NOT NULL,
	[tipotarjeta] [varchar](10) NULL,
	[estado] [char](1) NULL,
	[puntos] [int] NULL,
 CONSTRAINT [PK_TarjetaCliente] PRIMARY KEY CLUSTERED 
(
	[idcliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PuntajeAcumulado]    Script Date: 10/15/2012 02:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PuntajeAcumulado](
	[idcliente] [int] NOT NULL,
	[Puntos] [int] NOT NULL,
 CONSTRAINT [PK_PuntajeAcumulado] PRIMARY KEY CLUSTERED 
(
	[idcliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promocion]    Script Date: 10/15/2012 02:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promocion](
	[IdPromocion] [int] IDENTITY(1,1) NOT NULL,
	[Puntos] [int] NOT NULL,
	[vigenciaInicio] [datetime] NOT NULL,
	[vigenciaFin] [datetime] NOT NULL,
	[IdProducto] [int] NOT NULL,
 CONSTRAINT [PK_Promocion] PRIMARY KEY CLUSTERED 
(
	[IdPromocion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pelicula]    Script Date: 10/15/2012 02:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pelicula](
	[IdPelicula] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[idcategoria] [int] NULL,
	[trailer] [varchar](50) NULL,
	[descripcion] [nchar](10) NULL,
	[idtipo] [int] NULL,
	[Estado] [char](1) NULL,
	[idgenero] [int] NULL,
	[duracion] [int] NULL,
 CONSTRAINT [PK_Pelicula] PRIMARY KEY CLUSTERED 
(
	[IdPelicula] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cartelera]    Script Date: 10/15/2012 02:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cartelera](
	[IdCartelera] [int] IDENTITY(1,1) NOT NULL,
	[IdPelicula] [int] NOT NULL,
	[IdSala] [int] NOT NULL,
	[FechaHora] [datetime] NOT NULL,
 CONSTRAINT [PK_Cartelera] PRIMARY KEY CLUSTERED 
(
	[IdCartelera] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_Sala_Estado]    Script Date: 10/15/2012 02:44:06 ******/
ALTER TABLE [dbo].[Sala] ADD  CONSTRAINT [DF_Sala_Estado]  DEFAULT ('A') FOR [Estado]
GO
/****** Object:  ForeignKey [FK_Cartelera_Pelicula]    Script Date: 10/15/2012 02:44:06 ******/
ALTER TABLE [dbo].[Cartelera]  WITH CHECK ADD  CONSTRAINT [FK_Cartelera_Pelicula] FOREIGN KEY([IdPelicula])
REFERENCES [dbo].[Pelicula] ([IdPelicula])
GO
ALTER TABLE [dbo].[Cartelera] CHECK CONSTRAINT [FK_Cartelera_Pelicula]
GO
/****** Object:  ForeignKey [FK_Cartelera_Sala]    Script Date: 10/15/2012 02:44:06 ******/
ALTER TABLE [dbo].[Cartelera]  WITH CHECK ADD  CONSTRAINT [FK_Cartelera_Sala] FOREIGN KEY([IdSala])
REFERENCES [dbo].[Sala] ([IdSala])
GO
ALTER TABLE [dbo].[Cartelera] CHECK CONSTRAINT [FK_Cartelera_Sala]
GO
/****** Object:  ForeignKey [FK_Pelicula_CategoriaPelicula]    Script Date: 10/15/2012 02:44:06 ******/
ALTER TABLE [dbo].[Pelicula]  WITH CHECK ADD  CONSTRAINT [FK_Pelicula_CategoriaPelicula] FOREIGN KEY([idcategoria])
REFERENCES [dbo].[CategoriaPelicula] ([idcategoria])
GO
ALTER TABLE [dbo].[Pelicula] CHECK CONSTRAINT [FK_Pelicula_CategoriaPelicula]
GO
/****** Object:  ForeignKey [FK_Pelicula_GeneroPelicula]    Script Date: 10/15/2012 02:44:06 ******/
ALTER TABLE [dbo].[Pelicula]  WITH CHECK ADD  CONSTRAINT [FK_Pelicula_GeneroPelicula] FOREIGN KEY([idgenero])
REFERENCES [dbo].[GeneroPelicula] ([idgenero])
GO
ALTER TABLE [dbo].[Pelicula] CHECK CONSTRAINT [FK_Pelicula_GeneroPelicula]
GO
/****** Object:  ForeignKey [FK_Pelicula_TipoPelicula]    Script Date: 10/15/2012 02:44:06 ******/
ALTER TABLE [dbo].[Pelicula]  WITH CHECK ADD  CONSTRAINT [FK_Pelicula_TipoPelicula] FOREIGN KEY([idtipo])
REFERENCES [dbo].[TipoPelicula] ([idtipo])
GO
ALTER TABLE [dbo].[Pelicula] CHECK CONSTRAINT [FK_Pelicula_TipoPelicula]
GO
/****** Object:  ForeignKey [FK_Promocion_Producto]    Script Date: 10/15/2012 02:44:06 ******/
ALTER TABLE [dbo].[Promocion]  WITH CHECK ADD  CONSTRAINT [FK_Promocion_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[Promocion] CHECK CONSTRAINT [FK_Promocion_Producto]
GO
/****** Object:  ForeignKey [FK_PuntajeAcumulado_Cliente]    Script Date: 10/15/2012 02:44:06 ******/
ALTER TABLE [dbo].[PuntajeAcumulado]  WITH CHECK ADD  CONSTRAINT [FK_PuntajeAcumulado_Cliente] FOREIGN KEY([idcliente])
REFERENCES [dbo].[Cliente] ([idcliente])
GO
ALTER TABLE [dbo].[PuntajeAcumulado] CHECK CONSTRAINT [FK_PuntajeAcumulado_Cliente]
GO
/****** Object:  ForeignKey [FK_TarjetaCliente_Cliente]    Script Date: 10/15/2012 02:44:06 ******/
ALTER TABLE [dbo].[TarjetaCliente]  WITH CHECK ADD  CONSTRAINT [FK_TarjetaCliente_Cliente] FOREIGN KEY([idcliente])
REFERENCES [dbo].[Cliente] ([idcliente])
GO
ALTER TABLE [dbo].[TarjetaCliente] CHECK CONSTRAINT [FK_TarjetaCliente_Cliente]
GO
/****** Object:  ForeignKey [FK_VisitaCliente_Cliente]    Script Date: 10/15/2012 02:44:06 ******/
ALTER TABLE [dbo].[VisitaCliente]  WITH CHECK ADD  CONSTRAINT [FK_VisitaCliente_Cliente] FOREIGN KEY([idcliente])
REFERENCES [dbo].[Cliente] ([idcliente])
GO
ALTER TABLE [dbo].[VisitaCliente] CHECK CONSTRAINT [FK_VisitaCliente_Cliente]
GO

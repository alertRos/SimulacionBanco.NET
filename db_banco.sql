
USE [db_banco]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 9/15/2023 8:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[idCuenta] [int] IDENTITY(1,1) NOT NULL,
	[numCuenta] [varchar](16) NOT NULL,
	[saldo] [float] NOT NULL,
	[fk_idCliente] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 9/15/2023 8:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](60) NOT NULL,
	[apellido] [varchar](60) NOT NULL,
	[cedula] [varchar](11) NOT NULL,
	[direccion] [varchar](60) NOT NULL,
	[telefono] [varchar](15) NOT NULL,
	[fk_idUsuario] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GuaranteeType]    Script Date: 9/15/2023 8:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GuaranteeType](
	[idGarantia] [int] NOT NULL,
	[_tipoGarantia] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idGarantia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoanApplication]    Script Date: 9/15/2023 8:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanApplication](
	[idSolicitud] [int] IDENTITY(1,1) NOT NULL,
	[montoSolicitado] [int] NOT NULL,
	[fechaSolicitud] [varchar](10) NOT NULL,
	[estadoSolicitud] [varchar](20) NOT NULL,
	[fk_idCliente] [int] NOT NULL,
	[numCuenta] [varchar](16) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idSolicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loans]    Script Date: 9/15/2023 8:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loans](
	[idPrestamo] [int] IDENTITY(1,1) NOT NULL,
	[Garantia] [varchar](20) NOT NULL,
	[idSolicitud] [int] NOT NULL,
	[fk_idCliente] [int] NOT NULL,
	[fechaAprobacion] [varchar](10) NOT NULL,
	[FechaInicio] [varchar](10) NOT NULL,
	[FechaTermino] [varchar](10) NOT NULL,
	[tasaInteres] [float] NOT NULL,
	[capital] [float] NOT NULL,
	[costoPrestamo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idPrestamo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoanSchedule]    Script Date: 9/15/2023 8:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanSchedule](
	[idCronograma_pres] [int] IDENTITY(1,1) NOT NULL,
	[fk_idPrestamo] [int] NOT NULL,
	[cuotaPrestamo] [float] NOT NULL,
	[tipoPago] [varchar](40) NOT NULL,
	[abonoCapital] [float] NOT NULL,
	[fechaPlanificada] [varchar](10) NOT NULL,
	[fechaEfectiva] [varchar](10) NOT NULL,
	[fk_idComprobante] [int] NOT NULL,
	[fk_idCliente] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCronograma_pres] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 9/15/2023 8:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[idComprobante] [int] IDENTITY(1,1) NOT NULL,
	[tipoPago] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idComprobante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 9/15/2023 8:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[idTransaccion] [int] IDENTITY(1,1) NOT NULL,
	[monto] [float] NOT NULL,
	[idEmisor] [int] NOT NULL,
	[emisor] [varchar](16) NOT NULL,
	[destinatario] [varchar](16) NOT NULL,
	[fechaTransaccion] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idTransaccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 9/15/2023 8:35:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[cUsuario] [varchar](16) NOT NULL,
	[pin] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

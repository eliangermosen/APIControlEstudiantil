USE [master]
GO
/****** Object:  Database [ControlEstudiantil]    Script Date: 23/12/2022 12:22:34 a. m. ******/
CREATE DATABASE [ControlEstudiantil]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ControlEstudiantil', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ControlEstudiantil.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ControlEstudiantil_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ControlEstudiantil_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ControlEstudiantil] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ControlEstudiantil].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ControlEstudiantil] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ControlEstudiantil] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ControlEstudiantil] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ControlEstudiantil] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ControlEstudiantil] SET ARITHABORT OFF 
GO
ALTER DATABASE [ControlEstudiantil] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ControlEstudiantil] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ControlEstudiantil] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ControlEstudiantil] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ControlEstudiantil] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ControlEstudiantil] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ControlEstudiantil] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ControlEstudiantil] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ControlEstudiantil] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ControlEstudiantil] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ControlEstudiantil] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ControlEstudiantil] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ControlEstudiantil] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ControlEstudiantil] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ControlEstudiantil] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ControlEstudiantil] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ControlEstudiantil] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ControlEstudiantil] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ControlEstudiantil] SET  MULTI_USER 
GO
ALTER DATABASE [ControlEstudiantil] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ControlEstudiantil] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ControlEstudiantil] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ControlEstudiantil] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ControlEstudiantil] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ControlEstudiantil] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ControlEstudiantil] SET QUERY_STORE = OFF
GO
USE [ControlEstudiantil]
GO
/****** Object:  Table [dbo].[Asistencia]    Script Date: 23/12/2022 12:22:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asistencia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EstudianteId] [int] NULL,
	[Fecha] [date] NULL,
	[Estado] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calificacion]    Script Date: 23/12/2022 12:22:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calificacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EstudianteId] [int] NULL,
	[LenguaEspanola] [int] NULL,
	[Matematicas] [int] NULL,
	[CienciasSociales] [int] NULL,
	[CienciasNaturales] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estudiante]    Script Date: 23/12/2022 12:22:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiante](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Matricula] [varchar](10) NULL,
	[Nombre] [varchar](40) NULL,
	[Apellido] [varchar](40) NULL,
	[Cedula] [varchar](20) NULL,
	[Telefono] [varchar](20) NULL,
	[Correo] [varchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Asistencia] ON 

INSERT [dbo].[Asistencia] ([Id], [EstudianteId], [Fecha], [Estado]) VALUES (1, 1, CAST(N'2022-11-13' AS Date), N'Presente')
INSERT [dbo].[Asistencia] ([Id], [EstudianteId], [Fecha], [Estado]) VALUES (2, 2, CAST(N'2022-10-08' AS Date), N'Retirado')
INSERT [dbo].[Asistencia] ([Id], [EstudianteId], [Fecha], [Estado]) VALUES (3, 3, CAST(N'2022-11-22' AS Date), N'Ausente')
INSERT [dbo].[Asistencia] ([Id], [EstudianteId], [Fecha], [Estado]) VALUES (4, 4, CAST(N'2022-12-04' AS Date), N'Excusa')
INSERT [dbo].[Asistencia] ([Id], [EstudianteId], [Fecha], [Estado]) VALUES (5, 4, CAST(N'2022-12-20' AS Date), N'Ausente')
SET IDENTITY_INSERT [dbo].[Asistencia] OFF
GO
SET IDENTITY_INSERT [dbo].[Calificacion] ON 

INSERT [dbo].[Calificacion] ([Id], [EstudianteId], [LenguaEspanola], [Matematicas], [CienciasSociales], [CienciasNaturales]) VALUES (1, 1, 99, 93, 96, 92)
INSERT [dbo].[Calificacion] ([Id], [EstudianteId], [LenguaEspanola], [Matematicas], [CienciasSociales], [CienciasNaturales]) VALUES (2, 2, 97, 98, 99, 90)
INSERT [dbo].[Calificacion] ([Id], [EstudianteId], [LenguaEspanola], [Matematicas], [CienciasSociales], [CienciasNaturales]) VALUES (3, 3, 96, 90, 95, 91)
INSERT [dbo].[Calificacion] ([Id], [EstudianteId], [LenguaEspanola], [Matematicas], [CienciasSociales], [CienciasNaturales]) VALUES (4, 4, 90, 90, 90, 90)
INSERT [dbo].[Calificacion] ([Id], [EstudianteId], [LenguaEspanola], [Matematicas], [CienciasSociales], [CienciasNaturales]) VALUES (5, 5, 60, 80, 100, 70)
INSERT [dbo].[Calificacion] ([Id], [EstudianteId], [LenguaEspanola], [Matematicas], [CienciasSociales], [CienciasNaturales]) VALUES (6, 8, 96, 86, 92, 86)
INSERT [dbo].[Calificacion] ([Id], [EstudianteId], [LenguaEspanola], [Matematicas], [CienciasSociales], [CienciasNaturales]) VALUES (7, 6, 60, 62, 71, 71)
INSERT [dbo].[Calificacion] ([Id], [EstudianteId], [LenguaEspanola], [Matematicas], [CienciasSociales], [CienciasNaturales]) VALUES (8, 12, 92, 100, 84, 78)
INSERT [dbo].[Calificacion] ([Id], [EstudianteId], [LenguaEspanola], [Matematicas], [CienciasSociales], [CienciasNaturales]) VALUES (9, 15, 100, 89, 90, 79)
SET IDENTITY_INSERT [dbo].[Calificacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Estudiante] ON 

INSERT [dbo].[Estudiante] ([Id], [Matricula], [Nombre], [Apellido], [Cedula], [Telefono], [Correo]) VALUES (1, N'2022-0001', N'Stacy', N'Sosa', N'402-1215192-3', N'809-000-1111', N'stacy@gmail.com')
INSERT [dbo].[Estudiante] ([Id], [Matricula], [Nombre], [Apellido], [Cedula], [Telefono], [Correo]) VALUES (2, N'2022-0002', N'Manuel', N'Germosen', N'058-1234567-0', N'829-222-3333', N'manuel@gmail.com')
INSERT [dbo].[Estudiante] ([Id], [Matricula], [Nombre], [Apellido], [Cedula], [Telefono], [Correo]) VALUES (3, N'2022-0003', N'Nuris', N'Brito', N'058-7654321-9', N'849-444-5555', N'nuris@gmail.com')
INSERT [dbo].[Estudiante] ([Id], [Matricula], [Nombre], [Apellido], [Cedula], [Telefono], [Correo]) VALUES (4, N'2022-0004', N'Manolo', N'Justo', N'402-1518191-2', N'809-666-7777', N'manolo@gmail.com')
INSERT [dbo].[Estudiante] ([Id], [Matricula], [Nombre], [Apellido], [Cedula], [Telefono], [Correo]) VALUES (5, N'2019-8757', N'Jose', N'Urbaez', N'402-2030501-2', N'809-201-1010', N'jurbaez@gmail.com')
INSERT [dbo].[Estudiante] ([Id], [Matricula], [Nombre], [Apellido], [Cedula], [Telefono], [Correo]) VALUES (6, N'2022-7844', N'Sauli', N'Mazueti', N'402-0589012-2', N'809-123-5892', N'sauli@gmail.com')
INSERT [dbo].[Estudiante] ([Id], [Matricula], [Nombre], [Apellido], [Cedula], [Telefono], [Correo]) VALUES (8, N'2022-9555', N'Yuberkis', N'Dominguez', N'402-0378901-0', N'809-177-4570', N'yubi@gmail.com')
INSERT [dbo].[Estudiante] ([Id], [Matricula], [Nombre], [Apellido], [Cedula], [Telefono], [Correo]) VALUES (12, N'2022-7516', N'Alonso', N'Vasquez', N'401-3030104-2', N'809-829-1020', N'alonsof@gmail.com')
INSERT [dbo].[Estudiante] ([Id], [Matricula], [Nombre], [Apellido], [Cedula], [Telefono], [Correo]) VALUES (13, N'2022-4489', N'Judith', N'Serrano', N'402-0580124-1', N'809-241-1290', N'jserrano@gmail.com')
INSERT [dbo].[Estudiante] ([Id], [Matricula], [Nombre], [Apellido], [Cedula], [Telefono], [Correo]) VALUES (15, N'2022-4883', N'Aguilas', N'Cibaenas', N'402-0313080-4', N'809-961-2054', N'aguilas@gmail.com')
SET IDENTITY_INSERT [dbo].[Estudiante] OFF
GO
ALTER TABLE [dbo].[Asistencia]  WITH CHECK ADD FOREIGN KEY([EstudianteId])
REFERENCES [dbo].[Estudiante] ([Id])
GO
ALTER TABLE [dbo].[Calificacion]  WITH CHECK ADD FOREIGN KEY([EstudianteId])
REFERENCES [dbo].[Estudiante] ([Id])
GO
USE [master]
GO
ALTER DATABASE [ControlEstudiantil] SET  READ_WRITE 
GO

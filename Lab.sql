USE [Lab]
GO
/****** Object:  Table [dbo].[Districts]    Script Date: 10/5/2019 10:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Districts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_District] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 10/5/2019 10:50:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Code] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [varchar](50) NULL,
	[Contact] [varchar](50) NOT NULL,
	[DistrictId] [int] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[CustomerDetailsView]    Script Date: 10/5/2019 10:50:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CustomerDetailsView]
AS
SELECT Code, c.Name, Address, Contact, d.Name AS 'District' FROM Customers AS c
LEFT JOIN Districts AS d ON d.Id = c.DistrictId
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Code], [Id], [Name], [Address], [Contact], [DistrictId]) VALUES (2341, 1, N'Arif', N'Uttara', N'01773611681', 3)
INSERT [dbo].[Customers] ([Code], [Id], [Name], [Address], [Contact], [DistrictId]) VALUES (1212, 2, N'Ariful Islam', N'Uttara', N'01957884309', 12)
SET IDENTITY_INSERT [dbo].[Customers] OFF
SET IDENTITY_INSERT [dbo].[Districts] ON 

INSERT [dbo].[Districts] ([Id], [Name]) VALUES (1, N'Dinajpur')
INSERT [dbo].[Districts] ([Id], [Name]) VALUES (2, N'Rangpur')
INSERT [dbo].[Districts] ([Id], [Name]) VALUES (3, N'Bogra')
INSERT [dbo].[Districts] ([Id], [Name]) VALUES (4, N'Barguna')
INSERT [dbo].[Districts] ([Id], [Name]) VALUES (5, N'Barishal')
INSERT [dbo].[Districts] ([Id], [Name]) VALUES (6, N'Bhola')
INSERT [dbo].[Districts] ([Id], [Name]) VALUES (7, N'Pirojpur')
INSERT [dbo].[Districts] ([Id], [Name]) VALUES (8, N'Bandarban')
INSERT [dbo].[Districts] ([Id], [Name]) VALUES (9, N'Brahmanbaria')
INSERT [dbo].[Districts] ([Id], [Name]) VALUES (10, N'Chandpur')
INSERT [dbo].[Districts] ([Id], [Name]) VALUES (11, N'Chattogram')
INSERT [dbo].[Districts] ([Id], [Name]) VALUES (12, N'Dhaka')
INSERT [dbo].[Districts] ([Id], [Name]) VALUES (13, N'Faridpur')
INSERT [dbo].[Districts] ([Id], [Name]) VALUES (14, N'Gazipur')
INSERT [dbo].[Districts] ([Id], [Name]) VALUES (15, N'Gopalganj')
INSERT [dbo].[Districts] ([Id], [Name]) VALUES (16, N'Kishoreganj')
SET IDENTITY_INSERT [dbo].[Districts] OFF
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customer_District] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[Districts] ([Id])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customer_District]
GO

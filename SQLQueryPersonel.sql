
Create DataBase Personel
USE [Personel]
GO
/****** Object:  Table [dbo].[Adres]    Script Date: 13/03/2022 15:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adres](
	[AdresID] [int] IDENTITY(1,1) NOT NULL,
	[Il] [nvarchar](10) NULL,
	[Ilce] [nvarchar](15) NULL,
	[AdresDetay] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[AdresID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kisiler]    Script Date: 13/03/2022 15:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kisiler](
	[KisiID] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](50) NULL,
	[Soyad] [nvarchar](50) NULL,
	[Telefon] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[KisiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KisilerVeAdresleri]    Script Date: 13/03/2022 15:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KisilerVeAdresleri](
	[KisiID] [int] NOT NULL,
	[AdresID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[KisiID] ASC,
	[AdresID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Adres] ON 
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (1, N'İstanbul', N'Başakşehir', N'4.cadde')
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (2, N'İzmir', N'Konak', N'6.cadde')
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (3, N'Ankara', N'Çağlayan', N'Atatürk caddesi')
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (4, N'İzmir', N'Konak', N'Güzel Yer')
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (5, N'İstanbul', N'Bebek', N'İyi')
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (6, N'İstanbul', N'Nişantaşı', N'iyi iyi')
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (8, N'İstanbul', N'Beyoğlu', N'aaaaaa')
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (9, N'a', N'v', N'c')
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (11, N'denemeYeni', N'de', N'adasd')
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (12, N'İstanbul', N'Bakırköy', N'Güncelledim')
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (14, N'İzmir', N'Bornova', N'asdasdasd')
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (15, N'asd', N'sdf', N'zxc')
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (16, N'unique', N'v', N'c')
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (17, N'unique1', N'v', N'c')
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (19, N'Moskava', N'Moskova1', N'ada')
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (20, N'silinecek', N'silinecek', N'silinecek')
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (21, N'silinecek1', N'silinecek1', N'silinecek1')
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (23, N'silinecek3', N'silinecek3', N'silinecek3')
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (24, N'asd', N'asd', N'asdasdasd')
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (25, N'de', N'asdasd', N'fasdas')
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (27, N'YeniAdres', N'ilçe', N'AdresDetayı ')
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (29, N'İstanbul', N'Karaköy', N'Karaköy')
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (30, N'Deneme', N'aaaaa', N'asdzxzc')
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (34, N'De', N'dd', N'asd')
GO
INSERT [dbo].[Adres] ([AdresID], [Il], [Ilce], [AdresDetay]) VALUES (37, N'asd', N'asd', N'asdasd')
GO
SET IDENTITY_INSERT [dbo].[Adres] OFF
GO
SET IDENTITY_INSERT [dbo].[Kisiler] ON 
GO
INSERT [dbo].[Kisiler] ([KisiID], [Ad], [Soyad], [Telefon]) VALUES (1, N'Ali', N'Veli', N'(136) 333-3333')
GO
INSERT [dbo].[Kisiler] ([KisiID], [Ad], [Soyad], [Telefon]) VALUES (2, N'Mehmet', N'Yılmaz', N'(345) 345-6666')
GO
INSERT [dbo].[Kisiler] ([KisiID], [Ad], [Soyad], [Telefon]) VALUES (4, N'Yeni', N'Yeni2', N'(111) 111-1111')
GO
INSERT [dbo].[Kisiler] ([KisiID], [Ad], [Soyad], [Telefon]) VALUES (11, N'Hakan', N'Yıldız', N'(222) 222-2222')
GO
INSERT [dbo].[Kisiler] ([KisiID], [Ad], [Soyad], [Telefon]) VALUES (12, N'Deneme', N'YeniDeneme', N'(234) 234-1561')
GO
SET IDENTITY_INSERT [dbo].[Kisiler] OFF
GO
INSERT [dbo].[KisilerVeAdresleri] ([KisiID], [AdresID]) VALUES (1, 1)
GO
INSERT [dbo].[KisilerVeAdresleri] ([KisiID], [AdresID]) VALUES (1, 2)
GO
INSERT [dbo].[KisilerVeAdresleri] ([KisiID], [AdresID]) VALUES (1, 3)
GO
INSERT [dbo].[KisilerVeAdresleri] ([KisiID], [AdresID]) VALUES (1, 15)
GO
INSERT [dbo].[KisilerVeAdresleri] ([KisiID], [AdresID]) VALUES (2, 8)
GO
INSERT [dbo].[KisilerVeAdresleri] ([KisiID], [AdresID]) VALUES (2, 12)
GO
INSERT [dbo].[KisilerVeAdresleri] ([KisiID], [AdresID]) VALUES (4, 25)
GO
INSERT [dbo].[KisilerVeAdresleri] ([KisiID], [AdresID]) VALUES (11, 27)
GO
INSERT [dbo].[KisilerVeAdresleri] ([KisiID], [AdresID]) VALUES (12, 1)
GO
INSERT [dbo].[KisilerVeAdresleri] ([KisiID], [AdresID]) VALUES (12, 15)
GO
INSERT [dbo].[KisilerVeAdresleri] ([KisiID], [AdresID]) VALUES (12, 25)
GO
INSERT [dbo].[KisilerVeAdresleri] ([KisiID], [AdresID]) VALUES (12, 30)
GO
ALTER TABLE [dbo].[KisilerVeAdresleri]  WITH CHECK ADD  CONSTRAINT [FK__KisilerVe__Adres__3B75D760] FOREIGN KEY([AdresID])
REFERENCES [dbo].[Adres] ([AdresID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KisilerVeAdresleri] CHECK CONSTRAINT [FK__KisilerVe__Adres__3B75D760]
GO
ALTER TABLE [dbo].[KisilerVeAdresleri]  WITH CHECK ADD FOREIGN KEY([KisiID])
REFERENCES [dbo].[Kisiler] ([KisiID])
GO

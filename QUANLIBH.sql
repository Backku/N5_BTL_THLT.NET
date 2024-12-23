USE [QUANLIBH]
GO
/****** Object:  Table [dbo].[DONHANG]    Script Date: 11/25/2024 2:11:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DONHANG](
	[STT] [int] IDENTITY(1,1) NOT NULL,
	[Soluong] [nvarchar](20) NULL,
	[Thanhtien] [decimal](10, 2) NULL,
	[MaSP] [int] NULL,
	[MaDH] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[STT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHACC]    Script Date: 11/25/2024 2:11:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHACC](
	[MaNCC] [int] NOT NULL,
	[TenNCC] [nvarchar](50) NULL,
	[SDT] [nvarchar](15) NULL,
	[Diachi] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHAPKHO]    Script Date: 11/25/2024 2:11:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHAPKHO](
	[STT] [int] IDENTITY(1,1) NOT NULL,
	[Soluongton] [nvarchar](20) NULL,
	[Ngaynhap] [datetime] NULL,
	[MaSP] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[STT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SANPHAM]    Script Date: 11/25/2024 2:11:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SANPHAM](
	[MaSP] [int] NOT NULL,
	[TenSP] [nvarchar](50) NULL,
	[LoaiSP] [nvarchar](50) NULL,
	[Gia] [decimal](10, 2) NULL,
	[MaNCC] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THONGKE]    Script Date: 11/25/2024 2:11:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THONGKE](
	[MaDH] [int] NOT NULL,
	[TenKH] [nvarchar](100) NULL,
	[Diachi] [nvarchar](50) NULL,
	[Ngaymua] [datetime] NULL,
	[TongHD] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DONHANG] ON 

INSERT [dbo].[DONHANG] ([STT], [Soluong], [Thanhtien], [MaSP], [MaDH]) VALUES (46, N'2', CAST(60000.00 AS Decimal(10, 2)), 1, 1)
INSERT [dbo].[DONHANG] ([STT], [Soluong], [Thanhtien], [MaSP], [MaDH]) VALUES (47, N'1', CAST(15000.00 AS Decimal(10, 2)), 2, 1)
INSERT [dbo].[DONHANG] ([STT], [Soluong], [Thanhtien], [MaSP], [MaDH]) VALUES (48, N'3', CAST(36000.00 AS Decimal(10, 2)), 3, 1)
INSERT [dbo].[DONHANG] ([STT], [Soluong], [Thanhtien], [MaSP], [MaDH]) VALUES (49, N'3', CAST(90000.00 AS Decimal(10, 2)), 1, 2)
INSERT [dbo].[DONHANG] ([STT], [Soluong], [Thanhtien], [MaSP], [MaDH]) VALUES (50, N'3', CAST(45000.00 AS Decimal(10, 2)), 2, 2)
INSERT [dbo].[DONHANG] ([STT], [Soluong], [Thanhtien], [MaSP], [MaDH]) VALUES (51, N'2', CAST(24000.00 AS Decimal(10, 2)), 3, 2)
INSERT [dbo].[DONHANG] ([STT], [Soluong], [Thanhtien], [MaSP], [MaDH]) VALUES (52, N'6', CAST(72000.00 AS Decimal(10, 2)), 3, 3)
SET IDENTITY_INSERT [dbo].[DONHANG] OFF
GO
INSERT [dbo].[NHACC] ([MaNCC], [TenNCC], [SDT], [Diachi]) VALUES (2, N'Back', N'123454', N'HANoi')
INSERT [dbo].[NHACC] ([MaNCC], [TenNCC], [SDT], [Diachi]) VALUES (3, N'bachh', N'444444', N'hasha')
GO
SET IDENTITY_INSERT [dbo].[NHAPKHO] ON 

INSERT [dbo].[NHAPKHO] ([STT], [Soluongton], [Ngaynhap], [MaSP]) VALUES (2, N'5', CAST(N'2024-11-17T19:58:41.787' AS DateTime), 2)
INSERT [dbo].[NHAPKHO] ([STT], [Soluongton], [Ngaynhap], [MaSP]) VALUES (3, N'5', CAST(N'2024-11-17T12:28:44.573' AS DateTime), 1)
INSERT [dbo].[NHAPKHO] ([STT], [Soluongton], [Ngaynhap], [MaSP]) VALUES (4, N'0', CAST(N'2024-11-21T21:52:21.507' AS DateTime), 3)
SET IDENTITY_INSERT [dbo].[NHAPKHO] OFF
GO
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [LoaiSP], [Gia], [MaNCC]) VALUES (1, N'Hello kitty', N'Bánh', CAST(30000.00 AS Decimal(10, 2)), 3)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [LoaiSP], [Gia], [MaNCC]) VALUES (2, N'SiuKay', N'Mì', CAST(15000.00 AS Decimal(10, 2)), 3)
INSERT [dbo].[SANPHAM] ([MaSP], [TenSP], [LoaiSP], [Gia], [MaNCC]) VALUES (3, N'KitKat', N'Kẹo', CAST(12000.00 AS Decimal(10, 2)), 2)
GO
INSERT [dbo].[THONGKE] ([MaDH], [TenKH], [Diachi], [Ngaymua], [TongHD]) VALUES (1, N'Nguyễn Xuân Bách', N'Hà Nội', CAST(N'2024-11-20T17:30:45.000' AS DateTime), N'111000.00')
INSERT [dbo].[THONGKE] ([MaDH], [TenKH], [Diachi], [Ngaymua], [TongHD]) VALUES (2, N'Bình', N'Thái Bình', CAST(N'2024-11-20T21:05:44.000' AS DateTime), N'159000.00')
INSERT [dbo].[THONGKE] ([MaDH], [TenKH], [Diachi], [Ngaymua], [TongHD]) VALUES (3, N'3', N'3', CAST(N'2024-11-21T21:49:38.000' AS DateTime), N'72000.00')
GO
ALTER TABLE [dbo].[DONHANG]  WITH CHECK ADD FOREIGN KEY([MaSP])
REFERENCES [dbo].[SANPHAM] ([MaSP])
GO
ALTER TABLE [dbo].[DONHANG]  WITH CHECK ADD  CONSTRAINT [FK_DONHANG_THONGKE] FOREIGN KEY([MaDH])
REFERENCES [dbo].[THONGKE] ([MaDH])
GO
ALTER TABLE [dbo].[DONHANG] CHECK CONSTRAINT [FK_DONHANG_THONGKE]
GO
ALTER TABLE [dbo].[NHAPKHO]  WITH CHECK ADD FOREIGN KEY([MaSP])
REFERENCES [dbo].[SANPHAM] ([MaSP])
GO
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NHACC] ([MaNCC])
GO

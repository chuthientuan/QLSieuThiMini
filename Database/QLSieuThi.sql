--CREATE DATABASE QuanlySieuthi
USE [QuanlySieuthi]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHDB](
	[MaHDB] [nvarchar](20) NOT NULL,
	[MaSP] [int] NOT NULL,
	[SLBan] [int] NULL,
	[ThanhTien] [decimal] NULL,
	[KhuyenMai] [nvarchar](100) NULL,
 CONSTRAINT [PK_ChiTietHDB] PRIMARY KEY CLUSTERED 
(
	[MaHDB] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = ON, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHDN]    Script Date: 11/10/2021 9:51:36 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHDN](
	[MaHDN] [nvarchar](20) NOT NULL,
	[MaSP] [int] NOT NULL,
	[ThanhTien] [decimal] NULL,
	[SLNhap] [int] NULL,
 CONSTRAINT [PK_ChiTietHDN] PRIMARY KEY CLUSTERED 
(
	[MaHDN] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = ON, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonBan]    Script Date: 11/10/2021 9:51:36 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonBan](
	[MaHDB] [nvarchar](20) NOT NULL,
	[MaNV] [nvarchar](30) NOT NULL,
	[NgayBan] [datetime] NULL,
	[TongTien] [decimal] NULL,
	[MaKH] [int] NULL,
 CONSTRAINT [PK_HoaDonBan] PRIMARY KEY CLUSTERED 
(
	[MaHDB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonNhap]    Script Date: 11/10/2021 9:51:36 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonNhap](
	[MaHDN] [nvarchar](20) NOT NULL,
	[MaNV] [nvarchar](30) NULL,
	[NgayNhap] [datetime] NULL,
	[TongTien] [decimal] NULL,
	[MaNCC] [int] NULL,
 CONSTRAINT [PK_HoaDonNhap] PRIMARY KEY CLUSTERED 
(
	[MaHDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 11/10/2021 9:51:36 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[TenKH] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar] (10) NULL,
	[DiaChi] [nvarchar] (100) NULL,
	[DienThoai] [nvarchar](15) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 11/10/2021 9:51:36 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNCC] [int] IDENTITY(1,1) NOT NULL,
	[TenNCC] [nvarchar](200) NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 11/10/2021 9:51:36 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [nvarchar](30) NOT NULL,
	[TenNV] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar] (50) NOT NULL,
	[ChucDanh] [int] NOT NULL,
	[Anh] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](5) NULL,
	[NgaySinh] [datetime] NULL,
	[DienThoai] [nvarchar](15) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiHang](
	[MaLH] [int] IDENTITY(1,1) NOT NULL,
	[TenLH] [nvarchar](200) NULL,
 CONSTRAINT [PK_LoaiHang] PRIMARY KEY CLUSTERED 
(
	[MaLH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SanPham]    Script Date: 11/10/2021 9:51:36 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSP] [int] IDENTITY(1,1) NOT NULL,
	[TenSP] [nvarchar](200) NULL,
	[DonGiaNhap] [decimal] NULL,
	[DonGiaBan] [decimal] NULL,
	[SoLuong] [int] NULL,
	[Anh] [nvarchar](max) NULL,
	[HSD] [date] NULL,
	[MaLH] [int] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO



ALTER TABLE [dbo].[ChiTietHDB]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHDB_HoaDonBan] FOREIGN KEY([MaHDB])
REFERENCES [dbo].[HoaDonBan] ([MaHDB])
GO
ALTER TABLE [dbo].[ChiTietHDB] CHECK CONSTRAINT [FK_ChiTietHDB_HoaDonBan]
GO
ALTER TABLE [dbo].[ChiTietHDB]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHDB_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTietHDB] CHECK CONSTRAINT [FK_ChiTietHDB_SanPham]
GO
ALTER TABLE [dbo].[ChiTietHDN]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHDN_HoaDonNhap] FOREIGN KEY([MaHDN])
REFERENCES [dbo].[HoaDonNhap] ([MaHDN])
GO
ALTER TABLE [dbo].[ChiTietHDN] CHECK CONSTRAINT [FK_ChiTietHDN_HoaDonNhap]
GO
ALTER TABLE [dbo].[ChiTietHDN]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHDN_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTietHDN] CHECK CONSTRAINT [FK_ChiTietHDN_SanPham]
GO
ALTER TABLE [dbo].[HoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonBan_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[HoaDonBan] CHECK CONSTRAINT [FK_HoaDonBan_KhachHang]
GO
ALTER TABLE [dbo].[HoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonBan_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HoaDonBan] CHECK CONSTRAINT [FK_HoaDonBan_NhanVien]
GO
ALTER TABLE [dbo].[HoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonNhap_NhaCungCap] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[HoaDonNhap] CHECK CONSTRAINT [FK_HoaDonNhap_NhaCungCap]
GO
ALTER TABLE [dbo].[HoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonNhap_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HoaDonNhap] CHECK CONSTRAINT [FK_HoaDonNhap_NhanVien]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiHang] FOREIGN KEY([MaLH])
REFERENCES [dbo].[LoaiHang] ([MaLH])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiHang]
GO
insert into NhanVien (MaNV, TenNV, MatKhau, ChucDanh, GioiTinh, DienThoai) values (N'NV01', N'Chu Thiên Tuấn', N'tuanchu123', 1, N'Nam', N'0964023310');
insert into NhanVien (MaNV, TenNV, MatKhau, ChucDanh, GioiTinh, DienThoai) values (N'Admin', N'Chu Thiên Tuấn', N'admin123', 0, N'Nam', N'0964023310');
insert into KhachHang (TenKH, GioiTinh, DiaChi, DienThoai) values (N'Chu Thiên Tuấn', N'Nam', N'Bắc Từ Liêm - Hà Nội', N'0964023310');
insert into SanPham (TenSP, DonGiaBan, SoLuong) values (N'Sữa NuVi', 20000, 40);
insert into SanPham (TenSP, DonGiaBan, SoLuong) values (N'Bánh ChôcPie', 40000, 60);
insert into SanPham (TenSP, DonGiaBan, SoLuong) values (N'Sữa MILO', 30000, 50);
insert into SanPham (TenSP, DonGiaBan, SoLuong) values (N'Khô bò', 10000, 60);
insert into SanPham (TenSP, DonGiaBan, SoLuong) values (N'Giấy ăn', 15000, 60);
insert into SanPham (TenSP, DonGiaNhap, DonGiaBan, SoLuong, MaLH) values (N'Bánh', 5000, 8000, 0, 1);

insert into LoaiHang (TenLH) values (N'Thực phẩm');

select * from SanPham;
select * from LoaiHang;
select * from NhanVien;
select * from HoaDonBan;
select * from ChiTietHDB;
select * from KhachHang;
select MaKH from KhachHang where DienThoai = N'0964023310';

select count(*) as SHD from HoaDonBan;
select sum(SoLuong) as SL, count(*) as SoSP from SanPham;
select sum(TongTien) from HoaDonBan;

select top 5 s.TenSP, sum(c.SLBan) AS TotalQuantity
from ChiTietHDB c inner join SanPham s on c.MaSP = s.MaSP
inner join HoaDonBan h on c.MaHDB = h.MaHDB
where month(h.NgayBan) = month(GETDATE()) and
year(h.NgayBan) = year(GETDATE())
group by s.TenSP
order by TotalQuantity DESC;

select sum((b.SLBan * s.DonGiaBan) - (n.SLNhap * s.DonGiaNhap)) as TongLoiNhuan
from SanPham s inner join ChiTietHDB b on s.MaSP = b.MaSP
inner join ChiTietHDN n on s.MaSP = n.MaSP;

SELECT FORMAT(NgayBan, 'dd-MM-yyyy') AS Date, 
                     SUM(TongTien) AS Revenue 
                     FROM HoaDonBan
                     GROUP BY FORMAT(NgayBan, 'dd-MM-yyyy')		
                     ORDER BY FORMAT(NgayBan, 'dd-MM-yyyy');

SELECT 
    FORMAT(NgayBan, 'dd-MM-yyyy') AS Date,
    DATENAME(WEEKDAY, NgayBan) AS DayName,
    SUM(TongTien) AS Revenue,
    CASE 
        WHEN DATEDIFF(WEEK, NgayBan, GETDATE()) = 1 THEN 'LastWeek'
        WHEN DATEDIFF(WEEK, NgayBan, GETDATE()) = 0 THEN 'ThisWeek'
    END AS WeekCategory
FROM 
    HoaDonBan
WHERE 
    DATEDIFF(WEEK, NgayBan, GETDATE()) IN (0, 1)
GROUP BY 
    NgayBan, 
    FORMAT(NgayBan, 'dd-MM-yyyy'), 
    DATENAME(WEEKDAY, NgayBan),
    CASE 
        WHEN DATEDIFF(WEEK, NgayBan, GETDATE()) = 1 THEN 'LastWeek'
        WHEN DATEDIFF(WEEK, NgayBan, GETDATE()) = 0 THEN 'ThisWeek'
    END
ORDER BY 
    WeekCategory, 
    FORMAT(NgayBan, 'dd-MM-yyyy');


DECLARE @StartOfWeek DATE = DATEADD(DAY, 1 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE));
DECLARE @EndOfWeek DATE = DATEADD(DAY, 7 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE));

SELECT 
    (ISNULL(SUM(HDB.TongTien), 0) - ISNULL(SUM(HDN.TongTien), 0)) AS LoiNhuanTrongTuan
FROM 
    (SELECT TongTien 
     FROM HoaDonBan 
     WHERE NgayBan >= @StartOfWeek AND NgayBan <= @EndOfWeek) AS HDB
FULL OUTER JOIN 
    (SELECT TongTien 
     FROM HoaDonNhap 
     WHERE NgayNhap >= @StartOfWeek AND NgayNhap <= @EndOfWeek) AS HDN
ON 1 = 1;


select count(*) as SHD from HoaDonBan where cast(NgayBan as date) = cast(GETDATE() as date);

WITH ThisWeek AS (
    SELECT 
        COUNT(MaHDB) AS SoHoaDon
    FROM 
        HoaDonBan
    WHERE 
        NgayBan BETWEEN DATEADD(DAY, 1 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE)) 
                    AND DATEADD(DAY, 7 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE))
),
LastWeek AS (
    SELECT 
        COUNT(MaHDB) AS SoHoaDon
    FROM 
        HoaDonBan
    WHERE 
        NgayBan BETWEEN DATEADD(DAY, 1 - DATEPART(WEEKDAY, GETDATE()) - 7, CAST(GETDATE() AS DATE)) 
                    AND DATEADD(DAY, 7 - DATEPART(WEEKDAY, GETDATE()) - 7, CAST(GETDATE() AS DATE))
)
SELECT 
    ThisWeek.SoHoaDon AS SoHoaDonTuanNay,
    CASE 
        WHEN LastWeek.SoHoaDon = 0 THEN 0
        ELSE CAST(((ThisWeek.SoHoaDon * 1.0 - LastWeek.SoHoaDon) / LastWeek.SoHoaDon) * 100 AS INT)
    END AS PhanTramThayDoi,
    CASE 
        WHEN LastWeek.SoHoaDon = 0 THEN '(0 hóa đơn)'
        ELSE CONCAT('(', LastWeek.SoHoaDon, ' hóa đơn)')
    END AS GhiChu
FROM 
    ThisWeek, LastWeek;



WITH ThisWeekRevenue AS (
    SELECT 
        SUM(TongTien) AS DoanhThuTuanNay
    FROM 
        HoaDonBan
    WHERE 
        NgayBan BETWEEN DATEADD(DAY, 1 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE)) 
        AND DATEADD(DAY, 7 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE))
),
LastWeekRevenue AS (
    SELECT 
        SUM(TongTien) AS DoanhThuTuanTruoc
    FROM 
        HoaDonBan
    WHERE 
        NgayBan BETWEEN DATEADD(DAY, 1 - DATEPART(WEEKDAY, GETDATE()) - 7, CAST(GETDATE() AS DATE)) 
        AND DATEADD(DAY, 7 - DATEPART(WEEKDAY, GETDATE()) - 7, CAST(GETDATE() AS DATE))
)
SELECT 
    ISNULL(ThisWeekRevenue.DoanhThuTuanNay, 0) AS DoanhThuTuanNay,
    ISNULL(LastWeekRevenue.DoanhThuTuanTruoc, 0) AS DoanhThuTuanTruoc,
    CASE 
        WHEN ISNULL(LastWeekRevenue.DoanhThuTuanTruoc, 0) = 0 THEN 0
        ELSE CAST(
            ROUND(
                ((ISNULL(ThisWeekRevenue.DoanhThuTuanNay, 0) - ISNULL(LastWeekRevenue.DoanhThuTuanTruoc, 0)) * 100.0) 
                / ISNULL(LastWeekRevenue.DoanhThuTuanTruoc, 1),
                0
            ) AS INT
        )
    END AS PhanTramThayDoi
FROM 
    ThisWeekRevenue, LastWeekRevenue;



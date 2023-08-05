IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Cungcap] (
    [CungcapID] int NOT NULL IDENTITY,
    [Tendaydu] nvarchar(255) NULL,
    [TenLienhe] nvarchar(255) NULL,
    [Diachi] nvarchar(255) NULL,
    [Thanhpho] nvarchar(255) NULL,
    [MaBuudien] nvarchar(255) NULL,
    [Quocgia] nvarchar(255) NULL,
    [Dienthoai] nvarchar(255) NULL,
    CONSTRAINT [PK_Cungcap] PRIMARY KEY ([CungcapID])
);
GO

CREATE TABLE [Danhmuc] (
    [DanhmucID] int NOT NULL IDENTITY,
    [TenDanhMuc] nvarchar(255) NULL,
    [MoTa] nvarchar(255) NULL,
    CONSTRAINT [PK_Danhmuc] PRIMARY KEY ([DanhmucID])
);
GO

CREATE TABLE [Donhang] (
    [DonhangID] int NOT NULL IDENTITY,
    [KhachhangID] int NULL,
    [NhanvienID] int NULL,
    [Ngaydathang] date NULL,
    [ShipperID] int NULL,
    CONSTRAINT [PK_Donhang] PRIMARY KEY ([DonhangID])
);
GO

CREATE TABLE [DonhangChitiet] (
    [DonhangChitietID] int NOT NULL IDENTITY,
    [DonhangID] int NULL,
    [SanphamID] int NULL,
    [Soluong] int NULL,
    CONSTRAINT [PK_DonhangChitiet] PRIMARY KEY ([DonhangChitietID])
);
GO

CREATE TABLE [Khachhang] (
    [KhachhangID] int NOT NULL IDENTITY,
    [HoTen] nvarchar(255) NULL,
    [TenLienLac] nvarchar(255) NULL,
    [Diachi] nvarchar(255) NULL,
    [Thanhpho] nvarchar(255) NULL,
    [MaBuudien] nvarchar(255) NULL,
    [QuocGia] nvarchar(255) NULL,
    CONSTRAINT [PK_Khachhang] PRIMARY KEY ([KhachhangID])
);
GO

CREATE TABLE [Nhanvien] (
    [NhanviennID] int NOT NULL IDENTITY,
    [Ten] nvarchar(255) NULL,
    [Ho] nvarchar(255) NULL,
    [NgaySinh] date NULL,
    [Anh] nvarchar(255) NULL,
    [Ghichu] text NULL,
    CONSTRAINT [PK__Nhanvien__92550447826C7F23] PRIMARY KEY ([NhanviennID])
);
GO

CREATE TABLE [Sanpham] (
    [SanphamID] int NOT NULL IDENTITY,
    [TenSanpham] nvarchar(255) NULL,
    [CungcapID] int NULL,
    [DanhmucID] int NULL,
    [Donvi] nvarchar(255) NULL,
    [Gia] decimal(13,2) NULL,
    CONSTRAINT [PK_Sanpham] PRIMARY KEY ([SanphamID])
);
GO

CREATE TABLE [Shippers] (
    [ShipperID] int NOT NULL IDENTITY,
    [Hoten] nvarchar(255) NULL,
    [Sodienthoai] nvarchar(255) NULL,
    CONSTRAINT [PK_Shippers] PRIMARY KEY ([ShipperID])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230805171213_v0', N'5.0.4');
GO

COMMIT;
GO


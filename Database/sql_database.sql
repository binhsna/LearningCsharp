USE xtlab;
go
SELECT DanhmucID, TenDanhMuc, MoTa FROM Danhmuc WHERE DanhmucID >= 5
go
-- INSERT into Shippers(Hoten, Sodienthoai) VALUES (N'Nguyễn Công Bình', N'0971912776') 
-- go
DELETE Shippers where ShipperID = 5
go
SELECT * FROM Shippers
GO
CREATE OR ALTER PROCEDURE GetProductInfo(@id int)
AS
BEGIN
    SELECT TenSanPham, TenDanhMuc FROM Sanpham
    INNER JOIN Danhmuc ON Danhmuc.DanhmucID = Sanpham.DanhmucID
    WHERE Sanpham.SanPhamID = @id
END
GO
EXEC GetProductInfo 5;
GO
SELECT NhanviennID, Ten, Ho FROM Nhanvien
-- Tạo SCDL QUANLYBANHANG

CREATE DATABASE QUANLYBANHANG
GO
USE QUANLYBANHANG
GO
SET DATEFORMAT dmy
GO
-- Tạo bảng NhanVien
CREATE TABLE NhanVien(
maNV nvarchar(10)NOT NULL,
tenNV nvarchar(30),
diaChi nvarchar(30),
sDT char(10),
chucVu varchar(20),
matKhau varchar(50)
)
GO
-- Tạo bảng KhoHang
CREATE TABLE KhoHang(
maSP nvarchar(10)NOT NULL,
tenSP nvarchar(100),
nhaSX nvarchar(20),
hanDung date,
loaiHang int,
donViTinh nvarchar(10),
donGia float,
soLuong int,
ngayNhap DATE
)
GO
-- Tạo bảng HoaDon
CREATE TABLE HoaDon(
maHD nvarchar(10)NOT NULL,
maKH nvarchar(10),
maNV nvarchar(10),
ngayLapHD DATE
)
GO
-- Tạo bảng KhachHang
CREATE TABLE KhachHang(
maKH nvarchar(10)NOT NULL,
tenKH nvarchar(30),
diaChi nvarchar(30),
sDT char(10)
)
GO
-- Tạo bảng ChiTietHoaDon
CREATE TABLE ChiTietHoaDon(
maHD nvarchar(10)NOT NULL,
maSP nvarchar(10)NOT NULL,
soLuong int,
ngaySX DATE
)
GO
-- Tạo bảng DanhMuc
CREATE TABLE DanhMuc(
maDanhMuc int NOT NULL,
tenDanhMuc nvarchar(20)
)
GO
-- Tạo khóa chính
ALTER TABLE NhanVien ADD CONSTRAINT PK_NhanVien PRIMARY KEY (maNV)
GO
ALTER TABLE KhoHang ADD CONSTRAINT PK_KhoHang PRIMARY KEY (maSP)
GO
ALTER TABLE HoaDon ADD CONSTRAINT PK_HoaDon PRIMARY KEY (maHD)
GO
ALTER TABLE KhachHang ADD CONSTRAINT PK_KhachHang PRIMARY KEY (maKH)
GO
ALTER TABLE ChiTietHoaDon ADD CONSTRAINT PK_ChiTietHoaDon PRIMARY KEY (maHD,maSP)
GO
ALTER TABLE DanhMuc ADD CONSTRAINT PK_DanhMuc PRIMARY KEY (maDanhMuc)
GO
-- Tạo khóa ngoại
ALTER TABLE KhoHang ADD CONSTRAINT FK_HangHoa_DanhMuc FOREIGN KEY (loaiHang) REFERENCES DanhMuc(maDanhMuc)
GO
ALTER TABLE ChiTietHoaDon ADD CONSTRAINT FK_ChiTietHoaDon_SanPham FOREIGN KEY (maSP) REFERENCES KhoHang(maSP)
GO
ALTER TABLE HoaDon ADD CONSTRAINT FK_HoaDon_NhanVien FOREIGN KEY (maNV) REFERENCES NhanVien(maNV)
GO
ALTER TABLE HoaDon ADD CONSTRAINT FK_HoaDon_KhachHang FOREIGN KEY (maKH) REFERENCES KhachHang(maKH)
GO
ALTER TABLE ChiTietHoaDon ADD CONSTRAINT FK_ChiTietHoaDon_HoaDon FOREIGN KEY (maHD) REFERENCES HoaDon(maHD)
GO


----------------------------------------- STORE PROCDURE -----------------------------------------
-------- Store Procdure KhoHang --------
-- PROC Thêm KhoHang
CREATE PROC SP_InsertKhoHang(
@maSP nvarchar(10),@tenSP nvarchar(100),@nhaSX nvarchar(20),@hanDung date,@loaiHang int,@donViTinh nvarchar(10),@donGia float,@soLuong int,@ngayNhap DATE)
AS
BEGIN
	INSERT INTO KhoHang(maSP,tenSP,nhaSX,hanDung,loaiHang,donViTinh,donGia,soLuong,ngayNhap)
	VALUES(@maSP,@tenSP,@nhaSX,@hanDung,@loaiHang,@donViTinh,@donGia,@soLuong,@ngayNhap)
END
GO
-- PROC Xóa KhoHang
CREATE PROC SP_DeleteKhoHang(
@maSP nvarchar(10))
AS
BEGIN
	DELETE FROM KhoHang WHERE maSP=@maSP
END
GO
-- PROC Sửa KhoHang
CREATE PROC SP_UpdateKhoHang(
@maSP nvarchar(10),@tenSP nvarchar(100),@nhaSX nvarchar(20),@hanDung date,@loaiHang int,@donViTinh nvarchar(10),@donGia float,@soLuong int,@ngayNhap DATE)
AS
BEGIN
	UPDATE KhoHang SET tenSP=@tenSP,nhaSX=@nhaSX,hanDung=@hanDung,loaiHang=@loaiHang,donViTinh=@donViTinh,donGia=@donGia,soLuong=@soLuong,ngayNhap=@ngayNhap
	WHERE maSP=@maSP
END
GO
-------- Store Procdure DanhMuc --------
-- PROC Thêm DanhMuc
CREATE PROC SP_InsertDanhMuc(
@maDanhMuc int,@tenDanhMuc nvarchar(20))
AS
BEGIN
	INSERT INTO DanhMuc(maDanhMuc,tenDanhMuc)
	VALUES(@maDanhMuc,@tenDanhMuc)
END
GO
-- PROC Xóa DanhMuc
CREATE PROC SP_DeleteDanhMuc(
@maDanhMuc int)
AS
BEGIN
	DELETE FROM DanhMuc WHERE maDanhMuc=@maDanhMuc
END
GO
-- PROC Sửa DanhMuc
CREATE PROC SP_UpdateDanhMuc(
@maDanhMuc int,@tenDanhMuc nvarchar(20))
AS
BEGIN
	UPDATE DanhMuc SET tenDanhMuc=@tenDanhMuc
	WHERE maDanhMuc=@maDanhMuc
END
GO

-------- Store Procdure NhanVien --------
-- PROC Thêm NhanVien
CREATE PROC SP_InsertNhanVien(
@maNV nvarchar(10),@tenNV nvarchar(30),@diaChi nvarchar(30),@sDT char(10),@chucVu varchar(20),@matKhau varchar(50))
AS
BEGIN
	INSERT INTO NhanVien(maNV,tenNV,diaChi,sDT,chucVu,matKhau)
	VALUES(@maNV,@tenNV,@diaChi,@sDT,@chucVu,@matKhau)
END
GO
-- PROC Xóa NhanVien
CREATE PROC SP_DeleteNhanVien(
@maNV nvarchar(10))
AS
BEGIN
	DELETE FROM NhanVien WHERE maNV=@maNV
END
GO
-- PROC Sửa NhanVien
CREATE PROC SP_UpdateNhanVien(
@maNV nvarchar(10),@tenNV nvarchar(30),@diaChi nvarchar(30),@sDT char(10),@chucVu varchar(20),@matKhau varchar(50))
AS
BEGIN
	UPDATE NhanVien SET tenNV=@tenNV, diaChi=@diaChi, sDT=@sDT, chucVu=@chucVu, matKhau = @matKhau
	WHERE maNV=@maNV
END
GO
-------- Store Procdure KhachHang --------
-- PROC Thêm KhachHang
CREATE PROC SP_InsertKhachHang(
@maKH nvarchar(10),@tenKH nvarchar(30),@diaChi nvarchar(30),@sDT char(10))
AS
BEGIN
	INSERT INTO KhachHang(maKH,tenKH,diaChi,sDT)
	VALUES(@maKH,@tenKH,@diaChi,@sDT)
END
GO
-- PROC Xóa KhachHang
CREATE PROC SP_DeleteKhachHang(
@maKH nvarchar(10))
AS
BEGIN
	DELETE FROM KhachHang WHERE maKH=@maKH
END
GO
-- PROC Sửa KhachHang
CREATE PROC SP_UpdateKhachHang(
@maKH nvarchar(10),@tenKH nvarchar(30),@diaChi nvarchar(30),@sDT char(10))
AS
BEGIN

	UPDATE KhachHang SET tenKH=@tenKH,diaChi=@diaChi,sDT=@sDT
	WHERE maKH=@maKH
END
GO
-------- Store Procdure HoaDon --------
-- PROC Thêm HoaDon
CREATE PROC SP_InsertHoaDon(
@maHD nvarchar(10),@maKH nvarchar(10),@maNV nvarchar(10),@ngayLapHD DATE)
AS
BEGIN
	INSERT INTO HoaDon(maHD,maKH,maNV,ngayLapHD)
	VALUES(@maHD,@maKH,@maNV,@ngayLapHD)
END
GO
-- PROC Xóa HoaDon
CREATE PROC SP_DeleteHoaDon(
@maHD nvarchar(10))
AS
BEGIN
	DELETE FROM HoaDon WHERE maHD=@maHD
END
GO
-- PROC Sửa HoaDon
CREATE PROC SP_UpdateHoaDon(
@maHD nvarchar(10),@maKH nvarchar(10),@maNV nvarchar(10),@ngayLapHD DATE)
AS
BEGIN
	UPDATE HoaDon SET maKH=@maKH,maNV=@maNV,ngayLapHD=@ngayLapHD
	WHERE maHD=@maHD
END
GO

-------- Store Procdure ChiTietHoaDon --------
-- PROC Thêm ChiTietHoaDon
CREATE PROC SP_InsertChiTietHoaDon(
@maHD nvarchar(10),@maSP nvarchar(10),@soLuong int,@ngaySX DATE)
AS
BEGIN
	INSERT INTO ChiTietHoaDon(maHD,maSP,soLuong,ngaySX)
	VALUES(@maHD,@maSP,@soLuong,@ngaySX)
END
GO
-- PROC Xóa ChiTietHoaDon
CREATE PROC SP_DeleteChiTietHoaDon(
@maHD nvarchar(10))
AS
BEGIN
	DELETE FROM ChiTietHoaDon WHERE maHD=@maHD
END
GO
-- PROC Sửa ChiTietHoaDon
CREATE PROC SP_UpdateChiTietHoaDon(
@maHD nvarchar(10),@maSP nvarchar(10),@soLuong int,@ngaySX DATE)
AS
BEGIN
	UPDATE ChiTietHoaDon SET soLuong=@soLuong,ngaySX=@ngaySX
	WHERE maHD=@maHD AND maSP=@maSP
END
GO

--------------------- PROC hiển thị các bảng------------------------
-- PROC hiển thị KhoHang
CREATE PROC SP_SelectKhoHang
AS
BEGIN
	SELECT * FROM KhoHang
END
GO
-- PROC hiển thị DanhMuc
CREATE PROC SP_SelectDanhMuc
AS
BEGIN
	SELECT * FROM DanhMuc
END
GO
-- PROC hiển thị SanPham
CREATE PROC SP_SelectSanPham
AS
BEGIN
	SELECT maSP, tenSP, nhaSX,loaiHang,donViTinh, donGia FROM KhoHang
END
GO
-- PROC hiển thị NhanVien
CREATE PROC SP_SelectNhanVien
AS
BEGIN
	SELECT * FROM NhanVien
END
GO
-- PROC hiển thị KhachHang
CREATE PROC SP_SelectKhachHang
AS
BEGIN
	SELECT * FROM KhachHang
END
GO
--- PROC hiển thị KhachHang theo mã KhachHang
CREATE PROC SP_SelectKhachHangByID(@maKH nvarchar(10))
AS
BEGIN
	SELECT * FROM KhachHang
	where maKH=@maKH
END
GO
-- PROC hiển thị HoaDon
CREATE PROC SP_SelectHoaDon
AS
BEGIN
	SELECT * FROM HoaDon
END
GO
-- PROC hiển thị ChiTietHoaDon
CREATE PROC SP_SelectChiTietHoaDon
AS
BEGIN
	SELECT * FROM ChiTietHoaDon
END
GO
--PROC xuất hàng hóa khi bán hàng
CREATE PROC SP_XuatKhoHang(@maSP nvarchar(10),@soLuongBan int)
	AS
	BEGIN
	UPDATE KhoHang SET soLuong=soLuong-@soLuongBan
	WHERE maSP=@maSP
	END
GO
---THỰC THI STORE PROCEDURE SELECT
EXEC SP_SelectKhoHang
GO
EXEC SP_SelectDanhMuc
GO
EXEC SP_SelectSanPham
GO
EXEC SP_SelectNhanVien
GO
EXEC SP_SelectKhachHang
GO
EXEC SP_SelectHoaDon
GO
EXEC SP_SelectChiTietHoaDon
GO
----------------------------------EXECUTE PROCEDURE------------------------------------
--------------------------------------EXEC DanhMuc----------------------------
-- EXEC SP_InsertDanhMuc
EXEC SP_InsertDanhMuc 1,N'Bánh'
GO
EXEC SP_InsertDanhMuc 2,N'Nước'
GO
EXEC SP_InsertDanhMuc 3,N'Vệ Sinh'
GO
--------------------------------------EXEC KhoHang----------------------------
-- EXEC SP_InsertKhoHang
EXEC SP_InsertKhoHang 'SP01',N'Bánh Chocopie','Orion','15/10/2021',1,N'Thùng',370000,150,'15/12/2020'
GO
EXEC SP_InsertKhoHang 'SP02',N'Nước ngọt Coca-cola','Coca-cola','13/12/2021',2,N'Thùng',185000,170,'13/12/2020'
GO
EXEC SP_InsertKhoHang 'SP03',N'Nước rửa chén Sunlight','Unilever','16/12/2022',3,N'Thùng',245000,100,'16/12/2020'
GO
EXEC SP_InsertKhoHang 'SP04',N'Bia Tiger','Heineken','17/12/2021',2,N'Thùng',335000,250,'17/12/2020'
GO
--------------------------------------EXEC NhanVien----------------------------
-- EXEC SP_InsertNhanVien
EXEC SP_InsertNhanVien 'NV01',N'Nguyễn Hữu Quyền',N'Vũng Tàu','0987654321','admin','123'
GO
EXEC SP_InsertNhanVien 'NV02',N'Hồ Viết Long',N'Huế','0987612345','admin','123'
GO
EXEC SP_InsertNhanVien 'NV03',N'Từ Văn Quốc Phú',N'Long An','0987123456','nv','123'
GO
EXEC SP_InsertNhanVien 'NV04',N'Nguyễn Quốc Việt',N'Đà Nẵng','0987456123','nv','123'
GO
--------------------------------------EXEC KhachHang----------------------------
-- EXEC SP_InsertKhachHang
EXEC SP_InsertKhachHang 'KH00',N'Vãng lai',N'null','null'
GO
EXEC SP_InsertKhachHang 'KH01',N'Trần Thị Thu Hà',N'Vũng Tàu','0981234567'
GO
EXEC SP_InsertKhachHang 'KH02',N'Nguyễn Công Huấn',N'Đồng Nai','0981237654'
GO
EXEC SP_InsertKhachHang 'KH03',N'Quách Thị Hải Hà',N'Đồng Nai','0988123123'
GO
EXEC SP_InsertKhachHang 'KH04',N'Phạm Nhật Tuân',N'Hà Nội','0987742743'
GO
--------------------------------------EXEC HoaDon----------------------------
-- EXEC SP_InsertHoaDon
EXEC SP_InsertHoaDon 'HD01','KH01','NV01','15/12/2020'
GO
EXEC SP_InsertHoaDon 'HD02','KH02','NV02','13/12/2020'
GO
EXEC SP_InsertHoaDon 'HD03','KH03','NV01','16/12/2020'
GO
EXEC SP_InsertHoaDon 'HD04','KH04','NV01','17/12/2020'
GO
--------------------------------------EXEC ChiTietHoaDon----------------------------
-- EXEC SP_InsertChiTietHoaDon
EXEC SP_InsertChiTietHoaDon 'HD01','SP01',150,'21/12/2020'
GO
EXEC SP_InsertChiTietHoaDon 'HD02','SP02',170,'13/12/2020'
GO
EXEC SP_InsertChiTietHoaDon 'HD03','SP03',100,'16/12/2020'
GO
EXEC SP_InsertChiTietHoaDon 'HD04','SP04',250,'17/12/2020'
GO

-----------FUCTION TỰ ĐỘNG TẠO MÃ HÓA ĐƠN------------
CREATE FUNCTION FC_AutoCreateMaHD()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(maHD) FROM HoaDon) = 0
		SET @ID = ''
	ELSE
		SELECT @ID = COUNT(maHD) FROM HoaDon
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'HD0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'HD' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
Go
---PROC chạy function tạo mã hóa đơn tự động
CREATE PROC SP_TaoMaHoaDon
AS
BEGIN
	DECLARE @ma nvarchar(10);
	EXEC @ma=FC_AutoCreateMaHD
	SELECT @ma
END
GO
-----PROC IN CHI TIẾT HÓA ĐƠN-----------
CREATE PROC SP_InChiTietHoaDon(@maHD nvarchar(10))
AS
BEGIN
	SELECT cthd.maHD,nv.tenNV,kh.maKH,kh.tenKH,hd.maHD,kho.tenSP,kho.donGia,cthd.soLuong,hd.ngayLapHD, (cthd.soLuong*kho.donGia) as Tong
	FROM NhanVien nv, HoaDon hd, KhachHang kh, KhoHang kho,ChiTietHoaDon cthd
	WHERE hd.maHD = @maHD and nv.maNV = hd.maNV and kh.maKH = hd.maKH and kho.maSP = cthd.maSP and cthd.maHD = hd.maHD and cthd.soLuong>0
END
GO

EXEC SP_InChiTietHoaDon 'HD01'
GO
exec SP_SelectKhachHangByID 'KH01'
GO
---FUNCTION lấy giá khi biết ID
CREATE FUNCTION FC_LayGiaByID(@MaSP nvarchar(10))
RETURNS FLOAT
AS
BEGIN
	DECLARE @GIA FLOAT
	SELECT @GIA = donGia
	FROM KhoHang
	WHERE maSP=@MaSP
	RETURN @GIA
END
GO
---PROC Lấy giá khi biết ID hóa đơn
CREATE PROC SP_LayGiaSPByID(@maSP varchar(10))
AS
	BEGIN
	DECLARE @TIEN nvarchar(10)
	select @TIEN = dbo.FC_LayGiaByID(@maSP)
	select @TIEN
END
GO
---PROC đăng nhập tài khoản
CREATE PROC SP_Login(@maNV varchar(10),@matKhau varchar(50))
AS
	BEGIN
	SELECT * FROM NhanVien 
	WHERE maNV = @maNV AND matKhau = @matKhau
	END
GO

--TẠO FUNCTION ĐẾM SỐ HÀNG THEO ID SẢN PHẨM TRONG KHO
CREATE FUNCTION FC_DemHangHoa(@maSP varchar(10))
RETURNS VARCHAR(5)
AS	
	BEGIN
	DECLARE @soLuong varchar(5)
	SELECT @soLuong = soLuong
	FROM KhoHang
	WHERE maSP=@maSP
	RETURN @soLuong
	END
GO
--TẠO PROC KIỂM TRA SỐ LƯỢNG KHI XUẤT KHO
CREATE PROC SP_checkSoLuong(@maSP varchar(10))
AS
	BEGIN
	DECLARE @SOLUONG VARCHAR(5)
	SELECT @SOLUONG = DBO.FC_DemHangHoa(@maSP)
	SELECT @SOLUONG
	END
GO
--TẠO PROC CẬP NHẬT THÔNG TIN SẢN PHẨM
CREATE PROC SP_UpdateSanPham(@maSP nvarchar(10),@tenSP nvarchar(100),@nhaSX nvarchar(20),@loaiHang int,@donViTinh nvarchar(10),@donGia float)
AS
BEGIN
	UPDATE KhoHang SET tenSP=@tenSP,nhaSX=@nhaSX,loaiHang=@loaiHang,donViTinh=@donViTinh,donGia=@donGia
	WHERE maSP=@maSP
END
GO
--TẠO PROC LẤY CHI TIẾT HÓA ĐƠN BẰNG MÃ HÓA ĐƠN
CREATE PROC SP_SelectChiTietHoaDonByID(@maHD varchar(10))
AS
BEGIN
	SELECT * FROM ChiTietHoaDon
	WHERE maHD=@maHD
END
GO
---Tạo PROC IN HÓA ĐƠN THEO NGÀY TÙY CHỌN
CREATE PROC SP_InHoaDonTheoThoiGian(@ngayBatDau DATE,@ngayKetThuc DATE)
AS
	BEGIN
	SELECT HD.maHD AS N'MÃ HÓA ĐƠN', NV.tenNV AS N'TÊN NHÂN VIÊN', KH.tenKH AS N'TÊN KHÁCH HÀNG', HD.ngayLapHD AS N'NGÀY LẬP HÓA ĐƠN'
	FROM HoaDon HD JOIN KhachHang KH
	ON HD.maKH=KH.maKH JOIN NhanVien NV
	ON NV.maNV=HD.maNV
	WHERE HD.ngayLapHD>=@ngayBatDau AND HD.ngayLapHD<=@ngayKetThuc
	END
GO
-- PROC LẤY SẢN PHẨM CÒN HÀNG
CREATE PROC SP_SelectSanPhamCon
AS
BEGIN
	SELECT maSP, tenSP, donGia FROM KhoHang
	WHERE soLuong>0
END
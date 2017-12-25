create schema bookmanagementdatabase;
use bookmanagementdatabase;
#drop database bookmanagementdatabase;

######## PHIEUNHAP TABLE ################
create table PHIEUNHAP
(
	MaPhieuNhap char(10) not null,
    NgayNhap date,
    
    primary key(MaPhieuNhap)
);

######## THELOAI TABLE ################
create table THELOAI
(
	MaTheLoai char(10) not null,
    TenTheLoai char(100),

    primary key(MaTheLoai)
);

######## SACH TABLE ################
create table SACH
(
	MaSach char(10) not null,
    TenSach char(100),
    TheLoai char(50),
    TacGia char(100),
    SoLuongTon int,
    DonGia decimal,
    TinhTrang bool, #removed or haven't been removed, true means haven't been removed
    
    primary key(MaSach)
);


DELIMITER //
Create Procedure InsertBook(in _MaSach char(10), in _TenSach char(100),in _TheLoai char(50), in _TacGia char(100), in _SoLuongTon int, 
							in _DonGia decimal, in _TinhTrang bool)
Begin
	Insert into SACH values(_MaSach, _TenSach, _TheLoai, _TacGia, _SoLuongTon, _DonGia, _TinhTrang);
End //
DELIMITER ;

DELIMITER //
Create Procedure UpdateBook(in _MaSach char(10), in _TenSach char(100),in _TheLoai char(50), in _TacGia char(100), in _DonGia decimal)
Begin
	update SACH set TenSach=_TenSach,TheLoai=_TheLoai, TacGia=_TacGia,DonGia=_DonGia where MaSach=_MaSach;
End //
DELIMITER ;

DELIMITER //
Create Procedure UpdateBookInventory(in _MaSach char(10), in _SoLuong int)
Begin
	update SACH set SoLuongTon = SoLuongTon + _SoLuong where MaSach=_MaSach;
End //
DELIMITER ;

DELIMITER //
Create Procedure FindBook(in _MaSach char(10), in _TinhTrang bool)
Begin	
   
    select *
    from SACH
    where MaSach = _MaSach and TinhTrang = _TinhTrang;
          	
End //
DELIMITER ;

DELIMITER //
Create Procedure FindBooks(in _MaSach char(10), in _TenSach char(100),in _TheLoai char(50), in _TacGia char(100), 
							in _DonGia decimal, in _DonGiaCompareType varchar(2), in _SoLuongTon int, in _SoLuongTonCompareType varchar(2), in _TinhTrang bool)
Begin	
    Create temporary table DonGiaTable (MaSach char(10));
    
    case _DonGiaCompareType 
		when '=' then insert into DonGiaTable select maSach from Sach where DonGia = _DonGia;
        when '>' then insert into DonGiaTable select maSach from Sach where DonGia > _DonGia;
        when '>=' then insert into DonGiaTable select maSach from Sach where DonGia >= _DonGia;
        when '<' then insert into DonGiaTable select maSach from Sach where DonGia < _DonGia;
        when '<=' then insert into DonGiaTable select maSach from Sach where DonGia <= _DonGia;
	end case;
	
	Create temporary table SoLuongTonTable (MaSach char(10));
    
     case _SoLuongTonCompareType 
		when '=' then insert into SoLuongTonTable select maSach from Sach where SoLuongTon = _SoLuongTon;
        when '>' then insert into SoLuongTonTable select maSach from Sach where SoLuongTon > _SoLuongTon;
        when '>=' then insert into SoLuongTonTable select maSach from Sach where SoLuongTon >= _SoLuongTon;
        when '<' then insert into SoLuongTonTable select maSach from Sach where SoLuongTon < _SoLuongTon;
        when '<=' then insert into SoLuongTonTable select maSach from Sach where SoLuongTon <= _SoLuongTon;
        when '=' then insert into SoLuongTonTable select maSach from Sach where SoLuongTon = _SoLuongTon;
	end case;
    
    select MaSach As 'Mã Sách', TenSach As 'Tên Sách', TheLoai As 'Thể Loại',TacGia As 'Tác Giả',SoLuongTon As 'Số Lượng Tồn', 
																				CONCAT('',Format(DonGia,0), ' đ') As 'Đơn Giá' 
    from SACH
    where MaSach like CONCAT('%', _MaSach, '%') and TenSach like CONCAT('%', _TenSach, '%') and TheLoai like CONCAT('%', _TheLoai, '%') and 
          TacGia like CONCAT('%', _TacGia, '%') and TinhTrang = _TinhTrang and MaSach in (select MaSach from DonGiaTable) and MaSach in (select MaSach from SoLuongTonTable);
	
    drop table DonGiaTable;
    drop table SoLuongTonTable;
End //
DELIMITER ;

DELIMITER //
Create Procedure UpdateBookStatus(in _MaSach char(10), in _TinhTrang bool)
Begin
	update SACH set TinhTrang = _TinhTrang where MaSach=_MaSach;
End //
DELIMITER ;


######## KHACHHANG TABLE ################
create table KHACHHANG
(
	MaKhachHang char(10) not null,
    HoTenKhachHang char(100),
    DiaChi char(100),
    DienThoai char(20),
    Email char(50),
    SoTienNo decimal,
    TinhTrang bool, #removed or haven't been removed
    primary key(MaKhachHang)
);


DELIMITER //
Create Procedure InsertCustomer(in _MaKhachHang char(10), in _TenKhachHang char(100),in _DiaChi char(100), in _DienThoai char(20), 
								in _Email char(50),in _SoTienNo decimal, in _TinhTrang bool)
Begin
	insert into KHACHHANG values(_MaKhachHang,_TenKhachHang,_DiaChi,_DienThoai,_Email,_SoTienNo,_TinhTrang);
End //
DELIMITER ;

DELIMITER //
Create Procedure UpdateCustomer(in _MaKhachHang char(10), in _TenKhachHang char(100),in _DiaChi char(100), in _DienThoai char(20), in _Email char(50))
Begin
	update KhachHang set HoTenKhachHang=_TenKhachHang,DiaChi=_DiaChi, DienThoai=_DienThoai ,Email=_Email where MaKhachHang=_MaKhachHang;
End //
DELIMITER ;

DELIMITER //
Create Procedure UpdateCustomerDebt(in _MaKhachHang char(10), in _SoTien decimal)
Begin
	update KhachHang set SoTienNo=SoTienNo + _SoTien where MaKhachHang=_MaKhachHang;
End //
DELIMITER ;

DELIMITER //
Create Procedure FindCustomer(in _MaKhachHang char(10), in _TinhTrang bool)
Begin	
   
    select *
    from KHACHHANG
    where MaKhachHang = _MaKhachHang and TinhTrang = _TinhTrang;
          	
End //
DELIMITER ;

DELIMITER //
Create Procedure FindCustomers(in _MaKhachHang char(10), in _TenKhachHang char(100),in _DiaChi char(100), in _DienThoai char(20), 
							in _Email char(50), in _SoTienNo decimal, in _SoTienNoCompareType varchar(2), in _TinhTrang bool)
Begin	
    Create temporary table SoTienNoTable (MaKhachHang char(10));
    
    case _SoTienNoCompareType 
		when '=' then insert into SoTienNoTable select MaKhachHang from KhachHang where SoTienNo = _SoTienNo;
        when '>' then insert into SoTienNoTable select MaKhachHang from KhachHang where SoTienNo > _SoTienNo;
        when '>=' then insert into SoTienNoTable select MaKhachHang from KhachHang where SoTienNo >= _SoTienNo;
        when '<' then insert into SoTienNoTable select MaKhachHang from KhachHang where SoTienNo < _SoTienNo;
        when '<=' then insert into SoTienNoTable select MaKhachHang from KhachHang where SoTienNo <= _SoTienNo;
	end case;

    
    select MaKhachHang As 'Mã Khách Hàng', HoTenKhachHang As 'Họ Tên Khách Hàng', DiaChi As 'Địa Chỉ',DienThoai As 'Điện Thoại', Email As 'Email',
																										CONCAT('',Format(SoTienNo,0), ' đ') As 'Số Tiền Nợ' 
	from KhachHang 
	where MaKhachHang like CONCAT('%', _MaKhachHang, '%') and  HoTenKhachHang like CONCAT('%', _TenKhachHang, '%') and DiaChi like CONCAT('%', _DiaChi, '%') and 
          DienThoai like CONCAT('%', _DienThoai, '%') and Email like CONCAT('%', _Email, '%') and TinhTrang = _TinhTrang and MaKhachHang in (select MaKhachHang from SoTienNoTable);
	
    drop table SoTienNoTable;
  
End //
DELIMITER ;


DELIMITER //
Create Procedure UpdateCustomerStatus(in _MaKhachHang char(10), in _TinhTrang Bool)
Begin
	update KhachHang set TinhTrang = _TinhTrang where MaKhachHang=_MaKhachHang;
End //
DELIMITER ;

######## CHITIETPHIEUNHAP TABLE ################
create table CHITIETPHIEUNHAP
(
	MaChiTietPhieuNhap char(10) not null,
    MaPhieuNhap char(10),
    MaSach char(10),
    SoLuongNhap int,
    
    primary key(MaChiTietPhieuNhap),
    foreign key(MaPhieuNhap) references PHIEUNHAP(MaPhieuNhap),
    foreign key(MaSach) references SACH(MaSach)
);

######## PHIEUHOADON TABLE ################
create table PHIEUHOADON
(
	MaPhieuHoaDon char(10) not null,
    MaKhachHang char(10),
    NgayLapHoaDon date,
    
    primary key(MaPhieuHoaDon),
    foreign key(MaKhachHang) references KHACHHANG(MaKhachHang)
);


######## CHITIETPHIEUHD TABLE ################
create table CHITIETPHIEUHD
(
	MaChiTietPhieuHoaDon char(10) not null,
    MaPhieuHoaDon char(10),
    MaSach char(10),
    SoLuongBan int,
    
    primary key(MaChiTietPhieuHoaDon),
    foreign key(MaSach) references SACH(MaSach),
    foreign key(MaPhieuHoaDon) references PHIEUHOADON(MaPhieuHoaDon)
);


######## PHIEUTHUTIEN TABLE ################
create table PHIEUTHUTIEN
(
	MaPhieuThu char(10) not null,
    SoTienThu decimal,
    NgayThuTien date,
    MaKhachHang char(10),
    
    primary key(MaPhieuThu),
    foreign key(MaKhachHang) references KHACHHANG(MaKhachHang)
);


######## BAOCAOTON TABLE ################
create table BAOCAOTON
(
	MaBaoCaoTon char(10) not null,
    Thang int,
    Nam int,
    
    primary key(MaBaoCaoTon)
);

######## CHITIETTON TABLE ################
create table CHITIETTON
(
	MaChiTietTon char(10) not null,
    MaBaoCaoTon char(10),
    MaSach char(10),
    TonDau int,
    TonPhatSinh int,
    TonCuoi int,
    
    primary key(MaChiTietTon),
	foreign key(MaBaoCaoTon) references BAOCAOTON(MaBaoCaoTon),
    foreign key(MaSach) references SACH(MaSach)
);

######## BAOCAOCONGNO TABLE ################
create table BAOCAOCONGNO
(
	MaBaoCaoCongNo char(10) not null,
    Thang int,
    Nam int,
    
    primary key(MaBaoCaoCongNo)
);

######## CHITIETCONGNO TABLE ################
create table CHITIETCONGNO
(
	MaChiTietCongNo char(10) not null,
	MaBaoCaoCongNo char(10),
    MaKhachHang char(10),
    NoDau decimal,
	NoPhatSinh decimal,
    NoCuoi decimal,
    
    primary key(MaChiTietCongNo),
    foreign key(MaKhachHang) references KHACHHANG(MaKhachHang),
    foreign key(MaBaoCaoCongNo) references BAOCAOCONGNO(MaBaoCaoCongNo)
);


######## THAMSO TABLE ################
create table THAMSO
(
	SoLuongNhapToiThieu int,
    SoLuongTonToiDaTruocNhap int,
    SoLuongTonSauToiThieu int,
    SoTienNoToiDa decimal,
    SuDungQuyDinh4 bool
);

Insert into THAMSO values(10,300,5,50000,False);


####### Sample #####################
call insertbook('MS0001','Thần đồng đất việt','Hài hước','KIM ĐỒNG','50','50000',true);
call insertbook('MS0002','Conan','Trinh Thám','Nhật Bản','100','70000',true);
call insertbook('MS0003','One punch man','Hài hước, Hành động','Nhật Bản','200','50000',true);
call insertbook('MS0004','Awkward Or Cute','Tình cảm','comicola','20','80000',true);
call insertbook('MS0005','Awkward Or Cute 2','Tình cảm','comicola','200','80000',true);
call insertbook('MS0006','Mèo mun đen','Hài hước','comicola','300','50000',true);

call insertcustomer('KH0001','Nông Văn Giền','Sô 16, Quang Trung, HCM','0905777888','NongVanLam@yahoo.com','0',true);
call insertcustomer('KH0002','Trương Quang Thắng','Số 2, Khởi Nghĩa, Hà Nội','0934123456','alwayss@yahoo.com','10000',true);
call insertcustomer('KH0003','Jame Bond','Australia','0905123444','Jame123@yahoo.com','0',true);
call insertcustomer('KH0004','David Truong','Sô 15, Nam Kì, HCM','0905777443','davidNhim@yahoo.com','20000',true);
call insertcustomer('KH0005','Nông Văn Lâm','Sô 16, Quang Đào, HCM','0906134543','NongVanGien@yahoo.com','0',true);

insert into theloai values('TL00000001','Hài hước');
insert into theloai values('TL00000002','Trinh thám');
insert into theloai values('TL00000003','Tình cảm');
insert into theloai values('TL00000004','Hành động');
insert into theloai values('TL00000005','Harem');
insert into theloai values('TL00000006','Phép thuật');
insert into theloai values('TL00000007','Kinh dị');
insert into theloai values('TL00000008','Phiêu lưu');

insert into phieunhap values('PN00000001','2017-06-05');
insert into phieunhap values('PN00000002','2017-06-06');

insert into chitietphieunhap values('CN00000001','PN00000001','MS0001','50');
insert into chitietphieunhap values('CN00000002','PN00000001','MS0002','100');
insert into chitietphieunhap values('CN00000003','PN00000001','MS0003','200');
insert into chitietphieunhap values('CN00000004','PN00000002','MS0004','20');
insert into chitietphieunhap values('CN00000005','PN00000002','MS0005','200');
insert into chitietphieunhap values('CN00000006','PN00000002','MS0006','300');

insert into baocaoton values('BT00000001','6','2017');
insert into chitietton values('CT00000001','BT00000001','MS0001','0','50','50');
insert into chitietton values('CT00000002','BT00000001','MS0002','0','100','100');
insert into chitietton values('CT00000003','BT00000001','MS0003','0','200','200');
insert into chitietton values('CT00000004','BT00000001','MS0004','0','20','20');
insert into chitietton values('CT00000005','BT00000001','MS0005','0','200','200');
insert into chitietton values('CT00000006','BT00000001','MS0006','0','300','300');


insert into baocaocongno values('BN00000001','6','2017');
insert into chitietcongno values('CN00000001','BN00000001','KH0001','0','0','0');
insert into chitietcongno values('CN00000002','BN00000001','KH0002','0','10000','10000');
insert into chitietcongno values('CN00000003','BN00000001','KH0003','0','20000','20000');
insert into chitietcongno values('CN00000004','BN00000001','KH0004','0','0','0');














                                      
                                      
                                      

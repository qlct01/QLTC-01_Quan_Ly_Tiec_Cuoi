use qltc;

SET GLOBAL event_scheduler = ON;

DROP EVENT IF EXISTS `back_up_thong_tin`;
DELIMITER $$
CREATE DEFINER=`root`@`localhost` EVENT `back_up_thong_tin` 
ON SCHEDULE EVERY 1 DAY 
STARTS '2019-04-13 23:59:59' ON COMPLETION PRESERVE ENABLE DO
BEGIN

INSERT INTO bkdt2019 (MaDatTiec, MaDSTiec, MaGD, MaCa, TienDatCoc, SoBanDuTru, TrangThai, TinhTrang, BKTime, DeleteTime) 
SELECT MaDatTiec, MaDSTiec, MaGD, MaCa, TienDatCoc, SoBanDuTru, TrangThai, TinhTrang, NOW(), NOW() + INTERVAL 4 YEAR
FROM dat_tiec
order by MaDatTiec;


INSERT INTO bkct_dat_tiec2019 (MaCT_DatTiec, MaDatTiec, MaMon, MaDV, BKTime, DeleteTime) 
SELECT MaCT_DatTiec, MaDatTiec, MaMon, MaDV, NOW(), NOW() + INTERVAL 4 YEAR
FROM ct_dat_tiec
order by MaCT_DatTiec;


INSERT INTO bkhoadon2019 (MaHD, MaDatTiec, TongTienBan, NgayThanhToan, TrangThai, BKTime, DeleteTime) 
SELECT MaHD, MaDatTiec, TongTienBan, NgayThanhToan, TrangThai, NOW(), NOW() + INTERVAL 4 YEAR
FROM hoa_don
order by MaHD;


INSERT INTO bkct_hoa_don2019 (MaCT_HD, MaHD, MaDatTiec, TongTienDV, TongTienHoaDon, TienDatCoc, ConLai, BKTime, DeleteTime) 
SELECT MaCT_HD, MaHD, MaDatTiec, TongTienDV, TongTienHoaDon, TienDatCoc, ConLai, NOW(), NOW() + INTERVAL 4 YEAR
FROM ct_hoa_don
order by MaCT_HD;


INSERT INTO bkdstiec2019 (MaDSTiec, MaGD, MaSanh, Ngay, Gio, SoLuongBan, BKTime, DeleteTime) 
SELECT MaDSTiec, MaGD, MaSanh, Ngay, Gio, SoLuongBan, NOW(), NOW() + INTERVAL 4 YEAR
FROM ds_tiec_cuoi
order by MaDSTiec;

END;


DROP EVENT IF EXISTS `xoa_thong_tin`;
DELIMITER $$
CREATE DEFINER=`root`@`localhost` EVENT `xoa_thong_tin` 
ON SCHEDULE EVERY 4 YEAR 
STARTS '2019-04-13 23:59:59' ON COMPLETION PRESERVE ENABLE DO
BEGIN

DELETE FROM `qltc`.`dat_tiec`;

DELETE FROM `qltc`.`ct_dat_tiec`;

DELETE FROM `qltc`.`hoa_don`;

DELETE FROM `qltc`.`ct_hoa_don`;

DELETE FROM `qltc`.`ds_tiec_cuoi`;

END;


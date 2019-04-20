use qltc;

DROP TRIGGER IF EXISTS `qltc`.`tai_khoan_AFTER_UPDATE`;

DELIMITER $$
USE `qltc`$$
CREATE DEFINER = CURRENT_USER TRIGGER `qltc`.`tai_khoan_AFTER_UPDATE` AFTER UPDATE ON `tai_khoan` FOR EACH ROW
BEGIN
	update `qltc`.`gia_dinh`
    set SDT = NEW.SDT
    WHERE SDT = OLD.SDT;
END$$
DELIMITER ;
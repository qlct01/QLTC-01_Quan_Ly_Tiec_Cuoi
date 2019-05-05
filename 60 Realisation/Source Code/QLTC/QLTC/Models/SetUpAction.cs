using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTC.Models
{
    public class SetUpAction
    {
        public static int MaSanh = 0;
        public static int MaCa = 0;
        public static int MaGD = 0;

        public static int soLuongBanToiDa = 0;

        public static List<int> dsMaMon = new List<int>();
        public static List<int> dsMaDV = new List<int>();
        
        public static int maHD = 0;
        public static int maDSTiec = 0;
        public static int maDattiec = 0;

        private float tongTienBan = 0;
        private float tongTienDV = 0;

        public void SaveDSTiec(int maSanh, string ngay, string gio, int soLuongBan)
        {
            using (var db = new QLTCEntities())
            {
                gia_dinh gd = db.gia_dinh.Where(m => m.SDT == TaiKhoanAction.sdt).Single();

                MaGD = gd.MaGD;

                ds_tiec_cuoi dstc = new ds_tiec_cuoi()
                {
                    MaSanh = maSanh,
                    MaGD = MaGD,
                    Ngay = ngay,
                    Gio = gio,
                    SoLuongBan = soLuongBan
                };

                db.ds_tiec_cuoi.Add(dstc);
                
                db.SaveChanges();
                
                maDSTiec = dstc.MaDSTiec;
            }
        }

        public void SaveDatTiec(int maCa, float tienDatCoc, int soBanDuTru)
        {
            using (var db = new QLTCEntities())
            {
                dat_tiec dt = new dat_tiec()
                {
                    TinhTrang = "da thanh toan",
                    TrangThai = false,
                    MaDSTiec = maDSTiec,
                    MaGD = MaGD,
                    MaCa = maCa,
                    TienDatCoc = tienDatCoc,
                    SoBanDuTru = soBanDuTru
                };
                db.dat_tiec.Add(dt);

                db.SaveChanges();

                maDattiec = dt.MaDatTiec;
            }
        }

        public void SaveCTDatTiec()
        {
            using (var db = new QLTCEntities())
            {
                foreach (var item in dsMaMon)
                {
                    ct_dat_tiec ctdt = new ct_dat_tiec()
                    {
                        MaDatTiec = maDattiec,
                        MaMon = item,
                    };
                    db.ct_dat_tiec.Add(ctdt);

                    db.SaveChanges();
                }

                foreach (var item in dsMaDV)
                {
                    ct_dat_tiec ctdt = new ct_dat_tiec()
                    {
                        MaDatTiec = maDattiec,
                        MaDV = item,
                    };
                    db.ct_dat_tiec.Add(ctdt);

                    db.SaveChanges();
                }
            }
        }

        public void SaveHoaDon(int soLuongBan, int soBanDuTru, string ngayThanhToan)
        {
            tongTienBan = TongTienBan(soLuongBan, soBanDuTru);

            using (var db = new QLTCEntities())
            {
                hoa_don hd = new hoa_don()
                {
                    MaDatTiec = maDattiec,
                    TongTienBan = tongTienBan,
                    NgayThanhToan = ngayThanhToan,
                    TrangThai = false
                };
                db.hoa_don.Add(hd);

                db.SaveChanges();

                maHD = hd.MaHD;
            }
        }

        public void SaveCTHoaDon(float tienDatCoc)
        {
            tongTienDV = TongTienDV();

            float tongTienHD = TongTienHoaDon();

            float conlai = tongTienHD - tienDatCoc;

            using (var db = new QLTCEntities())
            {
                ct_hoa_don ct = new ct_hoa_don()
                {
                    MaDatTiec = maDattiec,
                    MaHD = maHD,
                    TongTienDV = tongTienDV,
                    TongTienHoaDon = tongTienHD,
                    TienDatCoc = tienDatCoc,
                    ConLai = conlai
                };
                db.ct_hoa_don.Add(ct);
                db.SaveChanges();
            }
        }


        
        public float TongTienBan(int soLuongBan, int soBanDuTru)
        {
            float tong = 0;
            using (var db = new QLTCEntities())
            {
                ds_sanh s = db.ds_sanh.Find(MaSanh);
                tong = Convert.ToSingle((soBanDuTru + soLuongBan) * s.DonGiaBanToiThieu);
            }
            return tong;
        }

        public float TongTienDV()
        {
            float tong = 0;
            using (var db = new QLTCEntities())
            {
                foreach (int item in dsMaDV)
                {
                    dich_vu d = db.dich_vu.Find(item);
                    tong += Convert.ToSingle(d.Gia);
                }
            }
            return tong;
        }

        public float TongTienHoaDon()
        {
            float tongTienMon = 0;
            float tong = 0;

            using (var db = new QLTCEntities())
            {
                foreach (int item in dsMaMon)
                {
                    mon_an d = db.mon_an.Find(item);
                    tongTienMon += Convert.ToSingle(d.Gia);
                }
            }

            tong = tongTienMon + tongTienBan + tongTienDV;

            return tong;
        }

        public bool KiemTra(string ngay, int maca)
        {
            using (var db = new QLTCEntities())
            {
                var query = (from m in db.ds_tiec_cuoi
                             join n in db.dat_tiec on m.MaDSTiec equals n.MaDSTiec
                             select new { m.MaSanh, n.MaCa, m.Ngay}).ToList();

                foreach (var item in query)
                {
                    if(item.Ngay == ngay && item.MaSanh == MaSanh && item.MaCa == maca)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
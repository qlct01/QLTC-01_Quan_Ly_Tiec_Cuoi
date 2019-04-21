using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTC.Models;

namespace QLTC.Controllers
{
    public class LichSuController : Controller
    {
        // GET: LichSu
        public ActionResult LichSu()
        {
            if (Notice.logIn)
            {
                LichSuGiaoDichList ls_L = new LichSuGiaoDichList();

                using (var db = new QLTCEntities())
                {

                    var query = (from m in db.gia_dinh
                                 join n in db.dat_tiec on m.MaGD equals n.MaGD
                                 join s in db.ct_dat_tiec on n.MaDatTiec equals s.MaDatTiec
                                 join t in db.hoa_don on n.MaDatTiec equals t.MaDatTiec
                                 join r in db.ct_hoa_don on n.MaDatTiec equals r.MaDatTiec
                                 where m.SDT == TaiKhoanAction.sdt && n.TrangThai == false
                                 select new { n.MaDatTiec, r.TienDatCoc, t.TongTienBan, r.TongTienHoaDon, t.NgayThanhToan }).Distinct();
                    
                    foreach(var item in query)
                    {
                        LichSuGiaoDich l = new LichSuGiaoDich()
                        {
                            MaDatTiec = item.MaDatTiec,
                            NgayThanhToan = item.NgayThanhToan,
                            TienDatCoc = Convert.ToDouble(item.TienDatCoc),
                            TongTienBan = Convert.ToDouble(item.TongTienBan),
                            TongTienHD = Convert.ToDouble(item.TongTienHoaDon)
                        };
                        ls_L.lichSu_List.Add(l);
                    }
                    
                    return View(ls_L);
                }
            }
            else return View();
        }


        public ActionResult Submit(string chitiet, string huy, int madattiec)
        {
            if (chitiet != null)
            {
                LichSuAction.MaDatTiec = madattiec;

                using (var db = new QLTCEntities())
                {
                    var query = (from m in db.dat_tiec
                                 join n in db.ds_tiec_cuoi on m.MaDSTiec equals n.MaDSTiec
                                 join s in db.ds_sanh on n.MaSanh equals s.MaSanh
                                 join g in db.gia_dinh on m.MaGD equals g.MaGD
                                 where m.MaDatTiec == madattiec
                                 select new { s.TenSanh, g.TenChuRe, g.TenCoDau }).Single();

                    LichSuAction.TenSanh = query.TenSanh;
                    LichSuAction.TenCoDau = query.TenCoDau;
                    LichSuAction.TenChuRe = query.TenChuRe;
                }

                return RedirectToAction("CTLichSu", "LichSu");
            }
            else if (Notice.CancelSetUp == true || huy != null)
            {
                using (var db = new QLTCEntities())
                {
                    dat_tiec dt = db.dat_tiec.Where(m => m.MaDatTiec == madattiec).Single();

                    dt.TrangThai = true;

                    db.SaveChanges();
                }
                return RedirectToAction("LichSu", "LichSu");
            }
            else return View();
        }


        public ActionResult CTLichSu()
        {
            if (Notice.logIn)
            {
                LichSuGiaoDichList ls_L = new LichSuGiaoDichList();

                using (var db = new QLTCEntities())
                {

                    var query = (from m in db.ct_dat_tiec
                                 join s in db.dich_vu on m.MaDV equals s.MaDV
                                 where m.MaDatTiec == LichSuAction.MaDatTiec
                                 select new { s.TenDV});

                    var query1 = (from m in db.ct_dat_tiec
                                 join s in db.mon_an on m.MaMon equals s.MaMon
                                 where m.MaDatTiec == LichSuAction.MaDatTiec
                                 select new { s.TenMon });

                    foreach (var item in query)
                    {
                        ChiTietLichSu l = new ChiTietLichSu()
                        {
                            TenDV = item.TenDV
                        };
                        ls_L.ctLichSu_List.Add(l);
                    }

                    foreach (var item in query1)
                    {
                        ChiTietLichSu l = new ChiTietLichSu()
                        {
                            TenMon = item.TenMon
                        };
                        ls_L.ctLichSu_List.Add(l);
                    }
                }
                return View(ls_L);
            }
            else return View();
        }
    }
}
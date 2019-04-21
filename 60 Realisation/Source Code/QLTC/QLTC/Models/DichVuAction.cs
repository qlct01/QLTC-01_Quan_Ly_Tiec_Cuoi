using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTC.Models
{
    public class DichVuAction
    {
        public static int maDV = 0;

        public void ThemDV(string tendv, int soluong, float gia)
        {
            using (var db = new QLTCEntities())
            {
                dich_vu dv = new dich_vu();
                dv.TenDV = tendv;
                dv.SoLuong = soluong;
                dv.Gia = gia;
                dv.TrangThai = false;
                db.dich_vu.Add(dv);
                db.SaveChanges();
            }
        }

        public void SuaDichVu(string tendv, int soluong, float gia)
        {
            using (var db = new QLTCEntities())
            {
                dich_vu dv = (from m in db.dich_vu
                              where m.MaDV == DichVuAction.maDV
                              select m).Single();
                dv.TenDV = tendv;
                dv.SoLuong = soluong;
                dv.Gia = gia;                
                db.SaveChanges();
            }
            //using (var db = new QLTCEntities())
            //{
            //    try
            //    {
            //        bool found = db.dich_vu.Any(m => m.TenDV == tendv);

            //        if (!found)
            //        {
            //            dich_vu a = (from m in db.dich_vu
            //                         where m.MaDV == DichVuAction.maDV
            //                         select m).Single();
            //            a.TenDV = tendv;
            //            a.SoLuong = soluong;
            //            a.Gia = gia;
            //            db.SaveChanges();
            //        }
            //    }
            //    catch
            //    {

            //    }
            //}
        }

        public void Xoa()
        {
            using (var db = new QLTCEntities())
            {
                try
                {
                    dich_vu a = (from m in db.dich_vu
                                 where m.MaDV == DichVuAction.maDV
                                 select m).Single();
                    a.TrangThai = true;
                    db.SaveChanges();
                }
                catch { }
            }
        }
    }
}

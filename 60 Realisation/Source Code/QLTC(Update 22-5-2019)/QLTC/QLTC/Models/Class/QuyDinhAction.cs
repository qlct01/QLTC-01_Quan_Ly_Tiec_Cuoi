using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLTC.Models
{
    public class QuyDinhAction
    {
        public static int maThamSo = 0;

        public void ThemQuyDinh(string tenquydinh, float gia)
        {
            using (var db = new QLTCEntities())
            {
                tham_so a = new tham_so();
                Random random = new Random();
                a.MaThamSo = random.Next(0, 100);
                a.TenThamSo = tenquydinh;
                a.GiaTri = gia;
                db.tham_so.Add(a);
                db.SaveChanges();
            }
        }

        public void SuaQuyDinh(string tenquydinh, float gia)
        {
            using (var db = new QLTCEntities())
            {
                try
                {
                    tham_so a = (from m in db.tham_so
                                 where m.MaThamSo == QuyDinhAction.maThamSo
                                 select m).Single();
                    a.TenThamSo = tenquydinh;
                    a.GiaTri = gia;
                    db.SaveChanges();
                }
                catch
                {

                }
            }
        }

        public void XoaQuyDinh()
        {
            using (var db = new QLTCEntities())
            {
                try
                {
                    tham_so a = (from m in db.tham_so
                                 where m.MaThamSo == QuyDinhAction.maThamSo
                                 select m).Single();
                    db.tham_so.Remove(a);
                    db.SaveChanges();
                }
                catch
                {

                }
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTC.Models
{
    public class MonAnAction
    {
        public static int maMon = 0;


        public void ThemMonAn(string tenmon, float gia, string ghichu)
        {
            using (var db = new QLTCEntities())
            {
                mon_an a = new mon_an();
                a.TenMon = tenmon;
                a.Gia = gia;                
                a.GhiChu = ghichu;
                a.TrangThai = false;
                db.mon_an.Add(a);
                db.SaveChanges();
            }
        }

        public void SuaMonAn(string tenmon, float gia, string ghichu)
        {
            using (var db = new QLTCEntities())
            {
                try
                {
                    bool found = db.mon_an.Any(m => m.TenMon == tenmon);

                    if (!found)
                    {
                        mon_an a = (from m in db.mon_an
                                    where m.MaMon == MonAnAction.maMon
                                    select m).Single();
                        a.TenMon = tenmon;
                        a.Gia = gia;
                        a.GhiChu = ghichu;
                        db.SaveChanges();
                    }
                }
                catch
                {

                }
            }
        }

        public void XoaMonAn()
        {
            using (var db = new QLTCEntities())
            {
                try
                {
                    mon_an a = (from m in db.mon_an
                                where m.MaMon == MonAnAction.maMon
                                select m).Single();
                    a.TrangThai = true;
                    db.SaveChanges();
                }
                catch
                {

                }
            }

        }


    }
}
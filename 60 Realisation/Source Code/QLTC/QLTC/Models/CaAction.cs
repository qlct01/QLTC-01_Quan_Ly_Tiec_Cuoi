using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTC.Models
{
    public class CaAction
    {
        public static int maCa = 0;

        public void ThemCa(string tenca)
        {
            using (var db = new QLTCEntities())
            {
                ca CA = new ca();
                CA.TenCa = tenca;
                CA.TrangThai = false;
                db.cas.Add(CA);
                db.SaveChanges();
            }
        }

        public void SuaCa(string tenca)
        {
            using (var db = new QLTCEntities())
            {
                ca C = (from m in db.cas
                        where m.MaCa == CaAction.maCa
                        select m).Single();
                C.TenCa = tenca.ToLower();
                db.SaveChanges();
            }
        }

        public void XoaCa()
        {
            using (var db = new QLTCEntities())
            {
                try
                {
                    ca a = (from m in db.cas
                            where m.MaCa == CaAction.maCa
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
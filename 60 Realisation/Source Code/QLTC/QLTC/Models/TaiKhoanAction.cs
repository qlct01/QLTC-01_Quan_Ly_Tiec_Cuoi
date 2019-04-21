using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTC.Models
{
    public class TaiKhoanAction
    {
        public static string sdt = "";

        public void AddTaiKoanAndGiaDinh(string sdt, string tencodau, string tenchure)
        {
            using (var db = new QLTCEntities())
            {
                tai_khoan tk_N = new tai_khoan()
                {
                    SDT = sdt,
                    Password = "123"
                };
                db.tai_khoan.Add(tk_N);
                db.SaveChanges();


                gia_dinh gd = new gia_dinh()
                {
                    SDT = sdt,
                    TenChuRe = tenchure,
                    TenCoDau = tencodau
                };
                db.gia_dinh.Add(gd);
                db.SaveChanges();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTC.Models;

namespace QLTC.Controllers
{
    public class XemDSController : Controller
    {
        public ActionResult XemDS()
        {
            List<DSTiecCuoiList> model = new List<DSTiecCuoiList>();

            using (var db = new QLTCEntities())
            {
                var a = (from m in db.ds_tiec_cuoi
                         join n in db.ds_sanh on m.MaSanh equals n.MaSanh
                         join s in db.gia_dinh on m.MaGD equals s.MaGD
                         select new {s.SDT, s.TenChuRe, s.TenCoDau, n.TenSanh, m.Ngay, m.Gio, m.SoLuongBan });

                foreach (var item in a)
                {
                    model.Add(new DSTiecCuoiList()
                    {
                        tencodau = item.TenCoDau,
                        tenchure = item.TenChuRe,
                        ngay = item.Ngay,
                        gio = item.Gio,
                        tensanh = item.TenSanh,
                        sdt = item.SDT,
                        soluongban = Convert.ToInt32(item.SoLuongBan)
                    });
                }

                return View(model);
            }
        }
    }
}
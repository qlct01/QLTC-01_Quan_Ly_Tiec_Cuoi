using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTC.Models;

namespace QLTC.Controllers
{
    public class BaoCaoController : Controller
    {
        // GET: BaoCao
        public ActionResult BaoCao(string thang)
        {
            Notice.tongDoanhThu = 0;

            BaoCaoList model = new BaoCaoList();

            List<BaoCaoTemp> temp = new List<BaoCaoTemp>();
            List<BaoCaoTemp> temp1 = new List<BaoCaoTemp>();

            int i = 0;
            int soluongTiec = 0;
            double doanhThuNgay = 0;
            double tongDoanhThu = 0;

            if (thang != null)
            {
                using (var db = new QLTCEntities())
                {
                    var query = (from m in db.ds_tiec_cuoi
                                 join n in db.dat_tiec on m.MaDSTiec equals n.MaDSTiec
                                 join s in db.ct_hoa_don on n.MaDatTiec equals s.MaDatTiec
                                 select new { m.Ngay}).Distinct();

                    foreach (var item in query)
                    {
                        temp.Add(new BaoCaoTemp()
                        {
                            Ngay = item.Ngay,
                            NgayFormat = DateTime.Parse(item.Ngay).ToString("yyyy-MM"),
                        });
                    }

                    foreach (var item in temp)
                    {
                        if (item.NgayFormat == thang)
                        {
                            using (var dv = new QLTCEntities())
                            {
                                var found = (from m in dv.ds_tiec_cuoi
                                             join n in dv.dat_tiec on m.MaDSTiec equals n.MaDSTiec
                                             join s in dv.ct_hoa_don on n.MaDatTiec equals s.MaDatTiec
                                             where m.Ngay == item.Ngay && item.NgayFormat == thang
                                             select new { s.TongTienHoaDon });

                                foreach (var a in found)
                                {
                                    soluongTiec++;
                                    doanhThuNgay += Convert.ToDouble(a.TongTienHoaDon);
                                    tongDoanhThu += Convert.ToDouble(a.TongTienHoaDon);
                                }
                            }

                            temp1.Add(new BaoCaoTemp()
                            {
                                Ngay = item.Ngay,
                                NgayFormat = item.NgayFormat,
                                DoanhThu = doanhThuNgay,
                                SoLuongTiec = soluongTiec
                            });

                            soluongTiec = 0;
                            doanhThuNgay = 0;
                        }
                    }
                    model.baoCao_List = temp1;
                }
                Notice.tongDoanhThu = tongDoanhThu;
            }
            if (thang == null)
                return View();
            else return View(model);
        }
    }
}
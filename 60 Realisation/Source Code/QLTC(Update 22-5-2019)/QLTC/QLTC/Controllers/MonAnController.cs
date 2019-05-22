using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTC.Models;

namespace QLTC.Controllers
{
    public class MonAnController : Controller
    {

        MonAnAction monAn = new MonAnAction();

        public ActionResult MonAnM()
        {
            MonAnList monAnList = new MonAnList();
            using (var db = new QLTCEntities())
            {

                var a = (from b in db.mon_an
                         where b.TrangThai == false || b.TrangThai == null
                         select b);
                monAnList.mon_anM = a.ToList();
            }
            return View(monAnList);

        }

        [HttpPost]
        public ActionResult ProcessForm(string them, string sua)
        {
            if (sua != null)
            {
                return RedirectToAction("MonAnE", "MonAn");
            }
            else if (them != null)
            {
                return RedirectToAction("MonAnA", "MonAn");
            }

            else
            {
                return RedirectToAction("MonAnM", "MonAn");
            }

        }


        public ActionResult MonAnE()
        {
            return View();
        }

        public ActionResult MonAnA()
        {
            return View();
        }


        public ActionResult XacNhanThem(string tenmon, float gia, string ghichu)
        {
            if (tenmon != null && gia != 0 && ghichu != null)
            {
                monAn.ThemMonAn(tenmon, gia, ghichu);
            }
            return View();
        }


        public ActionResult XacNhanSua(string tenmon, float gia, string ghichu)
        {
            if (tenmon != "" && gia != 0 && ghichu != "")
            {
                monAn.SuaMonAn(tenmon, gia, ghichu);
            }
            return View();
        }

        public ActionResult Xoa(IEnumerable<int> itemSelected1)
        {
            foreach (var item in itemSelected1)
            {
                FindAnhSaveIdMonAn(item);
            }
            monAn.XoaMonAn();
            return RedirectToAction("MonAnM", "MonAn");
        }

        public ActionResult Sua(IEnumerable<int> itemSelected)
        {
            foreach (var item in itemSelected)
            {
                FindAnhSaveIdMonAn(item);
            }
            return RedirectToAction("MonAnE", "MonAn");
        }


        public void FindAnhSaveIdMonAn(int a)
        {
            try
            {
                using (var db = new QLTCEntities())
                {
                    var b = db.mon_an.Where(m => m.MaMon == a).Single();
                    MonAnAction.maMon = b.MaMon;
                }
            }
            catch
            {

            }
        }

    }
}
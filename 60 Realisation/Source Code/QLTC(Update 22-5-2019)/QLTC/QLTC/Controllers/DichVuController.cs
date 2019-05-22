using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTC.Models;

namespace QLTC.Controllers
{
    public class DichVuController : Controller
    {
        DichVuAction dichVu = new DichVuAction();
        public ActionResult DichVuM()
        {
            ModelList dichvulist = new ModelList();
            using (var db = new QLTCEntities())
            {
                var a = (from b in db.dich_vu
                         where b.TrangThai == null || b.TrangThai == false
                         select b);
                dichvulist.dich_vuM = a.ToList();
            }
            return View(dichvulist);
        }

        [HttpPost]
        public ActionResult ProcessForm(string them, string sua)
        {
            if (sua != null)
                return RedirectToAction("DichVuE", "DichVu");
            else if (them != null)
            {
                return RedirectToAction("DichVuA", "DichVu");
            }
            else
                return RedirectToAction("DichVuM", "DichVu");
        }

        public ActionResult DichVuA()
        {
            return View();
        }

        public ActionResult DichVuE()
        {
            return View();
        }


        public ActionResult XacNhanThem1(string tendv, int soluong, float gia)
        {
            if (tendv != null && soluong != 0 && gia != 0)
            {
                dichVu.ThemDV(tendv, soluong, gia);
            }
            return View();
        }

        public ActionResult XacNhanSua(string tendv, int soluong, float gia)
        {
            if (tendv != "" && soluong != 0 && gia != 0)
            {
                dichVu.SuaDichVu(tendv, soluong, gia);
            }
            return View();
        }

        public ActionResult Xoa(IEnumerable<int> itemSelected1)
        {
            foreach (var item in itemSelected1)
            {
                FindAndSavIdService(item);
            }
            dichVu.Xoa();
            return RedirectToAction("DichVuM", "DichVu");
        }

        public ActionResult Sua(IEnumerable<int> itemSelected)
        {
            foreach (var item in itemSelected)
            {
                FindAndSavIdService(item);
            }
            return RedirectToAction("DichVuE", "DichVu");
        }

        public void FindAndSavIdService(int a)
        {
            try
            {
                using (var db = new QLTCEntities())
                {
                    var b = db.dich_vu.Where(item => item.MaDV == a).Single();
                    DichVuAction.maDV = b.MaDV;
                }
            }
            catch { }
        }
    }
}
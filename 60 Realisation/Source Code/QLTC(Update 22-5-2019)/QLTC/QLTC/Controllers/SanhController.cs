using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTC.Models;

namespace QLTC.Controllers
{
    public class SanhController : Controller
    {
        SanhAction sanhaction = new SanhAction();
        public ActionResult SanhM()
        {
            ModelList sanhlist = new ModelList();
            using (var db = new QLTCEntities())
            {
                var a = (from b in db.ds_sanh
                         where b.TrangThai == false || b.TrangThai == null
                         select b);
                sanhlist.ds_sanhsM = a.ToList();
            }
            return View(sanhlist);
        }

        [HttpPost]
        public ActionResult ProcessForm(string them, string sua)
        {
            if (sua != null)
            {
                return RedirectToAction("SanhE", "Sanh");
            }
            else if (them != null)
            {
                return RedirectToAction("SanhA", "Sanh");
            }
            else
            {
                return RedirectToAction("SanhM", "Sanh");
            }
        }

        public ActionResult SanhE()
        {
            return View();
        }

        public ActionResult SanhA()
        {
            return View();
        }

        public ActionResult XacNhanThem(string tensanh, string loaisanh, int soluongbantoida, int dongia, string ghichu)
        {
            if (tensanh != null && loaisanh != null && soluongbantoida != 0 && dongia != 0 && ghichu != null)
            {
                sanhaction.themsanh(tensanh, loaisanh, soluongbantoida, dongia, ghichu);
            }
            return View();

        }

        public ActionResult XacNhanSua(string tensanh, string loaisanh, int soluongbantoida, int dongia, string ghichu)
        {
            if (tensanh != null && loaisanh != null && soluongbantoida != 0 && dongia != 0 && ghichu != null)
            {
                sanhaction.SuaSanh(tensanh, loaisanh, soluongbantoida, dongia, ghichu);
            }
            return View();
        }

        public ActionResult XoaSanh(IEnumerable<int> itemSelected1)
        {
            foreach (var item in itemSelected1)
            {
                FindAnhSaveIdSanh(item);
            }
            sanhaction.xoasanh();
            return RedirectToAction("SanhM", "Sanh");
        }

        public ActionResult Sua(IEnumerable<int> itemSelected)
        {
            foreach (var item in itemSelected)
            {
                FindAnhSaveIdSanh(item);
            }
            return RedirectToAction("SanhE", "Sanh");
        }


        public void FindAnhSaveIdSanh(int a)
        {
            try
            {
                using (var db = new QLTCEntities())
                {
                    var b = db.ds_sanh.Where(m => m.MaSanh == a).Single();
                    SanhAction.mSanh = b.MaSanh;
                }
            }
            catch
            {

            }
        }
    }
}
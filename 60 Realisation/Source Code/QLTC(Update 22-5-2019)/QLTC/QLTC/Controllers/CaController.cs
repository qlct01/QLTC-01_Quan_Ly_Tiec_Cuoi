using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTC.Models;

namespace QLTC.Controllers
{
    public class CaController : Controller
    {
        CaAction caaction = new CaAction();
        public ActionResult CaM()
        {
            ModelList caList = new ModelList();
            using (var db = new QLTCEntities())
            {
                var a = (from b in db.cas
                         where b.TrangThai == false || b.TrangThai == null
                         select b);
                caList.caM = a.ToList();
            }
            return View(caList);
        }

        [HttpPost]
        public ActionResult ProcessForm(string them, string sua)
        {
            if (sua != null)
            {
                return RedirectToAction("CaE", "Ca");
            }
            else if (them != null)
            {
                return RedirectToAction("CaA", "Ca");
            }
            else
            {
                return RedirectToAction("CaM", "Ca");
            }
        }

        public ActionResult CaE()
        {
            return View();
        }

        public ActionResult CaA()
        {
            return View();
        }

        public ActionResult XacNhanThem(string tenca)
        {
            if (tenca != null)
            {
                caaction.ThemCa(tenca);
            }
            return View();
        }

        public ActionResult XacNhanSua(string tenca)
        {
            if (tenca != "")
            {
                caaction.SuaCa(tenca);
            }
            return View();
        }

        public ActionResult Xoa(IEnumerable<int> itemSelected)
        {
            foreach (var a in itemSelected)
            {
                FindAnhSaveIdCa(a);
            }
            caaction.XoaCa();
            return RedirectToAction("CaM", "Ca");
        }

        public ActionResult Sua(IEnumerable<int> itemSelected)
        {
            foreach (var a in itemSelected)
            {
                FindAnhSaveIdCa(a);
            }

            return RedirectToAction("CaE", "Ca");
        }

        public void FindAnhSaveIdCa(int a)
        {
            try
            {
                using (var db = new QLTCEntities())
                {
                    var b = db.cas.Where(m => m.MaCa == a).Single();
                    CaAction.maCa = b.MaCa;
                }
            }
            catch
            {

            }
        }
    }
}
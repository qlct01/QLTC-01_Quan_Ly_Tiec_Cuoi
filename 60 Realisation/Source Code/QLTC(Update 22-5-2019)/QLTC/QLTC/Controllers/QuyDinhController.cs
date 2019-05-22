using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTC.Models;

namespace QLTC.Controllers
{
    public class QuyDinhController : Controller
    {
        QuyDinhAction quyDinh = new QuyDinhAction();

        // GET: QuyDinh
        public ActionResult QuyDinhM()
        {
            QuyDinhList quyDinhList = new QuyDinhList();
            using (var db = new QLTCEntities())
            {
                quyDinhList.ds_thamsoM = db.tham_so.ToList();
            }
            return View(quyDinhList);
        }

        [HttpPost]
        public ActionResult ProcessForm(string them, string sua)
        {
            if (sua != null)
            {
                return RedirectToAction("QuyDinhE", "QuyDinh");
            }

            else if (them != null)
            {
                return RedirectToAction("QuyDinhA", "QuyDinh");
            }

            else
            {
                return RedirectToAction("QuyDinhM", "QuyDinh");
            }

        }


        public ActionResult QuyDinhE()
        {
            return View();
        }

        public ActionResult QuyDinhA()
        {
            return View();
        }


        public ActionResult XacNhanThem(string tenquydinh, float gia)
        {
            if (tenquydinh != "" && gia != 0)
            {
                quyDinh.ThemQuyDinh(tenquydinh, gia);
            }

            return View();
        }


        public ActionResult XacNhanSua(string tenquydinh, float gia)
        {
            if (tenquydinh != "" && gia != 0)
            {
                quyDinh.SuaQuyDinh(tenquydinh, gia);
            }

            return View();
        }


        public ActionResult Xoa(IEnumerable<int> itemSelected1)
        {
            foreach (var item in itemSelected1)
            {
                FindAnhSaveIdQuyDinh(item);
            }

            quyDinh.XoaQuyDinh();
            return RedirectToAction("QuyDinhM", "QuyDinh");
        }



        public ActionResult Sua(IEnumerable<int> itemSelected)
        {
            foreach (var item in itemSelected)
            {
                FindAnhSaveIdQuyDinh(item);
            }
            return RedirectToAction("QuyDinhE", "QuyDinh");
        }



        public void FindAnhSaveIdQuyDinh(int a)
        {
            try
            {
                using (var db = new QLTCEntities())
                {
                    var b = db.tham_so.Where(m => m.MaThamSo == a).Single();
                    QuyDinhAction.maThamSo = b.MaThamSo;
                }
            }
            catch
            {

            }
        }
    }
}
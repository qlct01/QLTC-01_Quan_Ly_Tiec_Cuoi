using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTC.Models;

namespace QLTC.Controllers
{
    public class SetUpController : Controller
    {
        SetUpAction setUp = new SetUpAction();

        public ActionResult SetUp()
        {
            ModelList modelList = new ModelList();
            using (var db = new QLTCEntities())
            {
                modelList.caM = db.cas.ToList();
                modelList.ds_sanhsM = db.ds_sanh.ToList();
                modelList.dich_vuM = db.dich_vu.ToList();
                modelList.mon_anM = db.mon_an.ToList();
            }
            return View(modelList);
        }

        public ActionResult SubmitSetUp(IEnumerable<string> dssanh, IEnumerable<string> dsmon, IEnumerable<string> dsdv)
        {
            //Set 2 danh sách bằng rỗng để khi bắt lỗi sẽ ko chèn dữ liệu cũ vào
            SetUpAction.dsMaDV = new List<int>();
            SetUpAction.dsMaMon = new List<int>();

            if (dssanh != null && dsmon != null && dsdv != null)
            {

                foreach (var item in dssanh)
                {
                    SetUpAction.MaSanh = Convert.ToInt32(item);
                    break;
                }


                foreach (var item in dsmon)
                {
                    SetUpAction.dsMaMon.Add(Convert.ToInt32(item));
                }


                foreach (var item in dsdv)
                {
                    SetUpAction.dsMaDV.Add(Convert.ToInt32(item));
                }
            }

            using (var db = new QLTCEntities())
            {
                var query = (from m in db.ds_sanh
                             where m.MaSanh == SetUpAction.MaSanh
                             select m).Single();

                SetUpAction.soLuongBanToiDa = query.SoLuongBanToiDa;
            }

            return View();
        }


        public ActionResult SetUpDetail()
        {
            ModelList modelList = new ModelList();
            using (var db = new QLTCEntities())
            {
                modelList.caM = db.cas.ToList();
            }
            return View(modelList);
        }

        
        public ActionResult SubmitSetUpDetail(float tiendatcoc, int sobandutru, int soluongban, DateTime ngaydattiec, int hour, int minute, string maca, string mathe)
        {
            Notice.enterSetSup = true;

            if (mathe != "" && maca != "" && minute != 0 && hour != 0 && ngaydattiec != null && soluongban.ToString() != "" && tiendatcoc.ToString() != "")
            {
                string ngay = ngaydattiec.ToString("yyyy-MM-dd");
                string gio = (hour + ":" + minute).ToString();

                
                bool trungThongTin = setUp.KiemTra(ngay, Convert.ToInt32(maca));

                if (!trungThongTin)
                {
                    setUp.SaveDSTiec(SetUpAction.MaSanh, ngay, gio, soluongban);
                    setUp.SaveDatTiec(Convert.ToInt32(maca), tiendatcoc, sobandutru);
                    setUp.SaveCTDatTiec();
                    setUp.SaveHoaDon(soluongban, sobandutru, ngay);
                    setUp.SaveCTHoaDon(tiendatcoc);

                    Notice.SetUpSuccess = true;
                }
                else
                {
                    Notice.SetUpSuccess = false;
                }
            }

            return RedirectToAction("Main", "Home");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTC.Models;

namespace QLTC.Controllers
{
    public class TaiKhoanController : Controller
    {
        TaiKhoanTempList tk = new TaiKhoanTempList();

        public ActionResult TaiKhoan(string tencodau, string tenchure, string matkhaucu, string matkhaumoi)
        {
            if(tencodau != null && tenchure != null)
            {
                if (Notice.logIn)
                {
                    using (var db = new QLTCEntities())
                    {
                        try
                        {
                            tai_khoan tk = db.tai_khoan.Where(m => m.SDT == TaiKhoanAction.sdt && m.Password == matkhaucu).Single();

                            gia_dinh gd = db.gia_dinh.Where(m => m.SDT == TaiKhoanAction.sdt).Single();

                            tk.Password = matkhaumoi;

                            db.SaveChanges();

                            gd.TenChuRe = tenchure;

                            gd.TenCoDau = tencodau;

                            db.SaveChanges();

                            Notice.updateSuccess = true;
                        }
                        catch
                        {
                            Notice.updateSuccess = false;

                            ViewBag.ErrorPassword = "Mật khẩu cũ sai";
                        }
                    }
                }
            }


            if (Notice.logIn && !Notice.updateSuccess)
            {
                using (var db = new QLTCEntities())
                {
                    var gd = (from m in db.gia_dinh
                              where m.SDT == TaiKhoanAction.sdt
                              select m).Single();

                    tk.tai_khoan_T = gd;
                    return View(tk);
                }
            }
            else if (!Notice.logIn && !Notice.updateSuccess) return View();
            else return RedirectToAction("Main", "Home");
        }
    }
}
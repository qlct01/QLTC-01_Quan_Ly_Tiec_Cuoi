using QLTC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLTC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult LogIn(string sdt, string matkhau)
        {
            if(sdt != null && matkhau != null)
            {
                using (var db = new QLTCEntities())
                {
                    try
                    {
                        var tk = db.tai_khoan.Where(m => m.SDT == sdt && m.Password == matkhau).Single();

                        Notice.logIn = true;

                        TaiKhoanAction.sdt = sdt;
                    }
                    catch
                    {
                        if (sdt == "admin" && matkhau == "admin")
                        {
                            ViewBag.Admin = "Bạn đăng nhập với quyền cao nhất";

                            Notice.adminLogIn = true;
                        }
                        else
                        {
                            ViewBag.Message = "SDT hoặc mật khẩu sai";

                            TaiKhoanAction.sdt = "";

                            Notice.logIn = false;
                        }
                    }
                }
            }

            if (Notice.logIn == false && Notice.adminLogIn == false)
                return View();
            else if(Notice.logIn = true && Notice.adminLogIn == false) return RedirectToAction("Main", "Home");
            else return RedirectToAction("Main", "Home");
        }

        public ActionResult BillDetail()
        {
            return View();
        }

        public ActionResult SignIn(string sdt, string tencodau, string tenchure)
        {
            if (sdt != null && tenchure != null && tencodau != null)
            {
                using (var db = new QLTCEntities())
                {
                    try
                    {
                        tai_khoan tk_F = db.tai_khoan.Where(m => m.SDT == sdt).Single();
                        
                        ViewBag.ExistAccount = "Tài khoản này đã tồn tại";

                        Notice.existAccount = true;

                        Notice.signIn = false;
                    }
                    catch
                    {
                        Notice.signIn = true;

                        Notice.existAccount = false;

                        TaiKhoanAction tk_A = new TaiKhoanAction();

                        tk_A.AddTaiKoanAndGiaDinh(sdt, tencodau, tenchure);
                    }
                }
            }

            if (Notice.signIn == true) return RedirectToAction("Main", "Home");
            else return View();
        }

        public ActionResult Main()
        {
            return View();
        }

        public ActionResult Index()
        {
            return RedirectToAction("Main", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
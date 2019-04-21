using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace QLTC.Models
{
    public class SanhAction
    {
        public static int mSanh = 0;

        public void themsanh(string tensanh, string loaisanh, int soluongbantoida, int dongia, string ghichu)
        {
            using (var db = new QLTCEntities())
            {
                ds_sanh s = new ds_sanh();
                s.TenSanh = tensanh;
                s.LoaiSanh = loaisanh;
                s.SoLuongBanToiDa = soluongbantoida;
                s.DonGiaBanToiThieu = dongia;
                s.GhiChu = ghichu;
                s.TrangThai = false;                
                db.ds_sanh.Add(s);
                db.SaveChanges();
            }
        }

        public void xoasanh()
        {
            using (var db = new QLTCEntities())
            {
                try
                {
                    ds_sanh a = (from m in db.ds_sanh
                                 where m.MaSanh == SanhAction.mSanh
                                 select m).Single();
                    a.TrangThai = true;
                    db.SaveChanges();
                }
                catch
                {

                }
            }
        }

        public void SuaSanh(string tensanh, string loaisanh, int soluongbantoida, int dongia, string ghichu)
        {
            //using (var db = new QLTCEntities())
            //{
            //    try
            //    {
            //        bool found = db.ds_sanh.Any(m => m.TenSanh == tensanh);

            //        if (!found)
            //        {
            //            ds_sanh a = (from m in db.ds_sanh
            //                        where m.MaSanh == SanhAction.mSanh
            //                        select m).Single();
            //            a.TenSanh = tensanh;
            //            a.LoaiSanh = loaisanh;
            //            a.SoLuongBanToiDa = soluongbantoida;
            //            a.DonGiaBanToiThieu = dongia;
            //            a.GhiChu = ghichu;
            //            db.SaveChanges();
            //        }
            //    }
            //    catch
            //    {

            //    }
            //}

            using (var db = new QLTCEntities())
            {
                ds_sanh sanh = (from m in db.ds_sanh
                                where m.MaSanh == SanhAction.mSanh
                                select m).Single();
                sanh.TenSanh = tensanh;
                sanh.LoaiSanh = loaisanh;
                sanh.SoLuongBanToiDa = soluongbantoida;
                sanh.DonGiaBanToiThieu = dongia;
                sanh.GhiChu = ghichu;                
                db.SaveChanges();

            }
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLTC.Models
{
    public class ds_sanh
    {
        [Key]
        public int MaSanh { get; set; }
        public string TenSanh { get; set; }
        public string LoaiSanh { get; set; }
        public int SoLuongBanToiDa { get; set; }
        public int DonGiaBanToiThieu { get; set; }
        public string GhiChu { get; set; }
        public Nullable<bool> TrangThai { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLTC.Models
{
    public class ds_tiec_cuoi
    {
        [Key]
        public int MaDSTiec { get; set; }
        public int MaGD { get; set; }
        public int MaSanh { get; set; }
        public string Ngay { get; set; }
        public string Gio { get; set; }
        public int SoLuongBan { get; set; }

        public virtual dat_tiec Dat_Tiec { get; set; }
        public virtual ds_sanh Ds_Sanh { get; set; }
    }
}

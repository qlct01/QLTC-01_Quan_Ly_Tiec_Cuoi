using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLTC.Models
{
    public class gia_dinh
    {
        [Key]
        public int MaGD { get; set; }
        public string TenCoDau { get; set; }
        public string TenChuRe { get; set; }
        [StringLength(30)]
        public string SDT { get; set; }
        public Nullable<bool> TrangThai { get; set; }

        public virtual dat_tiec Dat_Tiec { get; set; }
        public virtual ds_tiec_cuoi Ds_Tiec_Cuoi { get; set; }
    }
}

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
        public string SDT { get; set; }
        public Nullable<bool> TrangThai { get; set; }
    }
}

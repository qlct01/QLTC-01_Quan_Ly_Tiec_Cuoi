using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace QLTC.Models
{
    public class dich_vu
    {
        [Key]
        public int MaDV { get; set; }
        public string TenDV { get; set; }
        public int SoLuong { get; set; }
        public float Gia { get; set; }
        public Nullable<bool> TrangThai { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLTC.Models
{
    public class mon_an
    {
        [Key]
        public int MaMon { get; set; }
        public string TenMon { get; set; }
        public float Gia { get; set; }
        public string GhiChu { get; set; }
        public Nullable<bool> TrangThai { get; set; }
    }
}

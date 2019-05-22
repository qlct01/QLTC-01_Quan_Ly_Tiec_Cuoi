using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLTC.Models
{
    public class bkdstiec2019
    {
        [Key]
        public int MaDSTiec { get; set; }
        public int MaGD { get; set; }
        public int MaSanh { get; set; }
        public string Ngay { get; set; }
        public string Gio { get; set; }
        public int SoLuongBan { get; set; }
        public DateTime BKTime { get; set; }
        public DateTime DeleteTime { get; set; }
    }
}
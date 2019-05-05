using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLTC.Models
{
    public class bkhoadon2019
    {
        [Key]
        public int MaHD { get; set; }
        public int MaDatTiec { get; set; }
        public float TongTienBan { get; set; }
        public string NgayThanhToan { get; set; }
        public bool TrangThai { get; set; }
        public DateTime BKTime { get; set; }
        public DateTime DeleteTime { get; set; }
    }
}
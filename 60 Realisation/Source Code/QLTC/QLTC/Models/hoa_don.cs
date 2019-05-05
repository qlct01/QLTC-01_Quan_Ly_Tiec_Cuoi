using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace QLTC.Models
{
    public class hoa_don
    {
        [Key]
        public int MaHD { get; set; }
        public int MaDatTiec { get; set; }
        public float TongTienBan { get; set; }
        public string NgayThanhToan { get; set; }
        public Nullable<bool> TrangThai { get; set; }
    }
}
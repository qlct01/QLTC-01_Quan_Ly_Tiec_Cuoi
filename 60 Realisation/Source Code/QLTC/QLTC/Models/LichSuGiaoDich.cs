using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTC.Models
{
    public partial class LichSuGiaoDich
    {
        public int MaDatTiec { get; set; }
        public double TongTienBan { get; set; }
        public double TongTienHD { get; set; }
        public double TienDatCoc { get; set; }
        public string NgayThanhToan { get; set; }
    }
}
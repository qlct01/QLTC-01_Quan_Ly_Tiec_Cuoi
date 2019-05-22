using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLTC.Models
{
    public class bkct_hoa_don2019
    {
        [Key]
        public int MaCT_HD { get; set; }
        public int MaHD { get; set; }
        public int MaDatTiec { get; set; }
        public float TongTienDV { get; set; }
        public float TongTienHoaDon { get; set; }
        public float TienDatCoc { get; set; }
        public float ConLai { get; set; }
        public DateTime BKTime { get; set; }
        public DateTime DeleteTime { get; set; }
    }
}
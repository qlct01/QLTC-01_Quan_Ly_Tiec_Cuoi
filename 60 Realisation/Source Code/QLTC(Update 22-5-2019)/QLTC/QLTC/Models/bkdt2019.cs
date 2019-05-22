using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLTC.Models
{
    public class bkdt2019
    {
        [Key]
        public int MaDatTiec { get; set; }
        public int MaDSTiec { get; set; }
        public int MaGD { get; set; }
        public int MaCa { get; set; }
        public float TienDatCoc { get; set; }
        public int SoBanDuTru { get; set; }
        public bool TrangThai { get; set; }
        public string TinhTrang { get; set; }
        public DateTime BKTime { get; set; }
        public DateTime DeleteTime { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLTC.Models
{
    public class dat_tiec
    {
        [Key]
        public int MaDatTiec { get; set; }
        public int MaDSTiec { get; set; }
        public int MaGD { get; set; }
        public int MaCa { get; set; }
        public Nullable<float> TienDatCoc { get; set; }
        public Nullable<int> SoBanDuTru { get; set; }
        public Nullable<bool> TrangThai { get; set; }
        public string TinhTrang { get; set; }
    }
}

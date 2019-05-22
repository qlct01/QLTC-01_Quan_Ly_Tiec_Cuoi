using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLTC.Models
{
    public class ct_hoa_don
    {
        [Key]
        public int MaCT_HD { get; set; }
        public int MaHD { get; set; }
        public int MaDatTiec { get; set; }
        public Nullable<float> TongTienDV { get; set; }
        public Nullable<float> TongTienHoaDon { get; set; }
        public Nullable<float> TienDatCoc { get; set; }
        public Nullable<float> ConLai { get; set; }

        public virtual hoa_don Hoa_Don { get; set; }
    }
}
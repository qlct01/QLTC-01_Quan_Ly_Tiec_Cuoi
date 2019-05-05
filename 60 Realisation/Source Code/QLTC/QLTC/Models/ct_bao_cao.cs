using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLTC.Models
{
    public class ct_bao_cao
    {
        [Key]
        public int MaCT_BC { get; set; }
        public int MaBC { get; set; }
        public string Ngay { get; set; }
        public Nullable<int> SoLuongTiec { get; set; }
        public Nullable<float> DoanhThu { get; set; }
        public Nullable<float> TiLe { get; set; }
    }
}

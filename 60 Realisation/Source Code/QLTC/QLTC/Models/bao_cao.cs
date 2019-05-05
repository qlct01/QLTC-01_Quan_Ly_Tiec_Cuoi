using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLTC.Models
{
    public class bao_cao
    {
        [Key]
        public int MaBC { get; set; }
        public Nullable<int> Thang { get; set; }
        public Nullable<float> TongDoanhThu { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLTC.Models
{
    public class tham_so
    {
        [Key]
        public int MaThamSo { get; set; }
        public string TenThamSo { get; set; }
        public float GiaTri { get; set; }
    }
}

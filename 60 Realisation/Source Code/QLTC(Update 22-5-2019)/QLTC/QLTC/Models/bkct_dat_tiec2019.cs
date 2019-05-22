using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLTC.Models
{
    public class bkct_dat_tiec2019
    {
        [Key]
        public int MaCT_DatTiec { get; set; }
        public int MaDatTiec { get; set; }
        public int MaMon { get; set; }
        public int MaDV { get; set; }
        public DateTime BKTime { get; set; }
        public DateTime DeleteTime { get; set; }
    }
}
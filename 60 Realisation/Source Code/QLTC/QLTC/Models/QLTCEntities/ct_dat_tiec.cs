using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLTC.Models
{
    public class ct_dat_tiec
    {
        [Key]
        public int MaCT_DatTiec { get; set; }
        public int MaDatTiec { get; set;}
        public Nullable<int> MaMon { get; set; }
        public Nullable<int> MaDV { get; set; }
    }
}

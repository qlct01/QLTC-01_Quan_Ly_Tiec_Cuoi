using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLTC.Models
{
    public class ca
    {
        [Key]
        public int MaCa { get; set; }
        public string TenCa { get; set; }
        public Nullable<bool> TrangThai { get; set; }        
    }
}

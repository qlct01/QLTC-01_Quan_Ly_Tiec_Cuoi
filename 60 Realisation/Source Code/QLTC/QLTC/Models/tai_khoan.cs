using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLTC.Models
{
    public class tai_khoan
    {
        [Key]
        public string SDT { get; set; }
        public string Password { get; set; }
    }
}

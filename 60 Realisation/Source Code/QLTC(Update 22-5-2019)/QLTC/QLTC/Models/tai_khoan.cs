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
        [Required]
        [StringLength(30)]
        public string SDT { get; set; }
        public string Password { get; set; }

        public virtual gia_dinh Gia_Dinh { get; set; }
    }
}

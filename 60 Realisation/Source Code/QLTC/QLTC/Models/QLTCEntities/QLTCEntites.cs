using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace QLTC.Models
{
    public class QLTCEntities : DbContext
    {
        public QLTCEntities() : base()
        {
            string databasename = "QuanLyTiecCuoi";
            this.Database.Connection.ConnectionString = "workstation id=QuanLyTiecCuoi.mssql.somee.com;packet size=4096;user id=thanhbao43210_SQLLogin_1;pwd=7xk71xkkym;data source=QuanLyTiecCuoi.mssql.somee.com;persist security info=False;initial catalog=QuanLyTiecCuoi";
        }
        
        public DbSet<bao_cao> bao_cao { get; set; }
        public DbSet<ca> cas { get; set; }
        public DbSet<ct_bao_cao> ct_bao_cao { get; set; }
        public DbSet<ct_dat_tiec> ct_dat_tiec { get; set; }
        public DbSet<ct_hoa_don> ct_hoa_don { get; set; }
        public DbSet<dat_tiec> dat_tiec { get; set; }
        public DbSet<dich_vu> dich_vu { get; set; }
        public DbSet<ds_sanh> ds_sanh { get; set; }
        public DbSet<ds_tiec_cuoi> ds_tiec_cuoi { get; set; }
        public DbSet<gia_dinh> gia_dinh { get; set; }
        public DbSet<hoa_don> hoa_don { get; set; }
        public DbSet<mon_an> mon_an { get; set; }
        public DbSet<tai_khoan> tai_khoan { get; set; }
        public DbSet<tham_so> tham_so { get; set; }
    }
}
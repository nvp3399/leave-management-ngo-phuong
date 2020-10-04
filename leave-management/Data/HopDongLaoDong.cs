using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class HopDongLaoDong
    {
        [Key]
        public string MaHopDong { get; set; }
        [Required]
        public DateTime NgayKyKet { get; set; }
        [Required]
        public DateTime NgayBatDau { get; set; }
        [Required]
        public DateTime NgayKetThuc { get; set; }
        [Required]
        public string ViTriLuuBanScan { get; set; }
        [Required]
        public DateTime NgayGuiBanScan { get; set; }

        public string MaNhanVienGuiBanScan { get; set; }


        public string MaNhanVienChuTheHopDong { get; set; }

        [ForeignKey("MaMauHopDong")]
        public MauHopDong MauHopDong { get; set; }
        public string MaMauHopDong { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayHopDongBiHuy { get; set; }
        public string MaNhanVienHuyHopDong { get; set; }

    }
}

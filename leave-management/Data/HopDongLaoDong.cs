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

        [ForeignKey("MaNhanVienGuiBanScan")]
        public Employee NhanVienGuiBanScan { get; set; }
        public string MaNhanVienGuiBanScan { get; set; }

        [ForeignKey("MaNhanVienChuTheHopDong")]
        public Employee NhanVienChuTheHopDong { get; set; }
        public string MaNhanVienChuTheHopDong { get; set; }

        [ForeignKey("MaMauHopDong")]
        public MauHopDong MauHopDong { get; set; }
        public string MaMauHopDong { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayHopDongBiHuy { get; set; }

        [ForeignKey("MaNhanVienHuyHopDong")]
        public Employee NhanVienHuyHopDong { get; set; }
        public string MaNhanVienHuyHopDong { get; set; }

        [ForeignKey("MaNhanVienChinhSuaLanCuoi")]
        public Employee NhanVienChinhSuaLanCuoi { get; set; }
        public string MaNhanVienChinhSuaLanCuoi { get; set; }
        public DateTime ThoiGianChinhSuaLanCuoi { get; set; }

    }
}

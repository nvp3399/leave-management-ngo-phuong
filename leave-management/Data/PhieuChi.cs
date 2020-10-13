using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class PhieuChi
    {
        [ForeignKey("MaNhanVien")]
        public Employee NhanVien { get; set; }

        public string MaNhanVien { get; set; }
        public DateTime ThoiGianXuatPhieuChi { get; set; }
        [Required]
        public int SoTienChi { get; set; }
        [Required]
        public string LyDoChi { get; set; }

        [ForeignKey("MaNhanVienXuatPhieu")]
        public Employee NhanVienXuatPhieu { get; set; }
        public string MaNhanVienXuatPhieu { get; set; }
        [Required]
        public ushort NamTinhLuong { get; set; }
        [Required]
        public byte ThangTinhLuong { get; set; }
        public string GhiChu { get; set; }
        [Required]
        public string TrangThaiPhieuChi { get; set; }

        [ForeignKey("MaNhanVienChiTien")]
        public Employee NhanVienChiTien { get; set; }
        public string MaNhanVienChiTien { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class NhatKyLamViec
    {
        [ForeignKey("MaNhanVien")]
        public Employee NhanVien { get; set; }
        public string MaNhanVien { get; set; }

        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        [ForeignKey("MaLoaiLichBieu")]
        public LoaiLichBieu LoaiLichBieu { get; set; }
        public string MaLoaiLichBieu { get; set; }
        [Required]
        public int SoTienThuongThem { get; set; }
        public string GhiChu { get; set; }

        [ForeignKey("MaNhanVienThemVaoHeThong")]
        public Employee NhanVienThemVaoHeThong { get; set; }
        public string MaNhanVienThemVaoHeThong { get; set; }
        [Required]

        public DateTime NgayThemVaoHeThong { get; set; }
    }
}

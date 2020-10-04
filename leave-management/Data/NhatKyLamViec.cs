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
        [Key]
        public string MaNhanVien { get; set; }

        [Key]
        public DateTime ThoiGianBatDau { get; set; }
        [Key]
        public DateTime ThoiGianKetThuc { get; set; }
        [ForeignKey("MaLoaiLichBieu")]
        public LoaiLichBieu LoaiLichBieu { get; set; }
        public string MaLoaiLichBieu { get; set; }
        [Required]
        public int SoTienThuongThem { get; set; }
        public string GhiChu { get; set; }

    }
}

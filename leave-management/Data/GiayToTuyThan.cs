using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class GiayToTuyThan
    {
        [ForeignKey("MaNhanVien")]
        public Employee NhanVien { get; set; }
        public string MaNhanVien { get; set; }

        [ForeignKey("MaLoaiGiayTo")]
        public LoaiGiayToTuyThan LoaiGiayTo { get; set; }
        public string MaLoaiGiayTo { get; set; }
        [Required]
        public DateTime NgayLuuVaoHeThong { get; set; }

        [ForeignKey("MaNhanVienGui")]
        public Employee NhanVienGui { get; set; }
        public string MaNhanVienGui { get; set; }
        [Required]
        public string ViTriLuuBanScan { get; set; }
        public string GhiChu { get; set; }

        [ForeignKey("MaNhanVienChinhSuaLanCuoi")]
        public Employee NhanVienChinhSuaLanCuoi { get; set; }
        public string MaNhanVienChinhSuaLanCuoi { get; set; }
        public DateTime ThoiGianChinhSuaLanCuoi { get; set; }

    }
}

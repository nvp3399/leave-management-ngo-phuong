using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class YeuCauDatLuongCoBan
    {
        [Key]
        public string MaYeuCau { get; set; }
        [ForeignKey("MaNhanVienGuiYeuCau")]
        public Employee NhanVienGuiYeuCau { get; set; }
        public string MaNhanVienGuiYeuCau { get; set; }
        [ForeignKey("MaNhanVienDuocDatLuong")]
        public Employee NhanVienDuocDatLuong { get; set; }
        public string MaNhanVienDuocDatLuong { get; set; }
        [Required]
        public int MucLuongCoBan { get; set; }
        [Required]
        public DateTime ThoiGianGuiYeuCau { get; set; }
        public DateTime ThoiGianPheDuyet { get; set; }
        public string MaNhanVienPheDuyet { get; set; }
        [Required]
        public string TinhTrangPheDuyet { get; set; }
        public string GhiChu { get; set; }

    }
}

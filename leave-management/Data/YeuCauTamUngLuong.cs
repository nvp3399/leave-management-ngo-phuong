using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class YeuCauTamUngLuong
    {
        [Key]
        public int MaYeuCau { get; set; }

        [ForeignKey("MaNhanVienGuiYeuCau")]
        public Employee NhanVienGuiYeuCau { get; set; }
        public string MaNhanVienGuiYeuCau { get; set; }
        [Required]
        public DateTime NgayGuiYeuCau { get; set; }
        public string MaNhanVienPheDuyet { get; set; }
        public DateTime NgayPheDuyet { get; set; }
        [Required]
        public int SoTienTamUng { get; set; }
        public string GhiChu { get; set; }
        [Required]
        public string TinhTrangPheDuyet { get; set; }

    }
}

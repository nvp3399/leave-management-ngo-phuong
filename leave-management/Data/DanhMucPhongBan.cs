using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class DanhMucPhongBan
    {
        [Key]
        public string MaPhongBan { get; set; }
        [Required]
        public string TenPhongBan { get; set; }
        [ForeignKey("MaNhanVienTruongPhong")]
        public Employee NhanVienTruongPhong { get; set; }
        public string MaNhanVienTruongPhong { get; set; }
    }
}

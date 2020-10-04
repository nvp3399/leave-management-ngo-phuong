using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class MauHopDong
    {
        [Key]
        public string MaMauHopDong { get; set; }
        [Required]
        public string TenMauHopDong { get; set; }
        [ForeignKey("MaNhanVienLuuMauHopDong")]
        public Employee NhanVienLuuMauHopDong { get; set; }
        public string MaNhanVienLuuMauHopDong { get; set; }
        [Required]
        public DateTime NgayGuiMauHopDong { get; set; }
        [Required]
        public string ViTriLuuMauHopDong { get; set; }

        public string GhiChu { get; set; }
        [ForeignKey("MaLoaiHopDong")]
        public LoaiHopDong LoaiHopDong { get; set; }
        public string MaLoaiHopDong { get; set; }

    }
}

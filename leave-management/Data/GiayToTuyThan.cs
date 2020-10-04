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
        [ForeignKey("MaNhanVien"), Column(Order =0)]
        public Employee NhanVien { get; set; }
        [Key]
        public string MaNhanVien { get; set; }

        [ForeignKey("MaLoaiGiayTo"), Column(Order =1)]
        public LoaiGiayToTuyThan LoaiGiayTo { get; set; }
        [Key]
        public string MaLoaiGiayTo { get; set; }
        [Required]
        public DateTime NgayLuuVaoHeThong { get; set; }

        [ForeignKey("MaNhanVienGui")]
        public Employee NhanVienGui { get; set; }
        public string MaNhanVienGui { get; set; }
        [Required]
        public string ViTriLuuBanScan { get; set; }
        public string GhiChu { get; set; }

    }
}

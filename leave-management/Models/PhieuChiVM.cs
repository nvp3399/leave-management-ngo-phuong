using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class PhieuChiVM
    {

        public string MaPhieuChi { get; set; }


        public DateTime ThoiGianXuatPhieuChi { get; set; }

        [ForeignKey("MaNhanVienChiTien")]
        public EmployeeVM NhanVienChiTien { get; set; }
        public string MaNhanVienChiTien { get; set; }

        public DateTime ThoiGianChiTien { get; set; }


        [ForeignKey("MaNhanVienThuHoi")]
        public EmployeeVM NhanVienThuHoi { get; set; }
        public string MaNhanVienThuHoi { get; set; }

        public DateTime ThoiGianThuHoi { get; set; }

        public string GhiChu { get; set; }
    }
}

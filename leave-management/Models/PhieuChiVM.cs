using leave_management.Models;
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
        public EmployeeVM NhanVien { get; set; }

        public DateTime ThoiGianXuatPhieuChi { get; set; }
        public int SoTienChi { get; set; }
        public string LyDoChi { get; set; }

        public EmployeeVM NhanVienXuatPhieu { get; set; }
        public ushort NamTinhLuong { get; set; }
        public byte ThangTinhLuong { get; set; }
        public string GhiChu { get; set; }
        public string TrangThaiPhieuChi { get; set; }
        public EmployeeVM NhanVienChiTien { get; set; }

    }
}

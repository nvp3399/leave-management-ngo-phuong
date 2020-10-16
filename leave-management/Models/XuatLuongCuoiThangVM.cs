using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class XuatLuongCuoiThangVM

    {


        public EmployeeVM NhanVienDuocXuatLuong { get; set; }
        public string MaNhanVienDuocXuatLuong { get; set; }
        public EmployeeVM NhanVienXuatLuong { get; set; }
        public string MaNhanVienXuatLuong { get; set; }
        public TongSoGioLam TongSoGio  { get; set; }
        public int TongTienLuongCoBan { get; set; }
        public int TongTienThuong { get; set; }
        public int TongTienLuong { get; set; }

        public int NamTinhLuong { get; set; }
        public int ThangTinhLuong { get; set; }

        public bool TrangThaiXuatLuong { get; set; }
    }
}

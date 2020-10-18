using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class XuatLuongCuoiThangVM

    {


        [DisplayName("Nhân viên được xuất lương")]
        public EmployeeVM NhanVienDuocXuatLuong { get; set; }
        public string MaNhanVienDuocXuatLuong { get; set; }
        [DisplayName("Nhân viên xuất lương")]
        public EmployeeVM NhanVienXuatLuong { get; set; }
        public string MaNhanVienXuatLuong { get; set; }

        public TongSoGioLam TongSoGio  { get; set; }
        [DisplayName("Tổng tiền lương cơ bản")]
        public int TongTienLuongCoBan { get; set; }
        [DisplayName("Tổng tiền thưởng")]
        public int TongTienThuong { get; set; }
        [DisplayName("Tổng tiền lương")]
        public int TongTienLuong { get; set; }

        [DisplayName("Năm")]
        public int NamTinhLuong { get; set; }
        [DisplayName("Tháng")]
        public int ThangTinhLuong { get; set; }
        [DisplayName("Trạng thái xuất lương")]
        public bool TrangThaiXuatLuong { get; set; }
    }
}

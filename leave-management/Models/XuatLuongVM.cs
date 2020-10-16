using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{

    public class XuatLuongVM
    {
        [DisplayName("Tổng số giờ làm trong tháng")]
        public TongSoGioLam TongSoGioLam { get; set; }
        [DisplayName("Tổng tiền lương cơ bản (basic) đã tích lũy trong tháng")]
        public int TongTienLuongCoBanDaTichLuyTrongThang { get; set; }

        [DisplayName("Tổng tiền thưởng (bonus) đã tích lũy trong tháng")]
        public int TongTienThuongDaTichLuyTrongThang { get; set; }

        [DisplayName("Tổng tiền lương đã tích lũy trong tháng")]
        public int TongTienLuong { get; set; }

        public PhieuChi_TamUngLuongVM PhieuChi_TamUngLuongVM { get; set; }
        public PhieuChi_LuongCuoiThangVM phieuChi_LuongCuoiThangVM { get; set; }
    }

    public class PhieuChi_TamUngLuongVM_XuatLuong : PhieuChiVM
    {
        [DisplayName("Yêu cầu tạm ứng lương")]
        public YeuCauTamUngLuongVM YeuCauTamUngLuong { get; set; }
        public string MaYeuCauTamUngLuong { get; set; }

        public EmployeeVM NhanVienDuocChiTien { get; set; }

        public EmployeeVM NhanVienXuatPhieuChi { get; set; }
    }

    public class PhieuChi_LuongCuoiThangVM_XuatLuong : PhieuChiVM
    {
        [DisplayName("Nhân viên được chi tiền")]
        public EmployeeVM NhanVienDuocChiTien { get; set; }

        [DisplayName("Nhân viên xuất lương")]
        public EmployeeVM NhanVienXuatLuong { get; set; }
        public string MaNhanVienXuatLuong { get; set; }
    }
}

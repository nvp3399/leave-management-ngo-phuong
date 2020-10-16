using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class PhieuChi_LuongCuoiThangVM : PhieuChiVM
    {

        [DisplayName("Nhân viên xuất lương")]
        public EmployeeVM NhanVienXuatLuong { get; set; }
        public string MaNhanVienXuatLuong { get; set; }

        [DisplayName("Tổng số giờ làm trong tháng")]
        public double TongSoGioLam { get; set; }
        [DisplayName("Tổng tiền lương cơ bản (basic) đã tích lũy trong tháng")]
        public int TongTienLuongCoBanDaTichLuyTrongThang { get; set; }

        [DisplayName("Tổng tiền thưởng (bonus) đã tích lũy trong tháng")]
        public int TongTienThuongDaTichLuyTrongThang { get; set; }

        [DisplayName("Tổng tiền lương đã tích lũy trong tháng")]
        public int TongTienLuong { get; set; }


        [DisplayName("Nhân viên được chi tiền")]
        public EmployeeVM NhanVienDuocChiTien { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class PhieuChi_TamUngLuongVM : PhieuChiVM
    {

        [DisplayName("Yêu cầu tạm ứng lương")]
        public YeuCauTamUngLuongVM YeuCauTamUngLuong { get; set; }
        public string MaYeuCauTamUngLuong { get; set; }

        [DisplayName("Nhân viên được chi tiền")]

        public EmployeeVM NhanVienDuocChiTien { get; set; }

        [DisplayName("Nhân viên xuất phiếu chi")]
        public EmployeeVM NhanVienXuatPhieuChi { get; set; }

        //[DisplayName("Yêu cầu tạm ứng lương")]
        //public YeuCauTamUngLuongVM YeuCauTamUngLuongVM { get; set; }
    }

}

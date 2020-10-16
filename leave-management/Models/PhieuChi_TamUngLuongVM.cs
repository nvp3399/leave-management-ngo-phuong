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

        public EmployeeVM NhanVienDuocChiTien { get; set; }

        public EmployeeVM NhanVienXuatPhieuChi { get; set; }

    }
}

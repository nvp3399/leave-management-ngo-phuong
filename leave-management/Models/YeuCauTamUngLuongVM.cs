using leave_management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class YeuCauTamUngLuongVM
    {
        public string MaYeuCau { get; set; }

        public EmployeeVM NhanVienGuiYeuCau { get; set; }
        public DateTime NgayGuiYeuCau { get; set; }
        public EmployeeVM NhanVienPheDuyet { get; set; }
        public DateTime NgayPheDuyet { get; set; }
        public int SoTienTamUng { get; set; }
        public string GhiChu { get; set; }
        public string TinhTrangPheDuyet { get; set; }

    }
}

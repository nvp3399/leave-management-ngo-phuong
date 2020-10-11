using leave_management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class YeuCauDatLuongCoBanVM
    {
        public string MaYeuCau { get; set; }
        public EmployeeVM NhanVienGuiYeuCau { get; set; }
        public EmployeeVM NhanVienDuocDatLuong { get; set; }
        public int MucLuongCoBan { get; set; }
        public DateTime ThoiGianGuiYeuCau { get; set; }
        public DateTime ThoiGianPheDuyet { get; set; }
        public EmployeeVM NhanVienPheDuyet { get; set; }
        public string TinhTrangPheDuyet { get; set; }
        public string GhiChu { get; set; }

    }
}

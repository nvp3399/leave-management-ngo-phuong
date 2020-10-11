using leave_management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class MauHopDongVM
    {
        public string MaMauHopDong { get; set; }
        public string TenMauHopDong { get; set; }
        public EmployeeVM NhanVienLuuMauHopDong { get; set; }
        public DateTime NgayGuiMauHopDong { get; set; }
        public string ViTriLuuMauHopDong { get; set; }

        public string GhiChu { get; set; }
        public LoaiHopDongVM LoaiHopDong { get; set; }

    }
}

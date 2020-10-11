using leave_management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class NhatKyLamViecVM
    {
        public EmployeeVM NhanVien { get; set; }

        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public LoaiLichBieuVM LoaiLichBieu { get; set; }
        public int SoTienThuongThem { get; set; }
        public string GhiChu { get; set; }

    }
}

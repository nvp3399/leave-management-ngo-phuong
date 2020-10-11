using leave_management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class LuongTheoThangVM
    {
        public EmployeeVM NhanVien { get; set; }

        public ushort Nam { get; set; }
        public byte Thang { get; set; }
        public int SoTienThuongThem { get; set; }
        public int SoTienPhuCap { get; set; }
        public int TongLuongCoBan { get; set; }
        public bool TrangThaiXuatLuong { get; set; }

    }
}

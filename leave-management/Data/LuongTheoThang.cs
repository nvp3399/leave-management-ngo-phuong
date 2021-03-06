﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class LuongTheoThang
    {
        [ForeignKey("MaNhanVien")]
        public Employee NhanVien { get; set; }

        public string MaNhanVien { get; set; }
        public ushort Nam { get; set; }
        public byte Thang { get; set; }
        [Required]
        public int SoTienThuongThem { get; set; }
        [Required]
        public int SoTienPhuCap { get; set; }
        [Required]
        public int TongLuongCoBan { get; set; }
        [Required]
        public bool TrangThaiXuatLuong { get; set; }

    }
}

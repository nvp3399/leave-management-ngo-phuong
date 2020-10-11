using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class LoaiLichBieuVM
    {
        public string MaLoai { get; set; }
        public string TenLoaiLichBieu { get; set; }
        public byte HeSoLuongCoBan { get; set; }

    }
}
